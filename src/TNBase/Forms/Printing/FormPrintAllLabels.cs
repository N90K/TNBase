using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using TNBase.Objects;
using TNBase.DataStorage;
using Microsoft.Extensions.DependencyInjection;

namespace TNBase
{
    public partial class FormPrintAllLabels
    {
        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();
        List<Listener> theListeners = new List<Listener>();
        int totalCount = 0;

        int currentPageNumber = 0;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetInitial()
        {
            // Get 4 lots of listeners (one for each label).
            // Must use lists here to achieve the sorting (hence the casts).
            theListeners = new List<Listener>();
            theListeners.AddRange(serviceLayer.GetAlphabeticList().Cast<Listener>().ToList());
            theListeners.AddRange(serviceLayer.GetAlphabeticList().Cast<Listener>().ToList());
            theListeners.AddRange(serviceLayer.GetAlphabeticList().Cast<Listener>().ToList());
            theListeners.AddRange(serviceLayer.GetAlphabeticList().Cast<Listener>().ToList());

            // Sort them.
            theListeners.Sort(new IListener());

            totalCount = theListeners.Count();
            currentPageNumber = 0;
        }

        // Print labels.
        private void printLabels()
        {
            SetInitial();

            printPreview.Document = printLabelDoc;
            printPreview.ClientSize = new Size(600, 600);
            printPreview.ShowDialog();
        }

        private void printLabelDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font reportFont = new Font("Times New Roman", 24, FontStyle.Bold);
            Font reportFontSmall = new Font("Times New Roman", 12);
            Font reportFontSmallBold = new Font("Times New Roman", 14, FontStyle.Bold);
            Font reportFontSmallBoldTitles = new Font("Times New Roman", 16, FontStyle.Bold);
            Font reportFontBigBoldTitles = new Font("Times New Roman", 20, FontStyle.Bold);

            Graphics g = e.Graphics;
            var lineHeight = 16;
            var labelContentWidth = 260;
            var spacing = 4;

            if (theListeners.Count >= 5)
            {
                e.HasMorePages = true;
            }
            currentPageNumber = currentPageNumber + 1;

            int theIndex = 0;

            int min = Math.Min(theListeners.Count, 3 * 6);
            min--;

            for (int value = 0; value <= min; value++)
            {
                int myRow = (int)Math.Ceiling((double)((double)(value + 1) / (double)3)) - 1;
                int myColumn = value % 3;
                Listener myListener = theListeners[0];

                var initialY = (183 * myRow) + 33;
                var initialX = (myColumn * 260) + Properties.Settings.Default.LabelXAdjust;
                theIndex++;

                var addressLines = new List<string>
                {
                    string.Join(" ", myListener.Title, myListener.Forename, myListener.Surname),
                    myListener.Addr1,
                    myListener.Addr2,
                    myListener.Town,
                    myListener.County,
                    myListener.Postcode
                }.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();


                g.DrawString("First Class Post", reportFontSmallBoldTitles, Brushes.Black, initialX, initialY);

                for (int i = 0; i < addressLines.Count; i++)
                {
                    g.DrawString(addressLines[i], reportFontSmall, Brushes.Black, new RectangleF(initialX, initialY + lineHeight * (i + 1) + spacing, labelContentWidth, lineHeight), new StringFormat(StringFormatFlags.NoWrap));
                }

                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                Image newImage = b.Encode(BarcodeLib.TYPE.CODE39, myListener.Wallet.ToString(), Color.Black, Color.White, 150, 34);

                e.Graphics.DrawImage(newImage, initialX, initialY + lineHeight * 7 + spacing * 2, 150, 34);

                g.DrawString(myListener.Wallet.ToString(), reportFontBigBoldTitles, Brushes.Black, initialX + 142, initialY + lineHeight * 7 + spacing * 3);

                theListeners.RemoveAt(0);
            }

            // VB is stupid.... have to reset this so its back when you actually print it!
            if (!(e.HasMorePages))
            {
                SetInitial();
            }
        }

        private void formPrintAllLabels_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Ensure you insert labels into the printer tray before printing.", ModuleGeneric.getAppShortName(), MessageBoxButtons.OK);
            printLabels();
            MessageBox.Show("Make sure you replace the labels in the printer tray with plain paper.", ModuleGeneric.getAppShortName(), MessageBoxButtons.OK);
            this.Close();
        }
        public FormPrintAllLabels()
        {
            InitializeComponent();
        }
    }
}
