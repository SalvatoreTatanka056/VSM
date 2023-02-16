using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace CodeCompletion_CSharp
{
    public class MyListBox : ListBox
    {
        public MyListBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.Graphics.DrawRectangle(new Pen(Brushes.AliceBlue), 0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            e.DrawBackground();
            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int itemindex = e.Index;
            if (itemindex >= 0 && itemindex < this.Items.Count)
            {
                if (isItemSelected)
                {
                    Brush br = new SolidBrush(Color.DodgerBlue);
                    Graphics g = e.Graphics;
                    g.FillRectangle(br, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                    String itemtext = this.Items[itemindex].ToString();
                    SolidBrush textbrush = new SolidBrush((isItemSelected) ? Color.FromArgb(230, 230, 230) : Color.Black);
                    Font fnt = new System.Drawing.Font("Serif", 9 , FontStyle.Regular);
                    g.DrawString("      "+itemtext, fnt, textbrush, this.GetItemRectangle(itemindex).Location.X, this.GetItemRectangle(itemindex).Location.Y - 2);

                    Icon newIcon = new Icon("favicon.ico");
                    Rectangle rect = new Rectangle(this.GetItemRectangle(itemindex).Location.X, this.GetItemRectangle(itemindex).Location.Y - 3, 16, 16);
                    e.Graphics.DrawIconUnstretched(newIcon, rect);
                }
                else
                {
                    Brush br = new SolidBrush(Color.FromArgb(250, 250, 230)); 
                    Graphics g = e.Graphics;
                    g.FillRectangle(br, e.Bounds.X, e.Bounds.Y-1, e.Bounds.Width, e.Bounds.Height);
                    String itemtext = this.Items[itemindex].ToString();
                    SolidBrush textbrush = new SolidBrush((isItemSelected) ? Color.White : Color.Black);
                    Font fnt = new System.Drawing.Font("Serif", 9, FontStyle.Regular);
                    g.DrawString("      "+itemtext, fnt, textbrush, this.GetItemRectangle(itemindex).Location.X, this.GetItemRectangle(itemindex).Location.Y-3);
                    
                    Icon newIcon = new Icon("favicon.ico");
                    Rectangle rect = new Rectangle(this.GetItemRectangle(itemindex).Location.X, this.GetItemRectangle(itemindex).Location.Y - 3, 16, 16);
                    e.Graphics.DrawIconUnstretched(newIcon, rect);
                }
                
            }
            e.DrawFocusRectangle();
        }
    }
}
