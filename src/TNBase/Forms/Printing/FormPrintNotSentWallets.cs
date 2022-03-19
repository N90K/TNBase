using System;
using System.Collections.Generic;
using System.Drawing;
using TNBase.Objects;
using TNBase.DataStorage;
using Microsoft.Extensions.DependencyInjection;

namespace TNBase
{
    public partial class FormPrintNotSentWallets
	{
		List<Listener> theListeners = new List<Listener>();
		private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();
		int totalCount = 0;
		int currentPageNumber = 0;

		int totalPages = 0;
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void SetInitial()
		{
			theListeners = serviceLayer.GetUnsentListeners();

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

			g.DrawString("Unsent wallets this week.", reportFont, Brushes.Black, 260, 80, StringFormat.GenericTypographic);

			string nowDate = null;
			string weekDate = null;
			nowDate = System.DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT);

			DateTime tempDate = default(DateTime);
			tempDate = DateTime.Now.AddDays(6);
			weekDate = tempDate.ToString(ModuleGeneric.DATE_FORMAT);

			g.DrawString("Wallets that have not been sent this week due to listener stock levels.", reportFontSmall, Brushes.Black, 170, 130, StringFormat.GenericTypographic);

			if (theListeners.Count > 5) {
				e.HasMorePages = true;
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
				g.DrawString("Stock: " + theListener.Stock, reportFontSmall, Brushes.Black, 550, start + (gap * value) + 25);

				string lastOutStr = "N/a";
				if (theListener.LastOut.HasValue) {
					lastOutStr = theListener.LastOut.Value.ToString("dd/MM/yyyy");
				}

                g.DrawString("Last sent: " + lastOutStr, reportFontSmallBold, Brushes.Black, 550, start + (gap * value) + 50);


                g.DrawString("Status: " + theListener.Status, reportFontSmall, Brushes.Black, 550, start + (gap * value) + 75);

				theListeners.RemoveAt(0);
			}


			g.DrawString("Number of Listeners: " + totalCount, reportFontSmallBold, Brushes.Black, 100, 950);
			g.DrawString("Printed on " + System.DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT), reportFontSmallBold, Brushes.Black, 550, 950);
			g.DrawString("Page " + currentPageNumber + "/" + totalPages, reportFontSmallBold, Brushes.Black, 380, 970);

			// VB is stupid.... have to reset this so its back when you actually print it!
			if (!(e.HasMorePages)) {
				SetInitial();
			}
		}

		public FormPrintNotSentWallets()
		{
			InitializeComponent();
		}

        private void formPrintNotSentWallets_Load(object sender, EventArgs e)
        {
            printLabels();
            this.Close();
        }
	}
}
