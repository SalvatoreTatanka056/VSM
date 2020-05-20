using System;
using System.Drawing;
using System.Windows.Forms;


namespace VMS
{
    public partial class frmInfoMouse : Form
    {
        public bool lblmove;
        public int m_intX, m_intY,m_iLeft,m_iRight;
        public int m_intX_1, m_intY_1;

        public frmMain MainForm { get; set; }

        public frmInfoMouse(int intX,int intY)
        {
            InitializeComponent();

            m_intX_1 = intX;
            m_intY_1 = intY;
           //lblmove = true;
        }

        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            if (lblmove)
            {

                Point poit = AutoIt.AutoItX.MouseGetPos();
                labelMousePosition.Text = string.Format("x={0:0000}; y={1:0000}", poit.X, poit.Y);

                m_intX = poit.X;
                m_intY = poit.Y;

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
            
            if (lblmove)
            {
                if (m_iLeft == 1)
                {
                    Application.OpenForms["frmMain"].Controls["Query"].Text = Application.OpenForms["frmMain"].Controls["Query"].Text + string.Format("XY_L {0}-{1};\n", m_intX, m_intY);

                }
                else
                {
                    Application.OpenForms["frmMain"].Controls["Query"].Text = Application.OpenForms["frmMain"].Controls["Query"].Text + string.Format("XY_R {0}-{1};\n", m_intX, m_intY);
                }

            }

            lblmove = false;

            this.Dispose();
        }

        private void labelMousePosition_Click(object sender, EventArgs e)
        {

        }

        private void TestFormComponent_Load(object sender, System.EventArgs e)
        {

            lblmove = true;

        }

        private void TestFormComponent_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            
        }
    }
}
