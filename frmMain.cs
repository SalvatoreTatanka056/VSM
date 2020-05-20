using System;
using System.Drawing;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using System.Threading;
using System.IO;
using ICSharpCode.TextEditor;
using System.Diagnostics;
using VMS.Properties;

namespace VMS
{
    public partial class frmMain : Form
    {
        /* Varibili Globali al Modulo*/
        public Icon[] images;
        public int offset = 0;
        public string strMacro;
        public int _iCicli;
        public frmInfoMouse frm;
        public string strReadFile;

        /* Varibili Globali al Modulo Gestione Mouse */
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public int m_intX, m_intY;
        public int m_intX_1, m_intY_1;
        public bool m_cnf = false;


        /* Importazione dei Metodi per Gestione Mouse */
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x , int y);

        /* Importazione dei Metodi per Gestione Mouse */
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags , int dx , int dy , int cButtons , int dwExtraInfo);

        public frmMain()
        {
            InitializeComponent();

            try
            {
                HighlightingManager.Manager.AddSyntaxModeFileProvider(new FileSyntaxModeProvider("SintaxHighLight\\"));
                Query.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("SQL");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public static void LeftMouseClick(int xpos , int ypos)
        {
            Cursor.Position = new Point(xpos , ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN , xpos , ypos , 0 , 0);
            mouse_event(MOUSEEVENTF_LEFTUP , xpos , ypos , 0 , 0);
        }
        public static void RightMouseClick(int xpos , int ypos)
        {
            Cursor.Position = new Point(xpos , ypos);
            mouse_event(MOUSEEVENTF_RIGHTDOWN , xpos , ypos , 0 , 0);
            mouse_event(MOUSEEVENTF_RIGHTUP , xpos , ypos , 0 , 0);
        }

        private void BtnNext_Click(object sender , EventArgs e)
        {

            frmMain.ActiveForm.WindowState = FormWindowState.Minimized;
            strMacro = Query.Text;

            if (strMacro == "")
                return;

            /* Esecuzione thread per esecuzione comandi */
            EseguiMacro();
            Application.Exit();
        }

        /* esecuzione dei comandi salvati */
        private void EseguiMacro()
        {
           
            if (TStxtCicli.Text != "")
                _iCicli = Convert.ToInt16(TStxtCicli.Text);

            int AttesaOperazione = Convert.ToInt16(toolStripTextBox3.Text);


            for (int i = 0 ; i < _iCicli ; i++)
            {
                /* Compila Script */
                string strCompilazione = "";
                strCompilazione = strMacro.Replace("\n" , "");
                strCompilazione = strCompilazione.Replace("\r" , "");
                strCompilazione = strCompilazione.Replace("\n" , "");
                strCompilazione = strCompilazione.Replace("\t" , "");

                string[] str = strCompilazione.Split(';');

                Thread.Sleep(AttesaOperazione);

                foreach (string strSendMessage in str)
                {

                    /* avviare programma esterno */
                    if (strSendMessage.Length > 4 && strSendMessage.Substring(0 , 4) == "Run=")
                    {
                        string sRunProcess = strSendMessage.Substring(4).ToString();
                        System.Diagnostics.Process.Start(sRunProcess);
                        Thread.Sleep(5000);
                    }
                    /* atteso tempo */
                    else if (strSendMessage.Length > 1 && strSendMessage.Substring(0 , 2) == "T=")
                    {
                        string strTimer = strSendMessage.Substring(2).ToString();
                        Thread.Sleep(Convert.ToInt32(strTimer));

                    }
                    /* esegue spostamento del mouse ed esegue click pulsante sinistro */
                    else if (strSendMessage.Length > 3 && strSendMessage.Substring(0 , 4) == "XY_L"/*strSendMessage.IndexOf("XY") != -1*/)
                    {
                        string[] strCoordXY = strSendMessage.Substring(5).Split('-');
                        m_intX = Convert.ToInt16(strCoordXY[0]);
                        m_intY = Convert.ToInt16(strCoordXY[1]);
                        LeftMouseClick(m_intX , m_intY);
                        Thread.Sleep(AttesaOperazione);
                    }
                    /* esegue spostamento del mouse ed esegue click pulsante destro */
                    else if (strSendMessage.Length > 3 && strSendMessage.Substring(0 , 4) == "XY_R"/*strSendMessage.IndexOf("XY") != -1*/)
                    {

                        string[] strCoordXY = strSendMessage.Substring(5).Split('-');
                        m_intX = Convert.ToInt16(strCoordXY[0]);
                        m_intY = Convert.ToInt16(strCoordXY[1]);
                        RightMouseClick(m_intX , m_intY);
                        Thread.Sleep(AttesaOperazione);
                    }
                    else
                    {
                        /*  invia messaggi sendkeys --> */ 
                        SendKeys.SendWait(strSendMessage);
                        Thread.Sleep(AttesaOperazione);
                    }

                    Application.DoEvents();
                }

                string tmp_operation = string.Format("Terminato {0}/{1}" , i + 1 , _iCicli);
                nfiMain.ShowBalloonTip(0, "Script" , tmp_operation , ToolTipIcon.Info);
                nfiMain.BalloonTipClosed += (sender , e) => nfiMain.Dispose();
            }
        }

        private void toolStripButton1_Click(object sender , EventArgs e)
        {
            string tempPath = "";

            opFDMain.FileName = "*.exe";
            opFDMain.DefaultExt = ".exe";
            opFDMain.Filter = "Script (*.exe)|*.exe";

            if (opFDMain.ShowDialog(this) == DialogResult.OK)
            {
                tempPath = opFDMain.FileName;
               
            }
        }

        private void BtnScegliApplicazione_Click(object sender , EventArgs e)
        {
            string dummy = "file.vsm";
            string path = "";
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = dummy;
            sf.DefaultExt = ".vsm";
            sf.Filter = "Script (*.vsm)|*.vsm";
            if (sf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                path = sf.FileName;
                File.WriteAllText(path , Query.Text);
            }
        }

        private void BtnOpen_Click(object sender , EventArgs e)
        {

            opFDMain.Filter = "Script (*.vsm)|*.vsm";
            opFDMain.FileName = "*.vsm";
            opFDMain.DefaultExt = ".vsm";
            opFDMain.Filter = "Script (*.vsm)|*.vsm";

            if (opFDMain.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                    System.IO.StreamReader(opFDMain.FileName);
                Query.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg , Keys keyData)
        {

            if (keyData == (Keys.Control | Keys.F))
            {
                frmFind frmCerca = new frmFind(Query);
                frmCerca.Show();

                return true;
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                BtnScegliApplicazione_Click(BtnExtremeStop , new EventArgs());
                return true;
            }
            else if (keyData == (Keys.Control | Keys.O))
            {
                BtnOpen_Click(BtnComment , new EventArgs());
                return true;
            }

            return base.ProcessCmdKey(ref msg , keyData);
        }

        /* Gestione Ricerca sull'Editor */
        private void BtnFind_Click(object sender , EventArgs e)
        {

            FindAndReplaceForm _findForm = new FindAndReplaceForm();

            TextEditorControl editor = Query;
            if (editor == null) return;
            _findForm.ShowFor(editor , false);
        }

        /* Caricamento Form Principale */
        private void frmMain_Load(object sender , EventArgs e)
        {

            string[] args = Environment.GetCommandLineArgs();

            foreach (string arg in args)
            {
                if (arg.IndexOf(".vsm") != -1)
                {
                    Query.Text = File.ReadAllText(arg);

                }
            }

            /* Caricament o Icone Per Animazione in tray */
            images = new Icon[8];
            images[0] = new Icon("Rotate1.ico");
            images[1] = new Icon("Rotate2.ico");
            images[2] = new Icon("Rotate3.ico");
            images[3] = new Icon("Rotate4.ico");
            images[4] = new Icon("Rotate5.ico");
            images[5] = new Icon("Rotate6.ico");
            images[6] = new Icon("Rotate7.ico");
            images[7] = new Icon("Rotate8.ico");

            //pblnThreadTray = true;
            nfiMain.Icon = images[0];

            /* Gestione Parametri di Default */
            toolStripTextBox3.Text = "1000";
            TStxtCicli.Text = "1";

            /* Disabilita di controlli dei parametri */
            TStxtCicli.Enabled = false;

        }

        /* Dispose di Tutti gli Oggetti e scaricamento della frmMain */
        private void frmMain_FormClosed(object sender , FormClosedEventArgs e)
        {
            this.Controls.Clear();
            this.Dispose();
            globalEventProvider1.Dispose();
            Application.Exit();
        }

        /* Recupera Coordinate X,Y del Click Mouse da ripetere */
        private void BtnBookmark_Click(object sender , EventArgs e)
        {
            Point poit = AutoIt.AutoItX.MouseGetPos();

            m_intX_1 = poit.X;
            m_intY_1 = poit.Y;

            this.Query.Enabled = false;
            BtnBookmark.Enabled = false;

            frm = new frmInfoMouse( m_intX_1, m_intY_1);
            frm.Show();
            
        }

        /* Chiusura Form Mouse */
        void frm_FormClosed(object sender , FormClosedEventArgs e)
        {
       

        }

        /* Parametro Cicli di esecuzione Script */
        private void TStxtCicli_Click(object sender , EventArgs e)
        {
            /* Se il campo cicli e' valido */
            if (TStxtCicli.Text != "")
                _iCicli = Convert.ToInt16(TStxtCicli.Text);
        }

        private void BtnSearch_Click(object sender , EventArgs e)
        {
       
            int tot = 0;

            if(Convert.ToInt32(TStxtCicli.Text) < 1 )
            {
                TStxtCicli.Text = "1";

            }
            else
            {
                tot = Convert.ToInt32(TStxtCicli.Text) - 1;
                if (tot == 0)
                {
                    tot += 1;
                    TStxtCicli.Text = tot.ToString();
                }
                else
                {
                    TStxtCicli.Text = tot.ToString();
                }

            }
        }

        private void Query_Load(object sender , EventArgs e)
        {
            

        }

        public int m_Timer = 2000;

        private void toolStripButton2_Click_1(object sender , EventArgs e)
        {

            strReadFile = "";


            var editor = Query;
            if (editor != null)
            {
                fontDialog.Font = editor.Font;
                if (fontDialog.ShowDialog(this) == DialogResult.OK)
                {
                    editor.Font = fontDialog.Font;
                }
            }

        }

        private void leggiToolStripMenuItem_Click(object sender , EventArgs e)
        {
            leggiToolStripMenuItem.Checked = !leggiToolStripMenuItem.Checked;

            if (leggiToolStripMenuItem.Checked)
            {
                Query.Text = Query.Text + "$FNomefile.txt\r\n$1\r\n";
            }
            else
            {
                Query.Text = Query.Text.Replace("$FNomefile.txt\r\n" , "");
                Query.Text = Query.Text.Replace("$1\r\n" , "");
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender , MouseEventArgs e)
        {

            nfiMain.Visible = false;
            frmMain.ActiveForm.WindowState = FormWindowState.Normal;
            _iCicli = 0;
        }

        private void nfiMain_BalloonTipClosed(object sender , EventArgs e) => Dispose();

        private void toolStripButton3_Click(object sender , EventArgs e)
        {
            Form frm = new frmHelp();
            frm.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Click(object sender, EventArgs e)
        {
            this.Query.Enabled = true;
            BtnBookmark.Enabled = true; 
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            int tot = 0;

            if (Convert.ToInt32(TStxtCicli.Text) <= 0)
            {
                TStxtCicli.Text = "1";
            }
            else
            {
                tot = Convert.ToInt32(TStxtCicli.Text) + 1;
                TStxtCicli.Text = tot.ToString();
            }
        }
        private void exitToolStripMenuItem_Click(object sender , EventArgs e)
        {
            nfiMain.Visible = false;
            nfiMain.Dispose();
            Application.Exit();

        }
    }
}
