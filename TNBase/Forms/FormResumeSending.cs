using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TNBase.Objects;
using TNBase.DataStorage;
namespace TNBase
{
    public partial class FormResumeSending
    {
        private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        private IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());
        private List<Listener> theListeners = new List<Listener>();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Add items to the list.
        public void addListenerToList(Listener theListener)
        {
            //Add items in the listview
            string[] arr = new string[7];
            ListViewItem itm = null;

            //Add first item
            arr[0] = theListener.Wallet.ToString();
            arr[1] = theListener.Title;
            arr[2] = theListener.Forename;
            arr[3] = theListener.Surname;
            arr[4] = theListener.GetStoppedDate().ToString(DateTimeExtensions.DEFAULT_FORMAT);
            arr[5] = theListener.GetResumeDateString();

            itm = new ListViewItem(arr);
            lstData.Items.Add(itm);
        }

        // When the form loads, populate it.
        private void formResumeSending_Load(object sender, EventArgs e)
        {
            theListeners = serviceLayer.GetListenersByStatus(ListenerStates.PAUSED);

            foreach (Listener tListener in theListeners)
            {
                addListenerToList(tListener);
            }
        }

        // Cancel the stop on a listener
        private void btnCancelStop_Click(object sender, EventArgs e)
        {
            int theIndex = 0;
            theIndex = lstData.FocusedItem.Index;

            int walletNumb = 0;
            walletNumb = int.Parse(lstData.Items[theIndex].SubItems[0].Text);

            Listener myListener = null;
            foreach (Listener tListener in theListeners)
            {
                if (tListener.Wallet == walletNumb)
                {
                    myListener = tListener;
                }
            }

            if ((myListener != null))
            {
                myListener.Resume();

                serviceLayer.UpdateListener(myListener);

                Interaction.MsgBox("Listener updated successfully!");
                log.Info("Resumed listener with wallet: " + myListener.Wallet);
                Close();
            }
        }
        public FormResumeSending()
        {
            Load += formResumeSending_Load;
            InitializeComponent();
        }
    }
}
