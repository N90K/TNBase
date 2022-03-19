using System;

namespace TNBase
{
    public partial class FormDuplicateFound
	{
        private int autoCloseTime = 8;
        private Boolean addEnabled = false;

        /// <summary>
        /// Setup the form
        /// </summary>
        /// <param name="walletId"></param>
		public void setupForm(int walletId)
		{
			lblWallet.Text = walletId.ToString();
            timerEnableAdd.Enabled = true;
        }

        /// <summary>
        /// Close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void btnDontAdd_Click(object sender, EventArgs e)
		{
            My.MyProject.Forms.formScanIn.ClearScanText();
			this.Hide();
		}

        /// <summary>
        /// Add button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void btnAdd_Click(object sender, EventArgs e)
		{
            // Add is disabled initially to avoid scanner auto-enter
            if (addEnabled)
            {
                My.MyProject.Forms.formScanIn.AddListItem(int.Parse(lblWallet.Text));
                this.Hide();
                addEnabled = false;
            }
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

        private void timerEnableAdd_Tick(object sender, EventArgs e)
        {
            addEnabled = true;
            timerEnableAdd.Enabled = false;
        }
    }
}
