using Microsoft.VisualBasic;
using System;
using System.Drawing;
using TNBase.Objects;

namespace TNBase
{
    public partial class FormPrintLabels
	{
		Listener myListener;

		int myIndex = 0;
		public void setupForm(Listener theListener, int startIndex)
		{
			myListener = theListener;
			myIndex = startIndex;
			//MsgBox("Ensure you insert labels into the printer tray before printing.", MessageBoxButtons.OkOnly)
			Interaction.MsgBox("Please choose the correct printer for label printing by right clicking on the printer icon on the next screen - top left picture of printer.");
			printLabels();
			//MsgBox("Make sure you replace the labels in the printer tray with plain paper.", MessageBoxButtons.OkOnly)
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Print labels.
		private void printLabels()
		{
			printPreview.Document = printLabelDoc;
			printPreview.ClientSize = new Size(600, 600);
			printPreview.ShowDialog();
		}

		private void printLabelDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Font reportFont = new System.Drawing.Font("Times New Roman", 24, FontStyle.Bold);
			Font reportFontSmall = new System.Drawing.Font("Times New Roman", 12);
			Font reportFontSmallBold = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);
			Font reportFontSmallBoldTitles = new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold);
			Font reportFontBigBoldTitles = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);

			Graphics g = e.Graphics;
			int pageHeight = e.MarginBounds.Height;

			int theIndex = myIndex;

			for (int value = 0; value <= 3; value++) {
				int myRow = (int) Math.Ceiling((double) ((double)(theIndex + 1) / (double)3)) - 1;
				int myColumn = (theIndex % 3);

				var initialY = (175 * myRow) + 34;
				var initialX = (myColumn * 240) + Properties.Settings.Default.LabelXAdjust;
				theIndex = theIndex + 1;

				g.DrawString("First Class Post", reportFontSmallBoldTitles, Brushes.Black, initialX, initialY);
				g.DrawString(myListener.Title + ". " + myListener.Forename + " " + myListener.Surname, reportFontSmall, Brushes.Black, initialX, initialY + 16 + 4);
				g.DrawString(myListener.Addr1, reportFontSmall, Brushes.Black, initialX, initialY + 32 + 4);
				g.DrawString(myListener.Addr2, reportFontSmall, Brushes.Black, initialX, initialY + 48 + 4);
				g.DrawString(myListener.Town + ", " + myListener.Postcode, reportFontSmall, Brushes.Black, initialX, initialY + 66 + 4);
                
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                Image newImage = b.Encode(BarcodeLib.TYPE.CODE39, myListener.Wallet.ToString(), Color.Black, Color.White, 150, 70);

                e.Graphics.DrawImage(newImage, initialX - 10, initialY + 82 + 8, 150, 70);

                g.DrawString(myListener.Wallet.ToString(), reportFontBigBoldTitles, Brushes.Black, initialX + 122, initialY + 82 + 4 + 8);
			}
		}
		public FormPrintLabels()
		{
			InitializeComponent();
		}
	}
}
