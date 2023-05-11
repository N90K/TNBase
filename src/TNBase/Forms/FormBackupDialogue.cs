using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;

namespace TNBase.Forms
{
    public partial class FormBackupDialogue : Form
    {
        private string password;

        public FormBackupDialogue()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = "Listeners.s3db";
            dialog.Title = "Backup Listener Database";
            dialog.Filter = "SQLite Database Files|*.s3db";
            dialog.CheckPathExists = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbxFilePath.Text = dialog.FileName;
            }
        }

        private void rdbSamePassword_CheckedChanged(object sender, EventArgs e)
        {
            btnSetPassword.Enabled = false;
        }

        private void rdbNewPassword_CheckedChanged(object sender, EventArgs e)
        {
            btnSetPassword.Enabled = true;
        }

        private void btnSetPassword_Click(object sender, EventArgs e)
        {
            var form = new FormSetDatabasePassword();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                password = form.Password;
            }
            else
            {
                password = "";
            }
        }

        private void FormBackupDialogue_Load(object sender, EventArgs e)
        {
            tbxFilePath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Listeners.s3db");
            rdbSamePassword.Checked = true;
            btnSetPassword.Enabled = false;
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            var databaseManager = Program.ServiceProvider.GetService<DatabaseManager>();

            bool success;
            if (rdbNewPassword.Checked)
            {
                success = databaseManager.BackupDatabase(tbxFilePath.Text, password);
            }
            else
            {
                success = databaseManager.BackupDatabase(tbxFilePath.Text);
            }

            if (success)
            {
                Interaction.MsgBox("Database backup completed successfully.");
            }
            else
            {
                Interaction.MsgBox("Error: Database was not copied correctly!");
            }
        }
    }
}
