using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using TNBase.Objects;
using TNBase.DataStorage;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TNBase.Infrastructure;

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
                DoScanAction();
            }
        }

        private void DoScanAction()
        {
            if (Information.IsNumeric(txtScannerInput.Text))
            {
                ModuleSounds.PlayBeep();
                AddScanItem(int.Parse(txtScannerInput.Text));
            }
            else if (txtScannerInput.Text.Length > 0)
            {
                txtScannerInput.Text = "";
                ModuleSounds.PlayInvalidBarcode();
            }
        }

        public void AddScanItem(int walletId)
        {
            bool scannedAlready = false;
            foreach (ListViewItem item in lstScanned.Items)
            {
                if (item.SubItems[0].Text == walletId.ToString())
                {
                    scannedAlready = true;
                }
            }

            if (walletId == lastScanned | scannedAlready)
            {
                txtScannerInput.Text = "";
                ModuleSounds.PlayTwoOut();
                MessageBox.Show("You have just tried to scan the same wallet out twice. Second entry rejected.");
            }
            else
            {
                AddListItem(walletId);
            }
            lastScanned = walletId;
        }

        public void AddListItem(int walletId)
        {
            string[] subItems = new string[3];

            subItems[0] = walletId.ToString();
            subItems[1] = "1";

            lstScanned.Items.Add(new ListViewItem(subItems));

            txtScannerInput.Text = "";
            scannedOut++;

            lstScanned.Focus();
            lstScanned.Items[lstScanned.Items.Count - 1].Selected = true;
            lstScanned.Items[lstScanned.Items.Count - 1].Focused = true;
            lstScanned.Items[lstScanned.Items.Count - 1].EnsureVisible();
            txtScannerInput.Focus();

            Task.Delay(100).Wait();

            var theListener = serviceLayer.GetListenerById(walletId);
            if (theListener == null)
            {
                ModuleSounds.PlayNotInUse();
            }
            else
            {
                if (theListener.Status == ListenerStates.ACTIVE && theListener.Joined > DateTime.Now.AddDays(-6) && theListener.Stock == 3)
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
        public void DoClose()
        {
            ModuleScanning.setScannedOut(ModuleScanning.getScannedOut() + scannedOut);

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
