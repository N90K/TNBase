using System;
using System.Collections.Generic;
using System.Drawing;
using TNBase.Objects;
using TNBase.DataStorage;
namespace TNBase
{
    public partial class FormPrintStoppedWalletsAll
	{
        IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());
		List<Listener> theListeners = new List<Listener>();
		int totalCount = 0;
		int currentPageNumber = 0;

		int totalPages = 0;
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void SetInitial()
		{
			theListeners = serviceLayer.GetStoppedListeners();

			totalCount = theListeners.Count;
			currentPageNumber = 0;
		}

		// Print labels.
		private void printLabels()
		{
			SetInitial();
			totalPages = (int) Math.Ceiling((double) totalCount / 5);
			if (totalPages == 0) {
				totalPages = 1;
			}

			printPreview.Document = printStoppedWalletsDoc;
			printPreview.ClientSize = new Size(600, 600);
			printPreview.ShowDialog();
		}

		private void printStoppedWalletsDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Font reportFont = new System.Drawing.Font("Times New Roman", 24, FontStyle.Bold);
			Font reportFontSmall = new System.Drawing.Font("Times New Roman", 14);
			Font reportFontSmallBold = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);
			Font reportFontSmallBoldTitles = new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold);
			Graphics g = e.Graphics;
			int pageHeight = e.MarginBounds.Height;

			g.DrawString("Stopped Listeners list.", reportFont, Brushes.Black, 260, 80, StringFormat.GenericTypographic);
			g.DrawString("A list of all stopped listeners.", reportFontSmall, Brushes.Black, 300, 130, StringFormat.GenericTypographic);

			if (theListeners.Count > 5) {
				e.HasMorePages = true;
			} else {
				e.HasMorePages = false;
			}
			currentPageNumber = currentPageNumber + 1;

			int min = Math.Min(theListeners.Count, 5);
			min = min - 1;

			int gap = 140;
			int start = 220;

			for (int value = 0; value <= min; value++) {
				Listener theListener = theListeners[0];

				g.DrawString(theListener.Wallet + ". " + theListener.Title + " " + theListener.Forename + " " + theListener.Surname, reportFontSmallBold, Brushes.Black, 100, start + (gap * value));

				string telephoneStr = theListener.Telephone;
				if ((string.IsNullOrEmpty(telephoneStr))) {
					telephoneStr = "Telephone unknown.";
				}
				g.DrawString("TEL: " + telephoneStr, reportFontSmall, Brushes.Black, 550, start + (gap * value));

				string lineastr = "";
				if (!(string.IsNullOrEmpty(theListener.Addr2))) {
					lineastr = theListener.Addr1 + ", " + theListener.Addr2;
				} else {
					lineastr = theListener.Addr1;
				}

				string linebstr = "";
				if (!(string.IsNullOrEmpty(theListener.Town))) {
					linebstr = theListener.County;
					if (!(string.IsNullOrEmpty(theListener.County))) {
						linebstr = linebstr + ", " + theListener.County;
					}
				} else {
					if (!(string.IsNullOrEmpty(theListener.County))) {
						linebstr = theListener.County;
					}
				}

				g.DrawString(lineastr, reportFontSmall, Brushes.Black, 150, start + (gap * value) + 25);
				g.DrawString(linebstr, reportFontSmall, Brushes.Black, 150, start + (gap * value) + 50);
				g.DrawString(theListener.Postcode, reportFontSmall, Brushes.Black, 150, start + (gap * value) + 75);

				g.DrawString("DOB: " + theListener.Birthday, reportFontSmall, Brushes.Black, 550, start + (gap * value) + 25);
				g.DrawString("Stopped Date: " + Listener.GetStoppedDate(theListener), reportFontSmallBold, Brushes.Black, 550, start + (gap * value) + 50);
				g.DrawString("Resume date: " + Listener.GetResumeDateString(theListener), reportFontSmallBold, Brushes.Black, 550, start + (gap * value) + 75);

				theListeners.RemoveAt(0);
			}

			g.DrawString("Number of Listeners: " + totalCount, reportFontSmallBold, Brushes.Black, 100, 950);
			g.DrawString("Printed on " + System.DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT), reportFontSmallBold, Brushes.Black, 550, 950);
			g.DrawString("Page " + currentPageNumber + "/" + totalPages, reportFontSmallBold, Brushes.Black, 380, 970);

			if (!(e.HasMorePages)) {
				SetInitial();
			}
		}

		private void formPrintStoppedWalletsAll_Load(object sender, EventArgs e)
		{
			printLabels();
			this.Close();
		}
		public FormPrintStoppedWalletsAll()
		{
			InitializeComponent();
		}
	}
}
