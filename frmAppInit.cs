using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace VSM
{
    public partial class frmAppInit : Form
    {

        public frmMain frmM;
        public bool blnPresentazione = true;

        public frmAppInit()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Activated_1(object sender, EventArgs e)
        {
            if (blnPresentazione)
            {
                this.Invalidate();
                Application.DoEvents();

                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;

                for (int i = 0; i < 100; i++)
                {
                    progressBar1.Value = i;
                    Thread.Sleep(30);
                }

                blnPresentazione = false;

                Thread.Sleep(2000);
                Hide();
                frmMain frmM = new frmMain();
                frmM.FormClosed += new FormClosedEventHandler(frmM_FormClosed);
                frmM.Show();

                
            }

        }

        void frmM_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmM != null)
                frmM = null;
            this.Dispose();
            //throw new NotImplementedException();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
