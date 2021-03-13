using Microsoft.VisualBasic;
using System;
using System.Drawing;
using TNBase.Objects;
using TNBase.DataStorage;

namespace TNBase
{
    public partial class FormStopSending
    {
        private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        private IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

        private Listener myListener;

        public static FormStopSending Create(Listener listener)
        {
            return new FormStopSending().Setup(listener);
        }

        public FormStopSending Setup(Listener theListener)
        {
            bool dateSet = false;

            // Setup some labels
            lblName.Text = theListener.Title + " " + theListener.Forename + " " + theListener.Surname;
            lblWallet.Text = "Wallet: " + theListener.Wallet;
            lblStatus.Text = theListener.Status.ToString();

            // Add some color
            if (theListener.Status == ListenerStates.DELETED)
            {
                lblStatus.ForeColor = Color.Red;
            }
            else if (theListener.Status == ListenerStates.ACTIVE)
            {
                lblStatus.ForeColor = Color.Green;
            }
            else if (theListener.Status == ListenerStates.PAUSED)
            {
                startDate.Value = theListener.GetStoppedDate();
                if (!theListener.GetResumeDate().HasValue)
                {
                    endDate.Value = DateTime.Now;

                    chkNoResume.Checked = true;
                    endDate.Enabled = false;
                }
                else
                {
                    endDate.Value = theListener.GetResumeDate().Value;
                }
                dateSet = true;
            }

            if (!dateSet)
            {
                // Add 7 days onto date.
                DateTime tempDate = default(DateTime);
                tempDate = DateTime.Now.AddDays(7);
                endDate.Value = tempDate;
            }

            myListener = theListener;

            return this;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime sDate = startDate.Value;
                if (chkNoResume.Checked)
                {
                    myListener.Pause(sDate);
                }
                else
                {
                    myListener.Pause(sDate, endDate.Value);
                }

                serviceLayer.UpdateListener(myListener);
                Interaction.MsgBox("Listener has been updated successfully!");
                log.Info("Paused listener. Wallet: " + myListener.Wallet + ", Status: " + myListener.Status);
                this.Close();
            }
            catch (ListenerStateChangeException ey)
            {
                Interaction.MsgBox("Error: Can't pause this listener!");
                log.Warn(ey, "Failed to pause a listener. State Change Exception. Wallet: " + myListener.Wallet + ", Status: " + myListener.Status);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Failed to pause a listener. Unhandled Exception.");
            }
        }

        private void chkNoResume_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoResume.Checked)
            {
                endDate.Enabled = false;
            }
            else
            {
                endDate.Enabled = true;
            }
        }
    }
}
