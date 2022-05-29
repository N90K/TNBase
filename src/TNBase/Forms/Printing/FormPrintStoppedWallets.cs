using System;
using System.Collections.Generic;
using System.Drawing;
using TNBase.Objects;
using TNBase.DataStorage;
using Microsoft.Extensions.DependencyInjection;

namespace TNBase
{
    public partial class FormPrintStoppedWallets
    {
		private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();
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
			Font reportFont = new Font("Times New Roman", 24, FontStyle.Bold);
			Font reportFontSmall = new Font("Times New Roman", 14);
			Font reportFontSmallBold = new Font("Times New Roman", 14, FontStyle.Bold);
			Font reportFontSmallBoldTitles = new Font("Times New Roman", 16, FontStyle.Bold);
			Graphics g = e.Graphics;
			int pageHeight = e.MarginBounds.Height;

			g.DrawString("Paused Wallet List", reportFont, Brushes.Black, 260, 80, StringFormat.GenericTypographic);
           
			string nowDate = DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT);
            DateTime tempDate = DateTime.Now.AddDays(6);
            string weekDate = tempDate.ToString(ModuleGeneric.DATE_FORMAT);

            g.DrawString("Listeners inactive in the next six days (" + nowDate + " to " + weekDate + ").", reportFontSmall, Brushes.Black, 180, 130, StringFormat.GenericTypographic);

			if (theListeners.Count > 5) {
				e.HasMorePages = true;
			} else {
				e.HasMorePages = false;
			}
			currentPageNumber++;

			int min = Math.Min(theListeners.Count, 5);
			min--;

			int gap = 140;
			int start = 220;

			for (int value = 0; value <= min; value++) {
				Listener theListener = theListeners[0];

				g.DrawString(theListener.Wallet + ". " + theListener.Title + " " + theListener.Forename + " " + theListener.Surname, reportFontSmallBold, Brushes.Black, 100, start + (gap * value));

				string telephoneStr = theListener.Telephone;
				if (string.IsNullOrEmpty(telephoneStr)) {
					telephoneStr = "Telephone unknown.";
				}

				g.DrawString("TEL: " + telephoneStr, reportFontSmall, Brushes.Black, 550, start + (gap * value));
				g.DrawString("DOB: " + theListener.BirthdayText, reportFontSmall, Brushes.Black, 550, start + (gap * value) + 25);
				g.DrawString("Resume date: " + theListener.GetResumeDateString(), reportFontSmallBold, Brushes.Black, 550, start + (gap * value) + 50);

				theListeners.RemoveAt(0);
			}

			g.DrawString("Number of Listeners: " + totalCount, reportFontSmallBold, Brushes.Black, 100, 950);
			g.DrawString("Printed on " + DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT), reportFontSmallBold, Brushes.Black, 550, 950);
			g.DrawString("Page " + currentPageNumber + "/" + totalPages, reportFontSmallBold, Brushes.Black, 380, 970);

			if (!e.HasMorePages) {
				SetInitial();
			}
		}

		private void formPrintStoppedWallets_Load(object sender, EventArgs e)
		{
			printLabels();
			this.Close();
		}
		public FormPrintStoppedWallets()
		{
			InitializeComponent();
		}
	}
}
