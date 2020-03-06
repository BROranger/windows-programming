using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.ExceptionServices;

namespace MyCalculator
{
    public partial class Form1 : Form
    {
        [DllImport(@"..\..\..\Debug\GETRESULT.dll", EntryPoint = "trans", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern void trans(string exp, byte []postexp);
        [DllImport(@"..\..\..\Debug\GETRESULT.dll", EntryPoint = "compvalue", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern double compvalue(byte [] postexp);

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Backspace_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != "" && textBox1.Text !="")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "1";
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "2";
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "3";
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "4";
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "5";
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "6";
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "7";
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "8";
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "9";
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "+";
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "-";
        }

        private void button_multiplication_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "*";
        }

        private void button_division_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "/";
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "0";
        }

        private void button_RC_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += ")";
        }

        private void button_LC_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "(";
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            GetResult(textBox1.Text);
        }

        [HandleProcessCorruptedStateExceptions]
        public void GetResult(string s)
        {
            try
            {
                byte[] postexp = new byte[100];
                trans(s, postexp);
                textBox2.Text = compvalue(postexp).ToString();
            }
            catch (Exception e)
            {
                textBox2.Text = "除零错误";
            }
        }

        private void button_Point_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += ".";
        }

        private void button_Precent_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "%";
        }

        private void button_power_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "^";
        }

        private void button_factorial_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                textBox1.Text = textBox2.Text;
                textBox2.Text = "";
            }
            textBox1.Text += "!";
        }
    }
    
}
