using System;
using System.Drawing;
using System.Windows.Forms;
using TNBase.Objects;
using TNBase.DataStorage;
using TNBase.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace TNBase
{
    public partial class FormDuplicates
    {
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();

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
                arr[12] = theListener.Joined.ToNullableNaString(DateTimeExtensions.DEFAULT_FORMAT);
                arr[13] = theListener.BirthdayText;
                arr[14] = theListener.Status.ToString();
                arr[15] = theListener.StatusInfo;
                arr[16] = theListener.Stock.ToString();
                arr[17] = theListener.LastIn.ToNullableNaString();
                arr[18] = theListener.LastOut.ToNullableNaString();
                arr[19] = theListener.Info;

                arr[20] = theListener.InOutRecords.In1.ToString();
                arr[21] = theListener.InOutRecords.In2.ToString();
                arr[22] = theListener.InOutRecords.In3.ToString();
                arr[23] = theListener.InOutRecords.In4.ToString();
                arr[24] = theListener.InOutRecords.In5.ToString();
                arr[25] = theListener.InOutRecords.In6.ToString();
                arr[26] = theListener.InOutRecords.In7.ToString();
                arr[27] = theListener.InOutRecords.In8.ToString();
                arr[28] = theListener.InOutRecords.Out1.ToString();
                arr[29] = theListener.InOutRecords.Out2.ToString();
                arr[30] = theListener.InOutRecords.Out3.ToString();
                arr[31] = theListener.InOutRecords.Out4.ToString();
                arr[32] = theListener.InOutRecords.Out5.ToString();
                arr[33] = theListener.InOutRecords.Out6.ToString();
                arr[34] = theListener.InOutRecords.Out7.ToString();
                arr[35] = theListener.InOutRecords.Out8.ToString();

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

            if (lstDuplicates.FocusedItem == null)
                return;

            var index = lstDuplicates.FocusedItem.Index;
            var wallet = int.Parse(lstDuplicates.Items[index].SubItems[0].Text);
            var listener = serviceLayer.GetListenerById(wallet);

            if (theFormType == DuplicateFormType.DeleteForm)
            {
                var deleteForm = FormDelete.Create(listener);
                deleteForm.ShowDialog();
            }

            if (theFormType == DuplicateFormType.EditForm)
            {
                My.MyProject.Forms.formEdit.Show();
                My.MyProject.Forms.formEdit.Setup(listener);
            }

            if (theFormType == DuplicateFormType.StopSending)
            {
                My.MyProject.Forms.formStopSending.Show();
                My.MyProject.Forms.formStopSending.Setup(listener);
            }

            if (theFormType == DuplicateFormType.PrintLabels)
            {
                My.MyProject.Forms.formChoosePrintPoint.Show();
                My.MyProject.Forms.formChoosePrintPoint.SetupForm(listener);
            }

            if (theFormType == DuplicateFormType.PrintCollector)
            {
                bool deleted = true;
                if (!listener.OnlineOnly)
                {
                    DialogResult result = MessageBox.Show("Are you printing this form for a deleted listener? (Select No if its a new one)", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
                    deleted = result == DialogResult.Yes;
                }

                My.MyProject.Forms.formPrintCollectionForm.Show();
                My.MyProject.Forms.formPrintCollectionForm.SetupForm(listener, deleted);
            }

            if (theFormType == DuplicateFormType.AdjustStock)
            {

                FormAdjustStockLevels formAdjustStock = new FormAdjustStockLevels();
                formAdjustStock.setListener(listener);
                formAdjustStock.Show();
            }

            Close();
        }
        public FormDuplicates()
        {
            InitializeComponent();
        }
    }
}
