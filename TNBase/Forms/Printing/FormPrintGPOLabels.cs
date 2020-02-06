using System;
using System.Drawing;
namespace TNBase
{
    public partial class FormPrintGPOLabels
	{
        bool firstPage = true;

		private void printLabels()
		{
			printPreview.Document = printGPODoc;
			printPreview.ClientSize = new Size(600, 600);
			printPreview.ShowDialog();
		}

		private void SetInitial()
		{
			firstPage = true;
		}

		private void formPrintGPOLabels_Load(object sender, EventArgs e)
		{
			SetInitial();
			printLabels();
			this.Close();
		}

		private void printGPODoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Font reportFont = new System.Drawing.Font("Times New Roman", 24, FontStyle.Bold);
			Font reportFontSmall = new System.Drawing.Font("Times New Roman", 12);
			Font reportFontSmallBold = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);
			Font reportFontSmallBoldTitles = new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold);
			Font reportFontBigBoldTitles = new System.Drawing.Font("Times New Roman", 30, FontStyle.Bold);
			Graphics g = e.Graphics;
			int pageHeight = e.MarginBounds.Height;

			if (firstPage) {
				e.HasMorePages = true;
			}

			for (int value = 0; value <= 18-1; value++) {
                int myRow = ((int)Math.Ceiling((double)((double)(value + 1) / (double)3))) - 1;
                int myColumn = (value % 3);
                var theNumber = value+1;
				if (!firstPage) {
					theNumber += (18);
				}

				var initialY = (175 * myRow) + 50;
				var initialX = (myColumn * 240) + 60;

				string myBoldText = "";
				if ((theNumber <= 9)) {
					myBoldText = "B90";
				} else if ((theNumber <= (18 + 9))) {
					myBoldText = "B91+B92";
				} else {
					myBoldText = "B93";
				}

				g.DrawString("For the attention of the" + Environment.NewLine + " NIGHT MANAGER", reportFontSmall, Brushes.Black, initialX, initialY);
				g.DrawString(myBoldText, reportFontBigBoldTitles, Brushes.Black, initialX, initialY + 40);
			}
			firstPage = false;

			if (!e.HasMorePages) {
				SetInitial();
			}
		}
		public FormPrintGPOLabels()
		{
			InitializeComponent();
		}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}
