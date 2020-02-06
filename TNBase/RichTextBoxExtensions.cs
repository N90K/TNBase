using System.Drawing;
using System.Windows.Forms;

namespace TNBase
{
    public static class RichTextBoxExtensions
    {
        /// <summary>
        /// My rich text extension to add new lines
        /// </summary>
        /// <param name="box"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="backColor"></param>
        public static void MyAppendText(this RichTextBox box, string text, Color color, Color backColor)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.SelectionBackColor = backColor;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
