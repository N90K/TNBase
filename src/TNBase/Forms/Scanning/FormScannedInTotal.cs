using System;
namespace TNBase
{
    public partial class FormScannedInTotal
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
			My.MyProject.Forms.formScanIn.DoClose();
		}

		public FormScannedInTotal()
		{
			InitializeComponent();
		}
	}
}
