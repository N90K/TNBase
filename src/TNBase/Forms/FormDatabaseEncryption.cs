using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace TNBase.Forms
{
    public partial class FormDatabaseEncryption : Form
    {
        private DatabaseManager dbManager = Program.ServiceProvider.GetService<DatabaseManager>();

        public FormDatabaseEncryption()
        {
            InitializeComponent();
        }

        private void FormDatabaseEncryption_Load(object sender, System.EventArgs e)
        {
            RefreshForm();
        }

        private void btnSetEncryption_Click(object sender, System.EventArgs e)
        {
            var form = new FormSetDatabasePassword();
            if (form.ShowDialog() == DialogResult.OK)
            {
                dbManager.EncryptDatabase(form.Password);
                RefreshForm();
            }
        }

        private void RefreshForm()
        {
            if (dbManager.Database.IsEncrypted)
            {
                lblState.Text = "Database is encrypted";
                btnSetEncryption.Text = "Change Password";
            }
            else
            {
                lblState.Text = "Database is currently NOT encrypted";
                btnSetEncryption.Text = "Set Encryption";
            }
        }
    }
}
