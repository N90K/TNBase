using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TNBase.DataStorage;
using TNBase.Model;

namespace TNBase.Forms.Printing
{
    public partial class FormPrintWalletStock : Form
    {
        const string FONT_FAMILY = "Times New Roman";

        private string title = "Stock";
        private List<StockItem> stockItems = new List<StockItem>();
        private List<StockItem> stockItemsInPrint = new List<StockItem>();
        private int totalCount = 0;
        private int currentPageNumber = 0;

        public FormPrintWalletStock()
        {
            InitializeComponent();
        }

        public void Setup(string title, IEnumerable<StockItem> stockItems)
        {
            this.title = title;
            this.stockItems = stockItems.ToList();
        }

        private void SetInitial()
        {
            stockItemsInPrint = stockItems.ToList();
            totalCount = stockItemsInPrint.Count;
            currentPageNumber = 0;
        }

        private void PrintForm()
        {
            SetInitial();
            printWalletsStockDoc.DefaultPageSettings.Margins.Top = 70;
            printWalletsStockDoc.DefaultPageSettings.Margins.Left = 70;
            printWalletsStockDoc.DefaultPageSettings.Margins.Right = 70;
            printWalletsStockDoc.DefaultPageSettings.Margins.Bottom = 70;
            printPreview.Document = printWalletsStockDoc;
            printPreview.ClientSize = new Size(600, 600);
            printPreview.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormPrintWalletStock_Load(object sender, EventArgs e)
        {
            PrintForm();
            Close();
        }

        private void printWalletsStockDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var g = e.Graphics;

            var spaceWidth = 3;
            var fontNormal = new Font(FONT_FAMILY, 12);
            var fontBold = new Font(FONT_FAMILY, 12, FontStyle.Bold);

            currentPageNumber = currentPageNumber + 1;

            var headerPosition = DrawHeader(title, e.MarginBounds, g);

            var tableHeaders = new List<string> { "Wallet", "Qty" }
                .Select(x => new
                {
                    Text = x,
                    Size = g.MeasureString(x, fontBold).ToSize()
                }).ToList();

            var tableHeaderSize = new Size(tableHeaders.Sum(x => x.Size.Width + spaceWidth), tableHeaders.First().Size.Height);
            var tableWidth = tableHeaderSize.Width + spaceWidth;
            var pageColumns = e.MarginBounds.Width / tableWidth;
            var pageColumnSpacing = (e.MarginBounds.Width - tableWidth * pageColumns) / (pageColumns - 1);

            var recordCount = 0;
            for (int pageColumn = 0; pageColumn < pageColumns; pageColumn++)
            {
                var offset = pageColumn * pageColumnSpacing;
                var tableHeaderPosition = new Rectangle(e.MarginBounds.Left + offset + tableWidth * pageColumn, (int)headerPosition.Bottom, tableWidth, tableHeaderSize.Height);
                g.FillRectangle(new SolidBrush(Color.Gray), tableHeaderPosition);

                var tableColumnPosition = tableHeaderPosition.Left + spaceWidth;
                foreach (var header in tableHeaders)
                {
                    var position = new Point(tableColumnPosition, tableHeaderPosition.Top + 2);
                    g.DrawString(header.Text, fontBold, Brushes.White, position);
                    tableColumnPosition += header.Size.Width + spaceWidth;
                }

                var row = 0;
                var bottom = tableHeaderPosition.Bottom + 2;
                var rowHeight = (int)g.MeasureString("0", fontNormal).Height;

                while (bottom < e.MarginBounds.Bottom)
                {
                    if (IsAlternating(row))
                    {
                        var backgroundPosition = new Rectangle(tableHeaderPosition.Left, bottom, tableWidth, rowHeight);
                        g.FillRectangle(new SolidBrush(Color.LightGray), backgroundPosition);
                    }

                    var stockItem = stockItemsInPrint.FirstOrDefault();
                    if (stockItem != null)
                    {
                        var position1 = new Rectangle(tableHeaderPosition.Left + spaceWidth, bottom, tableHeaders[0].Size.Width, rowHeight);
                        g.DrawString(stockItem.Wallet.ToString(), fontNormal, Brushes.Black, position1);

                        var stockText = stockItem.Stock;
                        var position2 = new Rectangle(position1.Right + spaceWidth, bottom, tableHeaders[1].Size.Width, rowHeight);
                        g.DrawString(stockText, fontNormal, Brushes.Black, position2);

                        stockItemsInPrint.RemoveAt(0);
                    }

                    bottom += rowHeight;
                    row++;
                }

                recordCount += row;
            }

            var totalPages = (totalCount + recordCount - 1) / recordCount;

            var bottomMargin = e.MarginBounds.Bottom + 25;

            g.DrawString("Printed on " + DateTime.Now.ToString(ModuleGeneric.DATE_FORMAT), fontBold, Brushes.Black, 550, bottomMargin);
            g.DrawString("Page " + currentPageNumber + "/" + totalPages, fontBold, Brushes.Black, 380, bottomMargin);

            e.HasMorePages = stockItemsInPrint.Any();

            // VB is stupid.... have to reset this so its back when you actually print it!
            if (!(e.HasMorePages))
            {
                SetInitial();
            }
        }

        private static bool IsAlternating(int row)
        {
            return row % 2 != 0;
        }

        private RectangleF DrawHeader(string text, Rectangle marginBounds, Graphics graphics)
        {
            var font = new Font(FONT_FAMILY, 20, FontStyle.Bold);
            var headerSize = graphics.MeasureString(text, font);
            var headerPosition = new RectangleF(marginBounds.Left, marginBounds.Top - headerSize.Height, marginBounds.Width, headerSize.Height);
            var headerFormat = new StringFormat { Alignment = StringAlignment.Center };
            graphics.DrawString(text, font, Brushes.Black, headerPosition, headerFormat);
            return headerPosition;
        }
    }
}
