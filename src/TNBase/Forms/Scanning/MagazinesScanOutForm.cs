using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TNBase.Objects;

namespace TNBase.Forms.Scanning
{
    public partial class MagazinesScanOutForm : Form
    {
        private enum ScanStatus
        {
            Ok,
            Error
        }

        private List<Scan> scans = new List<Scan>();
        private List<int> walletsToScan;
        private IEnumerable<int> stoppedWallets;
        private WalletTypes walletType;

        public IEnumerable<Scan> Scans => scans;

        public MagazinesScanOutForm()
        {
            InitializeComponent();
        }

        private void txtScannerInput_TextChanged(object sender, EventArgs e)
        {
            if (txtScannerInput.Text.Length > 5)
            {
                Scan();
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void txtScannerInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (!string.IsNullOrWhiteSpace(txtScannerInput.Text))
                    Scan();
            }
        }

        private void Scan()
        {
            int.TryParse(txtScannerInput.Text, out int wallet);
            if (wallet > 0)
            {
                if (walletsToScan.Contains(wallet))
                {
                    walletsToScan.Remove(wallet);
                    scans.Add(new Scan
                    {
                        Wallet = wallet,
                        ScanType = ScanTypes.OUT,
                        WalletType = walletType
                    });
                    ModuleSounds.PlayBeep();
                    SetStatusMessage($"Last scanned {wallet}.", ScanStatus.Ok);
                    UpdateScanList(wallet);
                }
                else
                {
                    if (scans.Any(x => x.Wallet == wallet))
                    {
                        ModuleSounds.DoubleBeep();
                        SetStatusMessage($"Duplicate! Wallet {wallet} already scanned.", ScanStatus.Error);
                    }
                    else if (stoppedWallets.Contains(wallet))
                    {
                        ModuleSounds.PlayStopped();
                        SetStatusMessage($"Wallet {wallet} is paused.", ScanStatus.Error);
                    }
                    else
                    {
                        ModuleSounds.BeepInvalid();
                        SetStatusMessage($"Not Found! Wallet {wallet} should not be scanned.", ScanStatus.Error);
                    }
                }
            }
            else
            {
                ModuleSounds.BeepInvalid();
                SetStatusMessage($"Invalid barcode {txtScannerInput.Text}.", ScanStatus.Error);
            }

            txtScannerInput.Text = "";
        }

        private void SetStatusMessage(string message, ScanStatus status)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = status == ScanStatus.Ok ? System.Drawing.SystemColors.ControlDarkDark : System.Drawing.Color.Red;
        }

        private void UpdateScanList(int lastScaned)
        {
            lstToScan.Items.Clear();
            lstToScan.Items.AddRange(walletsToScan
                .OrderBy(x => x)
                .Select((x, index) => new ListViewItem(x.ToString())
                {
                    BackColor = GetAlternateColour(index)
                })
                .ToArray());

            lstToScan.Columns[0].Width = -2;

            lstScanned.Items.Clear();
            lstScanned.Items.AddRange(scans
                .Select((x, index) => new ListViewItem(x.Wallet.ToString())
                {
                    Selected = lastScaned == x.Wallet,
                    BackColor = GetAlternateColour(index)
                })
                .ToArray());

            lstScanned.Columns[0].Width = -2;
        }

        private static Color GetAlternateColour(int index)
        {
            return index % 2 == 0 ? Color.White : Color.GhostWhite;
        }

        private void FormMagazineScanIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK && scans.Any())
            {
                var result = MessageBox.Show("Closing this form will discard all the scans. Do you want to continue?", "Close", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        public void Setup(string title, WalletTypes walletType, IEnumerable<int> walletsToScan, IEnumerable<int> scanned, IEnumerable<int> stoppedWallets)
        {
            this.walletType = walletType;
            this.walletsToScan = walletsToScan.ToList();
            this.stoppedWallets = stoppedWallets;

            Text = title;
            ScanInputLabel.Text = $"Please scan out a {walletType.ToString().ToLower()} wallet:";
            lblStatus.Text = "";

            if (scanned != null && scanned.Any())
            {
                scans.AddRange(scanned.Select(x => new Scan
                {
                    Wallet = x,
                    ScanType = ScanTypes.OUT,
                    WalletType = walletType
                }));
            }
        }

        private void ScanOutForm_Load(object sender, EventArgs e)
        {
            UpdateScanList(0);
        }

        private void lstToScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            SetFocusOnScannerInput(e.KeyChar);
        }

        private void lstScanned_KeyPress(object sender, KeyPressEventArgs e)
        {
            SetFocusOnScannerInput(e.KeyChar);
        }

        private void SetFocusOnScannerInput(char keyChar)
        {
            if (!char.IsControl(keyChar))
            {
                txtScannerInput.Focus();
                txtScannerInput.Text = txtScannerInput.Text + keyChar;
                txtScannerInput.SelectionStart = txtScannerInput.Text.Length;
            }
        }
    }
}
