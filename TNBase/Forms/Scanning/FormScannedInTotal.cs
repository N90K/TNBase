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
			My.MyProject.Forms.formScanIn.doClose();
		}

		private void formScannedInTotal_FormClosing(object sender, FormClosingEventArgs e)
		{
			My.MyProject.Forms.formMain.ScanInDone();
		}
		public FormScannedInTotal()
		{
			FormClosing += formScannedInTotal_FormClosing;
			InitializeComponent();
		}
	}
}
