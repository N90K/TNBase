using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TNBase.DataStorage;

namespace TNBase
{
    public partial class FormSplash
    {
        private readonly Logger log = LogManager.GetCurrentClassLogger();
        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();

        private bool readyToProgress;

        public FormSplash()
        {
            Load += FormSplash_Load;
            InitializeComponent();
        }

        private void FormSplash_Load(object sender, EventArgs e)
        {
            log.Info("Starting...");

            Application.ThreadException += new ThreadExceptionEventHandler(ExceptionHandler.AppDomain_Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandler.AppDomain_CurrentDomain_UnhandledException);

            progressBar.Value = 0;

            //if (!serviceLayer.IsConnected())
            //{
            //    MessageBox.Show("Could not find database file", ModuleGeneric.getAppShortName(), MessageBoxButtons.OK);
            //    log.Fatal("Could not find database file.");
            //    Close();
            //}

            progressBar.Value = 10;

            BackupDatabase();

            ModuleGeneric.SaveStartTime();
            progressBar.Value = 15;

            var databasePath = "//"; //ModuleGeneric.GetDatabasePath();
            var context = new Repository.TNBaseContext($"Data Source={databasePath}");
            context.UpdateDatabase();

            progressBar.Value = 25;

            if (!ModuleSounds.CheckResourcesFolder())
            {
                MessageBox.Show("Could not find resources folder. Please check the resouces folder exists at: " + ModuleSounds.GetResourcesFolder(), ModuleGeneric.getAppShortName(), MessageBoxButtons.OK);
                log.Fatal("Could not find resources folder.");
                Close();
            }

            progressBar.Value = 30;

            serviceLayer.ResumePausedListeners();
            progressBar.Value = 40;

            serviceLayer.UpdateYearStatsInternal();
            progressBar.Value = 60;

            serviceLayer.DeleteOverdueDeletedListeners(Settings.Default.MonthsUntilDelete);
            progressBar.Value = 100;
            log.Debug("Finished loading!");

            // Progress
            ProgressToMainForm();
        }

        private void BackupDatabase()
        {
            var drives = DriveInfo.GetDrives().ToList();

            bool found = false;
            string path = "";
            foreach (DriveInfo drive in drives)
            {
                try
                {
                    if (drive.VolumeLabel.Equals(Settings.Default.BackupDrive) || drive.Name.Equals(Settings.Default.BackupDrive))
                    {
                        path = drive.RootDirectory.ToString() + ModuleGeneric.getAppShortName() + "\\backups\\";
                        Directory.CreateDirectory(path);

                        if (drive.AvailableFreeSpace < (Settings.Default.BackupMBSpaceWarning * 1000000))
                        {
                            MessageBox.Show("Warning: Low space available on backup drive: " + Settings.Default.BackupDrive, ModuleGeneric.getAppShortName(), MessageBoxButtons.OK);
                            log.Warn("Warning: Low space available on backup drive: " + Settings.Default.BackupDrive);
                        }

                        found = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    log.Trace(ex, "Error loading drive labels: ");
                }
            }

            if (found)
            {
                try
                {
                    String fullbackuppath = path + ModuleGeneric.getAppShortName() + "_backup_" + DateTime.Now.ToString("dd-MM-yyyy") + ".bak";
                    if (!DBUtils.CopyDatabase("ModuleGeneric.GetDatabasePath()", fullbackuppath))
                    {
                        MessageBox.Show("Warning: Could not backup database: " + Settings.Default.BackupDrive, ModuleGeneric.getAppShortName(), MessageBoxButtons.OK);
                        log.Warn("Could not backup database: " + fullbackuppath);
                    }
                    else
                    {
                        log.Info("Backed up database to: " + fullbackuppath);
                    }
                }
                catch (Exception ey)
                {
                    log.Warn(ey, "Could not backup database.");
                }
            }
            else
            {
                MessageBox.Show("Warning: Could not find the backup drive: " + Settings.Default.BackupDrive, ModuleGeneric.getAppShortName(), MessageBoxButtons.OK);
                log.Warn("Could not find resources folder.");
            }
        }

        private void ProgressToMainForm()
        {
            // Progress on the second call (either after 1 second or whenever database processing is complete).
            if (readyToProgress)
            {
                var form = new FormMain();
                form.Show();
               // this.Close();
            }
            else
            {
                readyToProgress = true;
            }
        }

        // Don't progress too fast, we need visual feedback.
        private void TimerProgress_Tick(object sender, EventArgs e)
        {
            timerProgress.Stop();
            ProgressToMainForm();
        }
    }
}
