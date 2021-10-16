using System;
namespace TNBase
{
    public partial class FormScannedOutTotal
	{
		public void setup(int totalScanned)
		{
			lblTotal.Text = totalScanned.ToString();
		}

		private void btnScanMore_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnFinished_Click(object sender, EventArgs e)
		{
			this.Close();
			My.MyProject.Forms.formScanOut.doClose();

			// Show birthdays form.
			My.MyProject.Forms.formPrintBirthdays.Show();
			// Show not sent out form.
			My.MyProject.Forms.formPrintNotSentWallets.Show();
		}

		public FormScannedOutTotal()
		{
			InitializeComponent();
		}
	}
}
