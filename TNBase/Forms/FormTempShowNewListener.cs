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
namespace TNBase
{
	public partial class FormTempShowNewListener
	{
        IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

		public void setupForm(int walletId)
		{
			Listener theListener = default(Listener);
			theListener = serviceLayer.GetListenerById(walletId);

			lblWallet.Text = "" + walletId;
			lblName.Text = theListener.Title + " " + theListener.Forename + " " + theListener.Surname;
		}

		private void tmrClose_Tick(object sender, EventArgs e)
		{
			this.Close();
		}
		public FormTempShowNewListener()
		{
			InitializeComponent();
		}
	}
}
