using System;
using TNBase.Objects;
using TNBase.DataStorage;
using Microsoft.Extensions.DependencyInjection;

namespace TNBase
{
    public partial class FormTempShowNewListener
	{
		private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();

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
