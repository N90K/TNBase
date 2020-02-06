using System;
using System.Drawing;
using TNBase.DataStorage;
namespace TNBase
{
    public partial class FormStats
	{
        private IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

		private void formStats_Load(object sender, EventArgs e)
		{
			lblDate.Text = System.DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT);
			int year = DateTime.Now.Year;

			lblWeeklyYearListeners.Text = serviceLayer.GetListenersAtYearStart(year).ToString();
            lblListenersToday.Text = serviceLayer.GetCurrentListenerCount().ToString();
			lblNewListeners.Text = serviceLayer.GetNewListenersForYear(year).ToString();
			lblLostListeners.Text = serviceLayer.GetLostListenersForYear(year).ToString();
			lblNetListeners.Text = serviceLayer.GetNetListenersForYear(year).ToString();
			lblAverageListeners.Text = serviceLayer.GetAverageListenersForYear(year).ToString();
			lblInactiveWallets.Text = serviceLayer.GetInactiveWalletNumbers().ToString();
            lblAverageDispatched.Text = serviceLayer.GetAverageDispatchedWallets(year).ToString();
            lblWalletsDispatched.Text = serviceLayer.GetWalletsDispatchedForYear(year).ToString();
			lblStoppedWallets.Text = serviceLayer.GetListenersByStatus(Objects.ListenerStates.PAUSED).Count.ToString();
			lblMemorySticksOnLoad.Text = serviceLayer.GetMemorySticksOnLoan().ToString();
            lblAverageStopped.Text = serviceLayer.GetAveragePausedWallets(year).ToString();
            lblDormant.Text = serviceLayer.Get3MonthInactiveListeners().ToString();
		}

		private void btnFinished_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void printStats()
		{
			printPreview.Document = printStatsDoc;
			printPreview.ClientSize = new Size(600, 600);
			printPreview.ShowDialog();
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			printStats();
		}

		private void printStatsDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Font reportFont = new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold);
			Font reportFontSmall = new System.Drawing.Font("Times New Roman", 20);
			Font reportFontSmallBold = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
			Font reportFontSmallBoldTitles = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);
			Graphics g = e.Graphics;
			int pageHeight = e.MarginBounds.Height;

			g.DrawString(Settings.Default.AssociationName, reportFont, Brushes.Black, 100, 80, StringFormat.GenericTypographic);

			string nowDate = null;
			nowDate = System.DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT);

			g.DrawString("Database Statistics at for this year up to " + nowDate + ".", reportFontSmall, Brushes.Black, 100, 120);

			int year = DateTime.Now.Year;
			g.DrawString("Weekly listeners at the start of the year:", reportFontSmall, Brushes.Black, 80, 180);
            g.DrawString(lblWeeklyYearListeners.Text, reportFontSmall, Brushes.Black, 680, 180);
			g.DrawString("Weekly listeners as of today:", reportFontSmall, Brushes.Black, 80, 220);
            g.DrawString(lblListenersToday.Text, reportFontSmall, Brushes.Black, 680, 220);
			g.DrawString("Number of new listeners this year:", reportFontSmall, Brushes.Black, 80, 260);
            g.DrawString(lblNewListeners.Text, reportFontSmall, Brushes.Black, 680, 260);
			g.DrawString("Number of lost listeners this year:", reportFontSmall, Brushes.Black, 80, 300);
            g.DrawString(lblLostListeners.Text, reportFontSmall, Brushes.Black, 680, 300);
			g.DrawString("Net change of listeners for the year:", reportFontSmallBold, Brushes.Black, 80, 340);
            g.DrawString(lblNetListeners.Text, reportFontSmallBold, Brushes.Black, 680, 340);
			g.DrawString("Average number of listeners for the year:", reportFontSmall, Brushes.Black, 80, 380);
			g.DrawString(lblAverageListeners.Text, reportFontSmall, Brushes.Black, 680, 380);
			g.DrawString("Inactive wallets (not available for use):", reportFontSmall, Brushes.Black, 80, 420);
			g.DrawString(lblInactiveWallets.Text, reportFontSmall, Brushes.Black, 680, 420);
			g.DrawString("Average number of wallets dispatched each week:", reportFontSmall, Brushes.Black, 80, 460);
            g.DrawString(lblAverageDispatched.Text, reportFontSmall, Brushes.Black, 680, 460);
			g.DrawString("News Wallets dispatched this year:", reportFontSmall, Brushes.Black, 80, 500);
			g.DrawString(lblWalletsDispatched.Text, reportFontSmall, Brushes.Black, 680, 500);
			g.DrawString("Memory stick players on loan:", reportFontSmall, Brushes.Black, 80, 540);
			g.DrawString(lblMemorySticksOnLoad.Text, reportFontSmall, Brushes.Black, 680, 540);
			g.DrawString("Stopped wallets:", reportFontSmall, Brushes.Black, 80, 580);
			g.DrawString(lblStoppedWallets.Text, reportFontSmall, Brushes.Black, 680, 580);
			g.DrawString("Average number of stopped wallets during the year:", reportFontSmall, Brushes.Black, 80, 620);
            g.DrawString(lblAverageStopped.Text, reportFontSmall, Brushes.Black, 680, 620);
			g.DrawString("Listeners inactive for 3 months:", reportFontSmall, Brushes.Black, 80, 660);
            g.DrawString(lblDormant.Text, reportFontSmall, Brushes.Black, 680, 660);

			//g.DrawString("Figures do not include producers unless otherwise stated.", reportFontSmallBold, Brushes.Black, 200, 500)
		}
		public FormStats()
		{
			Load += formStats_Load;
			InitializeComponent();
		}
	}
}
