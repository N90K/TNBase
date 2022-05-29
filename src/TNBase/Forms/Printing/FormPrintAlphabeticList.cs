using System;
using System.Collections.Generic;
using System.Drawing;
using TNBase.Objects;
using TNBase.DataStorage;
using Microsoft.Extensions.DependencyInjection;

namespace TNBase
{
    public partial class FormPrintAlphabeticList
    {
        private const int itemsPerPage = 20;
        List<Listener> theListeners = new List<Listener>();
        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();
        int totalCount = 0;
        int currentPageNumber = 0;

        int totalPages = 0;
        private void printDormantDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font reportFont = new Font("Times New Roman", 24, FontStyle.Bold);
            Font reportFontSmall = new Font("Times New Roman", 14);
            Font reportFontSmallBold = new Font("Times New Roman", 14, FontStyle.Bold);
            Font reportFontSmallBoldTitles = new Font("Times New Roman", 16, FontStyle.Bold);
            Graphics g = e.Graphics;
            int pageHeight = e.MarginBounds.Height;

            g.DrawString("All Listeners (Alphabetic).", reportFont, Brushes.Black, 220, 80, StringFormat.GenericTypographic);

            string nowDate = DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT);
            DateTime tempDate = DateTime.Now.AddDays(6);
            string weekDate = tempDate.ToString(ModuleGeneric.DATE_FORMAT);

            g.DrawString("All listeners sorted alphabetically by surname.", reportFontSmall, Brushes.Black, 220, 130, StringFormat.GenericTypographic);

            if (theListeners.Count > itemsPerPage)
            {
                e.HasMorePages = true;
            }
            currentPageNumber++;

            int min = Math.Min(theListeners.Count, itemsPerPage);
            min--;

            int gap = 35;
            int start = 220;

            for (int value = 0; value <= min; value++)
            {
                Listener theListener = theListeners[0];

                g.DrawString(theListener.Wallet + ". ", reportFontSmall, Brushes.Black, 100, start + (gap * value));
                g.DrawString(theListener.Title + " " + theListener.Forename + " " + theListener.Surname, reportFontSmall, Brushes.Black, 160, start + (gap * value));

                theListeners.RemoveAt(0);
            }

            g.DrawString("Number of Listeners: " + totalCount, reportFontSmallBold, Brushes.Black, 100, 980);
            g.DrawString("Printed on " + DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT), reportFontSmallBold, Brushes.Black, 550, 980);
            g.DrawString("Page " + currentPageNumber + "/" + totalPages, reportFontSmallBold, Brushes.Black, 380, 1000);

            // VB is stupid.... have to reset this so its back when you actually print it!
            if (!e.HasMorePages)
            {
                SetInitial();
            }
        }

        private void SetInitial()
        {
            theListeners = serviceLayer.GetAlphabeticList();
            totalCount = theListeners.Count;
            currentPageNumber = 0;
        }

        // Print age analysis form.
        private void printForm()
        {
            SetInitial();
            totalPages = (int)Math.Ceiling((double)totalCount / itemsPerPage);
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

        public FormPrintAlphabeticList()
        {
            InitializeComponent();
        }

        private void formPrintAlphabeticList_Load(object sender, EventArgs e)
        {
            printForm();
            this.Close();
        }

    }
}
