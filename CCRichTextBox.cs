using System;
using System.Drawing;
using System.Windows.Forms;
namespace CodeCompletion_CSharp
{

    public class CCRichTextBox : RichTextBox
    {

        //*********************************************************************
        //   declare ListBox object CodeCompleteBox
        //*********************************************************************
        public ListBox CodeCompleteBox = new ListBox();

        //*********************************************************************
        //   declare ToolTipControlPanel object ToolTipControl
        //*********************************************************************
        public ToolTipControlPanel ToolTipControl = new ToolTipControlPanel();


        //*********************************************************************
        //  declare static string EnteredKey variable
        //*********************************************************************
        public static String EnteredKey = "";

        public static Boolean isClassCreated = false;

        public static Boolean isDataTypeDeclared = false;

        public static Boolean isAutoCompleteBrackets = false;

        public static Boolean isToolTipControlAdded = false;

        // declare backcolor & forecolor variables
        public static Color backcolor = SystemColors.Window;
        public static Color forecolor = Color.Black;

        public CCRichTextBox()
        {

            //*********************************************************************
            //  set FixedSingle Border style to CodeCompleteBox
            //*********************************************************************
            CodeCompleteBox.BorderStyle = BorderStyle.Fixed3D;

            //***************************************************************************************
            //  Add KeyDown,KeyPress & MouseClick events to CodeCompleteBox
            //***************************************************************************************
            CodeCompleteBox.KeyDown += new KeyEventHandler(CodeCompleteBox_KeyDown);
            CodeCompleteBox.KeyUp += new KeyEventHandler(CodeCompleteBox_KeyUp);
            CodeCompleteBox.KeyPress += new KeyPressEventHandler(CodeCompleteBox_KeyPress);
        }


        //**************************************************************************
        // get & set backcolor & forecolor to CodeCompleteBox
        //**************************************************************************
        public Color CodeCompleBackColor
        {
            get { return backcolor; }
            set { backcolor = value; CodeCompleteBox.BackColor = value; Invalidate(); }
        }

        public Color CodeCompleForeColor
        {
            get { return forecolor; }
            set { forecolor = value; CodeCompleteBox.ForeColor = value; Invalidate(); }
        }



        //**********************************************************************************************
        //  getXYPoints() function that returns (x,y) co-ordinates taken from CCRichTextBox
        //  to set Location of CodeCompleteBox on CCRichTextBox
        //**********************************************************************************************
        public Point getXYPoints()
        {
            //get current caret position point from CCRichTextBox
            Point pt = this.GetPositionFromCharIndex(this.SelectionStart);
            // increase the Y co-ordinate size by 10 & Font size of CCRichTextBox
            pt.Y = pt.Y + (int)this.Font.Size + 10;

            //  check Y co-ordinate value is greater than CCRichTextBox Height - CodeCompleteBox
            //   for add CodeCompleteBox at the Bottom of CCRichTextBox
            if (pt.Y > this.Height - CodeCompleteBox.Height)
            {
                pt.Y = pt.Y - CodeCompleteBox.Height - (int)this.Font.Size - 10;
            }

            return pt;
        }


        //*********************************************************************************************************************
        //  getWidth() function returns specific width depending on the length of items in CodeCompleteBox
        //*********************************************************************************************************************
        public int getWidth()
        {
            int width = 100;

            foreach (String item in CodeCompleteBox.Items)
            {
                if (item.Length <= 5)
                {
                    width = 160;
                }
                else if (item.Length <= 10)
                {
                    width = 200;
                }
                else if (item.Length <= 20)
                {
                    width = width + item.Length * 2;
                }
                else
                {
                    width = width + item.Length * 4;
                }
            }

            return width;
        }


        //*********************************************************************************************************************
        //  getHeight() function returns specific height depending on the number of items in CodeCompleteBox
        //*********************************************************************************************************************
        public int getHeight()
        {
            int height = 10;

            //  get Font size of CCRichTextBox
            int fontsize = (int)this.Font.Size;

            //  get number of items added to CodeCompleteBox
            int count = CodeCompleteBox.Items.Count;

            //   increase the height of CodeCompleteBox according added items count
            if (count == 0)
            {
                height = fontsize;
            }
            else if (count > 0 && count <= 15)
            {
                height += (count * 10) + fontsize;
            }
            else
            {
                height += 200 + fontsize;
            }

            return height;
        }


        //**********************************************************************************************
        //  declare list of String keywordslist and adding keywords or any syntax to it
        //**********************************************************************************************
        public String[] keywordslist = {
            "{BACKSPACE}",
            "{BREAK}",
            "{CAPSLOCK}",
            "{CLEAR}",
            "{DELETE}",
            "{DOWN}",
            "{END}",
            "{ENTER}",
            "{ESCAPE}",
            "{HELP}",
            "{HOME}",
            "{INSERT}",
            "{LEFT}",
            "{NUMLOCK}",
            "{PGDN}",
            "{PGUP}",
            "{RETURN}",
            "{RIGHT}",
            "{SCROLLLOCK}",
            "{TAB}",
            "{UP}",
            "{F1}",
            "+",
            "^",
            "%",
        };



        public String[] KeywordsList
        {
            get { return keywordslist; }
            set { keywordslist = value; Invalidate(); }
        }







        //*******************************************************************************************************************
        //  ProcessToolTips() function
        //  match selected item with keywords list item and set width & height & change text of label
        //*******************************************************************************************************************
        public void ProcessToolTips(String input)
        {
            switch (input)
            {
                case "{BACKSPACE}":
                    ToolTipControl.ToolTipText = " or {BS} BACKSPACE ";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 35;
                    break;

                case "{BREAK}":
                    ToolTipControl.ToolTipText = "BREAK";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 35;
                    break;

                case "{CAPSLOCK}":
                    ToolTipControl.ToolTipText = "CAPS LOCK ";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 60;
                    break;

                case "{CLEAR}":
                    ToolTipControl.ToolTipText = "CLEAR ";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 60;
                    break;

                case "{DELETE}":
                    ToolTipControl.ToolTipText = "or {DEL} DELETE or DEL ";
                    ToolTipControl.Width = 260;
                    ToolTipControl.Height = 35;
                    break;

                case "{DOWN}":
                    ToolTipControl.ToolTipText = "DOWN ARROW";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 60;
                    break;

                case "{END}":
                    ToolTipControl.ToolTipText = "END";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 60;
                    break;

                case "{ENTER}":
                    ToolTipControl.ToolTipText = "ENTER";
                    ToolTipControl.Width = 260;
                    ToolTipControl.Height = 35;
                    break;

                case "{ESC}":
                    ToolTipControl.ToolTipText = "or {ESC} ESC";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 60;
                    break;

                case "{HELP}":
                    ToolTipControl.ToolTipText = "HELP";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 60;
                    break;

                case "{HOME}":
                    ToolTipControl.ToolTipText = "HOME";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 35;
                    break;

                case "{INS}":
                    ToolTipControl.ToolTipText = "INS";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 35;
                    break;

                case "{LEFT}":
                    ToolTipControl.ToolTipText = "LEFT ARROW ";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 35;
                    break;

                case "{NUMLOCK}":
                    ToolTipControl.ToolTipText = " NUM LOCK";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 60;
                    break;

                case "{PGDN}":
                    ToolTipControl.ToolTipText = "PAGE DOWN ";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 60;
                    break;

                case "{PGUP}":
                    ToolTipControl.ToolTipText = "PAGE UP";
                    ToolTipControl.Width = 150;
                    ToolTipControl.Height = 60;
                    break;

                case "{RETURN}":
                    ToolTipControl.ToolTipText = "RETURN ";
                    ToolTipControl.Width = 180;
                    ToolTipControl.Height = 60;
                    break;

                case "{RIGHT}":
                    ToolTipControl.ToolTipText = "RIGHT ARROW ";
                    ToolTipControl.Width = 320;
                    ToolTipControl.Height = 35;
                    break;

                case "{SCROLLLOCK}":
                    ToolTipControl.ToolTipText = "SCROLL LOCK ";
                    ToolTipControl.Width = 200;
                    ToolTipControl.Height = 35;
                    break;

                case "{TAB}":
                    ToolTipControl.ToolTipText = "TAB";
                    ToolTipControl.Width = 200;
                    ToolTipControl.Height = 35;
                    break;


                case "{UP}":
                    ToolTipControl.ToolTipText = " UP ARROW";
                    ToolTipControl.Width = 200;
                    ToolTipControl.Height = 35;
                    break;


                case "{F1}":
                    ToolTipControl.ToolTipText = "F1 ...F2";
                    ToolTipControl.Width = 200;
                    ToolTipControl.Height = 35;
                    break;

                case "+":
                    ToolTipControl.ToolTipText = "Shift";
                    ToolTipControl.Width = 200;
                    ToolTipControl.Height = 35;
                    break;

                case "%":
                    ToolTipControl.ToolTipText = "Alt";
                    ToolTipControl.Width = 200;
                    ToolTipControl.Height = 35;
                    break;

                case "^":
                    ToolTipControl.ToolTipText = "Ctrl";
                    ToolTipControl.Width = 200;
                    ToolTipControl.Height = 35;
                    break;


                default:
                    if (isToolTipControlAdded)
                    {
                        ToolTipControl.Visible = false;
                    }
                    break;

            }
        }


        private void InsertCodeSnippets(String text, int length)
        {
            int sel = this.SelectionStart;
            text = text.Remove(0, length);
            this.Text = this.Text.Insert(sel, text);
            this.SelectionStart = sel + text.Length;
            this.Controls.Remove(CodeCompleteBox);

            if (isToolTipControlAdded)
            {
                this.Controls.Remove(ToolTipControl);
            }
        }


        // insert code into CCRichTextBox at selection start position 
        // when Tab key is down
        // e.g if user pressed a key 'Tab' twice on 'for' selected item in
        // CodeCompleteBox then insert for loop
        public void InsertSyntax(String text)
        {
            if (isCodeCompleteBoxAdded)
            {
                if (EnteredKey != "")
                {
                    if (EnteredKey.Length == 1)
                    {
                        this.InsertCodeSnippets(text, 1);
                    }
                    else if (EnteredKey.Length == 2)
                    {
                        this.InsertCodeSnippets(text, 2);
                    }
                    else if (EnteredKey.Length == 3)
                    {
                        this.InsertCodeSnippets(text, 3);
                    }
                    else
                    {
                        this.InsertCodeSnippets(text, EnteredKey.Length);
                    }
                }
            }
        }



        //**************************************************************
        // InsertingCodeSnippetCodes() function
        //**************************************************************
        public void InsertingCodeSnippetCodes()
        {
            if (isCodeCompleteBoxAdded)
            {
                RichTextBox rtb = new RichTextBox();

                switch (CodeCompleteBox.SelectedItem.ToString())
                {
                    case "{BACKSPACE}":
                        rtb.Text = "";
                        rtb.Text = "{BACKSPACE};\n";
                        this.InsertSyntax(rtb.Text);
                        break;
                }
            }
        }

        //***********************************************************************************
        //  declare static Boolean isCodeCompleteBoxAdded variable to check
        //  for CodeCompleteBox is added to CCRichTextBox or not
        //***********************************************************************************
        public static Boolean isCodeCompleteBoxAdded = false;


   


        //****************************************************************************
        //   ProcessCodeCompletion() function
        //****************************************************************************
        public void ProcessCodeCompletionAction(String key)
        {
            EnteredKey = "";

            // concat the key & EnteredKey postfix
            EnteredKey = EnteredKey + key;

              // Clear the CodeCompleteBox Items 
                CodeCompleteBox.Items.Clear();
                //add each item to CodeCompleteBox
                foreach (String item in keywordslist)
                {
                    //check item is starts with EnteredKey or not
                    if (item.StartsWith(EnteredKey))
                    {
                        CodeCompleteBox.Items.Add(item);
                    }
                }


                //  read each item from CodeCompleteBox to set SelectedItem
                foreach (String item in keywordslist)
                {
                    if (item.StartsWith(EnteredKey))
                    {
                        CodeCompleteBox.SelectedItem = item;

                        //  set Default cursor to CodeCompleteBox
                        CodeCompleteBox.Cursor = Cursors.Default;

                        //  set Size to CodeCompleteBox
                        // width=this.getWidth() & height=this.getHeight()+(int)this.Font.Size
                        CodeCompleteBox.Size = new System.Drawing.Size(this.getWidth(), this.getHeight() + (int)this.Font.Size);

                        //  set Location to CodeCompleteBox by calling getXYPoints() function
                        CodeCompleteBox.Location = this.getXYPoints();

                        //  adding controls of CodeCompleteBox to CCRichTextBox
                        this.Controls.Add(CodeCompleteBox);

                        //  set Focus to CodeCompleteBox
                        CodeCompleteBox.Focus();

                        //  set isCodeCompleteBoxAdded to true
                        isCodeCompleteBoxAdded = true;


                        // set location to ToolTipControl
                        ToolTipControl.Location = new Point(CodeCompleteBox.Location.X + CodeCompleteBox.Width, CodeCompleteBox.Location.Y);

                        // call ProcessToolTips() function
                        this.ProcessToolTips(CodeCompleteBox.SelectedItem.ToString());

                        // add ToolTipControl to CCRichTextBox
                        this.Controls.Add(ToolTipControl);

                        isToolTipControlAdded = true;

                        break;
                    }

                    else
                    {
                        isCodeCompleteBoxAdded = false;
                    }
                }
         
        }


        //*************************************************************************************
        //  Text Changed event of CCRichTextBox
        //  if text is null then remove CodeCompleteBox from CCRichTextBox
        //*****************************************************************************************
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            // remove CodeCompleteBox when text is null in CCRichTextBox
            // before remove check CodeCompleteBox is added to CCRichTextBox or not
            if (this.Text == "")
            {
                if (isCodeCompleteBoxAdded)
                {
                    this.Controls.Remove(CodeCompleteBox);
                    EnteredKey = "";

                    if (isToolTipControlAdded)
                    {
                        this.Controls.Remove(ToolTipControl);
                    }
                }
            }
        }


        //***********************************************************************************
        // KeyDown event of CCRichTextBox
        //**********************************************************************************
        protected override void OnKeyDown(KeyEventArgs e)
        {
             base.OnKeyDown(e);

            switch (e.KeyCode)
            {
                // if Space key is down then remove CodeCompleteBox control from CCRichTextBox
                case Keys.Space:
                    if (isCodeCompleteBoxAdded)
                    {
                        this.Controls.Remove(CodeCompleteBox);
                        EnteredKey = "";

                        if (isToolTipControlAdded)
                        {
                            this.Controls.Remove(ToolTipControl);
                        }
                    }
                    break;

                // if Enter key is down then remove CodeCompleteBox control from CCRichTextBox
                case Keys.Enter:
                    if (isCodeCompleteBoxAdded)
                    {
                        this.Controls.Remove(CodeCompleteBox);
                        EnteredKey = "";

                        if (isToolTipControlAdded)
                        {
                            this.Controls.Remove(ToolTipControl);
                        }
                    }
                    break;

                // if Escape key is down then remove CodeCompleteBox control from CCRichTextBox
                case Keys.Escape:
                    if (isCodeCompleteBoxAdded)
                    {
                        this.Controls.Remove(CodeCompleteBox);
                        EnteredKey = "";

                        if (isToolTipControlAdded)
                        {
                            this.Controls.Remove(ToolTipControl);
                        }
                    }
                    break;

                // if Back key is down then remove CodeCompleteBox control from CCRichTextBox
                case Keys.Back:
                    if (isCodeCompleteBoxAdded)
                    {
                        this.Controls.Remove(CodeCompleteBox);
                        EnteredKey = "";

                        if (isToolTipControlAdded)
                        {
                            this.Controls.Remove(ToolTipControl);
                        }
                    }
                    break;
            }
        }


        //******************************************************************************
        //  Key Press event of CCRichTextBox
        //*****************************************************************************
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

         

            String key = e.KeyChar.ToString();

            // as you know how class object is declared
            // e.g Form f=new Form();
            // if you selected the Form text from CodeCompleteBox then it must be completed with
            // semicolon or declare the object of that class using new keyword by specifying = sign
            // same as data types

         
                ProcessCodeCompletionAction(key);
        }


        //*****************************************************************************************
        //  Mouse Click event of CCRichTextBox
        //****************************************************************************************
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            // when mouse click on CCRichTextBox then remove CodeCompleteBox from CCRichTextBox

            if (isCodeCompleteBoxAdded)
            {
                this.Controls.Remove(CodeCompleteBox);
                EnteredKey = "";

                if (isToolTipControlAdded)
                {
                    this.Controls.Remove(ToolTipControl);
                }
            }
        }


        //*****************************************************************************************
        //  VScroll event of CCRichTextBox
        //****************************************************************************************
        protected override void OnVScroll(EventArgs e)
        {
            base.OnVScroll(e);

            // remove CodeCompleteBox when VScroll is changed in CCRichTextBox
            // before remove check CodeCompleteBox is added to CCRichTextBox or not
            if (isCodeCompleteBoxAdded)
            {
                this.Controls.Remove(CodeCompleteBox);
                EnteredKey = "";

                if (isToolTipControlAdded)
                {
                    this.Controls.Remove(ToolTipControl);
                }
            }
        }


        private void CodeCompleteBox_InsertSelectedText(int length)
        {
            int sel = this.SelectionStart;
            String text = CodeCompleteBox.SelectedItem.ToString();
            text = text.Remove(0, length);
            this.Text = this.Text.Insert(sel, text + "");
            this.SelectionStart = sel + (text + "").Length;
            this.Controls.Remove(CodeCompleteBox);

            //this.ProcessDeclaredClasses(CodeCompleteBox.SelectedItem.ToString());
            //this.ProcessDeclaredDataTypes(CodeCompleteBox.SelectedItem.ToString());

            if (isToolTipControlAdded)
            {
                this.Controls.Remove(ToolTipControl);
            }
        }


        //*********************************************************************
        //  CodeCompleteBox KeyDown events function
        //*********************************************************************
        private void CodeCompleteBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // if Space key is down when CodeCompleteBox is added to the CCRichTextBox
                //  then insert SelectedItem from CodeCompleteBox to this at SelectionStart location
                //  also inserting a single space because space bar key is down

                case Keys.Space:
                    if (isCodeCompleteBoxAdded)
                    {
                        if (CodeCompleteBox.SelectedItem.ToString().StartsWith(EnteredKey))
                        {
                            if (EnteredKey != "")
                            {
                                // before inserting a selected item first check EnteredKey length
                                // if it is 1 then remove first character of selected item from CodeCompleteBox
                                // if it is 2 then remove first 2 characters of selected item from CodeCompleteBox
                                // if it is 3 then remove first 3 characters
                                // if it is greater than 3 then replace EnteredKey with null/"" in selected item text
                                // this all arrangement is important because characters keywords added to CodeCompleteBox could be same
                                if (EnteredKey.Length == 1)
                                {
                                    this.CodeCompleteBox_InsertSelectedText(1);
                                }
                                else if (EnteredKey.Length == 2)
                                {
                                    this.CodeCompleteBox_InsertSelectedText(2);
                                }
                                else if (EnteredKey.Length == 3)
                                {
                                    this.CodeCompleteBox_InsertSelectedText(3);
                                }
                                else
                                {
                                    this.CodeCompleteBox_InsertSelectedText(EnteredKey.Length);
                                }
                            }
                        }
                        else
                        {
                            int sel = this.SelectionStart;
                            this.Text = this.Text.Insert(sel, " ");
                            this.SelectionStart = sel + " ".Length;
                        }
                    }
                    break;


                // if Enter key is down when CodeCompleteBox is added to the CCRichTextBox
                //  then insert SelectedItem from CodeCompleteBox to this at SelectionStart location
                // same all procedure as used when Space key is down only without inserting a single space here

                case Keys.Enter:
                    if (isCodeCompleteBoxAdded)
                    {
                        if (EnteredKey != "")
                        {
                            if (EnteredKey.Length == 1)
                            {
                                this.CodeCompleteBox_InsertSelectedText(1);
                            }
                            else if (EnteredKey.Length == 2)
                            {
                                this.CodeCompleteBox_InsertSelectedText(2);
                            }
                            else if (EnteredKey.Length == 3)
                            {
                                this.CodeCompleteBox_InsertSelectedText(3);
                            }
                            else
                            {
                                this.CodeCompleteBox_InsertSelectedText(EnteredKey.Length);
                            }
                        }
                    }
                    break;

                // if Left key is down then remove CodeCompleteBox from this
                case Keys.Left:
                    if (isCodeCompleteBoxAdded)
                    {
                        this.Controls.Remove(CodeCompleteBox);
                        EnteredKey = "";

                        if (isToolTipControlAdded)
                        {
                            this.Controls.Remove(ToolTipControl);
                        }

                    }
                    break;

                // if Right key is down then remove CodeCompleteBox from this
                case Keys.Right:
                    if (isCodeCompleteBoxAdded)
                    {
                        this.Controls.Remove(CodeCompleteBox);
                        EnteredKey = "";

                        if (isToolTipControlAdded)
                        {
                            this.Controls.Remove(ToolTipControl);
                        }

                    }
                    break;
            }
        }


        //*********************************************************************
        //  CodeCompleteBox KeyUp events function
        //*********************************************************************
        private void CodeCompleteBox_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                    if (isCodeCompleteBoxAdded)
                    {
                        ToolTipControl.Visible = true;
                        this.ProcessToolTips(CodeCompleteBox.SelectedItem.ToString());
                    }
                    break;


                case Keys.Tab:
                    if (isCodeCompleteBoxAdded)
                    {
                        this.InsertingCodeSnippetCodes();
                        this.Controls.Remove(CodeCompleteBox);
                        EnteredKey = "";

                        if (isToolTipControlAdded)
                        {
                            this.Controls.Remove(ToolTipControl);
                        }

                    }
                    break;
            }
        }


        //*********************************************************************
        //  CodeCompleteBox KeyPress events function
        //*********************************************************************
        private void CodeCompleteBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            String str = e.KeyChar.ToString();

            // in this event we must insert pressed key to this because Focus is on CodeCompleteBox

            // first check pressed key is not Space,Enter,Escape & Back
            // Space=32, Enter=13, Escape=27, Back=8
            if (Convert.ToInt32(e.KeyChar) != 13 && Convert.ToInt32(e.KeyChar) != 32 && Convert.ToInt32(e.KeyChar) != 27 && Convert.ToInt32(e.KeyChar) != 8)
            {
                if (isCodeCompleteBoxAdded)
                {
                    // insert pressed key to CCRichTextBox at SelectionStart position
                    int sel = this.SelectionStart;
                    this.Text = this.Text.Insert(sel, str);
                    this.SelectionStart = sel + 1;
                    e.Handled = true;

                    // concat the EnteredKey and pressed key on CodeCompleteBox
                    EnteredKey = EnteredKey + str;

                    // search item in CodeCompleteBox which starts with EnteredKey and set it to selected
                    foreach (String item in CodeCompleteBox.Items)
                    {
                        if (item.StartsWith(EnteredKey))
                        {
                            CodeCompleteBox.SelectedItem = item;

                            ToolTipControl.Visible = true;
                            this.ProcessToolTips(CodeCompleteBox.SelectedItem.ToString());
                            break;
                        }
                    }
                }
            }

            // if pressed key is Back then set focus to CCRichTextBox
            else if (Convert.ToInt32(e.KeyChar) == 8)
            {
                this.Focus();
            }

            // if pressed key is not Back then remove CodeCompleteBox from CCRichTextBox
            else if (Convert.ToInt32(e.KeyChar) != 8)
            {
                if (isCodeCompleteBoxAdded)
                {
                    this.Controls.Remove(CodeCompleteBox);
                    EnteredKey = "";

                    if (isToolTipControlAdded)
                    {
                        this.Controls.Remove(ToolTipControl);
                    }

                }
            }
        }
    }
}
