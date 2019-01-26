using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using TNBase.Objects;
using TNBase.DataStorage;
using NLog;

namespace TNBase
{
	public partial class FormAddMini
	{
		private Logger log = NLog.LogManager.GetCurrentClassLogger();
        private IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

		private void progressForm()
		{
			// Check all fields have data.
			if ((string.IsNullOrEmpty(txtForename.Text) | string.IsNullOrEmpty(txtSurname.Text) | string.IsNullOrEmpty(comboTitle.Text))) {
				log.Warn("User attempted to submit empty form.");
				Interaction.MsgBox("You must complete the form first.");
			} else {
				// Check Name exists
                List<Listener> theListeners = new List<Listener>();
				log.Trace("Looking up listeners by name and surname.");
                theListeners = serviceLayer.GetListenersByName(txtForename.Text, txtSurname.Text, comboTitle.Text);

				// Check for results.
				if ((theListeners != null) & theListeners.Count > 0) {
					// If its just one form.
					string dataString = null;
					if (theListeners.Count == 1) {
						// Look up data.
						Listener theListener = theListeners[0];
						dataString = Listener.FormatListenerData(theListener);

						// Show prompt.
                        DialogResult result = MessageBox.Show("There would appear to be another listener with the same name. Is this a duplicate?" + Environment.NewLine + Environment.NewLine + dataString + Environment.NewLine + "Press [Y] if this is a duplicate or [N] otherwise.", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
						if (result == DialogResult.No) {
							// Show the form.
							showFullForm();
						} else if (result == DialogResult.Yes) {
							log.Trace("Not adding new user as a duplicate exists!");
							Interaction.MsgBox("Addition cancelled - duplicate listener." + Environment.NewLine + Environment.NewLine + "Press [enter] to continue.");
							this.Close();
						}
					} else {
						log.Trace("Multiple duplicates, displaying choice form.");
						Interaction.MsgBox("Multiple Listeners with this Forename and Surname have been found. Please review the Listeners and cancel if a duplicate exists.");

                        showDuplicateForm(theListeners);
					}
				} else {
					showFullForm();
				}
			}
		}

		private void btnFinished_Click(object sender, EventArgs e)
		{
			progressForm();
		}

        /// <summary>
        /// Show the full add form
        /// </summary>
		private void showFullForm()
		{
            FormAddFull form = new FormAddFull();
            form.Show();

            form.comboTitle.Text = comboTitle.Text;
            form.txtSurname.Text = txtSurname.Text;
            form.txtForename.Text = txtForename.Text;
            
			this.Close();
		}

        private void showDuplicateForm(List<Listener> theListeners)
        {
            FormDuplicates form = new FormDuplicates();

            form.Show();
            form.setupForm(FormDuplicates.DuplicateFormType.AddForm);

            foreach (Listener tListener in theListeners)
            {
                form.addDuplicate(tListener);
            }

            this.Close();
        }

		private void comboTitle_Click(object sender, EventArgs e)
		{
			// Show the combo box.
			comboTitle.DroppedDown = true;
		}

		private void formAddMini_Load(object sender, EventArgs e)
		{
            comboTitle.Items.AddRange(ListenerTitles.getAllTitles().ToArray());
		}
	}
}
