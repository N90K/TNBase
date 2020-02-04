using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TNBase.Objects;
using TNBase.DataStorage;
namespace TNBase
{
	public partial class FormHistory
	{
		private int minYear;
		private int maxYear;
		private int currentYear;

		NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		private void btnDone_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

		private void SetYear(int year)
		{
			currentYear = year;
			lblYear.Text = year.ToString();

			try {
				// Set the year stats.
				YearStats yearStats = serviceLayer.GetYearStats(year);
				lstYearStats.Items.Clear();

				//Add items in the listview
				string[] arr = new string[7];
				ListViewItem itm = null;
				arr[0] = yearStats.StartListeners.ToString();
                arr[1] = yearStats.EndListeners.ToString();
                arr[2] = yearStats.SentTotal.ToString();
                arr[3] = yearStats.MagazinesSent.ToString();
                arr[4] = yearStats.MemStickPlayerLoanTotal.ToString();
                arr[5] = yearStats.NewListeners.ToString();
				itm = new ListViewItem(arr);
				lstYearStats.Items.Add(itm);
			} catch (Exception ex) {
				// Do not log if the year is the current year as this would be expected.
				if (!(year == DateTime.Now.Year)) {
					log.Warn(ex, "Could not load yearly stats for year: " + year);
				}
			}

			// Set the weekly stats.
			lstWeekStats.Items.Clear();
            List<WeeklyStats> weeklyStats = serviceLayer.GetWeeklyStatsForYear(year);
			for (int index = 0; index <= weeklyStats.Count - 1; index++) {
				WeeklyStats weekStats = weeklyStats[index];
				//Add items in the listview
				string[] arr = new string[7];
				ListViewItem itm = null;
				arr[0] = weekStats.WeekNumber.ToString();
				arr[1] = weekStats.ScannedIn.ToString();
				arr[2] = weekStats.ScannedOut.ToString();
				arr[3] = weekStats.PausedCount.ToString();
				arr[4] = weekStats.WeekDate.ToNiceStr();
				arr[5] = weekStats.TotalListeners.ToString();
				itm = new ListViewItem(arr);
				lstWeekStats.Items.Add(itm);
			}
		}

		private void formHistory_Load(object sender, EventArgs e)
		{
			minYear = serviceLayer.GetMinimumYear();
            maxYear = serviceLayer.GetHighestYearNumber();
			if ((DateTime.Now.Year > maxYear)) {
				maxYear = maxYear + 1;
			}

			SetYear(maxYear);
		}

		private void btnFirst_Click(object sender, EventArgs e)
		{
			SetYear(minYear);
		}

		private void btnLast_Click(object sender, EventArgs e)
		{
			SetYear(maxYear);
		}

		private void btnPrevious_Click(object sender, EventArgs e)
		{
			if ((currentYear - 1 < minYear)) {
				// Do nothing
			} else {
				SetYear(currentYear - 1);
			}
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			if ((currentYear + 1 > maxYear)) {
				// Do nothing
			} else {
				SetYear(currentYear + 1);
			}
		}
		public FormHistory()
		{
			Load += formHistory_Load;
			InitializeComponent();
		}
	}
}
