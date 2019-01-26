using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
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

		private void formScannedOutTotal_FormClosed(object sender, FormClosedEventArgs e)
		{
			My.MyProject.Forms.formMain.ScanOutDone();
		}
		public FormScannedOutTotal()
		{
			FormClosed += formScannedOutTotal_FormClosed;
			InitializeComponent();
		}
	}
}
