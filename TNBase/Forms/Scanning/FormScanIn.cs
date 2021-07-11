using Microsoft.VisualBasic;
using System;
using System.Speech.Synthesis;
using System.Windows.Forms;
using TNBase.DataStorage;
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
        private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        private IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

        private int scannedIn = 0;
        private int lastScanned = 0;

        private bool exitMe = false;

        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();

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
                try
                {
                    addScanItem(int.Parse(txtScannerInput.Text));
                }
                catch (Exception e)
                {
                    log.Warn(e, "Failed to parse large integer on scanning: " + txtScannerInput.Text);
                }
            }
            else if (txtScannerInput.Text.Length > 0)
            {
                txtScannerInput.Text = "";
                ModuleSounds.PlayInvalidBarcode();
            }
        }

        public void clearScanText()
        {
            txtScannerInput.Text = String.Empty;
            txtScannerInput.Focus();
        }

        public void addScanItem(int walletId)
        {
            if ((walletId == lastScanned))
            {
                ModuleSounds.PlayExplode();
                My.MyProject.Forms.formDuplicateFound.Show();
                My.MyProject.Forms.formDuplicateFound.setupForm(walletId);
            }
            else
            {
                addListItem(walletId);
            }
            lastScanned = walletId;
        }

        public void addListItem(int walletId)
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
                if (listener.Status == ListenerStates.PAUSED)
                {
                    ModuleSounds.PlayStopped();
                }
                else if (listener.Status == ListenerStates.DELETED)
                {
                    ModuleSounds.PlayNotInUse();
                    Interaction.MsgBox("This listener has been deleted. Please remove the label and place wallet into the stock of unused wallets.");
                }
                else
                {
                    if (newQuantity == 2)
                    {
                        ModuleSounds.PlayTwoIn();
                    }
                    else if (newQuantity >= 3)
                    {
                        ModuleSounds.PlayThreeIn();
                        newQuantity = 3; // 3 is the max.
                    }
                    else
                    {
                        ModuleSounds.PlaySecondBeep();
                    }
                }
            }

            item.SubItems[1].Text = newQuantity.ToString();

            // Clear text.
            txtScannerInput.Text = string.Empty;
            scannedIn = scannedIn + 1;

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

        private void btnFinished_Click(object sender, EventArgs e)
        {
            // Show scanned form.
            My.MyProject.Forms.formScannedInTotal.Show();
            My.MyProject.Forms.formScannedInTotal.setup(scannedIn);
        }

        // Close the form and process the wallets.
        public void doClose()
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
                    listener.inOutRecords.In8 = quantity;

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

            // Update the new week stats
            ModuleGeneric.UpdateStatsWeek(serviceLayer, true);

            this.Close();
        }

        private void formScanIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitMe)
            {
                if (MessageBox.Show("Are you sure you want to quit? You will lose any scanned wallets unless you press Finished!", "Are you Sure?", MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void txtScannerInput_TextChanged(object sender, EventArgs e)
        {
            // The barcodes are in a 6 digit format (e.g. 000001)
            if (txtScannerInput.Text.Length == 6)
            {
                doScanAction();
            }
        }
    }
}