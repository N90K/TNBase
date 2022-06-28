using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Windows.Forms;
using TNBase.DataStorage;
using TNBase.Infrastructure;
using TNBase.Objects;

namespace TNBase
{
    // Process Details
    //
    // Scanning in, wallets are scanned in and put into the in tray or stock.
    // First wallet number goes into the tray, the rest into stock.
    // Program then lists all that are active and arent in the in tray and then calls them out to be put in.
    // Then they are scanned out.
    //
    public partial class FormScanIn
    {
        private readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();

        private int scannedIn = 0;
        private int lastScanned = 0;

        private bool exitMe = false;

        private void TxtScannerInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                DoScanAction();
            }
        }

        private void DoScanAction()
        {
            if (int.TryParse(txtScannerInput.Text, out var walletId))
            {
                ModuleSounds.PlaySecondBeep();
                AddScanItem(walletId);
            }
            else if (txtScannerInput.Text.Length > 0)
            {
                txtScannerInput.Text = "";
                ModuleSounds.PlayInvalidBarcode();
            }
        }

        public void ClearScanText()
        {
            txtScannerInput.Text = String.Empty;
            txtScannerInput.Focus();
        }

        public void AddScanItem(int walletId)
        {
            if (walletId == lastScanned)
            {
                ModuleSounds.PlayExplode();
                My.MyProject.Forms.formDuplicateFound.Show();
                My.MyProject.Forms.formDuplicateFound.setupForm(walletId);
            }
            else
            {
                AddListItem(walletId);
            }
            lastScanned = walletId;
        }

        public void AddListItem(int walletId)
        {
            var item = GetOrAddScannedItem(walletId);
            var newQuantity = int.Parse(item.SubItems[1].Text) + 1;

            var listener = serviceLayer.GetListenerById(walletId);
            if (listener == null)
            {
                ModuleSounds.PlayNotInUse();
            }
            else
            {
                if (listener.OnlineOnly)
                {
                    ModuleSounds.PlayOnlineOnly();
                }
                else if (listener.Status == ListenerStates.PAUSED)
                {
                    ModuleSounds.PlayStopped();
                }
                else if (listener.Status == ListenerStates.DELETED)
                {
                    ModuleSounds.PlayNotInUse();
                    lblInfo.Text = $"Listener {walletId} has been deleted. Please remove the label and place wallet into the stock of unused wallets.";
                }
                else
                {
                    if (listener.WarnOfAddressChange)
                    {
                        lblInfo.Text = $"Listener's address has changed\nNew address is: \n{listener.FormatListenerData()}";
                        Refresh();
                        ModuleSounds.PlayAddressChanged();
                        Thread.Sleep(1500);
                    }

                    if (newQuantity == 2)
                    {
                        ModuleSounds.PlayTwoIn();
                    }
                    else if (newQuantity >= 3)
                    {
                        ModuleSounds.PlayThreeIn();
                        newQuantity = 3; // 3 is the max.
                    }
                }
            }

            item.SubItems[1].Text = newQuantity.ToString();

            // Clear text.
            txtScannerInput.Text = string.Empty;
            scannedIn++;

            FocusScannedItem(item);
        }

        private void FocusScannedItem(ListViewItem item)
        {
            lstScanned.Focus();
            item.Selected = true;
            item.Focused = true;
            item.EnsureVisible();
            txtScannerInput.Focus();
        }

        private ListViewItem GetOrAddScannedItem(int walletId)
        {
            foreach (ListViewItem item in lstScanned.Items)
            {
                if (item.SubItems[0].Text == walletId.ToString())
                {
                    return item;
                }
            }

            return lstScanned.Items.Add(new ListViewItem(new[]{
                walletId.ToString(),
                "0",
                ""
            }));
        }

        private void BtnFinished_Click(object sender, EventArgs e)
        {
            // Show scanned form.
            My.MyProject.Forms.formScannedInTotal.Show();
            My.MyProject.Forms.formScannedInTotal.setup(scannedIn);
        }

        // Close the form and process the wallets.
        public void DoClose()
        {
            ModuleScanning.setScannedIn(scannedIn);

            // Actually process the scanned items!
            foreach (ListViewItem item in lstScanned.Items)
            {
                var wallet = int.Parse(item.SubItems[0].Text);
                var quantity = int.Parse(item.SubItems[1].Text);

                // If the item exists, just update the quantity.
                var listener = serviceLayer.GetListenerById(wallet);
                if (listener != null)
                {
                    listener.InOutRecords.In8 = quantity;

                    for (int i = 0; i < quantity; i++)
                    {
                        listener.Scan(ScanTypes.IN, WalletTypes.News);
                    }

                    // Are there more than 3 stock items?
                    if (listener.Stock > Listener.DEFAULT_STOCK)
                    {
                        int overStock = listener.Stock;
                        listener.Stock = 3;
                        MessageBox.Show("Listener with Wallet: " + listener.Wallet + ", Name: " + listener.GetNiceName() + " would have " + overStock + " stock after scanning in these wallets. " + Environment.NewLine + Environment.NewLine +
                                         "Please look for any old wallets and remove the labels before clicking OK to continue.");
                        log.Warn("Listner " + listener.GetNiceName() + " would have " + overStock + " stock after the scanning in. Limiting to " + Listener.DEFAULT_STOCK + " and displaying warning.");
                    }

                    // If the listener is active, we will be also sending it out
                    if (listener.Status.Equals(ListenerStates.ACTIVE))
                    {
                        listener.Scan(ScanTypes.OUT, WalletTypes.News);

                        // Increment scanned out count
                        ModuleScanning.setScannedOut(ModuleScanning.getScannedOut() + 1);
                        serviceLayer.RecordScan(listener.Wallet, ScanTypes.OUT);

                        // Also update the last out time (as we will be updating this listener in a minute with out8 = 1).
                        listener.LastOut = DateTime.Now;
                    }

                    listener.LastIn = DateTime.Now;

                    serviceLayer.UpdateListener(listener);
                    log.Debug("Updated listener information.");

                    serviceLayer.RecordScan(listener.Wallet, ScanTypes.IN);
                }
            }

            // Show message and close.
            MessageBox.Show("The " + scannedIn + " wallets you have scanned have been successfully processed." + Environment.NewLine + Environment.NewLine + "You can now load them with memory sticks and place them in GPO mailbags.", ModuleGeneric.getAppShortName(), MessageBoxButtons.OK);
            exitMe = true;

            serviceLayer.UpdateListenerInOuts();

            this.Close();
        }

        private void FormScanIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitMe)
            {
                if (MessageBox.Show("Are you sure you want to quit? You will lose any scanned wallets unless you press Finished!", "Are you Sure?", MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void TxtScannerInput_TextChanged(object sender, EventArgs e)
        {
            if (txtScannerInput.Text.Length > 0)
            {
                lblInfo.Text = "";
            }

            // The barcodes are in a 6 digit format (e.g. 000001)
            if (txtScannerInput.Text.Length == 6)
            {
                DoScanAction();
            }
        }

        private void FormScanIn_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "";
        }
    }
}
