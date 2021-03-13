using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TNBase.Objects;
using TNBase.DataStorage;
using NLog;

namespace TNBase
{
    public partial class FormAddMini
    {
        private Logger log = LogManager.GetCurrentClassLogger();
        private IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());
        private bool preventClose;

        private void progressForm()
        {
            // Check all fields have data.
            if ((string.IsNullOrEmpty(txtForename.Text) | string.IsNullOrEmpty(txtSurname.Text) | string.IsNullOrEmpty(comboTitle.Text)))
            {
                log.Warn("User attempted to submit empty form.");
                Interaction.MsgBox("You must complete the form first.");
            }
            else
            {
                // Check Name exists
                List<Listener> theListeners = new List<Listener>();
                log.Trace("Looking up listeners by name and surname.");
                theListeners = serviceLayer.GetListenersByName(txtForename.Text, txtSurname.Text, comboTitle.Text);

                // Check for results.
                if ((theListeners != null) & theListeners.Count > 0)
                {
                    // If its just one form.
                    string dataString = null;
                    if (theListeners.Count == 1)
                    {
                        // Look up data.
                        Listener theListener = theListeners[0];
                        dataString = theListener.FormatListenerData();

                        // Show prompt.
                        DialogResult result = MessageBox.Show("There would appear to be another listener with the same name. Is this a duplicate?" + Environment.NewLine + Environment.NewLine + dataString + Environment.NewLine + "Press [Y] if this is a duplicate or [N] otherwise.", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                        {
                            // Show the form.
                            showFullForm();
                        }
                        else if (result == DialogResult.Yes)
                        {
                            log.Trace("Not adding new user as a duplicate exists!");
                            Interaction.MsgBox("Addition cancelled - duplicate listener." + Environment.NewLine + Environment.NewLine + "Press [enter] to continue.");
                            this.Close();
                        }
                    }
                    else
                    {
                        log.Trace("Multiple duplicates, displaying choice form.");
                        Interaction.MsgBox("Multiple Listeners with this Forename and Surname have been found. Please review the Listeners and cancel if a duplicate exists.");

                        showDuplicateForm(theListeners);
                    }
                }
                else
                {
                    showFullForm();
                }
            }
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                progressForm();
            }
            else
            {
                preventClose = true;
            }
        }

        /// <summary>
        /// Show the full add form
        /// </summary>
        private void showFullForm()
        {
            FormAddFull form = new FormAddFull();
            form.Setup(comboTitle.Text, txtSurname.Text, txtForename.Text);
            form.ShowDialog();
        }

        private void showDuplicateForm(List<Listener> theListeners)
        {
            FormDuplicates form = new FormDuplicates();

            form.setupForm(FormDuplicates.DuplicateFormType.AddForm);

            foreach (Listener tListener in theListeners)
            {
                form.addDuplicate(tListener);
            }
            form.ShowDialog();
        }

        private void comboTitle_Click(object sender, EventArgs e)
        {
            // Show the combo box.
            comboTitle.DroppedDown = true;
        }

        private void formAddMini_Load(object sender, EventArgs e)
        {
            comboTitle.Items.AddRange(ListenerTitles.GetAllTitles().ToArray());
        }

        private void comboTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (comboTitle.SelectedItem == null)
            {
                errorProvider.SetError(comboTitle, "Please set the title");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(comboTitle, "");
            }
        }

        private void txtSurname_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                errorProvider.SetError(txtSurname, "Please enter surname");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtSurname, "");
            }
        }

        private void txtForename_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtForename.Text))
            {
                errorProvider.SetError(txtForename, "Please enter forename");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtForename, "");
            }
        }

        private void FormAddMini_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (preventClose)
            {
                e.Cancel = true;
                preventClose = false;
            }
        }
    }
}
