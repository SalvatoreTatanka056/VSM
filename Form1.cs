using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace MacroIE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        // constants for the mouse_input() API function
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;


        // simulates movement of the mouse.  parameters specify changes
        // in relative position.  positive values indicate movement
        // right or down
        public static void Move(int xDelta, int yDelta)
        {
            mouse_event(MOUSEEVENTF_MOVE, xDelta, yDelta, 0, 0);
        }


        // simulates movement of the mouse.  parameters specify an
        // absolute location, with the top left corner being the
        // origin
        public static void MoveTo(int x, int y)
        {
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, x, y, 0, 0);
        }


        // simulates a click-and-release action of the left mouse
        // button at its current position
        public static void LeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {


            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "iexplore";
            proc.StartInfo.Arguments = @"http://10.72.16.45/";
            proc.Start();
         

            Thread.Sleep(2000);
            LeftClick();
            Thread.Sleep(2000);
            SendKeys.Send("+{TAB}");
            Thread.Sleep(1000);
            SendKeys.Send("{DOWN 15}");
            Thread.Sleep(200);
            SendKeys.Send("{TAB}");
            Thread.Sleep(200);
            SendKeys.Send("OPE");
            Thread.Sleep(2000);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(2000);
            SendKeys.Send(textBox1.Text);
            Thread.Sleep(2000);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(2000);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(2000);
            SendKeys.Send("{ENTER}");
            

            proc.Close();
            proc.Dispose();

            //Thread.Sleep(5000);
            SendKeys.Send("%{F4}");

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
