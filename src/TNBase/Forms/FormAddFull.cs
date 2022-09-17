using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using TNBase.Objects;
using NLog;
using TNBase.DataStorage;
using System.Globalization;
using TNBase.Infrastructure.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace TNBase
{
    public partial class FormAddFull
    {
        private Logger log = LogManager.GetCurrentClassLogger();
        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();
        private string title;
        private string surname;
        private string forename;
        private bool withSetup;
        private bool allowClose;
        private bool preventClose;

        public void Setup(string title, string surname, string forename)
        {
            this.title = title;
            this.surname = surname;
            this.forename = forename;
            withSetup = true;
        }

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                preventClose = true;
                return;
            }

            var newListener = new Listener
            {
                Wallet = 0,
                Title = comboTitle.Text,
                Forename = txtForename.Text,
                Surname = txtSurname.Text,
                Addr1 = txtAddr1.Text,
                Addr2 = txtAddr2.Text,
                Town = txtTown.Text,
                County = txtCounty.Text,
                Postcode = txtPostcode.Text,
                MemStickPlayer = chkTape.Checked && !chkOnlineOnly.Checked,
                Magazine = chkMagazine.Checked && !chkOnlineOnly.Checked,
                MagazineStock = chkMagazine.Checked && !chkOnlineOnly.Checked ? 1 : 0,
                OnlineOnly = chkOnlineOnly.Checked,
                Info = txtInformation.Text,
                Telephone = string.IsNullOrEmpty(txtTelephone.Text) ? "0" : txtTelephone.Text,
                Status = ListenerStates.ACTIVE,
                StatusInfo = "",
                DeletedDate = DateTime.Now,
                Joined = DateTime.Now,
                InOutRecords = new InOutRecords()
            };

            if (chkNoBirthday.Checked)
            {
                newListener.BirthdayDay = null;
                newListener.BirthdayMonth = null;
            }
            else
            {
                newListener.BirthdayDay = cbxBirthdayDay.SelectedIndex + 1;
                newListener.BirthdayMonth = cbxBirthdayMonth.SelectedIndex + 1;
            }

            var result = serviceLayer.AddListener(newListener);
            if (result > 0)
            {
                log.Debug("Listener has been added. ID: " + result + ", Name: " + newListener.GetNiceName());
                Interaction.MsgBox("The listener has successfully been added.");

                var newListenerWithWalletNo = serviceLayer.GetListenerById(result);

                if (!newListener.OnlineOnly)
                {
                    PrintLabels(newListenerWithWalletNo);
                    PrintMemoryStickForm(newListenerWithWalletNo);
                }
            }
            else
            {
                log.Error("Failed to add new listener!");
                Interaction.MsgBox("Failed to add new listener!");
            }

            allowClose = true;
        }

        private void PrintMemoryStickForm(Listener listener)
        {
            if (listener.MemStickPlayer)
            {
                Interaction.MsgBox("Please print the following form as listener requires a memory stick player.");
                var form = new FormPrintCollectionForm();
                form.Show();
                form.SetupForm(listener, false);
            }
        }

        private void PrintLabels(Listener listener)
        {
            var msgResult = MessageBox.Show("Would you like to print labels for the new listener?", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
            if (msgResult == DialogResult.Yes)
            {
                var form = new FormChoosePrintPoint();
                form.SetupForm(listener);
                form.ShowDialog();
            }
        }

        public FormAddFull()
        {
            InitializeComponent();

            AddBirthdayDays();
            AddBirthdayMonths();
        }

        private void AddBirthdayDays()
        {
            for (int i = 1; i <= 31; i++)
            {
                cbxBirthdayDay.Items.Add(i);
            }
            cbxBirthdayDay.SelectedIndex = 0;
        }

        private void AddBirthdayMonths()
        {
            for (int i = 1; i <= 12; i++)
            {
                cbxBirthdayMonth.Items.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i));
            }
            cbxBirthdayMonth.SelectedIndex = 0;
        }

        private void FormAddFull_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (allowClose)
            {
                return;
            }

            if (preventClose)
            {
                e.Cancel = true;
                return;
            }

            var result = MessageBox.Show("Are you sure you wish to cancel?" + Environment.NewLine + Environment.NewLine + "Press [y] to confirm, [n] to cancel.", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void chkNoBirthday_CheckedChanged(object sender, EventArgs e)
        {
            cbxBirthdayDay.Enabled = !chkNoBirthday.Checked;
            cbxBirthdayMonth.Enabled = !chkNoBirthday.Checked;
        }

        private void FormAddFull_Load(object sender, EventArgs e)
        {
            comboTitle.Items.AddRange(ListenerTitles.GetAllTitles().ToArray());
            if (title != null)
            {
                comboTitle.Text = title;
            }

            txtSurname.Text = surname;
            txtForename.Text = forename;

            if (withSetup)
            {
                ActiveControl = txtAddr1;
            }
        }

        private void cbxBirthdayDay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !ValidateBirthday();
        }

        private void cbxBirthdayMonth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !ValidateBirthday();
        }

        private void chkNoBirthday_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !ValidateBirthday();
        }

        private bool ValidateBirthday()
        {
            if (!chkNoBirthday.Checked)
            {
                if (cbxBirthdayDay.SelectedIndex < 0 || cbxBirthdayMonth.SelectedIndex < 0)
                {
                    errorProvider.SetError(cbxBirthdayMonth, "Birthday value is required");
                    return false;
                }

                if (cbxBirthdayDay.SelectedIndex + 1 > DateHelpers.GetDaysInMonth(cbxBirthdayMonth.SelectedIndex + 1))
                {
                    errorProvider.SetError(cbxBirthdayMonth, "Birthday value is not valid");
                    return false;
                }
            }
            return true;
        }

        private void chkOnlineOnly_CheckedChanged(object sender, EventArgs e)
        {
            chkTape.Enabled = !chkOnlineOnly.Checked;
            chkMagazine.Enabled = !chkOnlineOnly.Checked;
        }
    }
}
