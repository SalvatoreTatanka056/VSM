﻿using System;
using System.Drawing;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using System.Threading;
using System.IO;
using ICSharpCode.TextEditor;
using System.Diagnostics;
using VSM.Properties;
using System.Runtime.InteropServices;
using ProgramUsage;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Collections;
using CodeCompletion_CSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VSM
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
        bool mouse = false;
        bool first = true;
        public int m_intX, m_intY;

        GlobalKeyboardHook gHook;
        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType,
        IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr
           hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess,
           uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        const uint EVENT_OBJECT_NAMECHANGE = 0x800C;
        const uint WINEVENT_OUTOFCONTEXT = 0;

        /* Varibili Globali al Modulo Gestione Mouse */
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        IntPtr hhook;

        /* Importazione dei Metodi per Gestione Mouse */
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        /* Importazione dei Metodi per Gestione Mouse */
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);


        Thread PreformanceThread;
        Thread SaveListenThread;
        Thread ProgramListenThread;
        public Label label;
        public Label l2;

        /// <summary>
        ///  Implementazione Costruttore frmMain
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            try
            {
                mouse = false;
                tlbl_posizione_mouse.BackColor = Color.Red;
                tlbl_posizione_mouse.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            try
            {



                if (this.Query.Text.Contains(word))
                {
                    int index = -1;
                    int selectStart = this.Query.SelectionStart;

                    while ((index = this.Query.Text.IndexOf(word, (index + 1))) != -1)
                    {
                        this.Query.Select((index + startIndex), word.Length);
                        this.Query.SelectionColor = color;
                        //Query.SelectionFont = Query.Font;
                        Query.SelectionFont = new Font(Query.Font, FontStyle.Bold);
                        this.Query.Select((index + startIndex), word.Length);
                        this.Query.Select(selectStart, 0);
                        this.Query.SelectionColor = Color.Black;
                        Query.SelectionFont = new Font(Query.Font, FontStyle.Regular);
                        this.Query.Select(selectStart, 0);

                    }
                }

            }
            catch(Exception)
            {
                throw;
            }
        }


        public static void LeftMouseClick(int xpos, int ypos)
        {
            Cursor.Position = new Point(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

        public static void RightMouseClick(int xpos, int ypos)
        {
            Cursor.Position = new Point(xpos, ypos);
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
            /* Esecuzione thread per esecuzione comandi */
            EseguiMacro();
        }

        /// <summary>
        /// Esecuzione Macro
        /// </summary>
        private void EseguiMacro()
        {
            DialogResult dlg;

            if (TStxtCicli.Text != "")
                _iCicli = Convert.ToInt16(TStxtCicli.Text);

            dlg = MessageBox.Show("Attenzione non si è scelto nessun programma da eseguire!\n i comandi verranno eseguiti comunque\n si vuole continuare?", "Nessun programma scelto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlg == DialogResult.No)
            {
       
                return;
            }
          
            for (int i = 0; i < _iCicli; i++)
            {
                if (toolStripTextBox1.Text.Length > 0)
                {
                    try
                    {
                        Process.Start(toolStripTextBox1.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

                /* Compila Script */
                string strCompilazione = "";
                strCompilazione = strMacro.Replace("\n", "");
                strCompilazione = strCompilazione.Replace("\r", "");
                strCompilazione = strCompilazione.Replace("\n", "");
                strCompilazione = strCompilazione.Replace("\t", "");

                string[] str = strCompilazione.Split(';');

                Thread.Sleep(Convert.ToInt16(toolStripTextBox3.Text));

                /* importante posizionare i programmi aperti nella stessa posizione
                    * ( oppure non utilizzare i click del mouse per alcune operazioni ) */
                foreach (string strSendMessage in str)
                {

                    /* Gestione Timer ... */
                    if (strSendMessage.Length > 1 && strSendMessage.Substring(0, 2) == "T=")
                    {
                        string strTimer = strSendMessage.Substring(2).ToString();
                        Thread.Sleep(Convert.ToInt32(strTimer));

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
                        try
                        {
                            SendKeys.SendWait(strSendMessage);
                            Thread.Sleep(Convert.ToInt16(toolStripTextBox3.Text));

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }

                    Application.DoEvents();
                }
                string tmp_operation = string.Format("Terminato {0}/{1}", i + 1, _iCicli);
                notifyIcon1.ShowBalloonTip(1000, "Script", tmp_operation, ToolTipIcon.Info);
                // pblnThreadTray = false;
            }

            MessageBox.Show("Script Terminato...");
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
                try
                {

                    Query.Text = sr.ReadToEnd();
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
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

        }

        /* Caricamento Form Principale */
        private void frmMain_Load(object sender, EventArgs e)
        {
            TStxtCicli.Text = "1";
            TStxtCicli.Enabled= false;

            string[] args = Environment.GetCommandLineArgs();

            foreach (string arg in args)
            {
                if (arg.IndexOf(".vsm") != -1)
                {
                    Query.Text = File.ReadAllText(arg);
                    /* Thread.Sleep(1000);
                     BtnNext_Click(BtnNext, new EventArgs());*/
                }
            }
        }

        /* Dispose di Tutti gli Oggetti e scaricamento della frmMain */
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (gHook != null) gHook.unhook();
            MouseHook.stop();
            mouse = false;
            UnhookWinEvent(hhook);
            pblnThreadTray = false;
            this.Controls.Clear();
            this.Dispose();
            Application.Exit();
        }

        public bool lblnActive = false;

        /* Recupera Coordinate X,Y del Click Mouse da ripetere */
        private void BtnBookmark_Click(object sender, EventArgs e)
        {
            lblnActive = true;
            if (mouse)
            {
                MouseHook.stop();
                mouse = false;
                tlbl_posizione_mouse.BackColor = Color.Red;
                tlbl_posizione_mouse.Invalidate();

                if (Query.Text.Contains("XY_"))
                {
                    int foundS = Query.Text.LastIndexOf("XY_");
                    Query.Text = Query.Text.Remove(foundS);
                    Query.Invalidate();
                }
            }
            else
            {
                appendText(" ----- Mouse Hook Active -----");
                mouse = true;
                MouseHook.Start();
                if (first)
                {
                    first = false;
                    MouseHook.MouseAction += new EventHandler(Event);

                }
                tlbl_posizione_mouse.BackColor = Color.GreenYellow;
                tlbl_posizione_mouse.Invalidate();
            }
            lblnActive = false;
        }

        delegate void AppendTextDelegate(string text);
        public void appendText(string s)
        {
            tlbl_posizione_mouse.Text = s;
        }

        private void Event(object sender, EventArgs e)
        {

            MouseHook.MSLLHOOKSTRUCT temp = (MouseHook.MSLLHOOKSTRUCT)sender;

            switch (temp.MouseAction)
            {
                case "WM_LBUTTONDOWN":
                    appendText("Mouse Event Detected : " + temp.MouseAction + "\t Position : " + temp.pt.x + " " + temp.pt.y);
                    Query.Text = Query.Text + string.Format("XY_L {0}-{1};\n", temp.pt.x, temp.pt.y);
                    break;
                case "WM_LBUTTONUP":
                    appendText("Mouse Event Detected : " + temp.MouseAction + "\t Position : " + temp.pt.x + " " + temp.pt.y);
                    break;
                case "WM_RBUTTONUP":
                    appendText("Mouse Event Detected : " + temp.MouseAction + "\t Position : " + temp.pt.x + " " + temp.pt.y);
                    break;
                case "WM_RBUTTONDOWN":
                    appendText("Mouse Event Detected : " + temp.MouseAction + "\t Position : " + temp.pt.x + " " + temp.pt.y);

                    Query.Text = Query.Text + string.Format("XY_R {0}-{1};\n", temp.pt.x, temp.pt.y);

                    break;
                case "WM_MOUSEWHEEL":
                    appendText("Mouse Event Detected : " + temp.MouseAction + "\t Position : " + temp.pt.x + " " + temp.pt.y);
                    break;
                case "WM_MOUSEMOVE":
                    break;
                case "WM_MOUSEWHEELDOWN":
                    appendText("Mouse Event Detected : " + temp.MouseAction + "\t Position : " + temp.pt.x + " " + temp.pt.y);
                    break;
                default:
                    Console.WriteLine("Unknown mouse event!");
                    break;
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

        private void button1_Click(object sender, EventArgs e)
        {
            lblnActive = true;
            if (mouse)
            {
                MouseHook.stop();
                mouse = false;
                tlbl_posizione_mouse.BackColor = Color.Red;
                tlbl_posizione_mouse.Invalidate();

                if (Query.Text.Contains("XY_"))
                {
                    int foundS = Query.Text.LastIndexOf("XY_");
                    Query.Text = Query.Text.Remove(foundS);
                    Query.Invalidate();
                }
            }
            else
            {
                appendText(" ----- Mouse Hook Active -----");
                mouse = true;
                MouseHook.Start();
                if (first)
                {
                    first = false;
                    MouseHook.MouseAction += new EventHandler(Event);
                }
                tlbl_posizione_mouse.BackColor = Color.GreenYellow;
                tlbl_posizione_mouse.Invalidate();

            }

            lblnActive = false;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Query.Text = "";
        }

        private void Query_TextChanged(object sender, EventArgs e)
        {
            this.CheckKeyword("BACKSPACE", Color.Green, 0);
            this.CheckKeyword("BREAK", Color.Green, 0);
            this.CheckKeyword("CAPSLOCK", Color.Green, 0);
            this.CheckKeyword("CLEAR", Color.Green, 0);
            this.CheckKeyword("DELETE", Color.Green, 0);
            this.CheckKeyword("DOWN", Color.Green, 0);
            this.CheckKeyword("END", Color.Green, 0);
            this.CheckKeyword("ENTER", Color.Green, 0);
            this.CheckKeyword("ESCAPE", Color.Green, 0);
            this.CheckKeyword("HELP", Color.Green, 0);
            this.CheckKeyword("HOME", Color.Green, 0);
            this.CheckKeyword("INSERT", Color.Green, 0);
            this.CheckKeyword("LEFT", Color.Green, 0);
            this.CheckKeyword("NUMLOCK", Color.Green, 0);
            this.CheckKeyword("PGDN", Color.Green, 0);
            this.CheckKeyword("PGUP", Color.Green, 0);
            this.CheckKeyword("RETURN", Color.Green, 0);
            this.CheckKeyword("RIGHT", Color.Green, 0);
            this.CheckKeyword("SCROLLLOCK", Color.Green, 0);
            this.CheckKeyword("TAB", Color.Green, 0);
            this.CheckKeyword("UP", Color.Green, 0);
            this.CheckKeyword("F1", Color.Green, 0);
            this.CheckKeyword("+", Color.Green, 0);
            this.CheckKeyword("^", Color.Green, 0);
            this.CheckKeyword("%", Color.Green, 0);
            this.CheckKeyword("T=", Color.Green, 0);
            this.CheckKeyword("XY_L", Color.Green, 0);
            this.CheckKeyword("XY_R", Color.Green, 0);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pblnThreadTray = false;
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            Application.Exit();

        }


    }
}
