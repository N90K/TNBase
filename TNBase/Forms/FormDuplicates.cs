using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;
using TNBase.Objects;
using TNBase.DataStorage;
namespace TNBase
{
    public partial class FormDuplicates
    {
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

        public enum DuplicateFormType
        {
            AddForm,
            EditForm,
            DeleteForm,
            StopSending,
            PrintLabels,
            PrintCollector,
            AdjustStock
        }

        private DuplicateFormType theFormType;
        // Set up the form to a given type.
        public void setupForm(DuplicateFormType formType)
        {
            theFormType = formType;

            if (formType == DuplicateFormType.AddForm)
            {
                btnDynamic.Text = "Create Listener";
            }
            if (formType == DuplicateFormType.DeleteForm)
            {
                btnDynamic.Text = "Delete Listener";
            }
            if (formType == DuplicateFormType.EditForm)
            {
                btnDynamic.Text = "Edit Listener";
            }
            if (formType == DuplicateFormType.StopSending)
            {
                btnDynamic.Text = "Choose Listener";
            }
            if (formType == DuplicateFormType.PrintLabels)
            {
                btnDynamic.Text = "Choose Listener";
            }
            if (formType == DuplicateFormType.PrintCollector)
            {
                btnDynamic.Text = "Choose Listener";
            }
            if (formType == DuplicateFormType.AdjustStock)
            {
                btnDynamic.Text = "Choose Listener";
            }
        }

        // Add items to the list.
        public void addDuplicate(Listener theListener)
        {
            try
            {
                //Add items in the listview
                string[] arr = new string[21 + 17];
                ListViewItem itm = null;

                //Add first item
                arr[0] = theListener.Wallet.ToString();
                arr[1] = theListener.Title;
                arr[2] = theListener.Forename;
                arr[3] = theListener.Surname;
                arr[4] = theListener.Addr1;
                arr[5] = theListener.Addr2;
                arr[6] = theListener.Town;
                arr[7] = theListener.County;
                arr[8] = theListener.Postcode;
                arr[9] = theListener.Magazine.ToString();
                arr[10] = theListener.MemStickPlayer.ToString();
                arr[11] = theListener.Telephone;
                arr[12] = theListener.Joined.ToString(DateTimeExtensions.DEFAULT_FORMAT);
                arr[13] = theListener.BirthdayText;
                arr[14] = theListener.Status.ToString();
                arr[15] = theListener.StatusInfo;
                arr[16] = theListener.Stock.ToString();
                arr[17] = theListener.LastIn.ToNullableNaString();
                arr[18] = theListener.LastOut.ToNullableNaString();
                arr[19] = theListener.Info;

                arr[20] = theListener.inOutRecords.In1.ToString();
                arr[21] = theListener.inOutRecords.In2.ToString();
                arr[22] = theListener.inOutRecords.In3.ToString();
                arr[23] = theListener.inOutRecords.In4.ToString();
                arr[24] = theListener.inOutRecords.In5.ToString();
                arr[25] = theListener.inOutRecords.In6.ToString();
                arr[26] = theListener.inOutRecords.In7.ToString();
                arr[27] = theListener.inOutRecords.In8.ToString();
                arr[28] = theListener.inOutRecords.Out1.ToString();
                arr[29] = theListener.inOutRecords.Out2.ToString();
                arr[30] = theListener.inOutRecords.Out3.ToString();
                arr[31] = theListener.inOutRecords.Out4.ToString();
                arr[32] = theListener.inOutRecords.Out5.ToString();
                arr[33] = theListener.inOutRecords.Out6.ToString();
                arr[34] = theListener.inOutRecords.Out7.ToString();
                arr[35] = theListener.inOutRecords.Out8.ToString();

                itm = new ListViewItem(arr);
                if (theListener.Status == ListenerStates.DELETED)
                {
                    itm.BackColor = Color.DarkRed;
                    itm.ForeColor = Color.White;
                }

                lstDuplicates.Items.Add(itm);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Could not add listener to browse table.");
            }
        }

        // Close if we cancel.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDynamic_Click(object sender, EventArgs e)
        {
            if (theFormType == DuplicateFormType.AddForm)
            {
                var title = lstDuplicates.Items[0].SubItems[1].Text;
                var surname = lstDuplicates.Items[0].SubItems[2].Text;
                var forename = lstDuplicates.Items[0].SubItems[3].Text;
                var form = new FormAddFull();
                form.Setup(title, surname, forename);
                form.ShowDialog();
                Close();
            }

            // Delete Form
            if (theFormType == DuplicateFormType.DeleteForm)
            {
                // Do we have a selected item?
                if ((lstDuplicates.FocusedItem != null))
                {
                    int theIndex = 0;
                    theIndex = lstDuplicates.FocusedItem.Index;

                    // First sub item is wallet number.
                    int walletNumb = 0;
                    walletNumb = int.Parse(lstDuplicates.Items[theIndex].SubItems[0].Text);

                    string dataString = null;
                    dataString = Listener.FormatListenerData(serviceLayer.GetListenerById(walletNumb));

                    // Show prompt.
                    DialogResult result = MessageBox.Show("Are you sure you wish to delete the following listener?" + Environment.NewLine + Environment.NewLine + dataString + Environment.NewLine + "Press [Y] to confirm or [N] to cancel.", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string myReason = Interaction.InputBox("Please enter a reason for deletion", "S.B.T.N.A.", "");
                        bool resultofdelete = false;

                        // Check if the delete was a success.
                        resultofdelete = serviceLayer.SoftDeleteListener(serviceLayer.GetListenerById(walletNumb), myReason);
                        if (resultofdelete)
                        {
                            Interaction.MsgBox("Listener deleted successfully.");
                            lstDuplicates.Items[theIndex].Remove();

                            MessageBox.Show("You should remove all wallets including the magazine wallet" + Environment.NewLine + "from stock for Wallet number " + walletNumb + ".", ModuleGeneric.getAppShortName(), MessageBoxButtons.OK);
                        }
                        else
                        {
                            Interaction.MsgBox("Error deleting listener.");
                        }
                        this.Close();
                    }
                }
            }

            // Edit Form
            if (theFormType == DuplicateFormType.EditForm)
            {
                // Do we have a selected item?
                if ((lstDuplicates.FocusedItem != null))
                {
                    int theIndex = 0;
                    theIndex = lstDuplicates.FocusedItem.Index;

                    // First sub item is wallet number.
                    int walletNumb = 0;
                    walletNumb = int.Parse(lstDuplicates.Items[theIndex].SubItems[0].Text);

                    My.MyProject.Forms.formEdit.Show();
                    My.MyProject.Forms.formEdit.setupForm(serviceLayer.GetListenerById(walletNumb));
                    this.Close();
                }
            }

            // StopSending form
            if (theFormType == DuplicateFormType.StopSending)
            {
                // Do we have a selected item?
                if ((lstDuplicates.FocusedItem != null))
                {
                    int theIndex = 0;
                    theIndex = lstDuplicates.FocusedItem.Index;

                    // First sub item is wallet number.
                    int walletNumb = 0;
                    walletNumb = int.Parse(lstDuplicates.Items[theIndex].SubItems[0].Text);

                    My.MyProject.Forms.formStopSending.Show();
                    My.MyProject.Forms.formStopSending.setupForm(serviceLayer.GetListenerById(walletNumb));
                    this.Close();
                }
            }

            // Print labels form.
            if (theFormType == DuplicateFormType.PrintLabels)
            {
                // Do we have a selected item?
                if ((lstDuplicates.FocusedItem != null))
                {
                    int theIndex = 0;
                    theIndex = lstDuplicates.FocusedItem.Index;

                    // First sub item is wallet number.
                    int walletNumb = 0;
                    walletNumb = int.Parse(lstDuplicates.Items[theIndex].SubItems[0].Text);

                    My.MyProject.Forms.formChoosePrintPoint.Show();
                    My.MyProject.Forms.formChoosePrintPoint.SetupForm(serviceLayer.GetListenerById(walletNumb));
                    this.Close();
                }
            }

            if (theFormType == DuplicateFormType.PrintCollector)
            {
                // Do we have a selected item?
                if ((lstDuplicates.FocusedItem != null))
                {
                    int theIndex = 0;
                    theIndex = lstDuplicates.FocusedItem.Index;

                    // First sub item is wallet number.
                    int walletNumb = 0;
                    walletNumb = int.Parse(lstDuplicates.Items[theIndex].SubItems[0].Text);

                    DialogResult result = MessageBox.Show("Are you printing this form for a deleted listener? (Select No if its a new one)", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
                    bool deleted = (result == DialogResult.Yes);

                    My.MyProject.Forms.formPrintCollectionForm.Show();
                    My.MyProject.Forms.formPrintCollectionForm.SetupForm(serviceLayer.GetListenerById(walletNumb), deleted);
                    this.Close();
                }
            }

            if (theFormType == DuplicateFormType.AdjustStock)
            {
                // Do we have a selected item?
                if ((lstDuplicates.FocusedItem != null))
                {
                    int theIndex = 0;
                    theIndex = lstDuplicates.FocusedItem.Index;

                    // First sub item is wallet number.
                    int walletNumb = 0;
                    walletNumb = int.Parse(lstDuplicates.Items[theIndex].SubItems[0].Text);

                    FormAdjustStockLevels formAdjustStock = new FormAdjustStockLevels();
                    formAdjustStock.setListener(serviceLayer.GetListenerById(walletNumb));
                    formAdjustStock.Show();
                    this.Close();
                }
            }
        }
        public FormDuplicates()
        {
            InitializeComponent();
        }
    }
}
