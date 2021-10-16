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

            string nowDate = null;
            string weekDate = null;

            // Also duplicated in the service layer!!!!
            if ((System.DateTime.Now.Month == 12 & System.DateTime.Now.Day >= 8 & System.DateTime.Now.Day <= 14))
            {
                nowDate = System.DateTime.Now.AddDays(9).ToString(ModuleGeneric.DATE_FORMAT);
                weekDate = DateTime.Now.AddDays(29).ToString(ModuleGeneric.DATE_FORMAT);
            }
            else if ((System.DateTime.Now.Month == 12 & System.DateTime.Now.Day >= 15 & System.DateTime.Now.Day <= 25))
            {
                nowDate = System.DateTime.Now.AddDays(23).ToString(ModuleGeneric.DATE_FORMAT);
                weekDate = DateTime.Now.AddDays(29).ToString(ModuleGeneric.DATE_FORMAT);
            }
            else
            {
                nowDate = System.DateTime.Now.AddDays(9).ToString(ModuleGeneric.DATE_FORMAT);
                weekDate = DateTime.Now.AddDays(15).ToString(ModuleGeneric.DATE_FORMAT);
            }

            g.DrawString("Producers list of birthdays from " + nowDate + " to " + weekDate + ".", reportFontSmall, Brushes.Black, 100, 140);

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

                g.DrawString(theListener.Title + " " + theListener.Forename + " " + theListener.Surname, reportFontSmallBold, Brushes.Black, 100, 240 + (70 * value));

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

            g.DrawString("Number of Birthdays: " + totalCount, reportFontSmallBold, Brushes.Black, 100, 950);
            g.DrawString("Printed on " + System.DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT), reportFontSmallBold, Brushes.Black, 550, 950);
            g.DrawString("Page " + currentPageNumber + "/" + totalPages, reportFontSmallBold, Brushes.Black, 380, 970);

            // VB is stupid.... have to reset this so its back when you actually print it!
            if (!(e.HasMorePages))
            {
                SetInitial();
            }
        }

        private void SetInitial()
        {
            theListeners = serviceLayer.GetNextWeekBirthdays();
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
            printBirthdaysForm();
            this.Close();
        }

        public FormPrintBirthdays()
        {
            InitializeComponent();
        }
    }
}
