using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using CodeCompletion_CSharp;
using ICSharpCode.TextEditor;

namespace VSM
{
    public partial class frmFind : Form
    {

        public CCRichTextBox _editor;
        int startLine;
        int endLine;
        public int endCol;


        public frmFind(CCRichTextBox editor)
        {
            _editor = editor;
            InitializeComponent();
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            startLine = 0;
            endLine = 0;
        
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string lstrMessaggio = "Ricerca Terminata";
            string lstrTitolo = "Ricerca Stringa" ;
            DialogResult DlgRes;

            try
            {

                if (startLine == -1)
                {
                    startLine = 0;
                    endLine = 0;
                    DlgRes = MessageBox.Show(lstrMessaggio, lstrTitolo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _editor.SelectionStart = startLine;
                _editor.SelectionLength = endLine;
                _editor.SelectionBackColor = Color.White;

                if (txtRicerca.Text == "" )
                {
                    return;
                }

                startLine = _editor.Text.IndexOf(txtRicerca.Text.ToString(), startLine+1);
                endLine = txtRicerca.Text.ToString().Length;

                _editor.SelectionStart = startLine;
                _editor.SelectionLength = endLine;
                _editor.SelectionBackColor = Color.Gray;


            }
            catch 
            {
                return;
            };


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
