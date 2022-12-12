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
namespace TNBase
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class FormMain : System.Windows.Forms.Form
	{

		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try {
				if (disposing && components != null) {
					components.Dispose();
				}
			} finally {
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer

		private System.ComponentModel.IContainer components;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.Label1 = new System.Windows.Forms.Label();
            this.menuTop = new System.Windows.Forms.MenuStrip();
            this.mBtnListeners = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopSendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelAStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BrowseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintenenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintAllListenerLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustStockLevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpcomingBirthdaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecentlyAddedListenersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintAddressLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListenersInactiveFor30DaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GPOSackLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StoppedListenersThisWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WalletsNotSentOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnreturnedSpeakersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintAlphabeticSurnameListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printCollectorForListenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magazineWalletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walletsStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magazineWalletStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineonlyListenersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatisticsHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScanningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScanInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScanOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CollectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCollectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BrowseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrintLabels = new System.Windows.Forms.Button();
            this.btnCancelStop = new System.Windows.Forms.Button();
            this.btnStopSending = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFinished = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnScanOut = new System.Windows.Forms.Button();
            this.btnScanIn = new System.Windows.Forms.Button();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblHints = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerHints = new System.Windows.Forms.Timer(this.components);
            this.backupDialog = new System.Windows.Forms.SaveFileDialog();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.restoreDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblWeekNumber = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnMagScanOut = new System.Windows.Forms.Button();
            this.btnMagScanIn = new System.Windows.Forms.Button();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.menuTop.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Label1.Location = new System.Drawing.Point(269, 134);
            this.Label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(0, 79);
            this.Label1.TabIndex = 0;
            // 
            // menuTop
            // 
            this.menuTop.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuTop.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mBtnListeners,
            this.MaintenenceToolStripMenuItem,
            this.PrintingToolStripMenuItem,
            this.StatisticsHistoryToolStripMenuItem,
            this.ScanningToolStripMenuItem,
            this.CollectorsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuTop.Location = new System.Drawing.Point(0, 0);
            this.menuTop.Name = "menuTop";
            this.menuTop.Padding = new System.Windows.Forms.Padding(13, 4, 0, 4);
            this.menuTop.Size = new System.Drawing.Size(2277, 53);
            this.menuTop.TabIndex = 1;
            this.menuTop.Text = "MenuStrip1";
            // 
            // mBtnListeners
            // 
            this.mBtnListeners.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.StopSendingToolStripMenuItem,
            this.CancelAStopToolStripMenuItem,
            this.BrowseToolStripMenuItem});
            this.mBtnListeners.Name = "mBtnListeners";
            this.mBtnListeners.ShortcutKeyDisplayString = "";
            this.mBtnListeners.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.mBtnListeners.Size = new System.Drawing.Size(154, 45);
            this.mBtnListeners.Text = "&Listeners";
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(335, 50);
            this.AddToolStripMenuItem.Text = "Add";
            this.AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(335, 50);
            this.DeleteToolStripMenuItem.Text = "Delete";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(335, 50);
            this.EditToolStripMenuItem.Text = "Edit";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // StopSendingToolStripMenuItem
            // 
            this.StopSendingToolStripMenuItem.Name = "StopSendingToolStripMenuItem";
            this.StopSendingToolStripMenuItem.Size = new System.Drawing.Size(335, 50);
            this.StopSendingToolStripMenuItem.Text = "Stop Sending";
            this.StopSendingToolStripMenuItem.Click += new System.EventHandler(this.StopSendingToolStripMenuItem_Click);
            // 
            // CancelAStopToolStripMenuItem
            // 
            this.CancelAStopToolStripMenuItem.Name = "CancelAStopToolStripMenuItem";
            this.CancelAStopToolStripMenuItem.Size = new System.Drawing.Size(335, 50);
            this.CancelAStopToolStripMenuItem.Text = "Cancel a Stop";
            this.CancelAStopToolStripMenuItem.Click += new System.EventHandler(this.CancelAStopToolStripMenuItem_Click);
            // 
            // BrowseToolStripMenuItem
            // 
            this.BrowseToolStripMenuItem.Name = "BrowseToolStripMenuItem";
            this.BrowseToolStripMenuItem.Size = new System.Drawing.Size(335, 50);
            this.BrowseToolStripMenuItem.Text = "Browse";
            this.BrowseToolStripMenuItem.Click += new System.EventHandler(this.BrowseToolStripMenuItem_Click);
            // 
            // MaintenenceToolStripMenuItem
            // 
            this.MaintenenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackupToolStripMenuItem,
            this.RestoreToolStripMenuItem,
            this.PrintAllListenerLabelsToolStripMenuItem,
            this.logViewToolStripMenuItem,
            this.openLogDirectoryToolStripMenuItem,
            this.adjustStockLevelsToolStripMenuItem,
            this.dataImportToolStripMenuItem});
            this.MaintenenceToolStripMenuItem.Name = "MaintenenceToolStripMenuItem";
            this.MaintenenceToolStripMenuItem.Size = new System.Drawing.Size(210, 45);
            this.MaintenenceToolStripMenuItem.Text = "&Maintenence";
            // 
            // BackupToolStripMenuItem
            // 
            this.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem";
            this.BackupToolStripMenuItem.Size = new System.Drawing.Size(459, 50);
            this.BackupToolStripMenuItem.Text = "Backup";
            this.BackupToolStripMenuItem.Click += new System.EventHandler(this.BackupToolStripMenuItem_Click);
            // 
            // RestoreToolStripMenuItem
            // 
            this.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem";
            this.RestoreToolStripMenuItem.Size = new System.Drawing.Size(459, 50);
            this.RestoreToolStripMenuItem.Text = "Restore";
            this.RestoreToolStripMenuItem.Click += new System.EventHandler(this.RestoreToolStripMenuItem_Click);
            // 
            // PrintAllListenerLabelsToolStripMenuItem
            // 
            this.PrintAllListenerLabelsToolStripMenuItem.Name = "PrintAllListenerLabelsToolStripMenuItem";
            this.PrintAllListenerLabelsToolStripMenuItem.Size = new System.Drawing.Size(459, 50);
            this.PrintAllListenerLabelsToolStripMenuItem.Text = "Print All Listener Labels";
            this.PrintAllListenerLabelsToolStripMenuItem.Click += new System.EventHandler(this.PrintAllListenerLabelsToolStripMenuItem_Click);
            // 
            // logViewToolStripMenuItem
            // 
            this.logViewToolStripMenuItem.Name = "logViewToolStripMenuItem";
            this.logViewToolStripMenuItem.Size = new System.Drawing.Size(459, 50);
            this.logViewToolStripMenuItem.Text = "Log View";
            this.logViewToolStripMenuItem.Click += new System.EventHandler(this.LogViewToolStripMenuItem_Click);
            // 
            // openLogDirectoryToolStripMenuItem
            // 
            this.openLogDirectoryToolStripMenuItem.Name = "openLogDirectoryToolStripMenuItem";
            this.openLogDirectoryToolStripMenuItem.Size = new System.Drawing.Size(459, 50);
            this.openLogDirectoryToolStripMenuItem.Text = "Open Log Directory";
            this.openLogDirectoryToolStripMenuItem.Click += new System.EventHandler(this.OpenLogDirectoryToolStripMenuItem_Click);
            // 
            // adjustStockLevelsToolStripMenuItem
            // 
            this.adjustStockLevelsToolStripMenuItem.Name = "adjustStockLevelsToolStripMenuItem";
            this.adjustStockLevelsToolStripMenuItem.Size = new System.Drawing.Size(459, 50);
            this.adjustStockLevelsToolStripMenuItem.Text = "Adjust Stock Levels";
            this.adjustStockLevelsToolStripMenuItem.Click += new System.EventHandler(this.AdjustStockLevelsToolStripMenuItem_Click);
            // 
            // dataImportToolStripMenuItem
            // 
            this.dataImportToolStripMenuItem.Name = "dataImportToolStripMenuItem";
            this.dataImportToolStripMenuItem.Size = new System.Drawing.Size(459, 50);
            this.dataImportToolStripMenuItem.Text = "Data Import";
            this.dataImportToolStripMenuItem.Click += new System.EventHandler(this.dataImportToolStripMenuItem_Click);
            // 
            // PrintingToolStripMenuItem
            // 
            this.PrintingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpcomingBirthdaysToolStripMenuItem,
            this.RecentlyAddedListenersToolStripMenuItem,
            this.PrintAddressLabelsToolStripMenuItem,
            this.ListenersInactiveFor30DaysToolStripMenuItem,
            this.GPOSackLabelsToolStripMenuItem,
            this.StoppedListenersThisWeekToolStripMenuItem,
            this.WalletsNotSentOutToolStripMenuItem,
            this.UnreturnedSpeakersToolStripMenuItem,
            this.PrintAlphabeticSurnameListToolStripMenuItem,
            this.printCollectorForListenerToolStripMenuItem,
            this.magazineWalletsToolStripMenuItem,
            this.walletsStockToolStripMenuItem,
            this.magazineWalletStockToolStripMenuItem,
            this.onlineonlyListenersToolStripMenuItem});
            this.PrintingToolStripMenuItem.Name = "PrintingToolStripMenuItem";
            this.PrintingToolStripMenuItem.Size = new System.Drawing.Size(141, 45);
            this.PrintingToolStripMenuItem.Text = "Prin&ting";
            // 
            // UpcomingBirthdaysToolStripMenuItem
            // 
            this.UpcomingBirthdaysToolStripMenuItem.Name = "UpcomingBirthdaysToolStripMenuItem";
            this.UpcomingBirthdaysToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.UpcomingBirthdaysToolStripMenuItem.Text = "Upcoming Birthdays";
            this.UpcomingBirthdaysToolStripMenuItem.Click += new System.EventHandler(this.UpcomingBirthdaysToolStripMenuItem_Click);
            // 
            // RecentlyAddedListenersToolStripMenuItem
            // 
            this.RecentlyAddedListenersToolStripMenuItem.Name = "RecentlyAddedListenersToolStripMenuItem";
            this.RecentlyAddedListenersToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.RecentlyAddedListenersToolStripMenuItem.Text = "Recently Added Listeners";
            this.RecentlyAddedListenersToolStripMenuItem.Click += new System.EventHandler(this.RecentlyAddedListenersToolStripMenuItem_Click);
            // 
            // PrintAddressLabelsToolStripMenuItem
            // 
            this.PrintAddressLabelsToolStripMenuItem.Name = "PrintAddressLabelsToolStripMenuItem";
            this.PrintAddressLabelsToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.PrintAddressLabelsToolStripMenuItem.Text = "Print Address Labels";
            this.PrintAddressLabelsToolStripMenuItem.Click += new System.EventHandler(this.PrintAddressLabelsToolStripMenuItem_Click);
            // 
            // ListenersInactiveFor30DaysToolStripMenuItem
            // 
            this.ListenersInactiveFor30DaysToolStripMenuItem.Name = "ListenersInactiveFor30DaysToolStripMenuItem";
            this.ListenersInactiveFor30DaysToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.ListenersInactiveFor30DaysToolStripMenuItem.Text = "Listeners inactive for 30 days";
            this.ListenersInactiveFor30DaysToolStripMenuItem.Click += new System.EventHandler(this.ListenersInactiveFor30DaysToolStripMenuItem_Click);
            // 
            // GPOSackLabelsToolStripMenuItem
            // 
            this.GPOSackLabelsToolStripMenuItem.Name = "GPOSackLabelsToolStripMenuItem";
            this.GPOSackLabelsToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.GPOSackLabelsToolStripMenuItem.Text = "Print Sack Labels";
            this.GPOSackLabelsToolStripMenuItem.Click += new System.EventHandler(this.GPOSackLabelsToolStripMenuItem_Click);
            // 
            // StoppedListenersThisWeekToolStripMenuItem
            // 
            this.StoppedListenersThisWeekToolStripMenuItem.Name = "StoppedListenersThisWeekToolStripMenuItem";
            this.StoppedListenersThisWeekToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.StoppedListenersThisWeekToolStripMenuItem.Text = "Paused Wallet List";
            this.StoppedListenersThisWeekToolStripMenuItem.Click += new System.EventHandler(this.StoppedListenersThisWeekToolStripMenuItem_Click);
            // 
            // WalletsNotSentOutToolStripMenuItem
            // 
            this.WalletsNotSentOutToolStripMenuItem.Name = "WalletsNotSentOutToolStripMenuItem";
            this.WalletsNotSentOutToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.WalletsNotSentOutToolStripMenuItem.Text = "Unsent Wallets This Week";
            this.WalletsNotSentOutToolStripMenuItem.Click += new System.EventHandler(this.WalletsNotSentOutToolStripMenuItem_Click);
            // 
            // UnreturnedSpeakersToolStripMenuItem
            // 
            this.UnreturnedSpeakersToolStripMenuItem.Name = "UnreturnedSpeakersToolStripMenuItem";
            this.UnreturnedSpeakersToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.UnreturnedSpeakersToolStripMenuItem.Text = "Unreturned Memory Stick Players";
            this.UnreturnedSpeakersToolStripMenuItem.Click += new System.EventHandler(this.UnreturnedSpeakersToolStripMenuItem_Click);
            // 
            // PrintAlphabeticSurnameListToolStripMenuItem
            // 
            this.PrintAlphabeticSurnameListToolStripMenuItem.Name = "PrintAlphabeticSurnameListToolStripMenuItem";
            this.PrintAlphabeticSurnameListToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.PrintAlphabeticSurnameListToolStripMenuItem.Text = "Print Alphabetic (Surname) List";
            this.PrintAlphabeticSurnameListToolStripMenuItem.Click += new System.EventHandler(this.PrintAlphabeticSurnameListToolStripMenuItem_Click);
            // 
            // printCollectorForListenerToolStripMenuItem
            // 
            this.printCollectorForListenerToolStripMenuItem.Name = "printCollectorForListenerToolStripMenuItem";
            this.printCollectorForListenerToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.printCollectorForListenerToolStripMenuItem.Text = "Print Collector For Listener";
            this.printCollectorForListenerToolStripMenuItem.Click += new System.EventHandler(this.PrintCollectorForListenerToolStripMenuItem_Click);
            // 
            // magazineWalletsToolStripMenuItem
            // 
            this.magazineWalletsToolStripMenuItem.Name = "magazineWalletsToolStripMenuItem";
            this.magazineWalletsToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.magazineWalletsToolStripMenuItem.Text = "Magazine Wallets";
            this.magazineWalletsToolStripMenuItem.Click += new System.EventHandler(this.MagazineWalletsToolStripMenuItem_Click);
            // 
            // walletsStockToolStripMenuItem
            // 
            this.walletsStockToolStripMenuItem.Name = "walletsStockToolStripMenuItem";
            this.walletsStockToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.walletsStockToolStripMenuItem.Text = "News Wallet Stock";
            this.walletsStockToolStripMenuItem.Click += new System.EventHandler(this.WalletsStockToolStripMenuItem_Click);
            // 
            // magazineWalletStockToolStripMenuItem
            // 
            this.magazineWalletStockToolStripMenuItem.Name = "magazineWalletStockToolStripMenuItem";
            this.magazineWalletStockToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.magazineWalletStockToolStripMenuItem.Text = "Magazine Wallet Stock";
            this.magazineWalletStockToolStripMenuItem.Click += new System.EventHandler(this.MagazineWalletStockToolStripMenuItem_Click);
            // 
            // onlineonlyListenersToolStripMenuItem
            // 
            this.onlineonlyListenersToolStripMenuItem.Name = "onlineonlyListenersToolStripMenuItem";
            this.onlineonlyListenersToolStripMenuItem.Size = new System.Drawing.Size(597, 50);
            this.onlineonlyListenersToolStripMenuItem.Text = "Online-only Listeners";
            this.onlineonlyListenersToolStripMenuItem.Click += new System.EventHandler(this.onlineonlyListenersToolStripMenuItem_Click);
            // 
            // StatisticsHistoryToolStripMenuItem
            // 
            this.StatisticsHistoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatisticsToolStripMenuItem,
            this.HistoryToolStripMenuItem});
            this.StatisticsHistoryToolStripMenuItem.Name = "StatisticsHistoryToolStripMenuItem";
            this.StatisticsHistoryToolStripMenuItem.Size = new System.Drawing.Size(274, 45);
            this.StatisticsHistoryToolStripMenuItem.Text = "Statistics / Histor&y";
            // 
            // StatisticsToolStripMenuItem
            // 
            this.StatisticsToolStripMenuItem.Name = "StatisticsToolStripMenuItem";
            this.StatisticsToolStripMenuItem.Size = new System.Drawing.Size(269, 50);
            this.StatisticsToolStripMenuItem.Text = "Statistics";
            this.StatisticsToolStripMenuItem.Click += new System.EventHandler(this.StatisticsToolStripMenuItem_Click);
            // 
            // HistoryToolStripMenuItem
            // 
            this.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem";
            this.HistoryToolStripMenuItem.Size = new System.Drawing.Size(269, 50);
            this.HistoryToolStripMenuItem.Text = "History";
            this.HistoryToolStripMenuItem.Click += new System.EventHandler(this.HistoryToolStripMenuItem_Click);
            // 
            // ScanningToolStripMenuItem
            // 
            this.ScanningToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScanInToolStripMenuItem,
            this.ScanOutToolStripMenuItem});
            this.ScanningToolStripMenuItem.Name = "ScanningToolStripMenuItem";
            this.ScanningToolStripMenuItem.Size = new System.Drawing.Size(159, 45);
            this.ScanningToolStripMenuItem.Text = "Scanning";
            this.ScanningToolStripMenuItem.Visible = false;
            // 
            // ScanInToolStripMenuItem
            // 
            this.ScanInToolStripMenuItem.Name = "ScanInToolStripMenuItem";
            this.ScanInToolStripMenuItem.Size = new System.Drawing.Size(275, 50);
            this.ScanInToolStripMenuItem.Text = "Scan In";
            this.ScanInToolStripMenuItem.Click += new System.EventHandler(this.ScanInToolStripMenuItem_Click);
            // 
            // ScanOutToolStripMenuItem
            // 
            this.ScanOutToolStripMenuItem.Name = "ScanOutToolStripMenuItem";
            this.ScanOutToolStripMenuItem.Size = new System.Drawing.Size(275, 50);
            this.ScanOutToolStripMenuItem.Text = "Scan Out";
            this.ScanOutToolStripMenuItem.Click += new System.EventHandler(this.ScanOutToolStripMenuItem_Click);
            // 
            // CollectorsToolStripMenuItem
            // 
            this.CollectorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddCollectorsToolStripMenuItem,
            this.BrowseToolStripMenuItem1});
            this.CollectorsToolStripMenuItem.Name = "CollectorsToolStripMenuItem";
            this.CollectorsToolStripMenuItem.Size = new System.Drawing.Size(170, 45);
            this.CollectorsToolStripMenuItem.Text = "Collectors";
            // 
            // AddCollectorsToolStripMenuItem
            // 
            this.AddCollectorsToolStripMenuItem.Name = "AddCollectorsToolStripMenuItem";
            this.AddCollectorsToolStripMenuItem.Size = new System.Drawing.Size(350, 50);
            this.AddCollectorsToolStripMenuItem.Text = "Add Collectors";
            this.AddCollectorsToolStripMenuItem.Click += new System.EventHandler(this.AddCollectorsToolStripMenuItem_Click);
            // 
            // BrowseToolStripMenuItem1
            // 
            this.BrowseToolStripMenuItem1.Name = "BrowseToolStripMenuItem1";
            this.BrowseToolStripMenuItem1.Size = new System.Drawing.Size(350, 50);
            this.BrowseToolStripMenuItem1.Text = "Browse";
            this.BrowseToolStripMenuItem1.Click += new System.EventHandler(this.BrowseToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(100, 45);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(359, 50);
            this.viewHelpToolStripMenuItem.Text = "&View Help";
            this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.viewHelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(359, 50);
            this.aboutToolStripMenuItem1.Text = "Abo&ut";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDate.Location = new System.Drawing.Point(1870, 273);
            this.lblDate.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(209, 44);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "??/??/????";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTime.Location = new System.Drawing.Point(160, 273);
            this.lblTime.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(167, 44);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "??:??:??";
            // 
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Interval = 1000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnPrintLabels);
            this.GroupBox1.Controls.Add(this.btnCancelStop);
            this.GroupBox1.Controls.Add(this.btnStopSending);
            this.GroupBox1.Controls.Add(this.btnBrowse);
            this.GroupBox1.Controls.Add(this.btnEdit);
            this.GroupBox1.Controls.Add(this.btnRemove);
            this.GroupBox1.Controls.Add(this.btnAdd);
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GroupBox1.Location = new System.Drawing.Point(115, 431);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.GroupBox1.Size = new System.Drawing.Size(455, 900);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Listeners";
            // 
            // btnPrintLabels
            // 
            this.btnPrintLabels.BackColor = System.Drawing.Color.White;
            this.btnPrintLabels.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintLabels.Location = new System.Drawing.Point(13, 757);
            this.btnPrintLabels.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnPrintLabels.Name = "btnPrintLabels";
            this.btnPrintLabels.Size = new System.Drawing.Size(429, 96);
            this.btnPrintLabels.TabIndex = 11;
            this.btnPrintLabels.Text = "&Print Labels";
            this.btnPrintLabels.UseVisualStyleBackColor = false;
            this.btnPrintLabels.Click += new System.EventHandler(this.btnPrintLabels_Click);
            // 
            // btnCancelStop
            // 
            this.btnCancelStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelStop.Location = new System.Drawing.Point(13, 538);
            this.btnCancelStop.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnCancelStop.Name = "btnCancelStop";
            this.btnCancelStop.Size = new System.Drawing.Size(429, 96);
            this.btnCancelStop.TabIndex = 9;
            this.btnCancelStop.Text = "&Cancel a Stop";
            this.btnCancelStop.UseVisualStyleBackColor = false;
            this.btnCancelStop.Click += new System.EventHandler(this.BtnCancelStop_Click);
            // 
            // btnStopSending
            // 
            this.btnStopSending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnStopSending.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopSending.Location = new System.Drawing.Point(13, 646);
            this.btnStopSending.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnStopSending.Name = "btnStopSending";
            this.btnStopSending.Size = new System.Drawing.Size(429, 96);
            this.btnStopSending.TabIndex = 8;
            this.btnStopSending.Text = "&Stop Sending";
            this.btnStopSending.UseVisualStyleBackColor = false;
            this.btnStopSending.Click += new System.EventHandler(this.BtnStopSending_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowse.Location = new System.Drawing.Point(13, 416);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(429, 96);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "Bro&wse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(13, 305);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(429, 96);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(13, 196);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(429, 94);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "&Delete";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(13, 77);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(429, 96);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnFinished
            // 
            this.btnFinished.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFinished.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinished.Location = new System.Drawing.Point(914, 1261);
            this.btnFinished.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(388, 130);
            this.btnFinished.TabIndex = 12;
            this.btnFinished.Text = "&Finished";
            this.btnFinished.UseVisualStyleBackColor = false;
            this.btnFinished.Click += new System.EventHandler(this.BtnFinished_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnScanOut);
            this.GroupBox2.Controls.Add(this.btnScanIn);
            this.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GroupBox2.Location = new System.Drawing.Point(1664, 431);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.GroupBox2.Size = new System.Drawing.Size(455, 356);
            this.GroupBox2.TabIndex = 12;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "News Scanning";
            // 
            // btnScanOut
            // 
            this.btnScanOut.BackColor = System.Drawing.Color.Yellow;
            this.btnScanOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScanOut.Location = new System.Drawing.Point(13, 196);
            this.btnScanOut.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnScanOut.Name = "btnScanOut";
            this.btnScanOut.Size = new System.Drawing.Size(429, 96);
            this.btnScanOut.TabIndex = 11;
            this.btnScanOut.Text = "Scan &Out";
            this.btnScanOut.UseVisualStyleBackColor = false;
            this.btnScanOut.Click += new System.EventHandler(this.BtnScanOut_Click);
            // 
            // btnScanIn
            // 
            this.btnScanIn.BackColor = System.Drawing.Color.Yellow;
            this.btnScanIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScanIn.Location = new System.Drawing.Point(13, 77);
            this.btnScanIn.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnScanIn.Name = "btnScanIn";
            this.btnScanIn.Size = new System.Drawing.Size(429, 96);
            this.btnScanIn.TabIndex = 10;
            this.btnScanIn.Text = "Scan &In";
            this.btnScanIn.UseVisualStyleBackColor = false;
            this.btnScanIn.Click += new System.EventHandler(this.BtnScanIn_Click);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.StatusStrip1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblHints});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 1492);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 30, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(2277, 42);
            this.StatusStrip1.TabIndex = 14;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // lblHints
            // 
            this.lblHints.Name = "lblHints";
            this.lblHints.Size = new System.Drawing.Size(95, 32);
            this.lblHints.Text = "lblHints";
            // 
            // timerHints
            // 
            this.timerHints.Enabled = true;
            this.timerHints.Interval = 3000;
            this.timerHints.Tick += new System.EventHandler(this.TimerHints_Tick);
            // 
            // backupDialog
            // 
            this.backupDialog.HelpRequest += new System.EventHandler(this.BtnAdd_Click);
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("PictureBox1.InitialImage")));
            this.PictureBox1.Location = new System.Drawing.Point(784, 431);
            this.PictureBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(665, 644);
            this.PictureBox1.TabIndex = 15;
            this.PictureBox1.TabStop = false;
            // 
            // restoreDialog
            // 
            this.restoreDialog.FileName = "OpenFileDialog1";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVersion.Location = new System.Drawing.Point(1014, 1101);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(171, 44);
            this.lblVersion.TabIndex = 16;
            this.lblVersion.Text = "V ?.?.?.?";
            // 
            // lblWeekNumber
            // 
            this.lblWeekNumber.AutoSize = true;
            this.lblWeekNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWeekNumber.Location = new System.Drawing.Point(984, 273);
            this.lblWeekNumber.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblWeekNumber.Name = "lblWeekNumber";
            this.lblWeekNumber.Size = new System.Drawing.Size(221, 44);
            this.lblWeekNumber.TabIndex = 17;
            this.lblWeekNumber.Text = "Week: ????";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnMagScanOut);
            this.groupBox3.Controls.Add(this.btnMagScanIn);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(1664, 928);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox3.Size = new System.Drawing.Size(455, 356);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Magazine Scanning";
            // 
            // btnMagScanOut
            // 
            this.btnMagScanOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMagScanOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMagScanOut.Location = new System.Drawing.Point(13, 196);
            this.btnMagScanOut.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnMagScanOut.Name = "btnMagScanOut";
            this.btnMagScanOut.Size = new System.Drawing.Size(429, 96);
            this.btnMagScanOut.TabIndex = 13;
            this.btnMagScanOut.Text = "Scan &Out";
            this.btnMagScanOut.UseVisualStyleBackColor = false;
            this.btnMagScanOut.Click += new System.EventHandler(this.BtnMagScanOut_Click);
            // 
            // btnMagScanIn
            // 
            this.btnMagScanIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMagScanIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMagScanIn.Location = new System.Drawing.Point(13, 77);
            this.btnMagScanIn.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnMagScanIn.Name = "btnMagScanIn";
            this.btnMagScanIn.Size = new System.Drawing.Size(429, 96);
            this.btnMagScanIn.TabIndex = 12;
            this.btnMagScanIn.Text = "Scan &In";
            this.btnMagScanIn.UseVisualStyleBackColor = false;
            this.btnMagScanIn.Click += new System.EventHandler(this.BtnMagScanIn_Click);
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "Resource\\TNBase.chm";
            // 
            // FormMain
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(2277, 1534);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblWeekNumber);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.menuTop);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.helpProvider.SetHelpKeyword(this, "0");
            this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuTop;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.helpProvider.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.formMain_Load);
            this.menuTop.ResumeLayout(false);
            this.menuTop.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.MenuStrip menuTop;
		internal System.Windows.Forms.ToolStripMenuItem mBtnListeners;
		internal System.Windows.Forms.ToolStripMenuItem MaintenenceToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem PrintingToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem StatisticsHistoryToolStripMenuItem;
		internal System.Windows.Forms.Label lblDate;
		internal System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timerUpdate;
		internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPrintLabels;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCancelStop;
        private System.Windows.Forms.Button btnStopSending;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnFinished;
		internal System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.Button btnScanOut;
        private System.Windows.Forms.Button btnScanIn;
		internal System.Windows.Forms.StatusStrip StatusStrip1;
		internal System.Windows.Forms.ToolStripStatusLabel lblHints;
        private System.Windows.Forms.Timer timerHints;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackupToolStripMenuItem;
		internal System.Windows.Forms.SaveFileDialog backupDialog;
		internal System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.ToolStripMenuItem UpcomingBirthdaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StopSendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CancelAStopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BrowseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestoreToolStripMenuItem;
        internal System.Windows.Forms.OpenFileDialog restoreDialog;
        private System.Windows.Forms.ToolStripMenuItem ScanningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScanInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScanOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RecentlyAddedListenersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintAddressLabelsToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem CollectorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddCollectorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BrowseToolStripMenuItem1;
		internal System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripMenuItem ListenersInactiveFor30DaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GPOSackLabelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StoppedListenersThisWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WalletsNotSentOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UnreturnedSpeakersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintAlphabeticSurnameListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintAllListenerLabelsToolStripMenuItem;
		internal System.Windows.Forms.Label lblWeekNumber;

		public FormMain()
		{
			FormClosing += formMain_FormClosing;
			Load += formMain_Load;
			InitializeComponent();
            Label1.Text = Properties.Settings.Default.AssociationName;
		}

        private ToolStripMenuItem logViewToolStripMenuItem;
        private ToolStripMenuItem openLogDirectoryToolStripMenuItem;
        private ToolStripMenuItem printCollectorForListenerToolStripMenuItem;
        private ToolStripMenuItem magazineWalletsToolStripMenuItem;
        private ToolStripMenuItem adjustStockLevelsToolStripMenuItem;
        private ToolStripMenuItem walletsStockToolStripMenuItem;
        internal GroupBox groupBox3;
        private Button btnMagScanOut;
        private Button btnMagScanIn;
        private ToolStripMenuItem magazineWalletStockToolStripMenuItem;
        private ToolStripMenuItem onlineonlyListenersToolStripMenuItem;
        private ToolStripMenuItem dataImportToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem viewHelpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private HelpProvider helpProvider;
    }
}
