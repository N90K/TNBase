using System;
using System.Windows.Forms;
using TNBase.DataStorage;
using TNBase.Objects;

namespace TNBase.Forms
{
    public partial class FormDelete : Form
    {
        private readonly IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());
        private Listener listener;
        private bool hasWalletsSent;

        public FormDelete()
        {
            InitializeComponent();
        }

        public static FormDelete Create(Listener listener)
        {
            return new FormDelete().Setup(listener);
        }

        private bool CanPermanentlyDelete => !hasWalletsSent && (!listener.MemStickPlayer || yesMemStickRadioButton.Checked);

        private FormDelete Setup(Listener listener)
        {
            this.listener = listener;
            listenerDetailsLabel.Text = listener.FormatListenerData();

            if (!listener.MemStickPlayer)
            {
                SetupNoPlayerIssued();
            }

            noMemStickRadioButton.Checked = listener.MemStickPlayer;
            SetupStock(listener);
            UpdateMemStickReceived();
            btnDelete.Enabled = true;
            return this;
        }

        private void SetupNoPlayerIssued()
        {
            memStickQuestionLabel.Text = "Memory stick player has not been issued to this listener";
            yesMemStickRadioButton.Visible = false;
            noMemStickRadioButton.Visible = false;
        }

        private void SetupStock(Listener listener)
        {
            newsSentLabel.Text = listener.SentNewsWallets.ToString();
            magazinesSentLabel.Text = listener.SentMagazineWallets.ToString();
            hasWalletsSent = listener.SentNewsWallets > 0 || listener.SentMagazineWallets > 0;
        }

        private void UpdateMemStickReceived()
        {
            toolStripStatusLabel.Text = CanPermanentlyDelete ?
                $"Listener has no player or wallets, therefore it's data will be deleted and the wallet number reserved for {Settings.Default.MonthsUntilDelete} months" :
                "Listener's data will be deleted automatically once the player and all wallets are returned";
            btnDelete.Text = CanPermanentlyDelete ? "Permanently delete" : "Mark for deletion";
        }

        private void memStickRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMemStickReceived();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listener.MemStickPlayer && yesMemStickRadioButton.Checked)
            {
                listener.MemStickPlayer = false;
            }

            listener.Delete(tbxReason.Text);
            serviceLayer.UpdateListener(listener);

            if (listener.MemStickPlayer)
            {
                PrintMemStickCollectionForm();
            }
        }

        private void PrintMemStickCollectionForm()
        {
            var collectionForm = new FormPrintCollectionForm();
            collectionForm.SetupForm(listener, true);
        }
    }
}
