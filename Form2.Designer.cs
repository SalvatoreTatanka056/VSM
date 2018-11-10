namespace MacroIE
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.Query = new ICSharpCode.TextEditor.TextEditorControl();
            this.ActionsToolStrip = new System.Windows.Forms.ToolStrip();
            this.BtnExecute = new System.Windows.Forms.ToolStripButton();
            this.BtnStop = new System.Windows.Forms.ToolStripButton();
            this.BtnExtremeStop = new System.Windows.Forms.ToolStripButton();
            this.BtnComment = new System.Windows.Forms.ToolStripButton();
            this.BtnUncomment = new System.Windows.Forms.ToolStripButton();
            this.BtnSearch = new System.Windows.Forms.ToolStripButton();
            this.BtnBookmark = new System.Windows.Forms.ToolStripButton();
            this.BtnPrevious = new System.Windows.Forms.ToolStripButton();
            this.BtnNext = new System.Windows.Forms.ToolStripButton();
            this.BtnClearBookmarks = new System.Windows.Forms.ToolStripButton();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.BtnLoad = new System.Windows.Forms.ToolStripButton();
            this.BtnShowHideResults = new System.Windows.Forms.ToolStripButton();
            this.BDTxt = new System.Windows.Forms.ToolStripTextBox();
            this.ServerTxt = new System.Windows.Forms.ToolStripTextBox();
            this.ActionsToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Query
            // 
            this.Query.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Query.IsIconBarVisible = true;
            this.Query.IsReadOnly = false;
            this.Query.Location = new System.Drawing.Point(0, 30);
            this.Query.Name = "Query";
            this.Query.ShowVRuler = false;
            this.Query.Size = new System.Drawing.Size(785, 361);
            this.Query.TabIndex = 2;
            this.Query.Load += new System.EventHandler(this.Query_Load);
            // 
            // ActionsToolStrip
            // 
            this.ActionsToolStrip.AutoSize = false;
            this.ActionsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ActionsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnExecute,
            this.BtnStop,
            this.BtnExtremeStop,
            this.BtnComment,
            this.BtnUncomment,
            this.BtnSearch,
            this.BtnBookmark,
            this.BtnPrevious,
            this.BtnNext,
            this.BtnClearBookmarks,
            this.BtnSave,
            this.BtnLoad,
            this.BtnShowHideResults,
            this.BDTxt,
            this.ServerTxt});
            this.ActionsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ActionsToolStrip.Name = "ActionsToolStrip";
            this.ActionsToolStrip.Size = new System.Drawing.Size(785, 30);
            this.ActionsToolStrip.TabIndex = 3;
            this.ActionsToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ActionsToolStrip_ItemClicked);
            // 
            // BtnExecute
            // 
            this.BtnExecute.AutoSize = false;
            this.BtnExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnExecute.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExecute.Name = "BtnExecute";
            this.BtnExecute.Size = new System.Drawing.Size(28, 28);
            this.BtnExecute.ToolTipText = "Execute query (F5)";
            // 
            // BtnStop
            // 
            this.BtnStop.AutoSize = false;
            this.BtnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnStop.Enabled = false;
            this.BtnStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(28, 28);
            this.BtnStop.ToolTipText = "Stop execution(Shift + F5)";
            // 
            // BtnExtremeStop
            // 
            this.BtnExtremeStop.AutoSize = false;
            this.BtnExtremeStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnExtremeStop.Enabled = false;
            this.BtnExtremeStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnExtremeStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExtremeStop.Name = "BtnExtremeStop";
            this.BtnExtremeStop.Size = new System.Drawing.Size(28, 28);
            this.BtnExtremeStop.ToolTipText = "Force the stop execution(Ctr + F5)";
            // 
            // BtnComment
            // 
            this.BtnComment.AutoSize = false;
            this.BtnComment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnComment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnComment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnComment.Name = "BtnComment";
            this.BtnComment.Size = new System.Drawing.Size(28, 28);
            this.BtnComment.ToolTipText = "Comment lines (Ctr + K, C)";
            // 
            // BtnUncomment
            // 
            this.BtnUncomment.AutoSize = false;
            this.BtnUncomment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnUncomment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnUncomment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUncomment.Name = "BtnUncomment";
            this.BtnUncomment.Size = new System.Drawing.Size(28, 28);
            this.BtnUncomment.ToolTipText = "Uncomment lines(Ctr + K, U)";
            // 
            // BtnSearch
            // 
            this.BtnSearch.AutoSize = false;
            this.BtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(28, 28);
            this.BtnSearch.ToolTipText = "Search (Ctr + F)";
            // 
            // BtnBookmark
            // 
            this.BtnBookmark.AutoSize = false;
            this.BtnBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnBookmark.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnBookmark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnBookmark.Name = "BtnBookmark";
            this.BtnBookmark.Size = new System.Drawing.Size(28, 28);
            this.BtnBookmark.ToolTipText = "Toggle bookmark(F2)";
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.AutoSize = false;
            this.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(28, 28);
            this.BtnPrevious.ToolTipText = "Go to previous bookmark (Shift + F2)";
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
            this.BtnNext.ToolTipText = "Go to next bookmark (Ctr + F2)";
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnClearBookmarks
            // 
            this.BtnClearBookmarks.AutoSize = false;
            this.BtnClearBookmarks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnClearBookmarks.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnClearBookmarks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnClearBookmarks.Name = "BtnClearBookmarks";
            this.BtnClearBookmarks.Size = new System.Drawing.Size(28, 28);
            this.BtnClearBookmarks.ToolTipText = "Clear bookmarks (Ctr + Shift + F2)";
            // 
            // BtnSave
            // 
            this.BtnSave.AutoSize = false;
            this.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(28, 28);
            this.BtnSave.ToolTipText = "Save script to file (Ctr + G)";
            // 
            // BtnLoad
            // 
            this.BtnLoad.AutoSize = false;
            this.BtnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnLoad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(28, 28);
            this.BtnLoad.ToolTipText = "Load file (Ctr + L)";
            // 
            // BtnShowHideResults
            // 
            this.BtnShowHideResults.AutoSize = false;
            this.BtnShowHideResults.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnShowHideResults.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnShowHideResults.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnShowHideResults.Name = "BtnShowHideResults";
            this.BtnShowHideResults.Size = new System.Drawing.Size(28, 28);
            this.BtnShowHideResults.ToolTipText = "Show/hide results tab (Ctr + W)";
            // 
            // BDTxt
            // 
            this.BDTxt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BDTxt.Name = "BDTxt";
            this.BDTxt.ReadOnly = true;
            this.BDTxt.Size = new System.Drawing.Size(180, 30);
            // 
            // ServerTxt
            // 
            this.ServerTxt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ServerTxt.Name = "ServerTxt";
            this.ServerTxt.ReadOnly = true;
            this.ServerTxt.Size = new System.Drawing.Size(180, 30);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 391);
            this.Controls.Add(this.Query);
            this.Controls.Add(this.ActionsToolStrip);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ActionsToolStrip.ResumeLayout(false);
            this.ActionsToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl Query;
        private System.Windows.Forms.ToolStrip ActionsToolStrip;
        private System.Windows.Forms.ToolStripButton BtnExecute;
        private System.Windows.Forms.ToolStripButton BtnStop;
        private System.Windows.Forms.ToolStripButton BtnExtremeStop;
        private System.Windows.Forms.ToolStripButton BtnComment;
        private System.Windows.Forms.ToolStripButton BtnUncomment;
        private System.Windows.Forms.ToolStripButton BtnSearch;
        private System.Windows.Forms.ToolStripButton BtnBookmark;
        private System.Windows.Forms.ToolStripButton BtnPrevious;
        private System.Windows.Forms.ToolStripButton BtnNext;
        private System.Windows.Forms.ToolStripButton BtnClearBookmarks;
        private System.Windows.Forms.ToolStripButton BtnSave;
        private System.Windows.Forms.ToolStripButton BtnLoad;
        private System.Windows.Forms.ToolStripButton BtnShowHideResults;
        private System.Windows.Forms.ToolStripTextBox BDTxt;
        private System.Windows.Forms.ToolStripTextBox ServerTxt;
    }
}