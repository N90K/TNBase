using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TNBase.Objects;
using TNBase.DataStorage;
using System.Globalization;
using TNBase.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace TNBase
{
    public partial class FormPrintBirthdays
    {
        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();
        List<Listener> theListeners = new List<Listener>();
        int totalCount = 0;
        int currentPageNumber = 0;

        int totalPages = 0;
        private void printBirthdayDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font reportFont = new System.Drawing.Font("Times New Roman", 24, FontStyle.Bold);
            Font reportFontSmall = new System.Drawing.Font("Times New Roman", 14);
            Font reportFontSmallBold = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);
            Font reportFontSmallBoldTitles = new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold);
            Graphics g = e.Graphics;
            int pageHeight = e.MarginBounds.Height;

            g.DrawString("Upcoming Birthdays", reportFont, Brushes.Black, 280, 80, StringFormat.GenericTypographic);

            g.DrawString("Producers list of birthdays from " + dtpFrom.Value.ToShortDateString() + " to " + dtpTo.Value.ToShortDateString() + ".", reportFontSmall, Brushes.Black, 100, 140);

            g.DrawString("NAME", reportFontSmallBoldTitles, Brushes.Black, 100, 200);
            g.DrawString("BIRTHDAY", reportFontSmallBoldTitles, Brushes.Black, 440, 200);
            g.DrawString("DAY", reportFontSmallBoldTitles, Brushes.Black, 650, 200);

            if (theListeners.Count > 10)
            {
                e.HasMorePages = true;
            }
            currentPageNumber = currentPageNumber + 1;

            int min = Math.Min(theListeners.Count, 10);
            min = min - 1;

            for (int value = 0; value <= min; value++)
            {
                Listener theListener = theListeners[0];

                var star = theListener.OnlineOnly ? "*" : "";
                g.DrawString($"{theListener.Title} {theListener.Forename} {theListener.Surname}{star}", reportFontSmallBold, Brushes.Black, 100, 240 + (70 * value));

                g.DrawString(theListener.BirthdayText, reportFontSmallBold, Brushes.Black, 460, 240 + (70 * value));

                var nextBirthday = theListener.NextBirthdayDate;
                if (nextBirthday.HasValue && nextBirthday.Value.Day != theListener.BirthdayDay)
                {
                    g.DrawString($"(carried to {nextBirthday.Value.Day.WithSuffix()} {DateTimeFormatInfo.CurrentInfo.GetMonthName(nextBirthday.Value.Month)})",
                        reportFontSmall, Brushes.Black, 460, 240 + (70 * value) + 25);
                }

                string birthdayDayOfWeek = theListener.HasBirthday ? theListener.NextBirthdayDate.Value.ToString("dddd") : "N/A";
                g.DrawString(birthdayDayOfWeek, reportFontSmallBold, Brushes.Black, 650, 240 + (70 * value));

                string commaString = ", ";
                if (string.IsNullOrEmpty(theListener.Town))
                {
                    commaString = "";
                }
                g.DrawString("   of " + theListener.Town + commaString + theListener.County, reportFontSmall, Brushes.Black, 100, 240 + (70 * value) + 25);

                theListeners.RemoveAt(0);
            }

            g.DrawString("*online-only listener", reportFontSmall, Brushes.Black, 100, 950);
            g.DrawString("Number of Birthdays: " + totalCount, reportFontSmallBold, Brushes.Black, 100, 1000);
            g.DrawString("Printed on " + System.DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT), reportFontSmallBold, Brushes.Black, 550, 1000);
            g.DrawString("Page " + currentPageNumber + "/" + totalPages, reportFontSmallBold, Brushes.Black, 380, 1020);

            // VB is stupid.... have to reset this so its back when you actually print it!
            if (!e.HasMorePages)
            {
                SetInitial();
            }
        }

        private void SetInitial()
        {
            theListeners = serviceLayer.GetUpcomingBirthdays(new DateRange() { from = dtpFrom.Value, to = dtpTo.Value });
            SortListeners();
            totalCount = theListeners.Count;
            currentPageNumber = 0;
        }

        private void printBirthdaysForm()
        {
            SetInitial();
            totalPages = (int)Math.Ceiling((double)totalCount / 10);
            if (totalPages == 0)
            {
                totalPages = 1;
            }

            printPreview.Document = printBirthdayDoc;
            printPreview.ClientSize = new Size(600, 600);
            printPreview.ShowDialog();
        }

        // Sort the listeners in order!
        private void SortListeners()
        {
            theListeners = theListeners.OrderBy(x => x.BirthdayMonth).ThenBy(x => x.BirthdayDay).ToList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formPrintBirthdays_Load(object sender, EventArgs e)
        {
            DateRange dateRange = serviceLayer.GetUpcomingBirthdayDates();

            dtpFrom.Value = dateRange.from;
            dtpTo.Value = dateRange.to;
        }

        public FormPrintBirthdays()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            pnlParams.Visible = false;
            lblPrinting.Text = string.Format(lblPrinting.Text, dtpFrom.Text, dtpTo.Text);
            pnlPrinting.Visible = true;
            Refresh();
            printBirthdaysForm();
            this.Close();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpTo.Value = dtpFrom.Value.AddDays(13);
        }
    }
}
