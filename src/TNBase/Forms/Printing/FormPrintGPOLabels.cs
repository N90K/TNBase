using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TNBase
{
    public partial class FormPrintGPOLabels
    {
        List<string> postcodes;

        private void printLabels()
        {
            printPreview.Document = printGPODoc;
            printPreview.ClientSize = new Size(600, 600);
            printPreview.ShowDialog();
        }

        private void SetInitial()
        {
            postcodes = new List<string> { "B90", "B91+B92", "B93" };
        }

        private void formPrintGPOLabels_Load(object sender, EventArgs e)
        {
            SetInitial();
            printLabels();
            Close();
        }

        private void printGPODoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font reportFontSmall = new Font("Times New Roman", 12);
            Font reportFontBigBoldTitles = new Font("Times New Roman", 30, FontStyle.Bold);
            Graphics g = e.Graphics;
            var postcode = postcodes.First();

            if (postcodes.Count > 1)
            {
                e.HasMorePages = true;
            }

            for (int value = 0; value <= 18 - 1; value++)
            {
                int myRow = ((int)Math.Ceiling((double)((double)(value + 1) / (double)3))) - 1;
                int myColumn = (value % 3);

                var initialY = (175 * myRow) + 50;
                var initialX = (myColumn * 240) + 60;

                g.DrawString("For the attention of the" + Environment.NewLine + " NIGHT MANAGER", reportFontSmall, Brushes.Black, initialX, initialY);
                g.DrawString(postcode, reportFontBigBoldTitles, Brushes.Black, initialX, initialY + 40);
            }

            postcodes.Remove(postcode);

            if (!e.HasMorePages)
            {
                SetInitial();
            }
        }
        public FormPrintGPOLabels()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
