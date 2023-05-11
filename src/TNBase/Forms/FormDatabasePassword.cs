using System;
using System.Windows.Forms;

namespace TNBase.Forms
{
    public partial class FormDatabasePassword : Form
    {
        public FormDatabasePassword()
        {
            InitializeComponent();
        }

        public string Password { get; internal set; }

        private void FormSetDatabaseEncryptionKey_Load(object sender, EventArgs e)
        {
            ActiveControl = tbxPassword;
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            Password = tbxPassword.Text;
        }
    }
}
