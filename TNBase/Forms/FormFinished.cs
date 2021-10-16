using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TNBase.DataStorage;
using TNBase.Infrastructure;

namespace TNBase
{
    public partial class FormFinished
	{
		private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();
		NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		bool readyToExit = false;
		// Exit whole application when closing.
		private void formFinished_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (readyToExit) {
				log.Info("Application exiting (clean).");
				Application.Exit();
			}
		}

		// On load.
		private void formFinished_Load(object sender, EventArgs e)
		{
			ModuleGeneric.saveEndTime();

			// Setup labels.
			int weeknumb = serviceLayer.GetCurrentWeekNumber();
			lblStartTime.Text = ModuleGeneric.getStartTimeString();
			lblFinishTime.Text = ModuleGeneric.getEndTimeString();
			lblElapsedTime.Text = ModuleGeneric.getElapsedTimeString();
			lblScannedIn.Text = ModuleScanning.getScannedIn().ToString();
			lblScannedOut.Text = ModuleScanning.getScannedOut().ToString();

            // Update the stats week
            ModuleGeneric.UpdateStatsWeek(serviceLayer, false);

			readyToExit = true;
		}

		// Exit application after x seconds.
		private void tmrQuit_Tick(object sender, EventArgs e)
		{
			if (readyToExit) {
				tmrQuit.Enabled = false;
				Application.Exit();
			}
		}
		public FormFinished()
		{
			Load += formFinished_Load;
			FormClosed += formFinished_FormClosed;
			InitializeComponent();
		}

	}
}
