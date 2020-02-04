using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using TNBase.Objects;
using TNBase.DataStorage;

namespace TNBase
{
    public partial class FormEdit
    {
        IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

        // Variables
        private int listenerWalletNo = 0;
        private Listener myListener;

        private bool dateChanged = false;
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

                if (theListener.Birthday.HasValue)
                {
                    birthdayDate.Value = new DateTime(DateTime.Now.Year, theListener.Birthday.Value.Month, theListener.Birthday.Value.Day);

                    chkNoBirthday.Checked = false;
                    birthdayDate.Enabled = true;
                }
                else
                {
                    birthdayDate.Enabled = false;
                    chkNoBirthday.Checked = true;
                    birthdayDate.Value = DateTime.Parse("01/01/" + DateTime.Now.Year);
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
            dateChanged = false;
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
                    myListener.Birthday = null;
                }
                else
                {
                    myListener.Birthday = birthdayDate.Value;
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

        /// <summary>
        /// Has the address changed?
        /// </summary>
        /// <returns></returns>
        private bool HasAddressChanged()
        {
            // Its true if any of these things have changed (i.e. they are not all equal)
            return !(txtAddr1.Text.Equals(myListener.Addr1)
                    && txtAddr2.Text.Equals(myListener.Addr2)
                    && txtTown.Text.Equals(myListener.Town)
                    && txtCounty.Text.Equals(myListener.County)
                    && txtPostcode.Text.Equals(myListener.Postcode));
        }

        /// <summary>
        /// Has the name changed.
        /// </summary>
        /// <returns></returns>
        private bool HasNameChanged()
        {
            string selectedItem = comboTitle.SelectedItem == null ? "n/a" : comboTitle.SelectedItem.ToString();

            return !(selectedItem.Equals(myListener.Title)
                    && txtSurname.Text.Equals(myListener.Surname)
                    && txtForename.Text.Equals(myListener.Forename));
        }

        /// <summary>
        /// Has the listener been updated
        /// </summary>
        /// <returns></returns>
        private bool HasUpdated()
        {
            string selectedItem = comboTitle.SelectedItem == null ? "n/a" : comboTitle.SelectedItem.ToString();

            return (HasAddressChanged() ||
                    !selectedItem.Equals(myListener.Title) ||
                    !txtForename.Text.Equals(myListener.Forename) ||
                    !txtSurname.Text.Equals(myListener.Surname) ||
                    !txtInformation.Text.Equals(myListener.Info) ||
                    !txtTelephone.Text.Equals(myListener.Telephone) ||
                    !chkMagazine.Checked.Equals(myListener.Magazine) ||
                    !chkMemStickPlayer.Checked.Equals(myListener.MemStickPlayer) ||
                    restored ||
                    !int.Parse(txtStock.Text).Equals(myListener.Stock) ||
                    !int.Parse(txtMagazineStock.Text).Equals(myListener.MagazineStock) ||
                    dateChanged);
        }

        private void birthdayDate_ValueChanged(object sender, EventArgs e)
        {
            dateChanged = true;
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

            // Restrict input to month and day
            birthdayDate.MinDate = new DateTime(DateTime.UtcNow.Year, 01, 01);
            birthdayDate.MaxDate = new DateTime(DateTime.UtcNow.Year, 12, 31);
            birthdayDate.Format = DateTimePickerFormat.Custom;
            birthdayDate.CustomFormat = "dd MMMM";
        }

        private void chkNoBirthday_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoBirthday.Checked == false)
            {
                birthdayDate.Enabled = true;
            }
            else
            {
                birthdayDate.Enabled = false;
                birthdayDate.Value = DateTime.Parse("01/01/" + DateTime.Now.Year);
            }
        }

        private void chkMagazine_CheckedChanged(object sender, EventArgs e)
        {
            txtMagazineStock.Enabled = chkMagazine.Checked;
        }
    }
}
