/*Form-- Calculator app that uses posfix notation to evaluate expressions

Copyright (c) 2015 Fernando Simon

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double num1, num2;
        string prevOP; // previous operation
        private bool clrDisplay;
        string realText = " ";
        public Form1()
        {
            InitializeComponent();
      
            btn0.Click += new EventHandler(NumericClick);
            btn1.Click += new EventHandler(NumericClick);
            btn2.Click += new EventHandler(NumericClick);
            btn3.Click += new EventHandler(NumericClick);
            btn4.Click += new EventHandler(NumericClick);
            btn5.Click += new EventHandler(NumericClick);
            btn6.Click += new EventHandler(NumericClick);
            btn7.Click += new EventHandler(NumericClick);
            btn8.Click += new EventHandler(NumericClick);
            btn9.Click += new EventHandler(NumericClick);

            btnPlus.Click += new EventHandler(NumericClick);
            btnMinus.Click += new EventHandler(NumericClick);
            btnMul.Click += new EventHandler(NumericClick);
            btnDiv.Click += new EventHandler(NumericClick);
            btnOpenPar.Click += new EventHandler(NumericClick);
            btnClosePar.Click += new EventHandler(NumericClick);
     
            btnDot.Click += new EventHandler(NumericClick);

            num1 = 0.0; num2 = 0.0;
            clrDisplay = true;
            prevOP = "";
            lblDisplay.Text = "0";
        
        }
        private void NumericClick(object sender, System.EventArgs e)
        {
            Button bt = (Button)sender;
            if (clrDisplay)
            {
                lblDisplay.Text = "";
                realText = " ";
                clrDisplay = false;
            }

            switch (bt.Text) // CSharp can switch on strings
            {
                case "0":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    if(realText.ElementAt(realText.Length-1)=='.')
                        realText = realText + bt.Text;
                    else
                        realText =  realText +  " " +bt.Text;
                    break;
                case "1":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    if (realText.ElementAt(realText.Length - 1) == '.')
                        realText = realText + bt.Text;
                    else
                        realText =  realText + " " + bt.Text;
                    break;
                case "2":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    if (realText.ElementAt(realText.Length - 1) == '.')
                        realText = realText + bt.Text;
                    else
                        realText = realText + " " + bt.Text;
                    break;
                case "3":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    if (realText.ElementAt(realText.Length - 1) == '.')
                        realText = realText + bt.Text;
                    else
                        realText = realText + " " + bt.Text;
                    break;
                case "4":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    if (realText.ElementAt(realText.Length - 1) == '.')
                        realText = realText + bt.Text;
                    else
                        realText = realText + " " + bt.Text;
                    break;
                case "5":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    if (realText.ElementAt(realText.Length - 1) == '.')
                        realText = realText + bt.Text;
                    else
                        realText = realText + " " + bt.Text;
                    break;
                case "6":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    if (realText.ElementAt(realText.Length - 1) == '.')
                        realText = realText + bt.Text;
                    else
                        realText = realText + " " + bt.Text;
                    break;
                case "7":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    if (realText.ElementAt(realText.Length - 1) == '.')
                        realText = realText + bt.Text;
                    else
                        realText = realText + " " + bt.Text;
                    break;
                case "8":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    if (realText.ElementAt(realText.Length - 1) == '.')
                        realText = realText + bt.Text;
                    else
                        realText = realText + " " + bt.Text;
                    break;
                case "9":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    if (realText.ElementAt(realText.Length - 1) == '.')
                        realText = realText + bt.Text;
                    else
                        realText = realText + " " + bt.Text;
                    break;

                case "+":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    realText = realText + " " + bt.Text;
                    break;
                case "-":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    realText = realText + " " + bt.Text;
                    break;
                case "*":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    realText =  realText + " " + bt.Text;
                    break;
                case "/":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    realText = realText + " " + bt.Text;
                    break;
                case "(":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    realText =  realText + " " + bt.Text;
                    break;
                case ")":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    realText =  realText + " " + bt.Text;
                    break;

                case ".":
                    lblDisplay.Text = lblDisplay.Text + bt.Text;
                    realText = realText + bt.Text;
                    break;

            }

        }
       
        private void OperationClick(object sender, System.EventArgs e)
        {
            Button btnOp = (Button)sender;
            string op = btnOp.Text;

            clrDisplay = true;  // clear display on next numeric click
            if (prevOP == "")
                num1 = double.Parse(lblDisplay.Text);
            else
                num2 = double.Parse(lblDisplay.Text);
                        
        }

        private void btnC_Click(object sender, System.EventArgs e)
        {
            prevOP = "";
            clrDisplay = true;
            lblDisplay.Text = "0";
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            int rtopButton = ClientRectangle.Height / 5;

            foreach (Control ct in this.Controls)
            {
                if (ct is Label)
                {
                    Rectangle rdisp = new Rectangle();
                    rdisp.Width = ClientRectangle.Width;
                    rdisp.Height = ClientRectangle.Height / 5;
                    rdisp.Inflate(-10, -10);
                    SetControlSize(ct, rdisp);
                }
                if (ct is Button)
                {
                    int ypos = int.Parse(ct.Name[ct.Name.Length - 1].ToString());
                    int xpos = int.Parse(ct.Name[ct.Name.Length - 2].ToString());
                    Rectangle rbt = new Rectangle();
                    rbt.Width = ClientRectangle.Width / 5;
                    rbt.Height = ClientRectangle.Height / 5;
                    Point ptopleft = new Point(ypos * ClientRectangle.Width / 5,
                      xpos * ClientRectangle.Height / 5);
                    rbt.Location = ptopleft;
                    rbt.Inflate(-10, -10);
                    SetControlSize(ct, rbt);
                }

            }

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            clrDisplay = true;
            string expr = lblDisplay.Text.ToString();
            int l = expr.Length;

            PostfixExpressionParser pf = new PostfixExpressionParser(realText.Trim());
            
            double res = pf.evaluate();
           
            lblDisplay.Text = res.ToString();
    
        }
        
        private void SetControlSize(Control ct, Rectangle rc)
        {
            ct.Width = rc.Width;
            ct.Height = rc.Height;
            ct.Location = rc.Location;
        }

    }
}

