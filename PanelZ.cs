using System;
using System.Drawing;
using System.Windows.Forms;
namespace CodeCompletion_CSharp
{
    public class PanelZ : System.Windows.Forms.Panel
    {
        private Color color1 = Color.SteelBlue;
        private Color color2 = Color.DarkBlue;
        private int color1Transparent = 150;
        private int color2Transparent = 150;
        private Color bdrcolor = Color.FromArgb(180, 180, 180);
        private int angle = 90;

        public Color StartColor
        {
            get { return color1; }
            set { color1 = value; Invalidate(); }
        }
        public Color EndColor
        {
            get { return color2; }
            set { color2 = value; Invalidate(); }
        }
        public Color BorderColor
        {
            get { return bdrcolor; }
            set { bdrcolor = value; Invalidate(); }
        }
        public int Transparent1
        {
            get { return color1Transparent; }
            set
            {
                color1Transparent = value;
                if (color1Transparent > 255)
                {
                    color1Transparent = 255;
                    Invalidate();
                }
                else
                    Invalidate();
            }
        }

        public int Transparent2
        {
            get { return color2Transparent; }
            set
            {
                color2Transparent = value;
                if (color2Transparent > 255)
                {
                    color2Transparent = 255;
                    Invalidate();
                }
                else
                    Invalidate();
            }
        }

        public int GradientAngle
        {
            get { return angle; }
            set { angle = value; Invalidate(); }
        }
        public PanelZ()
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Color c1 = Color.FromArgb(color1Transparent, color1);
            Color c2 = Color.FromArgb(color2Transparent, color2);
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, c1, c2, angle);
            e.Graphics.FillRectangle(b, ClientRectangle);

            e.Graphics.DrawRectangle(new Pen(bdrcolor), 0, 0, this.Width - 1, 1);
            e.Graphics.DrawRectangle(new Pen(bdrcolor), 0, 0, 1, this.Height - 1);
            e.Graphics.DrawRectangle(new Pen(bdrcolor), this.Width - 1, 0, 1, this.Height - 1);
            e.Graphics.DrawRectangle(new Pen(bdrcolor), 0, this.Height - 1, this.Width - 1, 1);

            b.Dispose();
        }
    }
}
