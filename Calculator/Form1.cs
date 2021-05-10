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
        public Form1()
        {
            InitializeComponent();
        }

        double result = 0;
        string performedOper = "";
        bool isOperPerformed = false;
        double memoryNum = 0;
        int opeCount = 0;
        List<string> operatorsUsed = new List<string>();
        List<double> numbers = new List<double>();


        private void buttonNum_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(tbResult.Text == "0" || isOperPerformed)
            {
                tbResult.Clear();
            }
            if (button.Text == ",")
            {
                if (!tbResult.Text.Contains(","))
                    tbResult.Text += button.Text;
            }else
                tbResult.Text += button.Text;

            if(lbEquation.Text == "" && tbResult.Text != "")
            {
                lbEquation.Text = tbResult.Text;
            }
            else 
            lbEquation.Text +=  button.Text;

            isOperPerformed = false;
            
        }

        private void btnOper_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            performedOper = button.Text;
            isOperPerformed = true;
            if (lbEquation.Text == "" && tbResult.Text != "")
            {
                lbEquation.Text = tbResult.Text;
            }

            lbEquation.Text += " " + performedOper + " ";

            operatorsUsed.Add(performedOper);
            numbers.Add(double.Parse(tbResult.Text));
            opeCount++;
            if (numbers.Count > 1)
            {
                if (operatorsUsed[opeCount-2] == "+")
                {
                    tbResult.Text = (result + numbers[opeCount-1]).ToString();
                    
                }
                if (operatorsUsed[opeCount - 2] == "-")
                {
                    tbResult.Text = (result - numbers[opeCount-1]).ToString();
                    
                }
                if (operatorsUsed[opeCount - 2] == "*")
                {
                    tbResult.Text = (result * numbers[opeCount-1]).ToString();
                    
                }
                if (operatorsUsed[opeCount - 2] == "/")
                {
                    tbResult.Text = (result / numbers[opeCount-1]).ToString();
                    
                }
                result = double.Parse(tbResult.Text);
                
            }
            else
                result = double.Parse(tbResult.Text);

        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            string temp = tbResult.Text;
            tbResult.Text = "0";
            lbEquation.Text = lbEquation.Text.Replace(temp, "");

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            tbResult.Text = "0";
            result = 0;
            lbEquation.Text = "";
            operatorsUsed.Clear();
            numbers.Clear();
            opeCount = 0;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (performedOper == "+")
            {
                tbResult.Text = (result + Double.Parse(tbResult.Text)).ToString();
            }
            if (performedOper == "-")
            {
                tbResult.Text = (result - Double.Parse(tbResult.Text)).ToString();
            }
            if (performedOper == "*")
            {
                tbResult.Text = (result * Double.Parse(tbResult.Text)).ToString();
            }
            if (performedOper == "/")
            {
                tbResult.Text = (result / Double.Parse(tbResult.Text)).ToString();
            }

            lbEquation.Text = "";
            operatorsUsed.Clear();
            numbers.Clear();
            opeCount = 0;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
            tbResult.Text = tbResult.Text.Remove(tbResult.Text.Length-1, 1);
            if(lbEquation.Text!="")
                lbEquation.Text = lbEquation.Text.Remove(lbEquation.Text.Length - 1, 1);
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            memoryNum = 0;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            if (memoryNum != 0)
                tbResult.Text = "";
                tbResult.Text += memoryNum;
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            memoryNum += Double.Parse(tbResult.Text);
        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            memoryNum -= Double.Parse(tbResult.Text);
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (lbEquation.Text == "")
            {
                lbEquation.Text +=  $" √({tbResult.Text}) ";
            }
            else
            {
                string temp = tbResult.Text;
                lbEquation.Text = lbEquation.Text.Replace(temp, $" √({tbResult.Text}) ");
                
            }
            tbResult.Text = (Math.Sqrt(Double.Parse(tbResult.Text))).ToString();
            
        }
    }
}
