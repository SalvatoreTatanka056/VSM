using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;

namespace VMS
{
    public partial class frmFind : Form
    {

        TextEditorControl _editor;
        int _iPos;
        int iReCode;
        string strScript;
        int startLine;
        int startCol;
        int endLine;

        public frmFind(TextEditorControl editor)
        {
            _editor = editor;
            InitializeComponent();
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            _iPos = 0;
            startLine = 0;
            startCol = 0;
            endLine = 0;
            strScript = Application.OpenForms["frmMain"].Controls["Query"].Text;
        }

        private string[] GetLine(string strScript)
        {

            strScript += "\n";
            string[] strListTmp = { "\n" };
            string[] strList = strScript.Split(strListTmp,StringSplitOptions.RemoveEmptyEntries);
            return strList;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string lstrMessaggio = "Ricerca Terminata";
            string lstrTitolo = "Ricerca Stringa" ;
            DialogResult DlgRes;

            if (txtRicerca.Text == "" || string.IsNullOrEmpty(strScript))
                return;

            try
            {
                string[] strList = GetLine(strScript.Substring(0, Convert.ToInt16(strScript.IndexOf(txtRicerca.Text) + txtRicerca.Text.Length)));
                iReCode =  strList.Length;

                startCol = strList[iReCode - 1].IndexOf(txtRicerca.Text);

                if (startCol == -1)
                {
                    startLine = 0;
                    startCol = 0;
                    endLine = 0;
                    strScript = Application.OpenForms["frmMain"].Controls["Query"].Text;
                    DlgRes =  MessageBox.Show(lstrMessaggio,lstrTitolo,MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }

                startLine = startLine + (iReCode - 1);
                TextLocation start = new TextLocation(startCol, startLine);

                int endCol = startCol + txtRicerca.Text.ToString().Length;
                endLine = endLine + iReCode - 1;
                TextLocation end = new TextLocation(endCol, endLine);

                _editor.ActiveTextAreaControl.SelectionManager.SetSelection(start, end);
                _editor.ActiveTextAreaControl.Caret.Position = end;
            }
            catch 
            {
                return;
            };

            strScript = strScript.Substring(Convert.ToInt16(strScript.IndexOf(txtRicerca.Text) + txtRicerca.Text.Length), strScript.Length - Convert.ToInt16(strScript.IndexOf(txtRicerca.Text) + txtRicerca.Text.Length));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtRicerca_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(button2, new EventArgs());
            }
        }
    }
}
