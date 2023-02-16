using System;
using System.Windows.Forms;
using System.Drawing;
namespace CodeCompletion_CSharp
{
    public class ToolTipControlPanel : PanelZ
    {
        public Label tooltip = new Label();

        public String tooltiptext = "";

        public Color tooltipcolor = Color.Black;

        public ToolTipControlPanel()
        {
            this.StartColor = Color.FromArgb(240, 240, 250);
            this.EndColor = Color.FromArgb(220, 220, 240);
            this.Width = 2;
            this.Height = 2;

            this.tooltip.BackColor = Color.Transparent;
            this.tooltip.AutoSize = true;
            this.tooltip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tooltip.Location = new System.Drawing.Point(5, 4);
            this.tooltip.Name = "tooltip";
            this.tooltip.Size = new System.Drawing.Size(100, 23);
            this.Controls.Add(tooltip);
        }

        public String ToolTipText
        {
            get { return tooltiptext; }
            set { tooltiptext = value; tooltip.Text = value; Invalidate(); }
        }

        public Color ToolTipColor
        {
            get { return tooltipcolor; }
            set { tooltipcolor = value; tooltip.ForeColor = value; Invalidate(); }
        }

    }
}
