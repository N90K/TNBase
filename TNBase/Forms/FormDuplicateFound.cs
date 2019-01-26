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
	public partial class FormDuplicateFound
	{
        private int autoCloseTime = 8;

        /// <summary>
        /// Setup the form
        /// </summary>
        /// <param name="walletId"></param>
		public void setupForm(int walletId)
		{
			lblWallet.Text = walletId.ToString();
		}

        /// <summary>
        /// Close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void btnDontAdd_Click(object sender, EventArgs e)
		{
            My.MyProject.Forms.formScanIn.clearScanText();
			this.Hide();
		}

        /// <summary>
        /// Add button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void btnAdd_Click(object sender, EventArgs e)
		{
			My.MyProject.Forms.formScanIn.addListItem(int.Parse(lblWallet.Text));
			this.Hide();
		}

        /// <summary>
        /// Form load.
        /// </summary>
		public FormDuplicateFound()
		{
			InitializeComponent();
		}

        private void formDuplicateFound_Load(object sender, EventArgs e)
        {
            lblSeconds.Text = autoCloseTime.ToString();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            autoCloseTime -= 1;
            lblSeconds.Text = autoCloseTime.ToString();

            // If we have run out of time, exit the form.
            if (autoCloseTime < 0)
            {
                timer.Enabled = false;
                this.Close();
            }
        }
	}
}
