namespace VMS
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.Query = new ICSharpCode.TextEditor.TextEditorControl();
            this.ActionsToolStrip = new System.Windows.Forms.ToolStrip();
            this.BtnExtremeStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnComment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnUncomment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TStxtCicli = new System.Windows.Forms.ToolStripTextBox();
            this.BtnSearch = new System.Windows.Forms.ToolStripButton();
            this.BtnBookmark = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.opFDMain = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.nfiMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.leggiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalEventProvider1 = new Gma.UserActivityMonitor.GlobalEventProvider();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.ActionsToolStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Query
            // 
            this.Query.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Query.ForeColor = System.Drawing.Color.Blue;
            this.Query.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Query.IsReadOnly = false;
            this.Query.LineViewerStyle = ICSharpCode.TextEditor.Document.LineViewerStyle.FullRow;
            this.Query.Location = new System.Drawing.Point(0, 61);
            this.Query.Margin = new System.Windows.Forms.Padding(4);
            this.Query.Name = "Query";
            this.Query.ShowVRuler = false;
            this.Query.Size = new System.Drawing.Size(1378, 611);
            this.Query.TabIndex = 2;
            this.Query.Load += new System.EventHandler(this.Query_Load);
            // 
            // ActionsToolStrip
            // 
            this.ActionsToolStrip.AutoSize = false;
            this.ActionsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ActionsToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ActionsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnExtremeStop,
            this.toolStripSeparator1,
            this.BtnComment,
            this.toolStripSeparator2,
            this.BtnUncomment,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.TStxtCicli,
            this.BtnSearch,
            this.BtnBookmark,
            this.toolStripSeparator5,
            this.BtnNext,
            this.toolStripSeparator7,
            this.toolStripTextBox3,
            this.toolStripButton2,
            this.toolStripButton3});
            this.ActionsToolStrip.Location = new System.Drawing.Point(0, 24);
            this.ActionsToolStrip.Name = "ActionsToolStrip";
            this.ActionsToolStrip.Size = new System.Drawing.Size(1378, 37);
            this.ActionsToolStrip.TabIndex = 3;
            // 
            // BtnExtremeStop
            // 
            this.BtnExtremeStop.AutoSize = false;
            this.BtnExtremeStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnExtremeStop.Image = ((System.Drawing.Image)(resources.GetObject("BtnExtremeStop.Image")));
            this.BtnExtremeStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnExtremeStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExtremeStop.Name = "BtnExtremeStop";
            this.BtnExtremeStop.Size = new System.Drawing.Size(28, 28);
            this.BtnExtremeStop.ToolTipText = "Save Script(Ctr + S)";
            this.BtnExtremeStop.Click += new System.EventHandler(this.BtnScegliApplicazione_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // BtnComment
            // 
            this.BtnComment.AutoSize = false;
            this.BtnComment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnComment.Image = ((System.Drawing.Image)(resources.GetObject("BtnComment.Image")));
            this.BtnComment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnComment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnComment.Name = "BtnComment";
            this.BtnComment.Size = new System.Drawing.Size(28, 28);
            this.BtnComment.ToolTipText = "Open Script (Ctr + O)";
            this.BtnComment.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // BtnUncomment
            // 
            this.BtnUncomment.AutoSize = false;
            this.BtnUncomment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnUncomment.Image = ((System.Drawing.Image)(resources.GetObject("BtnUncomment.Image")));
            this.BtnUncomment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnUncomment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUncomment.Name = "BtnUncomment";
            this.BtnUncomment.Size = new System.Drawing.Size(28, 28);
            this.BtnUncomment.ToolTipText = "Search (Ctr + F)";
            this.BtnUncomment.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "+";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 37);
            // 
            // TStxtCicli
            // 
            this.TStxtCicli.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TStxtCicli.Name = "TStxtCicli";
            this.TStxtCicli.Size = new System.Drawing.Size(132, 37);
            this.TStxtCicli.Click += new System.EventHandler(this.TStxtCicli_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.AutoSize = false;
            this.BtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearch.Image")));
            this.BtnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(28, 28);
            this.BtnSearch.Text = "-";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnBookmark
            // 
            this.BtnBookmark.AutoSize = false;
            this.BtnBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnBookmark.Image = global::VMS.Properties.Resources.images;
            this.BtnBookmark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnBookmark.Name = "BtnBookmark";
            this.BtnBookmark.Size = new System.Drawing.Size(28, 28);
            this.BtnBookmark.ToolTipText = "Coordinate Mouse";
            this.BtnBookmark.Click += new System.EventHandler(this.BtnBookmark_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 37);
            // 
            // BtnNext
            // 
            this.BtnNext.AutoSize = false;
            this.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNext.Image = ((System.Drawing.Image)(resources.GetObject("BtnNext.Image")));
            this.BtnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(28, 28);
            this.BtnNext.ToolTipText = "Run Script (Ctr + F2)";
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(132, 37);
            this.toolStripTextBox3.Text = "0";
            this.toolStripTextBox3.ToolTipText = "Timer";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 34);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Font";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::VMS.Properties.Resources.Books;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 34);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Comandi Help";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // opFDMain
            // 
            this.opFDMain.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // nfiMain
            // 
            this.nfiMain.ContextMenuStrip = this.contextMenuStrip1;
            this.nfiMain.Text = "Macro Script.";
            this.nfiMain.Visible = true;
            this.nfiMain.BalloonTipClosed += new System.EventHandler(this.nfiMain_BalloonTipClosed);
            this.nfiMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 52);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.showToolStripMenuItem.Text = "&Show";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // stsMain
            // 
            this.stsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.stsMain.Location = new System.Drawing.Point(0, 646);
            this.stsMain.Name = "stsMain";
            this.stsMain.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.stsMain.Size = new System.Drawing.Size(1378, 26);
            this.stsMain.TabIndex = 4;
            this.stsMain.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leggiToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // leggiToolStripMenuItem
            // 
            this.leggiToolStripMenuItem.Name = "leggiToolStripMenuItem";
            this.leggiToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.leggiToolStripMenuItem.Text = "&Leggi ";
            this.leggiToolStripMenuItem.Click += new System.EventHandler(this.leggiToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1378, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fontDialog
            // 
            this.fontDialog.AllowVerticalFonts = false;
            this.fontDialog.ShowEffects = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1378, 672);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.Query);
            this.Controls.Add(this.ActionsToolStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Virtual SendMessage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Click += new System.EventHandler(this.frmMain_Click);
            this.ActionsToolStrip.ResumeLayout(false);
            this.ActionsToolStrip.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl Query;
        private System.Windows.Forms.ToolStrip ActionsToolStrip;
        private System.Windows.Forms.ToolStripButton BtnExtremeStop;
        private System.Windows.Forms.ToolStripButton BtnComment;
        private System.Windows.Forms.ToolStripButton BtnUncomment;
        private System.Windows.Forms.ToolStripButton BtnSearch;
        private System.Windows.Forms.ToolStripButton BtnBookmark;
        private System.Windows.Forms.ToolStripButton BtnNext;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog opFDMain;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.NotifyIcon nfiMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripTextBox TStxtCicli;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem leggiToolStripMenuItem;
        private Gma.UserActivityMonitor.GlobalEventProvider globalEventProvider1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}