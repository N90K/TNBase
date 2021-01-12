using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using TNBase.Objects;
using TNBase.DataStorage;
using System.Globalization;
using TNBase.Infrastructure.Helpers;

namespace TNBase
{
    public partial class FormEdit
    {
        IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

        // Variables
        private int listenerWalletNo = 0;
        private Listener myListener;

        private bool restored = false;

        /// <summary>
        /// Setup the form
        /// </summary>
        /// <param name="theListener"></param>
		public void setupForm(Listener theListener)
        {
            if (theListener != null)
            {
                comboTitle.Text = theListener.Title;
                txtForename.Text = theListener.Forename;
                txtSurname.Text = theListener.Surname;
                txtAddr1.Text = theListener.Addr1;
                txtAddr2.Text = theListener.Addr2;
                txtTown.Text = theListener.Town;
                txtCounty.Text = theListener.County;
                txtPostcode.Text = theListener.Postcode;
                txtTelephone.Text = theListener.Telephone;
                txtStock.Text = theListener.Stock.ToString();
                chkMagazine.Checked = theListener.Magazine;
                txtMagazineStock.Enabled = chkMagazine.Checked;
                chkMemStickPlayer.Checked = theListener.MemStickPlayer;
                listenerWalletNo = theListener.Wallet;
                lblWallet.Text = listenerWalletNo.ToString();
                lblStatus.Text = theListener.Status.ToString();

                if (theListener.HasBirthday)
                {
                    cbBirthdayDay.SelectedIndex = theListener.BirthdayDay.Value - 1;
                    cbBirthdayMonth.SelectedIndex = theListener.BirthdayMonth.Value - 1;

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

                dtpJoined.Value = theListener.Joined.EnsureMinDate();
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
                    lblExtraContent.Text = theListener.StatusInfo;

                    // Just incase it doesnt have a value
                    string dateString = theListener.DeletedDate.HasValue ? theListener.DeletedDate.Value.ToNiceStr() : "??/??/????";
                    lblStatus.Text = lblStatus.Text + " on " + dateString;

                    btnRestore.Visible = true;
                }
                else if (lblStatus.Text.Equals(ListenerStates.PAUSED.ToString()))
                {
                    lblStatus.ForeColor = Color.Gray;
                    lblExtra.Text = "Duration:";
                    lblExtraContent.ForeColor = Color.Gray;
                    lblExtraContent.Text = Listener.GetStoppedDate(theListener).ToNiceStr() + " to " + Listener.GetResumeDateString(theListener);
                    btnRestore.Visible = false;
                }

                txtInformation.Text = theListener.Info;
                txtStock.Text = theListener.Stock.ToString();
                txtMagazineStock.Text = theListener.MagazineStock.ToString();

                // Display or hide the last in value 
                if (theListener.LastIn.HasValue)
                {
                    DateLastIn.Value = theListener.LastIn.Value;
                    DateLastIn.Show();
                }
                else
                {
                    DateLastIn.Hide();
                }

                // Display or hide the last out value 
                if (theListener.LastOut.HasValue)
                {
                    DateLastOut.Value = theListener.LastOut.Value;
                    DateLastOut.Show();
                }
                else
                {
                    DateLastOut.Hide();
                }

                myListener = theListener;
                populateTable(theListener);
            }
            // Update the headers.
            updateEditHeaders();

            // Set the date changed bool to false
            restored = false;
        }

        // Populate the in/out table.
        private void populateTable(Listener theListener)
        {
            lstInOut.Items.Clear();

            string[] arr = new string[10];
            ListViewItem itm = null;

            //Add first item
            arr[0] = "OUT";
            arr[1] = theListener.inOutRecords.Out1.ToString();
            arr[2] = theListener.inOutRecords.Out2.ToString();
            arr[3] = theListener.inOutRecords.Out3.ToString();
            arr[4] = theListener.inOutRecords.Out4.ToString();
            arr[5] = theListener.inOutRecords.Out5.ToString();
            arr[6] = theListener.inOutRecords.Out6.ToString();
            arr[7] = theListener.inOutRecords.Out7.ToString();
            arr[8] = theListener.inOutRecords.Out8.ToString();

            itm = new ListViewItem(arr);
            lstInOut.Items.Add(itm);

            //Add first item
            arr[0] = "IN";
            arr[1] = theListener.inOutRecords.In1.ToString();
            arr[2] = theListener.inOutRecords.In2.ToString();
            arr[3] = theListener.inOutRecords.In3.ToString();
            arr[4] = theListener.inOutRecords.In4.ToString();
            arr[5] = theListener.inOutRecords.In5.ToString();
            arr[6] = theListener.inOutRecords.In6.ToString();
            arr[7] = theListener.inOutRecords.In7.ToString();
            arr[8] = theListener.inOutRecords.In8.ToString();

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

            if (comboTitle.SelectedItem == null)
            {
                Interaction.MsgBox("Invalid title entered, please use an item in the drop down list.");
                return;
            }

            // Only if they are updated...
            if (updated)
            {
                myListener.Title = comboTitle.SelectedItem.ToString();
                myListener.Forename = txtForename.Text;
                myListener.Surname = txtSurname.Text;
                myListener.Addr1 = txtAddr1.Text;
                myListener.Addr2 = txtAddr2.Text;
                myListener.Town = txtTown.Text;
                myListener.County = txtCounty.Text;
                myListener.Postcode = txtPostcode.Text;
                myListener.MemStickPlayer = chkMemStickPlayer.Checked;
                myListener.Magazine = chkMagazine.Checked;
                myListener.Info = txtInformation.Text;
                if ((!string.IsNullOrEmpty(txtTelephone.Text)))
                {
                    myListener.Telephone = (txtTelephone.Text);
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

                if (serviceLayer.UpdateListener(myListener))
                {
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
            }
            this.Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            lblStatus.ForeColor = Color.Green;
            lblExtra.Text = "";
            lblExtraContent.Text = "";
            lblStatus.Text = ListenerStates.ACTIVE.ToString();
            btnRestore.Visible = false;

            myListener.Status = ListenerStates.ACTIVE;
            myListener.StatusInfo = "";

            restored = true;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            Listener theListener = serviceLayer.GetListeners().First();
            setupForm(theListener);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Listener theListener = serviceLayer.GetListeners().Last();
            setupForm(theListener);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Listener theListener = serviceLayer.GetNextListener(serviceLayer.GetListenerById(listenerWalletNo));
            setupForm(theListener);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            Listener theListener = serviceLayer.GetPreviousListener(serviceLayer.GetListenerById(listenerWalletNo));
            setupForm(theListener);
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
            string selectedItem = comboTitle.SelectedItem == null ? "n/a" : comboTitle.SelectedItem.ToString();

            return !(selectedItem.Equals(myListener.Title)
                    && txtSurname.Text.Equals(myListener.Surname)
                    && txtForename.Text.Equals(myListener.Forename));
        }

        private bool HasUpdated()
        {
            string selectedItem = comboTitle.SelectedItem == null ? "n/a" : comboTitle.SelectedItem.ToString();

            return HasAddressChanged() ||
                    HasBirthdayChanged() ||
                    !selectedItem.Equals(myListener.Title) ||
                    !txtForename.Text.Equals(myListener.Forename) ||
                    !txtSurname.Text.Equals(myListener.Surname) ||
                    !txtInformation.Text.Equals(myListener.Info) ||
                    !txtTelephone.Text.Equals(myListener.Telephone) ||
                    !chkMagazine.Checked.Equals(myListener.Magazine) ||
                    !chkMemStickPlayer.Checked.Equals(myListener.MemStickPlayer) ||
                    restored ||
                    !int.Parse(txtStock.Text).Equals(myListener.Stock) ||
                    !int.Parse(txtMagazineStock.Text).Equals(myListener.MagazineStock);
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
            int weekNumber = serviceLayer.GetCurrentWeekNumber();
            lstInOut.Columns[8].Text = weekNumber.ToString();
            lstInOut.Columns[7].Text = (weekNumber - 1).ToString();
            lstInOut.Columns[6].Text = (weekNumber - 2).ToString();
            lstInOut.Columns[5].Text = (weekNumber - 3).ToString();
            lstInOut.Columns[4].Text = (weekNumber - 4).ToString();
            lstInOut.Columns[3].Text = (weekNumber - 5).ToString();
            lstInOut.Columns[2].Text = (weekNumber - 6).ToString();
            lstInOut.Columns[1].Text = (weekNumber - 7).ToString();
        }

        public FormEdit()
        {
            InitializeComponent();

            comboTitle.Items.AddRange(ListenerTitles.getAllTitles().ToArray());
            cbBirthdayDay.Items.AddRange(Enumerable.Range(1, 31).Select(x => x.ToString()).ToArray());
            cbBirthdayMonth.Items.AddRange(Enumerable.Range(1, 12).Select(x => DateTimeFormatInfo.CurrentInfo.GetMonthName(x)).ToArray());
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
    }
}
