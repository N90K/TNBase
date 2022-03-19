using System;
using System.Collections.Generic;
using System.Drawing;
using TNBase.DataStorage;

namespace TNBase
{
    public partial class FormPrintWarnings
	{
        List<String> warnings = new List<String>();
        
		int myIndex = 0;
		public void setupForm(List<String> warnings)
		{
            this.warnings = warnings;

            printWarnings();

			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Print labels.
		private void printWarnings()
		{
			printPreview.Document = printWarningsDoc;
			printPreview.ClientSize = new Size(600, 600);
			printPreview.ShowDialog();
		}

		private void printWarningsDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Font reportFont = new System.Drawing.Font("Times New Roman", 24, FontStyle.Bold);
			Font reportFontSmall = new System.Drawing.Font("Times New Roman", 12);
			Font reportFontSmallBold = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);
			Font reportFontSmallBoldTitles = new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold);
			Font reportFontBigBoldTitles = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);

			Graphics g = e.Graphics;
			int pageHeight = e.MarginBounds.Height;

			int theIndex = myIndex;

            g.DrawString("Weekly Warnings", reportFont, Brushes.Black, 290, 80, StringFormat.GenericTypographic);

            // Loop through
			for (int i=0; i< warnings.Count; i++) {
				g.DrawString(warnings[i], reportFontSmallBoldTitles, Brushes.Black, 100, 140 + (30 * i));
            } 
            
            g.DrawString("Printed on " + System.DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT), reportFontSmallBold, Brushes.Black, 550, 950);
		}

        public FormPrintWarnings()
		{
			InitializeComponent();
		}
	}
}
