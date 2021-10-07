using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using TNBase.Objects;
using TNBase.DataStorage;
using Microsoft.Extensions.DependencyInjection;

namespace TNBase
{
    public partial class FormScanOut
    {
        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();

        int scannedOut = 0;
        int lastScanned = 0;

        bool exitMe = false;
        private void txtScannerInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                doScanAction();
            }
        }

        private void doScanAction()
        {
            if ((Information.IsNumeric(txtScannerInput.Text)))
            {
                ModuleSounds.PlayBeep();
                addScanItem(int.Parse(txtScannerInput.Text));
            }
            else if (txtScannerInput.Text.Length > 0)
            {
                txtScannerInput.Text = "";
                ModuleSounds.PlayInvalidBarcode();
            }
        }

        public void addScanItem(int walletId)
        {
            bool scannedAlready = false;

            // Actually process the scanned items!
            for (int i = 0; i <= (lstScanned.Items.Count - 1); i++)
            {
                ListViewItem item = lstScanned.Items[i];
                // If the item exists, just update the quantity.
                if ((item.SubItems[0].Text == walletId.ToString()))
                {
                    scannedAlready = true;
                }
            }

            if ((walletId == lastScanned | scannedAlready))
            {
                txtScannerInput.Text = "";
                ModuleSounds.PlayTwoOut();
                MessageBox.Show("You have just tried to scan the same wallet out twice. Second entry rejected.");
            }
            else
            {
                addListItem(walletId);
            }
            lastScanned = walletId;
        }

        public void addListItem(int walletId)
        {
            // If there is no duplicate, just add the item.
            string[] arr = new string[3];
            ListViewItem itm = null;

            //Add first item
            arr[0] = walletId.ToString();
            arr[1] = "1";

            itm = new ListViewItem(arr);
            lstScanned.Items.Add(itm);

            txtScannerInput.Text = "";
            scannedOut = scannedOut + 1;

            // Focus list item properly.
            lstScanned.Focus();
            lstScanned.Items[lstScanned.Items.Count - 1].Selected = true;
            lstScanned.Items[lstScanned.Items.Count - 1].Focused = true;
            lstScanned.Items[lstScanned.Items.Count - 1].EnsureVisible();
            txtScannerInput.Focus();

            // Process and play a second beep.
            ModuleGeneric.Sleep(100);
            Listener theListener = default(Listener);
            theListener = serviceLayer.GetListenerById(walletId);
            if (((theListener == null)))
            {
                ModuleSounds.PlayNotInUse();
            }
            else
            {
                if (theListener.Status == ListenerStates.ACTIVE & (theListener.Joined > DateTime.Now.AddDays(-6) & theListener.Stock == 3))
                {
                    ModuleSounds.PlayNew();
                }
                else if (theListener.Status == ListenerStates.PAUSED)
                {
                    ModuleSounds.PlayStopped();
                }
                else
                {
                    ModuleSounds.PlaySecondBeep();
                }
            }
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            // Show scanned form.
            My.MyProject.Forms.formScannedOutTotal.Show();
            My.MyProject.Forms.formScannedOutTotal.setup(scannedOut);
        }

        private void formScanOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitMe)
            {
                if (MessageBox.Show(" Are you sure you want to quit? You will lose any scanned wallets unless you press Finished!", "Are you Sure?", MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        // Close the form and process the wallets.
        public void doClose()
        {
            ModuleScanning.setScannedOut(scannedOut);

            // Actually process the scanned items!
            for (int i = 0; i <= (lstScanned.Items.Count - 1); i++)
            {
                ListViewItem item = lstScanned.Items[i];
                // If the item exists, just update the quantity.
                Listener theListener = serviceLayer.GetListenerById(int.Parse(item.SubItems[0].Text));
                if ((theListener != null))
                {
                    theListener.InOutRecords.Out8 = int.Parse(item.SubItems[1].Text);
                    // Also adjust stock.
                    theListener.Stock = theListener.Stock - int.Parse(item.SubItems[1].Text);
                    theListener.LastOut = DateTime.Now;

                    serviceLayer.UpdateListener(theListener);
                    serviceLayer.RecordScan(theListener.Wallet, ScanTypes.OUT);
                }
            }

            // Show message and close.
            exitMe = true;
            this.Close();
        }
        public FormScanOut()
        {
            FormClosing += formScanOut_FormClosing;
            InitializeComponent();
        }
    }
}
