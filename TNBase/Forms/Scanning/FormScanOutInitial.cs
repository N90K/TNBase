using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TNBase.Objects;
using TNBase.DataStorage;

namespace TNBase
{
    public partial class FormScanOutInitial
	{
        List<Listener> listenerWallets = new List<Listener>();
        IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

		int currentItem = 0;
		private void formScanOutInitial_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right) 
            {
				GoToNext();
			}

            if (e.KeyCode == Keys.Left)
            {
                GoToPrevious();
            }
		}

        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                GoToNext();
            }

            if (e.KeyCode == Keys.Left)
            {
                GoToPrevious();
            }
        }

		private void formScanOutInitial_Load(object sender, EventArgs e)
		{
			listenerWallets = serviceLayer.GetActiveListenersNotScannedIn();
            
            foreach (Control control in this.Controls)
            {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
            }
            
            UpdateDisplay(currentItem);
		}

		private void UpdateDisplay(int index)
		{
			if ((index >= 0 & index <= listenerWallets.Count & listenerWallets.Count > 0)) 
            {
				Listener theListener = listenerWallets[index];
				lblWalletNumber.Text = "" + theListener.Wallet;
				lblName.Text = theListener.Title + ". " + theListener.Surname;
			}
		}

		// Go to the next item.
		private void GoToNext()
		{
			if ((currentItem + 1 >= listenerWallets.Count)) 
            {
				My.MyProject.Forms.formScanOut.Show();
				this.Close();
			} 
            else 
            {
				currentItem = currentItem + 1;
			}

			UpdateDisplay(currentItem);
		}

		// Go to the previous item.
		private void GoToPrevious()
		{
			if (((currentItem - 1) >= 0)) 
            {
				currentItem = currentItem - 1;
			}

			UpdateDisplay(currentItem);
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			GoToNext();
		}

		private void btnPrevious_Click(object sender, EventArgs e)
		{
			GoToPrevious();
		}

		public FormScanOutInitial()
		{
			Load += formScanOutInitial_Load;
			KeyDown += formScanOutInitial_KeyDown;
			InitializeComponent();
		}
	}
}
