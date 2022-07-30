using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using TNBase.Objects;
using TNBase.DataStorage;
using System.Globalization;
using TNBase.Infrastructure.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace TNBase
{
    public partial class FormEdit
    {
        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();

        private int listenerWalletNo = 0;
        private Listener myListener;

        private bool restored = false;

        public static FormEdit Create(Listener listener)
        {
            return new FormEdit().Setup(listener);
        }

        public FormEdit Setup(Listener listener)
        {
            if (listener != null)
            {
                comboTitle.Text = listener.Title;
                txtForename.Text = listener.Forename;
                txtSurname.Text = listener.Surname;
                txtAddr1.Text = listener.Addr1;
                txtAddr2.Text = listener.Addr2;
                txtTown.Text = listener.Town;
                txtCounty.Text = listener.County;
                txtPostcode.Text = listener.Postcode;
                chkWarnOfAddressChange.Checked = listener.WarnOfAddressChange;
                txtTelephone.Text = listener.Telephone;
                txtStock.Text = listener.Stock.ToString();
                chkMagazine.Checked = listener.Magazine;
                chkOnlineOnly.Checked = listener.OnlineOnly;
                txtMagazineStock.Enabled = chkMagazine.Checked;
                chkMemStickPlayer.Checked = listener.MemStickPlayer;
                listenerWalletNo = listener.Wallet;
                lblWallet.Text = listenerWalletNo.ToString();
                lblStatus.Text = listener.Status.ToString();

                if (listener.HasBirthday)
                {
                    cbBirthdayDay.SelectedIndex = listener.BirthdayDay.Value - 1;
                    cbBirthdayMonth.SelectedIndex = listener.BirthdayMonth.Value - 1;

                    chkNoBirthday.Checked = false;
                    cbBirthdayDay.Enabled = true;
                    cbBirthdayMonth.Enabled = true;
                }
                else
                {
                    cbBirthdayDay.SelectedIndex = -1;
                    cbBirthdayMonth.SelectedIndex = -1;

                    cbBirthdayDay.Enabled = false;
                    cbBirthdayMonth.Enabled = false;
                    chkNoBirthday.Checked = true;
                }

                dtpJoined.Value = listener.Joined.HasValue ? listener.Joined.Value.EnsureMinDate() : DateTime.MinValue.EnsureMinDate();
                dtpJoined.Enabled = false;

                if (lblStatus.Text.Equals(ListenerStates.ACTIVE.ToString()))
                {
                    lblStatus.ForeColor = Color.Green;
                    lblExtra.Text = "";
                    lblExtraContent.Text = "";
                    btnRestore.Visible = false;
                }
                else if (lblStatus.Text.Equals(ListenerStates.DELETED.ToString()))
                {
                    lblStatus.ForeColor = Color.Red;
                    lblExtra.Text = "Reason:";
                    lblExtraContent.ForeColor = Color.Red;
                    lblExtraContent.Text = listener.StatusInfo;

                    // Just incase it doesnt have a value
                    string dateString = listener.DeletedDate.HasValue ? listener.DeletedDate.Value.ToNiceStr() : "??/??/????";
                    lblStatus.Text = lblStatus.Text + " on " + dateString;

                    btnRestore.Visible = true;
                }
                else if (lblStatus.Text.Equals(ListenerStates.PAUSED.ToString()))
                {
                    lblStatus.ForeColor = Color.Gray;
                    lblExtra.Text = "Duration:";
                    lblExtraContent.ForeColor = Color.Gray;
                    lblExtraContent.Text = listener.GetStoppedDate().ToNiceStr() + " to " + listener.GetResumeDateString();
                    btnRestore.Visible = false;
                }

                txtInformation.Text = listener.Info;
                txtStock.Text = listener.Stock.ToString();
                txtMagazineStock.Text = listener.MagazineStock.ToString();

                // Display or hide the last in value 
                if (listener.LastIn.HasValue)
                {
                    DateLastIn.Value = listener.LastIn.Value;
                    DateLastIn.Show();
                }
                else
                {
                    DateLastIn.Hide();
                }

                // Display or hide the last out value 
                if (listener.LastOut.HasValue)
                {
                    DateLastOut.Value = listener.LastOut.Value;
                    DateLastOut.Show();
                }
                else
                {
                    DateLastOut.Hide();
                }

                myListener = listener;
                populateTable(listener);
            }
            // Update the headers.
            updateEditHeaders();

            // Set the date changed bool to false
            restored = false;

            return this;
        }

        // Populate the in/out table.
        private void populateTable(Listener theListener)
        {
            lstInOut.Items.Clear();

            string[] arr = new string[10];
            ListViewItem itm = null;

            //Add first item
            arr[0] = "OUT";
            arr[1] = theListener.InOutRecords.Out1.ToString();
            arr[2] = theListener.InOutRecords.Out2.ToString();
            arr[3] = theListener.InOutRecords.Out3.ToString();
            arr[4] = theListener.InOutRecords.Out4.ToString();
            arr[5] = theListener.InOutRecords.Out5.ToString();
            arr[6] = theListener.InOutRecords.Out6.ToString();
            arr[7] = theListener.InOutRecords.Out7.ToString();
            arr[8] = theListener.InOutRecords.Out8.ToString();

            itm = new ListViewItem(arr);
            lstInOut.Items.Add(itm);

            //Add first item
            arr[0] = "IN";
            arr[1] = theListener.InOutRecords.In1.ToString();
            arr[2] = theListener.InOutRecords.In2.ToString();
            arr[3] = theListener.InOutRecords.In3.ToString();
            arr[4] = theListener.InOutRecords.In4.ToString();
            arr[5] = theListener.InOutRecords.In5.ToString();
            arr[6] = theListener.InOutRecords.In6.ToString();
            arr[7] = theListener.InOutRecords.In7.ToString();
            arr[8] = theListener.InOutRecords.In8.ToString();

            itm = new ListViewItem(arr);
            lstInOut.Items.Add(itm);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Confirm we really want to cancel.
            DialogResult result = MessageBox.Show("Are you sure you wish to cancel?" + Environment.NewLine + Environment.NewLine + "Press [y] to confirm, [n] to cancel.", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            bool addrChanged = HasAddressChanged();
            bool nameChanged = HasNameChanged();
            bool updated = HasUpdated();

            if (!ValidateChildren())
            {
                return;
            }

            // Only if they are updated...
            if (updated)
            {
                myListener.Title = comboTitle.Text;
                myListener.Forename = txtForename.Text;
                myListener.Surname = txtSurname.Text;
                myListener.Addr1 = txtAddr1.Text;
                myListener.Addr2 = txtAddr2.Text;
                myListener.Town = txtTown.Text;
                myListener.County = txtCounty.Text;
                myListener.Postcode = txtPostcode.Text;
                myListener.WarnOfAddressChange = chkWarnOfAddressChange.Checked;
                myListener.OnlineOnly = chkOnlineOnly.Checked;
                myListener.MemStickPlayer = chkMemStickPlayer.Checked;
                myListener.Magazine = chkMagazine.Checked;
                myListener.Info = txtInformation.Text;
                if (!string.IsNullOrEmpty(txtTelephone.Text))
                {
                    myListener.Telephone = txtTelephone.Text;
                }
                else
                {
                    myListener.Telephone = "0";
                }
                if (!string.IsNullOrEmpty(txtStock.Text))
                {
                    myListener.Stock = int.Parse(txtStock.Text);
                }

                if (!string.IsNullOrEmpty(txtMagazineStock.Text) && chkMagazine.Checked)
                {
                    myListener.MagazineStock = int.Parse(txtMagazineStock.Text);
                }

                if (chkNoBirthday.Checked)
                {
                    myListener.BirthdayDay = null;
                    myListener.BirthdayMonth = null;
                }
                else
                {
                    myListener.BirthdayDay = cbBirthdayDay.SelectedIndex + 1;
                    myListener.BirthdayMonth = cbBirthdayMonth.SelectedIndex + 1;
                }

                if (chkOnlineOnly.Checked && myListener.Status == ListenerStates.PAUSED)
                {
                    myListener.Resume();
                }

                serviceLayer.UpdateListener(myListener);
                Interaction.MsgBox("The listener has successfully been updated.");

                if (addrChanged || nameChanged)
                {
                    // Show prompt.
                    DialogResult result = MessageBox.Show("Would you like to print new address labels for the updated address?", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        My.MyProject.Forms.formChoosePrintPoint.Show();
                        My.MyProject.Forms.formChoosePrintPoint.SetupForm(serviceLayer.GetListenerById(listenerWalletNo));
                    }
                }
            }
            this.Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            myListener.Restore();

            lblStatus.ForeColor = Color.Green;
            lblExtra.Text = "";
            lblExtraContent.Text = "";
            lblStatus.Text = ListenerStates.ACTIVE.ToString();
            btnRestore.Visible = false;

            restored = true;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            Listener theListener = serviceLayer.GetListeners().First();
            Setup(theListener);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Listener theListener = serviceLayer.GetListeners().Last();
            Setup(theListener);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Listener theListener = serviceLayer.GetNextListener(serviceLayer.GetListenerById(listenerWalletNo));
            Setup(theListener);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            Listener theListener = serviceLayer.GetPreviousListener(serviceLayer.GetListenerById(listenerWalletNo));
            Setup(theListener);
        }

        private bool HasAddressChanged()
        {
            // Its true if any of these things have changed (i.e. they are not all equal)
            return !(txtAddr1.Text.Equals(myListener.Addr1)
                    && txtAddr2.Text.Equals(myListener.Addr2)
                    && txtTown.Text.Equals(myListener.Town)
                    && txtCounty.Text.Equals(myListener.County)
                    && txtPostcode.Text.Equals(myListener.Postcode));
        }

        private bool HasNameChanged()
        {
            string selectedItem = comboTitle.SelectedItem == null ? "" : comboTitle.SelectedItem.ToString();

            return !(selectedItem.Equals(myListener.Title)
                    && txtSurname.Text.Equals(myListener.Surname)
                    && txtForename.Text.Equals(myListener.Forename));
        }

        private bool HasUpdated()
        {
            string selectedItem = comboTitle.SelectedItem == null ? "" : comboTitle.SelectedItem.ToString();

            return HasAddressChanged() ||
                    HasBirthdayChanged() ||
                    !selectedItem.Equals(myListener.Title) ||
                    !txtForename.Text.Equals(myListener.Forename) ||
                    !txtSurname.Text.Equals(myListener.Surname) ||
                    !txtInformation.Text.Equals(myListener.Info) ||
                    !txtTelephone.Text.Equals(myListener.Telephone) ||
                    !chkMagazine.Checked.Equals(myListener.Magazine) ||
                    !chkMemStickPlayer.Checked.Equals(myListener.MemStickPlayer) ||
                    !chkOnlineOnly.Checked.Equals(myListener.OnlineOnly) ||
                    restored ||
                    !int.Parse(txtStock.Text).Equals(myListener.Stock) ||
                    !int.Parse(txtMagazineStock.Text).Equals(myListener.MagazineStock) ||
                    !chkWarnOfAddressChange.Checked.Equals(myListener.WarnOfAddressChange);
        }

        private bool HasBirthdayChanged()
        {
            return chkNoBirthday.Checked == myListener.HasBirthday ||
                (!myListener.BirthdayDay.HasValue && cbBirthdayDay.SelectedIndex >= 0) ||
                (!myListener.BirthdayMonth.HasValue && cbBirthdayMonth.SelectedIndex >= 0) ||
                (myListener.BirthdayDay.HasValue && cbBirthdayDay.SelectedIndex != myListener.BirthdayDay - 1) ||
                (myListener.BirthdayMonth.HasValue && cbBirthdayMonth.SelectedIndex != myListener.BirthdayMonth - 1);
        }

        private void updateEditHeaders()
        {
            for (int week = 0; week < 8; week++)
            {
                lstInOut.Columns[8 - week].Text = ISOWeek.GetWeekOfYear(DateTime.UtcNow.AddDays(week * -7)).ToString();
            }
        }

        public FormEdit()
        {
            InitializeComponent();

            comboTitle.Items.AddRange(ListenerTitles.GetAllTitles().ToArray());
            cbBirthdayDay.Items.AddRange(Enumerable.Range(1, 31).Select(x => x.ToString()).ToArray());
            cbBirthdayMonth.Items.AddRange(Enumerable.Range(1, 12).Select(x => DateTimeFormatInfo.CurrentInfo.GetMonthName(x)).ToArray());
            toolTip.SetToolTip(chkWarnOfAddressChange, "Notify user when scanning wallets that the wallet address has changed");
        }

        private void chkNoBirthday_CheckedChanged(object sender, EventArgs e)
        {
            cbBirthdayDay.Enabled = !chkNoBirthday.Checked;
            cbBirthdayMonth.Enabled = !chkNoBirthday.Checked;
        }

        private void chkMagazine_CheckedChanged(object sender, EventArgs e)
        {
            txtMagazineStock.Enabled = chkMagazine.Checked;
        }

        private void cbBirthdayMonth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !ValidateBirthday();
        }

        private void cbBirthdayDay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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
                if (cbBirthdayDay.SelectedIndex < 0 || cbBirthdayMonth.SelectedIndex < 0)
                {
                    errorProvider.SetError(cbBirthdayMonth, "Birthday value is required");
                    return false;
                }

                if (cbBirthdayDay.SelectedIndex + 1 > DateHelpers.GetDaysInMonth(cbBirthdayMonth.SelectedIndex + 1))
                {
                    errorProvider.SetError(cbBirthdayMonth, "Birthday value is not valid");
                    return false;
                }
            }
            return true;
        }

        private void chkOnlineOnly_CheckedChanged(object sender, EventArgs e)
        {
            stockGroup.Enabled = !chkOnlineOnly.Checked;
            if (chkOnlineOnly.Checked && myListener?.Status == ListenerStates.PAUSED)
            {
                MessageBox.Show("Listener is stopped. Making this listener online-only will cancel the stop.");

                lblStatus.ForeColor = Color.Green;
                lblExtra.Text = "";
                lblExtraContent.Text = "";
                btnRestore.Visible = false;
                lblStatus.Text = ListenerStates.ACTIVE.ToString();
            }
        }
    }
}
