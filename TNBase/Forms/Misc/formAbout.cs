using System;
using System.Windows.Forms;
using NLog;

namespace TNBase
{
    /// <summary>
    /// About form
    /// </summary>
	public partial class FormAbout
	{
		private Logger log = LogManager.GetCurrentClassLogger();
		private int clickCount = 0;

        /// <summary>
        /// Close the form if they click away
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void FormAbout_Deactivate(object sender, EventArgs e)
		{
			log.Trace("Closing form.");
			this.Close();
		}

        /// <summary>
        /// On the form load
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
		private void FormAbout_Load(object sender, EventArgs e)
		{
			log.Trace("Loading form.");
			lblVersion.Text = $"V{Application.ProductVersion}";
            lblDotNetVer.Text = ".Net " + Environment.Version;
            Label1.Text = Settings.Default.AssociationName;
		}

        /// <summary>
        /// Close the form if they click away
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
		private void FormAbout_LostFocus(object sender, EventArgs e)
		{
			log.Trace("Closing form.");
			this.Close();
		}

		public FormAbout()
		{
			LostFocus += FormAbout_LostFocus;
			Load += FormAbout_Load;
			Deactivate += FormAbout_Deactivate;
			InitializeComponent();
		}
	}
}
