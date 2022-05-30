using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using TNBase.DataStorage;
using NLog;
using TNBase.Forms.Printing;
using TNBase.Forms.Scanning;
using TNBase.Objects;
using System.Linq;
using TNBase.Model;
using Microsoft.Extensions.DependencyInjection;
using TNBase.Repository;
using System.Globalization;

namespace TNBase
{
    /// <summary>
    /// Main form
    /// </summary>
	public partial class FormMain
    {
        // Logging instance
        Logger log = LogManager.GetCurrentClassLogger();

        // Variabless
        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();

        /// <summary>
        /// Load the correct logo!
        /// </summary>
        private void LoadLogo()
        {
            string logo = Properties.Settings.Default.Logo;
            if (!string.IsNullOrEmpty(logo))
            {
                try
                {
                    PictureBox1.BackgroundImage = new Bitmap(logo); //Image.FromFile(logo);
                }
                catch (Exception e)
                {
                    log.Error(e, "Could not load logo: " + logo);
                }
            }
            else
            {
                log.Debug("No logo set, using the default.");
            }
        }

        /// <summary>
        /// When the form loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void formMain_Load(object sender, EventArgs e)
        {
            // Load the logo
            LoadLogo();

            // Initially update the time labels.
            UpdateTimers();

            // Set an initial hint.
            updateHints();

            // Update week number.
            UpdateWeekNumber();

            // Show version
            var version = $"v{Application.ProductVersion}";
            lblVersion.Text = version;
            Text = $"TNBase {version}";
            log.Info($"Loaded {version}");
        }

        private void UpdateWeekNumber()
        {
            var weekNumber = ISOWeek.GetWeekOfYear(DateTime.UtcNow).ToString();

            if (Properties.Settings.Default.ShowLegacyWeekNumber)
            {
                weekNumber += $" ({serviceLayer.GetCurrentWeekNumber()})";
            }

            lblWeekNumber.Text = $"Week: {weekNumber}";
        }

        private void UpdateTimers()
        {
            // Update the time labels with the following formatting.
            lblDate.Text = System.DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT);
            lblTime.Text = System.DateTime.Now.ToString(ModuleGeneric.TIME_FORMAT);
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            // Update time labels every second.
            UpdateTimers();
        }

        // Show the finished form when exiting.
        private void formMain_FormClosing(System.Object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Visible = false;
            var form = new FormFinished();
            form.ShowDialog();
        }

        private void updateHints()
        {
            var hints = new List<string>
            {
                "Log files can be found at: " + ModuleGeneric.GetLogFilePath(),
                ""
            };

            // Pick a random item from the hints.
            var randomNumber = new Random();
            lblHints.Text = hints[randomNumber.Next(0, hints.Count)];
        }

        private void TimerHints_Tick(object sender, EventArgs e)
        {
            updateHints();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            new FormAddMini().ShowDialog();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAddMini().ShowDialog();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formFindListener.Show();
            My.MyProject.Forms.formFindListener.theType = FormFindListener.FindListenerFormType.DeleteForm;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formFindListener.Show();
            My.MyProject.Forms.formFindListener.theType = FormFindListener.FindListenerFormType.EditForm;
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formFindListener.Show();
            My.MyProject.Forms.formFindListener.theType = FormFindListener.FindListenerFormType.DeleteForm;
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formFindListener.Show();
            My.MyProject.Forms.formFindListener.theType = FormFindListener.FindListenerFormType.EditForm;
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            ShowBackup();
        }

        // Show backup dialog.
        public void ShowBackup()
        {
            backupDialog.FileName = ModuleGeneric.DATABASE_NAME;
            backupDialog.Title = "Backup Listener Database";
            backupDialog.Filter = "SQLite Database Files|*.s3db";
            backupDialog.CheckPathExists = true;
            backupDialog.InitialDirectory = "A:\\";
            backupDialog.OverwritePrompt = Properties.Settings.Default.OverwritePrompt;

            // If successful, backup the database.
            if (backupDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var databaseOptions = Program.ServiceProvider.GetService<DatabaseManagerOptions>();
                if (DBUtils.CopyDatabase(databaseOptions.DatabasePath, backupDialog.FileName))
                {
                    Interaction.MsgBox("Database backup successful, please restart app!");
                }
                else
                {
                    Interaction.MsgBox("Error: Database was not copied correctly!");
                }
            }
        }

        // Show restore dialog.
        public void ShowRestore()
        {
            DialogResult result = MessageBox.Show("You should backup the existing database before restoring as restoring will overwrite the current database." + Environment.NewLine + Environment.NewLine + "Overwriting the current database is irreversible, are you sure you want to continue?", ModuleGeneric.getAppShortName(), MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            restoreDialog.FileName = ModuleGeneric.DATABASE_NAME;
            restoreDialog.Title = "Restore Listener Database";
            restoreDialog.Filter = "SQLite Database Files|*.s3db";
            restoreDialog.CheckPathExists = true;
            restoreDialog.InitialDirectory = "A:\\";

            // If successful, backup the database.
            if (restoreDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var databaseOptions = Program.ServiceProvider.GetService<DatabaseManagerOptions>();
                if (DBUtils.RestoreDatabase(restoreDialog.FileName, databaseOptions.DatabasePath))
                {
                    Program.NewScope();
                    var context = (TNBaseContext)Program.ServiceProvider.GetService<ITNBaseContext>();
                    context.UpdateDatabase();
                    Interaction.MsgBox("Database restore successful.");
                }
                else
                {
                    Interaction.MsgBox("Error: Database was not restored correctly!");
                }
            }
        }

        private void BackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBackup();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formAbout.Show();
        }

        private void BtnFinished_Click(object sender, EventArgs e)
        {
            // Show a load of forms automatically.!
            if ((Properties.Settings.Default.OnlyAutoPrintOnSat &&
                DateTime.UtcNow.DayOfWeek.Equals(DayOfWeek.Saturday)) || !Properties.Settings.Default.OnlyAutoPrintOnSat)
            {
                List<String> warnings = new List<String>();

                if (serviceLayer.GetRecentlyAddedListeners().Count > 0)
                {
                    FormPrintRecentListeners printRecentAdded = new FormPrintRecentListeners();
                    printRecentAdded.Show();
                    printRecentAdded.setupForm(true);
                }
                else
                {
                    warnings.Add("No recently added Listeners this week.");
                }

                if (serviceLayer.GetRecentlyDeletedListeners().Count > 0)
                {
                    FormPrintRecentListeners printRecentDeleted = new FormPrintRecentListeners();
                    printRecentDeleted.Show();
                    printRecentDeleted.setupForm(false);
                }
                else
                {
                    warnings.Add("No recently added Listeners this week.");
                }

                if (serviceLayer.GetNextWeekBirthdays().Count > 0)
                {
                    FormPrintBirthdays printBirthdays = new FormPrintBirthdays();
                    printBirthdays.Show();
                }
                else
                {
                    warnings.Add("No upcoming Listener birthdays for next week.");
                }

                if (serviceLayer.GetUnsentListeners().Count > 0)
                {
                    FormPrintNotSentWallets printNotSent = new FormPrintNotSentWallets();
                    printNotSent.Show();
                }
                else
                {
                    warnings.Add("No unsent wallets this week.");
                }

                // Show warnings for the week
                if (warnings.Count > 0)
                {
                    FormPrintWarnings formPrintWarnings = new FormPrintWarnings();
                    formPrintWarnings.Show();
                    formPrintWarnings.setupForm(warnings);
                }
            }

            Close();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formBrowse.Show();
        }

        private void btnPrintLabels_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formFindListener.Show();
            My.MyProject.Forms.formFindListener.theType = FormFindListener.FindListenerFormType.PrintLabels;
        }

        private void UpcomingBirthdaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formPrintBirthdays.Show();
        }

        private void BrowseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formBrowse.Show();
        }

        private void StatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formStats.Show();
        }

        private void BtnScanIn_Click(object sender, EventArgs e)
        {
            // Check if alterations have been completed.
            DialogResult result = MessageBox.Show("Have you completed all the alterations and additions from the pending tray?" + Environment.NewLine + Environment.NewLine + "If you still have alterations or additions press Cancel and scan in after.", ModuleGeneric.getAppShortName(), MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                // Is it not a new stats week?
                if (!(serviceLayer.IsNewStatsWeek()) &&
                    serviceLayer.GetCurrentWeekStats().HasScanningResults())
                {
                    // Check before we create a new stats bit then!
                    DialogResult newWeekCheck = MessageBox.Show("Scanning has already been done this week. Are you sure you want to continue, a new stats week will be created.", ModuleGeneric.getAppShortName());
                    if (result == DialogResult.OK)
                    {
                        My.MyProject.Forms.formScanIn.Show();
                    }
                }
                else
                {
                    My.MyProject.Forms.formScanIn.Show();
                }
            }
        }

        private void BrnRestore_Click(object sender, EventArgs e)
        {
            ShowRestore();
        }

        private void RestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRestore();
        }

        private void BtnStopSending_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formFindListener.Show();
            My.MyProject.Forms.formFindListener.theType = FormFindListener.FindListenerFormType.StopSending;
        }

        private void BtnCancelStop_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formResumeSending.Show();
        }

        private void PrintLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formPrintLabels.Show();
        }

        private void BtnScanOut_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formScanOutInitial.Show();
        }

        private void ScanInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formScanIn.Show();
        }

        private void ScanOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formScanOut.Show();
        }

        private void RecentlyAddedListenersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formPrintRecentListeners.Show();
            My.MyProject.Forms.formPrintRecentListeners.setupForm(true);
        }

        private void PrintAddressLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formFindListener.Show();
            My.MyProject.Forms.formFindListener.theType = FormFindListener.FindListenerFormType.PrintLabels;
        }

        private void AddCollectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formAddCollectors.Show();
        }

        private void BrowseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formBrowseCollectors.Show();
        }

        private void CancelAStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formResumeSending.Show();
        }

        private void StopSendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formStopSending.Show();
        }

        private void ListenersInactiveFor30DaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formPrintDormantListeners.Show();
        }

        private void HistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formHistory.Show();
        }

        private void GPOSackLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formPrintGPOLabels.Show();
        }

        private void RecentlyDeletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formPrintRecentListeners.Show();
            My.MyProject.Forms.formPrintRecentListeners.setupForm(false);
        }

        private void StoppedListenersThisWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formPrintStoppedWallets.Show();
        }

        private void WalletsNotSentOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formPrintNotSentWallets.Show();
        }

        private void UnreturnedSpeakersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formPrintUnreturnedSpeakers.Show();
        }

        private void PrintAlphabeticSurnameListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formPrintAlphabeticList.Show();
        }

        private void PrintAllListenerLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show prompt.
            DialogResult result = MessageBox.Show("Are you sure you wish to print 4 labels for every listener? This will require multiple label sheets.", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                My.MyProject.Forms.formPrintAllLabels.Show();
            }
        }

        private void StoppedListenerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formPrintStoppedWalletsAll.Show();
        }

        private void LogViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogViewer frm = new FormLogViewer();
            frm.Show();
        }

        private void OpenLogDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", ModuleGeneric.GetLogFilePath().Replace("Debug.log", ""));
        }

        private void PrintCollectorForListenerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formFindListener.Show();
            My.MyProject.Forms.formFindListener.theType = FormFindListener.FindListenerFormType.PrintCollector;
        }

        private void MagazineWalletsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrintMagazineWallets myForm = new FormPrintMagazineWallets();
            myForm.Show();
        }

        private void AdjustStockLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.formFindListener.Show();
            My.MyProject.Forms.formFindListener.theType = FormFindListener.FindListenerFormType.AdjustStock;
        }

        private void WalletsStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormPrintWalletStock();
            var stock = serviceLayer.GetListeners()
                .Select(x => new StockItem
                {
                    Wallet = x.Wallet,
                    Stock = x.Status == ListenerStates.DELETED ? "X" : x.Stock.ToString()
                })
                .OrderBy(x => x.Wallet)
                .ToList();

            form.Setup("News Wallet Stock", stock);
            form.Show();
        }

        private void MagazineWalletStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormPrintWalletStock();
            var stock = serviceLayer.GetListeners()
                .Select(x => new StockItem
                {
                    Wallet = x.Wallet,
                    Stock = x.Status == ListenerStates.DELETED || !x.Magazine ? "X" : x.MagazineStock.ToString()
                })
                .OrderBy(x => x.Wallet)
                .ToList();

            form.Setup("Magazine Wallet Stock", stock);
            form.Show();
        }

        private void BtnMagScanIn_Click(object sender, EventArgs e)
        {
            ScanIn(WalletTypes.Magazine);
        }

        private void BtnMagScanOut_Click(object sender, EventArgs e)
        {
            ScanOut(WalletTypes.Magazine);
        }

        private void ScanIn(WalletTypes walletType)
        {
            var magazineWallets = serviceLayer.GetListenersByStatus(ListenerStates.ACTIVE)
                .Where(x => x.Magazine)
                .Select(x => x.Wallet)
                .ToList();
            var stoppedListeners = serviceLayer.GetStoppedListeners().Select(x => x.Wallet);

            var scanForm = new MagazinesScanInForm();
            scanForm.Setup("Magazine Scan In", ScanTypes.IN, walletType, magazineWallets, stoppedListeners);

            if (scanForm.ShowDialog() == DialogResult.OK)
            {
                SaveScans(scanForm.Scans);

                if (scanForm.ShouldScanOut)
                {
                    var walletsToScanOut = scanForm.Scans
                        .Where(x => magazineWallets.Contains(x.Wallet))
                        .Select(x => x.Wallet)
                        .Distinct();

                    ScanOut(walletType, walletsToScanOut);
                }
            }
        }

        private void ScanOut(WalletTypes walletType, IEnumerable<int> scanned = null)
        {
            var listeners = serviceLayer.GetListenersByStatus(ListenerStates.ACTIVE);
            var toScan = listeners.Where(x => x.Magazine && (scanned == null || !scanned.Contains(x.Wallet))).Select(x => x.Wallet);
            var stoppedListeners = serviceLayer.GetStoppedListeners().Select(x => x.Wallet);

            var scanForm = new MagazinesScanOutForm();
            scanForm.Setup("Magazine Scan Out", walletType, toScan, scanned, stoppedListeners);

            if (scanForm.ShowDialog() == DialogResult.OK)
            {
                SaveScans(scanForm.Scans);
            }
        }

        private void SaveScans(IEnumerable<Scan> scans)
        {
            if (scans.Any())
            {
                var scanService = Program.ServiceProvider.GetService<ScanService>();
                scanService.AddScans(scans);
            }
        }
    }
}
