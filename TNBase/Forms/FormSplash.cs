using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TNBase.DataStorage;
using TNBase.Objects;

namespace TNBase
{
    public partial class FormSplash
    {
        private Logger log = LogManager.GetCurrentClassLogger();
        private IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

        // Default to false.
        private bool readyToProgress = false;

        public FormSplash()
        {
            Load += FormSplash_Load;
            InitializeComponent();
        }

        private void FormSplash_Load(object sender, EventArgs e)
        {
            log.Info("Starting...");

            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new ThreadExceptionEventHandler(ExceptionHandler.AppDomain_Application_ThreadException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandler.AppDomain_CurrentDomain_UnhandledException);

            progressBar.Value = 0;

            // Check database exists.            
            if (serviceLayer.IsConnected())
            {
                progressBar.Value = 10;
            }
            else
            {
                // No point continuing without a database.
                MessageBox.Show("Could not find database file", ModuleGeneric.getAppShortName(), MessageBoxButtons.OK);
                log.Fatal("Could not find database file.");
                this.Close();
            }

            // Back it up!!
            List<DriveInfo> drives = DriveInfo.GetDrives().ToList();

            Boolean found = false;
            String path = "";
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
                    if (!DBUtils.CopyDatabase(ModuleGeneric.GetDatabasePath(), fullbackuppath))
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

            ModuleGeneric.saveStartTime();
            progressBar.Value = 15;

            ModuleGeneric.UpdateDatabase();
            progressBar.Value = 25;

            if ((ModuleSounds.CheckResourcesFolder()))
            {
                progressBar.Value = 30;
            }
            else
            {
                MessageBox.Show("Could not find resources folder. Please check the resouces folder exists at: " + ModuleSounds.GetResourcesFolder(), ModuleGeneric.getAppShortName(), MessageBoxButtons.OK);
                log.Fatal("Could not find resources folder.");
                this.Close();
            }

            //Resume paused listeners.
            serviceLayer.ResumePausedListeners();
            progressBar.Value = 40;

            // Do yearly stats.
            serviceLayer.UpdateYearStatsInternal();
            progressBar.Value = 60;

            // Delete overdue listeners.
            serviceLayer.DeleteOverdueDeletedListeners(Settings.Default.MonthsUntilDelete);
            progressBar.Value = 80;

            // Delete any deleted dates for non deleted listeners!
            serviceLayer.CleanDeletedDates();
            progressBar.Value = 90;

            // Cleanup dates.
            serviceLayer.CleanUpDates();
            serviceLayer.CleanUpTitles();

            // Create dummy data if required?
            if (Settings.Default.CreateDummyData)
            {
                AddDummyData();
            }

            // Clear years (for old birthdays)
            serviceLayer.RunCommand("UPDATE Listeners SET Birthday = '" + DateTime.Now.Year + "' || SUBSTR(Birthday, 5);");

            progressBar.Value = 100;
            log.Debug("Finished loading!");

            // Progress
            ProgressToMainForm();
        }

        private void ProgressToMainForm()
        {
            // Progress on the second call (either after 1 second or whenever database processing is complete).
            if (readyToProgress)
            {
                My.MyProject.Forms.formMain.Show();
                this.Close();
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

        private void AddDummyData()
        {
            if (serviceLayer.GetListeners().Count > 0)
            {
                log.Warn("Dummy data was enabled but there are already listeners in the database!");
                return;
            }

            serviceLayer.AddListener(new Listener()
            {
                Wallet = 1,
                Title = "Mr",
                Forename = "Fred",
                Surname = "Jones",

                Addr1 = "201 London Road",
                Addr2 = "Borough",
                Town = "London",
                County = "County",
                Postcode = "SW145AD",
                Telephone = "02222 333444"
            });

            serviceLayer.AddListener(new Listener()
            {
                Wallet = 2,
                Title = "Miss",
                Forename = "Sarah",
                Surname = "Jane",

                Addr1 = "202 South End",
                Addr2 = "South Road",
                Town = "Southway",
                County = "County",
                Postcode = "SO145BB",
                Telephone = "01122 334455"
            });

            Listener paused = new Listener()
            {
                Wallet = 3,
                Title = "Mrs",
                Forename = "Inactive",
                Surname = "Listener",

                Addr1 = "100 Inactive Listener",
                Addr2 = "",
                Town = "Inactivity",
                County = "Incounty",
                Postcode = "IN88 6DD",
                Telephone = "02555 555666"
            };
            paused.Pause(DateTime.Now.AddDays(-1));
            serviceLayer.AddListener(paused);

            serviceLayer.AddListener(new Listener()
            {
                Wallet = 4,
                Title = "Mr",
                Forename = "Fred",
                Surname = "Another",

                Addr1 = "1 Road House",
                Addr2 = "Rock Street",
                Town = "Tuktuk",
                County = "County",
                Postcode = "NA345HH",
                Telephone = "01234 777555"
            });
        }
    }
}
