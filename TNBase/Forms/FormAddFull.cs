using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using TNBase.Objects;
using NLog;
using TNBase.DataStorage;

namespace TNBase
{
    public partial class FormAddFull
    {
        // Logging instance.
        private Logger log = LogManager.GetCurrentClassLogger();

        IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());
        private string title;
        private string surname;
        private string forename;
        private bool withSetup;

        public void Setup(string title, string surname, string forename)
        {
            this.title = title;
            this.surname = surname;
            this.forename = forename;
            this.withSetup = true;
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

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow digits.
            if (!char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Add the listener to the database.
        private void btnFinished_Click(object sender, EventArgs e)
        {
            Listener newListener = new Listener();
            newListener.Wallet = 0;
            newListener.Title = comboTitle.Text;
            newListener.Forename = txtForename.Text;
            newListener.Surname = txtSurname.Text;
            newListener.Addr1 = txtAddr1.Text;
            newListener.Addr2 = txtAddr2.Text;
            newListener.Town = txtTown.Text;
            newListener.County = txtCounty.Text;
            newListener.Postcode = txtPostcode.Text;
            newListener.MemStickPlayer = chkTape.Checked;
            newListener.Magazine = chkMagazine.Checked;
            newListener.Info = txtInformation.Text;
            if ((!string.IsNullOrEmpty(txtTelephone.Text)))
            {
                newListener.Telephone = (txtTelephone.Text);
            }
            else
            {
                newListener.Telephone = "0";
            }
            string theStr = "";
            if (chkNoBirthday.Checked)
            {
                theStr = "01/01/" + DateTime.Now.Year;
            }
            else
            {
                theStr = birthdayDate.Value.ToString(ModuleGeneric.DATE_FORMAT);
            }
            newListener.Birthday = DateTime.Parse(theStr);
            newListener.Status = ListenerStates.ACTIVE;
            newListener.StatusInfo = "";
            newListener.DeletedDate = DateTime.Now;
            newListener.Joined = DateTime.Now;

            newListener.inOutRecords = new InOutRecords();

            int result = 0;
            result = serviceLayer.AddListener(newListener);
            if (result > 0)
            {
                log.Debug("Listener has been added. ID: " + result + ", Name: " + newListener.GetNiceName());
                Interaction.MsgBox("The listener has successfully been added.");

                Listener newListenerWithWalletNo = serviceLayer.GetListenerById(result);

                // Do new labels need to be added?
                DialogResult msgResult = MessageBox.Show("Would you like to print labels for the new listener?", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
                if (msgResult == DialogResult.Yes)
                {
                    My.MyProject.Forms.formChoosePrintPoint.Show();
                    My.MyProject.Forms.formChoosePrintPoint.SetupForm(newListenerWithWalletNo);
                }

                // Will they use a memory stick player?
                if (newListener.MemStickPlayer)
                {
                    Interaction.MsgBox("Please print the following form as listener requires a memory stick player.");
                    My.MyProject.Forms.formPrintCollectionForm.Show();
                    My.MyProject.Forms.formPrintCollectionForm.setupForm(newListenerWithWalletNo, false);
                }

                this.Close();
            }
            else
            {
                log.Error("Failed to add new listener!");
                Interaction.MsgBox("Failed to add new listener!");
                this.Close();
            }
        }

        private void formAddFull_Load(object sender, EventArgs e)
        {
            comboTitle.Items.AddRange(ListenerTitles.getAllTitles().ToArray());
            if (title != null)
            {
                comboTitle.Text = title;
            }

            txtSurname.Text = surname;
            txtForename.Text = forename;

            if (withSetup)
            {
                txtAddr1.Focus();
            }
        }

        public FormAddFull()
        {
            Load += formAddFull_Load;
            InitializeComponent();

            // Restrict input to month and day
            birthdayDate.MinDate = new DateTime(DateTime.UtcNow.Year, 01, 01);
            birthdayDate.MaxDate = new DateTime(DateTime.UtcNow.Year, 12, 31);
            birthdayDate.Format = DateTimePickerFormat.Custom;
            birthdayDate.CustomFormat = "dd MMMM";
        }
    }
}
