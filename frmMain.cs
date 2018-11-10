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
        public bool pblnThreadTray = true;
        public int _iCicli;
        public ThreadStart childref1;
        public Thread childThread1;
        public ThreadStart childref2;
        public Thread childThread2;
        public TestFormComponent frm;
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


        /* Importazione dei Metodi per Gestione Mouse */
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x , int y);

        /* Importazione dei Metodi per Gestione Mouse */
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags , int dx , int dy , int cButtons , int dwExtraInfo);

        /// <summary>
        ///  Implementazione Costruttore frmMain
        /// </summary>
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

        /// <summary>
        /// Simula un'azione click-and-release del tasto sinistro del mouse
        /// </summary>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

        /// <summary>
        /// Simula un'azione click-and-release del tasto destro del mouse
        /// </summary>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        public static void RightMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, xpos, ypos, 0, 0);
        }

        /// Avvio Script Virtual SendMessage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNext_Click(object sender, EventArgs e)
        {

            frmMain.ActiveForm.WindowState = FormWindowState.Minimized;
            strMacro = Query.Text;

            if (strMacro == "")
                return;

            /* Esecuzione icona in Tray */
            childref1 = new ThreadStart(RotateIconTray);
            childThread1 = new Thread(childref1);
            childThread1.Start();

            /* Esecuzione thread per esecuzione comandi */
            childref2 = new ThreadStart(EseguiMacro);
            childThread2 = new Thread(childref2);
            childThread2.Start();

            /* Mettere in Join i thread*/
            childThread2.Join();
            childThread1.Join();

        }

        /// <summary>
        /// Esecuzione Macro
        /// </summary>
        private void EseguiMacro()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = toolStripTextBox1.Text;
            proc.StartInfo.Arguments = toolStripTextBox1.Text;
            DialogResult dlg;

            if (TStxtCicli.Text != "")
                _iCicli = Convert.ToInt16(TStxtCicli.Text);

            if (toolStripTextBox1.Text == "")
            {
                dlg = MessageBox.Show("Attenzione non si è scelto nessun programma da eseguire!\n i comandi verranno eseguiti comunque\n si vuole continuare?", "Nessun programma scelto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlg == DialogResult.No)
                {
                    notifyIcon1.Visible = false;
                    proc.Close();
                    proc.Dispose();
                    notifyIcon1.ShowBalloonTip(1000, "Script", "Script Terminato", ToolTipIcon.Info);
                    pblnThreadTray = false;
                    return;
                }
            }
            else
            {
                try
                {
                    proc.Start();
                }
                catch
                {
                    notifyIcon1.ShowBalloonTip(1000, "Script", "Script Terminato", ToolTipIcon.Info);
                    pblnThreadTray = false;
                    return;
                };
            }

            /* Nascondi l'icona */
            notifyIcon1.Visible = true;

            for (int i = 0; i < _iCicli; i++)
            {
                try
                {
                    /* Compila Script */
                    string strCompilazione = "";
                    strCompilazione = strMacro.Replace("\n", "");
                    strCompilazione = strCompilazione.Replace("\r", "");
                    strCompilazione = strCompilazione.Replace("\n", "");
                    strCompilazione = strCompilazione.Replace("\t", "");

                    string[] str = strCompilazione.Split(';');

                    Thread.Sleep(Convert.ToInt16(toolStripTextBox3.Text));

                    int iDSendMessage = 0;
                    StreamReader sr = null;
                    string LineRead = "";

                    if (str.Length > 0)
                    {
                        if (str[0].ToString().Substring(0, 2) == "$F")
                        {

                            try
                            {
                                sr = new StreamReader(str[0].ToString().Substring(2).ToString());
                            }
                            catch
                            {
                                MessageBox.Show("Attenzione!", "Errore Apertura File", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                            }
                        }
                    }

                    if (str[0].ToString().Substring(0, 2) == "$F")
                    {
                        while (sr.EndOfStream == false)
                        {

                            LineRead = sr.ReadLine();
                            /* importante posizionare i programmi aperti nella posiziona scelta
                             * ( oppure non utilizzare i click del mouse per alcune operazioni ) */
                            foreach (string strSendMessage in str)
                            {

                                if (strSendMessage.Length > 1 && strSendMessage.Substring(0, 2) == "$F")
                                {
                                    continue;
                                }

                                if (strSendMessage.Length > 1 && strSendMessage.Substring(0, 2) == "$1")
                                {

                                    SendKeys.SendWait(LineRead);
                                    Thread.Sleep(Convert.ToInt16(toolStripTextBox3.Text));
                                }


                                /* Gestione Mouse ... */
                                if (strSendMessage.Length > 1 && strSendMessage.Substring(0, 2) == "T=")
                                {
                                    string strTimer = strSendMessage.Substring(2).ToString();
                                    Thread.Sleep(Convert.ToInt16(strTimer));

                                }
                                else if (strSendMessage.Length > 3 && strSendMessage.Substring(0, 4) == "XY_L"
                                    /*strSendMessage.IndexOf("XY") != -1*/)
                                {
                                    string[] strCoordXY = strSendMessage.Substring(5).Split('-');
                                    m_intX = Convert.ToInt16(strCoordXY[0]);
                                    m_intY = Convert.ToInt16(strCoordXY[1]);
                                    LeftMouseClick(m_intX, m_intY);
                                    Thread.Sleep(Convert.ToInt16(toolStripTextBox3.Text));
                                }
                                else if (strSendMessage.Length > 3 && strSendMessage.Substring(0, 4) == "XY_R"
                                    /*strSendMessage.IndexOf("XY") != -1*/)
                                {

                                    string[] strCoordXY = strSendMessage.Substring(5).Split('-');
                                    m_intX = Convert.ToInt16(strCoordXY[0]);
                                    m_intY = Convert.ToInt16(strCoordXY[1]);
                                    RightMouseClick(m_intX, m_intY);
                                    Thread.Sleep(Convert.ToInt16(toolStripTextBox3.Text));
                                }
                                else
                                {

                                    if (strSendMessage.Length > 1 && strSendMessage.Substring(0, 2) == "$1")
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        SendKeys.SendWait(strSendMessage);
                                        Thread.Sleep(Convert.ToInt16(toolStripTextBox3.Text));
                                    }
                                }

                                Application.DoEvents();

                                iDSendMessage++;
                            }

                            Application.DoEvents();
                        }

                        string tmp_operation = string.Format("Terminato {0}/{1}", i + 1, _iCicli);

                        notifyIcon1.ShowBalloonTip(1000, "Script", tmp_operation, ToolTipIcon.Info);
                        pblnThreadTray = false;

                        sr.Close();
                        sr.Dispose();

                    }
                    else
                    {
                        /* importante posizionare i programmi aperti nella posiziona solita 
                         * ( oppure non utilizzare i click del mouse per alcune operazioni ) */
                        foreach (string strSendMessage in str)
                        {

                            /* Gestione Mouse ... */
                            if (strSendMessage.Length > 1 && strSendMessage.Substring(0, 2) == "T=")
                            {
                                string strTimer = strSendMessage.Substring(2).ToString();
                                Thread.Sleep(Convert.ToInt16(strTimer));

                            }
                            else if (strSendMessage.Length > 3 && strSendMessage.Substring(0, 4) == "XY_L"/*strSendMessage.IndexOf("XY") != -1*/)
                            {
                                string[] strCoordXY = strSendMessage.Substring(5).Split('-');
                                m_intX = Convert.ToInt16(strCoordXY[0]);
                                m_intY = Convert.ToInt16(strCoordXY[1]);
                                LeftMouseClick(m_intX, m_intY);
                                Thread.Sleep(Convert.ToInt16(toolStripTextBox3.Text));
                            }
                            else if (strSendMessage.Length > 3 && strSendMessage.Substring(0, 4) == "XY_R"/*strSendMessage.IndexOf("XY") != -1*/)
                            {

                                string[] strCoordXY = strSendMessage.Substring(5).Split('-');
                                m_intX = Convert.ToInt16(strCoordXY[0]);
                                m_intY = Convert.ToInt16(strCoordXY[1]);
                                RightMouseClick(m_intX, m_intY);
                                Thread.Sleep(Convert.ToInt16(toolStripTextBox3.Text));
                            }
                            else
                            {
                                SendKeys.SendWait(strSendMessage);
                                Thread.Sleep(Convert.ToInt16(toolStripTextBox3.Text));
                            }

                            iDSendMessage++;
                            Application.DoEvents();
                        }

                        string tmp_operation = string.Format("Terminato {0}/{1}", i + 1, _iCicli);


                        notifyIcon1.ShowBalloonTip(1000, "Script", tmp_operation, ToolTipIcon.Info);
                        pblnThreadTray = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message.ToString());
                    notifyIcon1.ShowBalloonTip(1000, "Script", "Script Terminato", ToolTipIcon.Info);
                    pblnThreadTray = false;
                }
            }

            Thread.Sleep(1000);
            notifyIcon1.Visible = false;
            proc.Close();
            proc.Dispose();

        }

        /// <summary>
        /// Scelta Eseguibile su cui Inviare Messaggi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string tempPath = "";

            openFileDialog1.FileName = "*.exe";
            openFileDialog1.DefaultExt = ".exe";
            openFileDialog1.Filter = "Script (*.exe)|*.exe";

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                tempPath = openFileDialog1.FileName;
                toolStripTextBox1.Text = tempPath;
            }
        }

        /// <summary>
        /// Salvataggio su Disco lo Script Creato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnScegliApplicazione_Click(object sender, EventArgs e)
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
                File.WriteAllText(path, Query.Text);
            }
        }

        /// <summary>
        /// Aprire Script Creato in Precedenza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpen_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Script (*.vsm)|*.vsm";
            openFileDialog1.FileName = "*.vsm";
            openFileDialog1.DefaultExt = ".vsm";
            openFileDialog1.Filter = "Script (*.vsm)|*.vsm";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                Query.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        /// <summary>
        /// Messaggio di Attesa in Tray con Animazione
        /// </summary>
        private void RotateIconTray()
        {
            try
            {
                while (true)
                {
                    notifyIcon1.Icon = images[offset];
                    offset++;
                    if (offset > 6) offset = 0;

                    if (!pblnThreadTray)
                        return;

                    Thread.Sleep(100);
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
                return;
            }
        }

        /// <summary>
        /// Gestore Comandi da Tastiera
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Control | Keys.F))
            {
                frmFind frmCerca = new frmFind(Query);
                frmCerca.Show();

                return true;
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                BtnScegliApplicazione_Click(BtnExtremeStop, new EventArgs());
                return true;
            }
            else if (keyData == (Keys.Control | Keys.O))
            {
                BtnOpen_Click(BtnComment, new EventArgs());
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /* Gestione Ricerca sull'Editor */
        private void BtnFind_Click(object sender, EventArgs e)
        {

            FindAndReplaceForm _findForm = new FindAndReplaceForm();

            TextEditorControl editor = Query;
            if (editor == null) return;
            _findForm.ShowFor(editor, false);
        }

        /* Caricamento Form Principale */
        private void frmMain_Load(object sender, EventArgs e)
        {

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
            notifyIcon1.Icon = images[0];

            /* Gestione Parametri di Default */
            toolStripTextBox3.Text = "1000";
            TStxtCicli.Text = "1";

            /* Disabilita di controlli dei parametri */
            TStxtCicli.Enabled = false;
            toolStripTextBox3.Enabled = false;

            string[] args = Environment.GetCommandLineArgs();

            foreach (string arg in args)
            {
                if (arg.IndexOf(".vsm") != -1)
                {
                    File.WriteAllText(arg, Query.Text);
                    Thread.Sleep(1000);
                    BtnNext_Click(BtnNext, new EventArgs());
                }
            }
        }

        /* Dispose di Tutti gli Oggetti e scaricamento della frmMain */
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            pblnThreadTray = false;
            this.Controls.Clear();
            this.Dispose();
            globalEventProvider1.Dispose();
            Application.Exit();
        }

        /* Recupera Coordinate X,Y del Click Mouse da ripetere */
        private void BtnBookmark_Click(object sender, EventArgs e)
        {

            frm = new TestFormComponent(this);
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);

            frm.Show();

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = toolStripTextBox1.Text;
            proc.StartInfo.Arguments = toolStripTextBox1.Text;

            if (toolStripTextBox1.Text != "")
                proc.Start();
            else
            {
                proc.Dispose();
            }
        }

        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            tlbl_posizione_mouse.Text = string.Format("x={0:0000}; y={1:0000}", e.X, e.Y);
        }


        /* Chiusura Form Mouse */
        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frm != null)
            {
                try
                {
                    /* Chiusura Processo Aperto in Corso */
                    Process[] pr = Process.GetProcessesByName(toolStripTextBox1.Text);
                    for (int i = 0; i < pr.Length; i++)
                    {
                        pr[0].CloseMainWindow();
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                frm = null;
            }

        }

        /* Parametro Cicli di esecuzione Script */
        private void TStxtCicli_Click(object sender, EventArgs e)
        {
            /* Se il campo cicli e' valido */
            if (TStxtCicli.Text != "")
                _iCicli = Convert.ToInt16(TStxtCicli.Text);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            toolStripTextBox3.Enabled = !toolStripTextBox3.Enabled;
            TStxtCicli.Enabled = !TStxtCicli.Enabled;

            if (TStxtCicli.Enabled == true)
            {
                BtnSearch.Image = Resources.Alarm_Padlock_Icon_16_2;
            }
            else
            {
                BtnSearch.Image = Resources.Alarm_Padlock_Icon_16;
            }
        }

        private void Query_Load(object sender, EventArgs e)
        {

        }

        public int m_Timer = 2000;

        private void toolStripButton2_Click_1(object sender, EventArgs e)
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

        private void leggiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leggiToolStripMenuItem.Checked = !leggiToolStripMenuItem.Checked;

            if (leggiToolStripMenuItem.Checked)
            {
                Query.Text = Query.Text + "$FNomefile.txt\r\n$1\r\n";
            }
            else
            {
                Query.Text = Query.Text.Replace("$FNomefile.txt\r\n", "");
                Query.Text = Query.Text.Replace("$1\r\n", "");
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            pblnThreadTray = false;
            childThread2.Abort();
            childThread1.Abort();
            notifyIcon1.Visible = false;

            frmMain.ActiveForm.WindowState = FormWindowState.Normal;

            _iCicli = 0;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pblnThreadTray = false;
            childThread2.Abort();
            childThread1.Abort();
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            Application.Exit();

        }


    }
}
