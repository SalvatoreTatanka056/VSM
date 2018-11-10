using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;

namespace MacroIE
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();



            #region Code to load the Highlight rules(files in resources) and the folding strategy class
            try
            {
                HighlightingManager.Manager.AddSyntaxModeFileProvider(new FileSyntaxModeProvider("SintaxHighLight\\"));
                Query.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("SQL");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void Query_Load(object sender, EventArgs e)
        {

        }

        private void ActionsToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            //Compila Script

            string strCompilazione = "";
            strCompilazione = Query.Text.Replace("\n", "");
            strCompilazione = strCompilazione.Replace("\r", "");
            strCompilazione = strCompilazione.Replace(" ", "");
            strCompilazione = strCompilazione.Replace("\n", "");
            strCompilazione = strCompilazione.Replace("\t", "");
            strCompilazione = strCompilazione.Replace("\"", "");

            string[] str = strCompilazione.Split(';');

            foreach (string strp in str)
            {
                if (strp.Substring(0, 4) == "SEND")
                {
                    //Controlla sintassi

                }

            }

        }
    }
}
