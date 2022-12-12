using Microsoft.Extensions.DependencyInjection;
using System;
using TNBase.DataStorage;
using TNBase.Infrastructure;

namespace TNBase
{
    public partial class FormFinished
	{
		private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();
		NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		bool readyToExit = false;

		// On load.
		private void formFinished_Load(object sender, EventArgs e)
		{
			ModuleGeneric.saveEndTime();

			// Setup labels.
			lblStartTime.Text = ModuleGeneric.getStartTimeString();
			lblFinishTime.Text = ModuleGeneric.getEndTimeString();
			lblElapsedTime.Text = ModuleGeneric.getElapsedTimeString();
			lblScannedIn.Text = ModuleScanning.getScannedIn().ToString();
			lblScannedOut.Text = ModuleScanning.getScannedOut().ToString();

            // Update the stats week
            ModuleGeneric.UpdateStatsWeek(serviceLayer);

			readyToExit = true;
		}

		// Exit application after x seconds.
		private void tmrQuit_Tick(object sender, EventArgs e)
		{
			if (readyToExit) {
				tmrQuit.Enabled = false;
				Close();
			}
		}
		public FormFinished()
		{
			Load += formFinished_Load;
			InitializeComponent();
		}

	}
}
