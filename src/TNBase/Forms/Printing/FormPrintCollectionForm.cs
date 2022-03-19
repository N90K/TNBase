using System;
using System.Drawing;
using TNBase.Objects;
using TNBase.DataStorage;
using Microsoft.Extensions.DependencyInjection;

namespace TNBase
{
    public partial class FormPrintCollectionForm
	{
		private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();
		Listener theListener = new Listener();
		Collector theColl = new Collector();

		bool deleted = false;
		private void printCollectionForm_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Font reportFont = new System.Drawing.Font("Times New Roman", 24, FontStyle.Bold);
			Font reportFontMiddle = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
			Font reportFontSmall = new System.Drawing.Font("Times New Roman", 14);
			Font reportFontSmallBold = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);
			Font reportFontSmallBoldTitles = new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold);
			Graphics g = e.Graphics;
			int pageHeight = e.MarginBounds.Height;

			if (deleted) {
				g.DrawString("Deleted Listener - Please collect Memory Stick player", reportFontMiddle, Brushes.Black, 100, 80, StringFormat.GenericTypographic);
			} else {
				g.DrawString("New Listener requires Memory Stick Player", reportFont, Brushes.Black, 100, 80, StringFormat.GenericTypographic);
			}

			g.DrawString("Details", reportFontSmallBoldTitles, Brushes.Black, 100, 130, StringFormat.GenericTypographic);

			g.DrawString("Name: ", reportFontSmallBold, Brushes.Black, 100, 170, StringFormat.GenericTypographic);
			g.DrawString(theListener.Title + ". " + theListener.Forename + " " + theListener.Surname, reportFontSmall, Brushes.Black, 270, 170, StringFormat.GenericTypographic);

			g.DrawString("Wallet: ", reportFontSmallBold, Brushes.Black, 570, 170, StringFormat.GenericTypographic);
			g.DrawString(theListener.Wallet.ToString(), reportFontSmall, Brushes.Black, 560 + 100, 170, StringFormat.GenericTypographic);

			if (deleted) {
				g.DrawString("Reason: ", reportFontSmallBold, Brushes.Black, 100, 195, StringFormat.GenericTypographic);
				g.DrawString(theListener.StatusInfo, reportFontSmall, Brushes.Black, 270, 195, StringFormat.GenericTypographic);

				g.DrawString("Deleted Date: ", reportFontSmallBold, Brushes.Black, 100, 220, StringFormat.GenericTypographic);
				g.DrawString(theListener.DeletedDate.ToString(), reportFontSmall, Brushes.Black, 270, 220, StringFormat.GenericTypographic);
			}

			g.DrawString("Address:", reportFontSmallBold, Brushes.Black, 100, 260, StringFormat.GenericTypographic);
			g.DrawString("Telephone:", reportFontSmallBold, Brushes.Black, 570, 260, StringFormat.GenericTypographic);

			g.DrawString(Environment.NewLine + theListener.Addr1 + Environment.NewLine + theListener.Addr2 + Environment.NewLine + theListener.Town + Environment.NewLine + theListener.County + Environment.NewLine + theListener.Postcode, reportFontSmall, Brushes.Black, 100, 265, StringFormat.GenericTypographic);
			g.DrawString(Environment.NewLine + theListener.Telephone, reportFontSmall, Brushes.Black, 570, 265, StringFormat.GenericTypographic);

			g.DrawString("Information:", reportFontSmallBold, Brushes.Black, 100, 420, StringFormat.GenericTypographic);
			g.DrawString("" + theListener.Info, reportFontSmall, Brushes.Black, 300, 420, StringFormat.GenericTypographic);

			g.DrawLine(Pens.Black, new Point(100, 470), new Point(720, 470));

			g.DrawString("Contact " + theColl.Forename + " " + theColl.Surname + " on " + theColl.Number, reportFontMiddle, Brushes.Black, 180, 500, StringFormat.GenericTypographic);
			g.DrawString("Printed: " + DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT), reportFontSmall, Brushes.Black, 560, 550, StringFormat.GenericTypographic);

			g.DrawLine(Pens.Black, new Point(100, 590), new Point(720, 590));


			if (deleted) {
				g.DrawString("When Player has been collected, please hand this list to the Saturday morning" + Environment.NewLine + "team to update the records.", reportFontSmallBold, Brushes.Black, 100, 620, StringFormat.GenericTypographic);
			} else {
				g.DrawString("When Player has been issued, please hand this list to the Saturday morning" + Environment.NewLine + "team to update the records.", reportFontSmallBold, Brushes.Black, 100, 620, StringFormat.GenericTypographic);
			}

			g.DrawString("Computer Team", reportFontSmallBoldTitles, Brushes.Black, 100, 680, StringFormat.GenericTypographic);
			g.DrawString("1. Select [Edit Listener] from the main menu.", reportFontSmallBold, Brushes.Black, 100, 710, StringFormat.GenericTypographic);
			g.DrawString("2. Enter the listener wallet number to open the edit page.", reportFontSmallBold, Brushes.Black, 100, 735, StringFormat.GenericTypographic);
			if (deleted) {
				g.DrawString("3. Untick the memory stick checkbox.", reportFontSmallBold, Brushes.Black, 100, 760, StringFormat.GenericTypographic);
			} else {
				g.DrawString("3. Tick the memory stick checkbox.", reportFontSmallBold, Brushes.Black, 100, 760, StringFormat.GenericTypographic);
			}
			g.DrawString("4. Press the finished button.", reportFontSmallBold, Brushes.Black, 100, 785, StringFormat.GenericTypographic);
		}

		private void printCollectionFormW()
		{
			printPreview.Document = printCollectionForm;
			printPreview.ClientSize = new Size(600, 600);
			printPreview.ShowDialog();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public void SetupForm(Listener argListener, bool valDeleted)
		{
			theListener = argListener;
			deleted = valDeleted;
			theColl = serviceLayer.GetCollectorForListener(theListener);
			printCollectionFormW();
			this.Close();
		}
        
		public FormPrintCollectionForm()
		{
			InitializeComponent();
		}

	}
}
