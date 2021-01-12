using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using TNBase.DataStorage;
using TNBase.Objects;

namespace TNBase
{
    public partial class FormBrowse
    {
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

        // Could be changed if page is made bigger. 15 just about fits on the page.
        int limit = 15;
        int offset = 0;

        bool deletedMode = false;
        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateOrder()
        {
            if (string.IsNullOrEmpty(cmbOrder.Text))
            {
                cmbOrder.Text = cmbOrder.Items[0].ToString();
            }
        }

        // Set to deleted only mode.
        public void DeletedOnlyMode()
        {
            deletedMode = true;
            lblTitle.Text = "Browse Deleted Listeners";
            btnEdit.Visible = false;
            btnCancelStop.Visible = false;
            btnStopSending.Visible = false;
            btnRemove.Text = "Restore";
            btnRemove.BackColor = Color.Orange;
            refreshList();
            log.Trace("Started in Delete mode.");
        }

        // Add items to the list.
        public void addToListeners(Listener listener)
        {
            try
            {
                lstFreeze.Items.Add(listener.Wallet.ToString());

                var subItems = new List<string>
                {
                    listener.Title,
                    listener.Forename,
                    listener.Surname,
                    listener.Addr1,
                    listener.Addr2,
                    listener.Town,
                    listener.County,
                    listener.Postcode,
                    listener.Magazine.ToString(),
                    listener.MemStickPlayer.ToString(),
                    listener.Telephone,
                    listener.Joined.ToNiceStr(),
                    listener.BirthdayText,
                    listener.Status.ToString(),
                    listener.StatusInfo,
                    listener.Stock.ToString(),
                    listener.MagazineStock.ToString(),
                    listener.LastIn.ToNullableNaString(),
                    listener.LastOut.ToNullableNaString(),
                    listener.Info,
                    listener.inOutRecords.In1.ToString(),
                    listener.inOutRecords.In2.ToString(),
                    listener.inOutRecords.In3.ToString(),
                    listener.inOutRecords.In4.ToString(),
                    listener.inOutRecords.Out1.ToString(),
                    listener.inOutRecords.Out2.ToString(),
                    listener.inOutRecords.Out3.ToString(),
                    listener.inOutRecords.Out4.ToString()
                };

                var itm = new ListViewItem(subItems.ToArray());
                if (listener.Status == ListenerStates.DELETED)
                {
                    itm.BackColor = Color.DarkRed;
                    itm.ForeColor = Color.White;
                }
                else if (listener.Status == ListenerStates.PAUSED)
                {
                    itm.BackColor = Color.LightGray;
                }

                lstBrowse.Items.Add(itm);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Could not add listener to browse table.");
            }

        }

        public void clearList()
        {
            lstFreeze.Items.Clear();
            lstBrowse.Items.Clear();
        }

        public void refreshList()
        {
            clearList();

            List<Listener> theListeners = new List<Listener>();
            if (deletedMode)
            {
                theListeners = serviceLayer.GetListenersByStatus(ListenerStates.DELETED).Skip(offset).Take(limit).ToList();
            }
            else
            {
                OrderVar order = cmbOrder.Text.Equals("Wallet") ? OrderVar.WALLET : OrderVar.SURNAME;
                theListeners = serviceLayer.GetOrderedListeners(order).Skip(offset).Take(limit).ToList();
            }

            foreach (Listener tListener in theListeners)
            {
                addToListeners(tListener);
            }
        }

        private void btnCancelStop_Click(object sender, EventArgs e)
        {
            int theIndex = 0;
            if (lstBrowse.FocusedItem != null)
            {
                theIndex = lstBrowse.FocusedItem.Index;

                // First sub item is wallet number.
                int walletNumb = 0;
                walletNumb = int.Parse(lstFreeze.Items[theIndex].Text);

                Listener theListener = serviceLayer.GetListenerById(walletNumb);
                try
                {
                    theListener.Resume();

                    if (!serviceLayer.UpdateListener(theListener))
                    {
                        log.Error("Failed to update and resume listener! WalletId: " + walletNumb);
                        Interaction.MsgBox("Error: Failed to update listener");
                    }
                    else
                    {
                        Interaction.MsgBox("Succesfully updated listener.");
                        log.Info("Resumed and updated listener with WalletId: " + walletNumb);
                        refreshList();
                    }
                }
                catch (ListenerStateChangeException ex)
                {
                    log.Error(ex, "Attempt to resume non paused listener! WalletId: " + walletNumb);
                    Interaction.MsgBox("This listener is not Paused.");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int theIndex = 0;
            if (lstBrowse.FocusedItem != null)
            {
                theIndex = lstBrowse.FocusedItem.Index;

                // First sub item is wallet number.
                int walletNumb = 0;
                walletNumb = int.Parse(lstFreeze.Items[theIndex].Text);

                Listener theListener = serviceLayer.GetListenerById(walletNumb);
                My.MyProject.Forms.formEdit.Show();
                My.MyProject.Forms.formEdit.setupForm(theListener);
            }
        }

        private void btnStopSending_Click(object sender, EventArgs e)
        {
            int theIndex = 0;
            if (lstBrowse.FocusedItem != null)
            {
                theIndex = lstBrowse.FocusedItem.Index;

                // First sub item is wallet number.
                int walletNumb = 0;
                walletNumb = int.Parse(lstFreeze.Items[theIndex].Text);

                Listener theListener = serviceLayer.GetListenerById(walletNumb);
                My.MyProject.Forms.formStopSending.Show();
                My.MyProject.Forms.formStopSending.setupForm(theListener);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int theIndex = 0;
            if (lstBrowse.FocusedItem != null)
            {
                theIndex = lstBrowse.FocusedItem.Index;

                // First sub item is wallet number.
                int walletNumb = 0;
                walletNumb = int.Parse(lstFreeze.Items[theIndex].Text);

                if (deletedMode)
                {
                    if (serviceLayer.RestoreListener(serviceLayer.GetListenerById(walletNumb)))
                    {
                        Interaction.MsgBox("Successfully restored listener.");
                        log.Info("Listener resumed: " + walletNumb);
                        refreshList();
                    }
                    else
                    {
                        log.Error("Failed to restore listener. Id: " + walletNumb);
                        Interaction.MsgBox("ERROR: Failed to restore listener");
                    }
                }
                else
                {
                    string dataString = null;
                    dataString = Listener.FormatListenerData(serviceLayer.GetListenerById(walletNumb));

                    // Show prompt.
                    DialogResult result = MessageBox.Show("Are you sure you wish to delete the following listener?" + Environment.NewLine + Environment.NewLine + dataString + Environment.NewLine + "Press [Y] to confirm or [N] to cancel.", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    else if (result == DialogResult.Yes)
                    {
                        string myReason = Interaction.InputBox("Please enter a reason for deletion", "S.B.T.N.A.", "");
                        bool resultofdelete = false;

                        // Check if the delete was a success.
                        resultofdelete = serviceLayer.SoftDeleteListener(serviceLayer.GetListenerById(walletNumb), myReason);
                        if (resultofdelete)
                        {
                            Interaction.MsgBox("Listener deleted successfully. ");
                            log.Info("Listener deleted: " + walletNumb);
                            MessageBox.Show("You should remove all wallets including the magazine wallet" + Environment.NewLine + "from stock for Wallet number " + walletNumb + ".", ModuleGeneric.getAppShortName(), MessageBoxButtons.OK);

                            // Check if the player / memory stick has been returned.
                            var tempListener = serviceLayer.GetListenerById(walletNumb);
                            if ((tempListener.MemStickPlayer))
                            {
                                DialogResult walletReturned = MessageBox.Show("Did the listener return the memory stick player?", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
                                if (walletReturned == DialogResult.Yes)
                                {
                                    tempListener.MemStickPlayer = false;
                                    if (!serviceLayer.UpdateListener(tempListener))
                                    {
                                        Interaction.MsgBox("Error deleting listener.");
                                    }
                                }
                                else
                                {
                                    // Else print deleted listener form.
                                    My.MyProject.Forms.formPrintCollectionForm.Show();
                                    My.MyProject.Forms.formPrintCollectionForm.SetupForm(tempListener, true);
                                }
                            }
                        }
                        else
                        {
                            Interaction.MsgBox("Error deleting listener.");
                            log.Error("Error deleting listener: " + walletNumb);
                        }
                        refreshList();
                    }
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            offset = 0;
            refreshList();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            offset = Math.Max(offset - limit, 0);
            refreshList();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (deletedMode)
            {
                offset = Math.Min(offset + limit, serviceLayer.GetInactiveListeners().Count - limit);
            }
            else
            {
                offset = Math.Min(offset + limit, serviceLayer.GetListeners().Count - limit);
            }
            refreshList();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (deletedMode)
            {
                offset = serviceLayer.GetInactiveListeners().Count - limit;
            }
            else
            {
                offset = serviceLayer.GetListeners().Count - limit;
            }
            refreshList();
        }

        private void AddHorribleHeaders()
        {
            int weekNumber = serviceLayer.GetCurrentWeekNumber();

            // Have a horrible 8 week history.
            for (int count = 1; count <= 4; count++)
            {
                int final = weekNumber - (4 - count);
                lstBrowse.Columns.Add(final + " (IN)");
            }
            for (int count = 1; count <= 4; count++)
            {
                int final = weekNumber - (4 - count);
                lstBrowse.Columns.Add(final + " (OUT)");
            }
        }

        private void formBrowse_Load(object sender, EventArgs e)
        {
            AddHorribleHeaders();

            UpdateOrder();
            refreshList();
        }

        private void cmbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshList();
        }
        public FormBrowse()
        {
            Load += formBrowse_Load;
            InitializeComponent();
        }

        private void lstBrowse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBrowse.FocusedItem != null)
            {
                lstFreeze.Items[lstBrowse.FocusedItem.Index].Focused = true;
                lstFreeze.Items[lstBrowse.FocusedItem.Index].Selected = true;
                lstFreeze.Select();
                lstFreeze.Focus();
                lstBrowse.Focus();
            }
        }

        private void lstFreeze_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFreeze.FocusedItem != null)
            {
                lstBrowse.Items[lstFreeze.FocusedItem.Index].Focused = true;
                lstBrowse.Items[lstFreeze.FocusedItem.Index].Selected = true;
                lstBrowse.Select();
                lstBrowse.Focus();
                lstFreeze.Focus();
                SelectItem(lstFreeze.FocusedItem.Index);
            }
        }

        private void SelectItem(int index)
        {
            var walletNumb = int.Parse(lstFreeze.Items[index].Text);

            Listener listener = serviceLayer.GetListenerById(walletNumb);

            // Buttons only available if required.
            btnRemove.Enabled = !listener.Status.Equals(ListenerStates.DELETED);
            btnStopSending.Enabled = listener.Status.Equals(ListenerStates.ACTIVE);
            btnCancelStop.Enabled = listener.Status.Equals(ListenerStates.PAUSED);
        }
    }
}
