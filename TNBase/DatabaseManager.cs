using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TNBase.DataStorage;

namespace TNBase
{
    public class DatabaseManager
    {
        private readonly DatabaseManagerOptions options;
        static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public DatabaseManager(DatabaseManagerOptions options)
        {
            this.options = options;
        }

        public void BackupDatabase()
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
                        path = drive.RootDirectory.ToString() + Application.ProductName + "\\backups\\";
                        Directory.CreateDirectory(path);

                        if (drive.AvailableFreeSpace < (Settings.Default.BackupMBSpaceWarning * 1000000))
                        {
                            MessageBox.Show("Warning: Low space available on backup drive: " + Settings.Default.BackupDrive, Application.ProductName, MessageBoxButtons.OK);
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
                    String fullbackuppath = path + Application.ProductName + "_backup_" + DateTime.Now.ToString("dd-MM-yyyy") + ".bak";
                    if (!DBUtils.CopyDatabase(options.DatabasePath, fullbackuppath))
                    {
                        MessageBox.Show("Warning: Could not backup database: " + Settings.Default.BackupDrive, Application.ProductName, MessageBoxButtons.OK);
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
                MessageBox.Show("Warning: Could not find the backup drive: " + Settings.Default.BackupDrive, Application.ProductName, MessageBoxButtons.OK);
                log.Warn("Could not find resources folder.");
            }
        }
    }

    public class DatabaseManagerOptions
    {
        public string DatabasePath { get; set; }
    }
}
