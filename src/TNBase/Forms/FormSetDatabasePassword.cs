using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TNBase.Forms
{
    public partial class FormSetDatabasePassword : Form
    {
        private bool preventClose;

        public string Password { get; internal set; }

        public FormSetDatabasePassword()
        {
            InitializeComponent();
        }

        private void btnSetPassword_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                preventClose = true;
                return;
            }

            Password = tbxPassword.Text;
            preventClose = false;
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            var score = CalculatePasswordStrength(tbxPassword.Text);
            switch (score)
            {
                case PasswordScore.Blank:
                    lblPasswordStrength.Text = "";
                    btnSetPassword.Enabled = true;
                    break;
                case PasswordScore.VeryWeak:
                    lblPasswordStrength.Text = "Password is too weak. Use upper and lower case letters as well as digits and special characters.";
                    lblPasswordStrength.ForeColor = Color.Firebrick;
                    btnSetPassword.Enabled = false;
                    break;
                case PasswordScore.Weak:
                    lblPasswordStrength.Text = "Password is too weak. Use upper and lower case letters as well as digits and special characters.";
                    lblPasswordStrength.ForeColor = Color.Firebrick;
                    btnSetPassword.Enabled = false;
                    break;
                case PasswordScore.Medium:
                    lblPasswordStrength.Text = "Password is too weak. Please use upper and lower cases as well as digits and special characters.";
                    lblPasswordStrength.ForeColor = Color.Firebrick;
                    btnSetPassword.Enabled = false;
                    break;
                case PasswordScore.Strong:
                    lblPasswordStrength.Text = "Password could be stronger.";
                    lblPasswordStrength.ForeColor = Color.Orange;
                    btnSetPassword.Enabled = true;
                    break;
                case PasswordScore.VeryStrong:
                    lblPasswordStrength.Text = "Perfect! Your password is strong.";
                    lblPasswordStrength.ForeColor = Color.DarkGreen;
                    btnSetPassword.Enabled = true;
                    break;
                default:
                    lblPasswordStrength.Text = "";
                    btnSetPassword.Enabled = false;
                    break;
            }
        }

        private PasswordScore CalculatePasswordStrength(string password)
        {
            int score = 1;
            if (password.Length < 1)
                return PasswordScore.Blank;
            if (password.Length < 10)
                return PasswordScore.VeryWeak;

            if (password.Length >= 12)
                score++;
            if (password.Length >= 18)
                score++;
            if (Regex.IsMatch(password, @"[0-9]+(\.[0-9][0-9]?)?", RegexOptions.ECMAScript))   //number only //"^\d+$" if you need to match more than one digit.
                score++;
            if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).+$", RegexOptions.ECMAScript)) //both, lower and upper case
                score++;
            if (Regex.IsMatch(password, @"[!,@,#,$,%,^,&,*,?,_, ,~,-,£,(,)]", RegexOptions.ECMAScript)) //^[A-Z]+$
                score++;
            return (PasswordScore)score;
        }

        private void FormSetDatabasePassword_Load(object sender, EventArgs e)
        {
            lblPasswordStrength.Text = "";
            ActiveControl = tbxPassword;
        }

        enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }

        private void tbxConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbxPassword.Text.Equals(tbxConfimPassword.Text, StringComparison.InvariantCulture))
            {
                errorProvider.SetError(tbxConfimPassword, "");
            }
            else
            {
                errorProvider.SetError(tbxConfimPassword, "Passwords do not match.");
                e.Cancel = true;
            }
        }

        private void FormSetDatabasePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (preventClose)
            {
                e.Cancel = true;
            }
        }
    }
}
