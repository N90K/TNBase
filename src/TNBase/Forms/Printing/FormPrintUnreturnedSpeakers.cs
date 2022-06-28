using System;
using System.Collections.Generic;
using System.Drawing;
using TNBase.Objects;
using TNBase.DataStorage;
using Microsoft.Extensions.DependencyInjection;

namespace TNBase
{
    public partial class FormPrintUnreturnedSpeakers
    {
        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();
        List<Listener> theListeners = new List<Listener>();
        int totalCount = 0;
        int currentPageNumber = 0;

        int totalPages = 0;
        private void printDormantDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font reportFont = new System.Drawing.Font("Times New Roman", 24, FontStyle.Bold);
            Font reportFontSmall = new System.Drawing.Font("Times New Roman", 14);
            Font reportFontSmallBold = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);
            Font reportFontSmallBoldTitles = new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold);
            Graphics g = e.Graphics;
            int pageHeight = e.MarginBounds.Height;

            g.DrawString("Speakers that require returning.", reportFont, Brushes.Black, 210, 80, StringFormat.GenericTypographic);

            string nowDate = null;
            string weekDate = null;
            nowDate = System.DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT);

            DateTime tempDate = default(DateTime);
            tempDate = DateTime.Now.AddDays(6);
            weekDate = tempDate.ToString(ModuleGeneric.DATE_FORMAT);

            g.DrawString("Listeners who have been deleted or made 'online-only' but have not returned their speakers.", reportFontSmall, Brushes.Black, 100, 130, StringFormat.GenericTypographic);

            if (theListeners.Count > 5)
            {
                e.HasMorePages = true;
            }
            currentPageNumber = currentPageNumber + 1;

            int min = Math.Min(theListeners.Count, 5);
            min = min - 1;

            int gap = 140;
            int start = 220;

            for (int value = 0; value <= min; value++)
            {
                Listener theListener = theListeners[0];

                g.DrawString(theListener.Wallet + ". " + theListener.Title + " " + theListener.Forename + " " + theListener.Surname, reportFontSmallBold, Brushes.Black, 100, start + (gap * value));

                string telephoneStr = theListener.Telephone;
                if ((string.IsNullOrEmpty(telephoneStr)))
                {
                    telephoneStr = "Telephone unknown.";
                }
                g.DrawString("TEL: " + telephoneStr, reportFontSmall, Brushes.Black, 550, start + (gap * value));

                string lineastr = "";
                if (!(string.IsNullOrEmpty(theListener.Addr2)))
                {
                    lineastr = theListener.Addr1 + ", " + theListener.Addr2;
                }
                else
                {
                    lineastr = theListener.Addr1;
                }

                string linebstr = "";
                if (!(string.IsNullOrEmpty(theListener.Town)))
                {
                    linebstr = theListener.County;
                    if (!(string.IsNullOrEmpty(theListener.County)))
                    {
                        linebstr = linebstr + ", " + theListener.County;
                    }
                }
                else
                {
                    if (!(string.IsNullOrEmpty(theListener.County)))
                    {
                        linebstr = theListener.County;
                    }
                }

                g.DrawString(lineastr, reportFontSmall, Brushes.Black, 150, start + (gap * value) + 25);
                g.DrawString(linebstr, reportFontSmall, Brushes.Black, 150, start + (gap * value) + 50);
                g.DrawString(theListener.Postcode, reportFontSmall, Brushes.Black, 150, start + (gap * value) + 75);

                g.DrawString("DOB: " + theListener.BirthdayText, reportFontSmall, Brushes.Black, 550, start + (gap * value) + 25);
                g.DrawString("Info: " + theListener.StatusInfo, reportFontSmallBold, Brushes.Black, 150, start + (gap * value) + 100);

                if (theListener.Status == ListenerStates.DELETED)
                {
                    g.DrawString("Deleted: " + theListener.DeletedDate, reportFontSmallBold, Brushes.Black, 550, start + (gap * value) + 75);
                }
                else if(theListener.OnlineOnly)
                {
                    g.DrawString("Online-Only Listener", reportFontSmallBold, Brushes.Black, 550, start + (gap * value) + 75);
                }

                theListeners.RemoveAt(0);
            }

            g.DrawString("Number of Listeners: " + totalCount, reportFontSmallBold, Brushes.Black, 100, 950);
            g.DrawString("Printed on " + System.DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT), reportFontSmallBold, Brushes.Black, 550, 950);
            g.DrawString("Page " + currentPageNumber + "/" + totalPages, reportFontSmallBold, Brushes.Black, 380, 970);

            // VB is stupid.... have to reset this so its back when you actually print it!
            if (!(e.HasMorePages))
            {
                SetInitial();
            }
        }

        private void SetInitial()
        {
            theListeners = serviceLayer.GetUnreturnedSpeakerListeners();
            totalCount = theListeners.Count;
            currentPageNumber = 0;
        }

        // Print age analysis form.
        private void printForm()
        {
            SetInitial();

            totalPages = (int)Math.Ceiling((double)totalCount / 5);
            if (totalPages == 0)
            {
                totalPages = 1;
            }

            printPreview.Document = printDormantDoc;
            printPreview.ClientSize = new Size(600, 600);
            printPreview.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public FormPrintUnreturnedSpeakers()
        {
            InitializeComponent();
        }

        private void formPrintUnreturnedSpeakers_Load(object sender, EventArgs e)
        {
            printForm();
            this.Close();
        }
    }
}
