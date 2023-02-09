﻿using System.Windows.Forms;

namespace VMS
{
    public partial class frmInfoMouse : Form
    {
        public bool lblmove;
        public int m_intX, m_intY,m_iLeft,m_iRight;
        public Form frmMain;

        public frmInfoMouse(frmMain HostForm)
        {
            InitializeComponent();

            frmMain = HostForm;
            lblmove = true;
        }

        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void HookManager_KeyUp(object sender, KeyEventArgs e)
        {
            //textBoxLog.AppendText(string.Format("KeyUp - {0}\n", e.KeyCode));
            //textBoxLog.ScrollToCaret();
        }

        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textBoxLog.AppendText(string.Format("KeyPress - {0}\n", e.KeyChar));
            //textBoxLog.ScrollToCaret();
        }

        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            if (lblmove)
            {
                labelMousePosition.Text = string.Format("x={0:0000}; y={1:0000}", e.X, e.Y);

                m_intX = e.X;
                m_intY = e.Y;

            }
        }

        private void HookManager_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                m_iLeft = 1;
                m_iRight = 0;
            }
            else
            {
                m_iLeft = 0;
                m_iRight = 1;
            }

           
            lblmove = false;
            Stop();
        }

        public void Stop()
        {
            this.Controls.Clear();
            Close();
            Dispose();
        }

        private void HookManager_MouseUp(object sender, MouseEventArgs e)
        {
       
        }

        private void HookManager_MouseDown(object sender, MouseEventArgs e)
        {
         
        }

        private void HookManager_MouseDoubleClick(object sender, MouseEventArgs e)
        {
       
        }

        private void HookManager_MouseWheel(object sender, MouseEventArgs e)
        {
            labelWheel.Text = string.Format("Wheel={0:000}", e.Delta);
        }

          private void TestFormComponent_Load(object sender, System.EventArgs e)
        {

             lblmove = true;
        }

        private void TestFormComponent_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(m_iLeft == 1)
                Application.OpenForms["frmMain"].Controls["Query"].Text = Application.OpenForms["frmMain"].Controls["Query"].Text + string.Format("XY_L {0}-{1};\n", m_intX-50, m_intY-90);
            else
                Application.OpenForms["frmMain"].Controls["Query"].Text = Application.OpenForms["frmMain"].Controls["Query"].Text + string.Format("XY_R {0}-{1};\n", m_intX-50, m_intY-90);

            //HookManager_MouseClick(Application.OpenForms["frmMain"].Controls["Query"],null);


            this.Dispose();
        }

        private void TestFormComponent_Activated(object sender, System.EventArgs e)
        {

            lblmove = true;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            
        }
    }
}
