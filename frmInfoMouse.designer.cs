namespace VMS
{
    partial class frmInfoMouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoMouse));
            this.labelWheel = new System.Windows.Forms.Label();
            this.labelMousePosition = new System.Windows.Forms.Label();
            this.globalEventProvider1 = new Gma.UserActivityMonitor.GlobalEventProvider();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelWheel
            // 
            this.labelWheel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWheel.AutoSize = true;
            this.labelWheel.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWheel.Location = new System.Drawing.Point(13, 58);
            this.labelWheel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWheel.Name = "labelWheel";
            this.labelWheel.Size = new System.Drawing.Size(134, 17);
            this.labelWheel.TabIndex = 9;
            this.labelWheel.Text = "Wheel={0:####}";
            // 
            // labelMousePosition
            // 
            this.labelMousePosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMousePosition.AutoSize = true;
            this.labelMousePosition.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMousePosition.Location = new System.Drawing.Point(13, 26);
            this.labelMousePosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMousePosition.Name = "labelMousePosition";
            this.labelMousePosition.Size = new System.Drawing.Size(206, 17);
            this.labelMousePosition.TabIndex = 7;
            this.labelMousePosition.Text = "x={0:####}; y={1:####}";
            // 
            // globalEventProvider1
            // 
            this.globalEventProvider1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HookManager_MouseMove);
            this.globalEventProvider1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HookManager_MouseClick);
            this.globalEventProvider1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HookManager_MouseDown);
            this.globalEventProvider1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HookManager_MouseUp);
            this.globalEventProvider1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HookManager_MouseDoubleClick);
            this.globalEventProvider1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HookManager_KeyPress);
            this.globalEventProvider1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HookManager_KeyUp);
            this.globalEventProvider1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HookManager_KeyDown);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 1000;
            this.toolTip1.ShowAlways = true;
            // 
            // frmInfoMaouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(282, 96);
            this.Controls.Add(this.labelWheel);
            this.Controls.Add(this.labelMousePosition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInfoMaouse";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestione Click Mouse";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Activated += new System.EventHandler(this.TestFormComponent_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestFormComponent_FormClosed);
            this.Load += new System.EventHandler(this.TestFormComponent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelWheel;
        private System.Windows.Forms.Label labelMousePosition;
        private Gma.UserActivityMonitor.GlobalEventProvider globalEventProvider1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}