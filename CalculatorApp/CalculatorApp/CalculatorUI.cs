using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class CalculatorUI : Form
    {
        public CalculatorUI()
        {
            InitializeComponent();
        }
        Calculator aCalculator = new Calculator();
        
        private void addButton_Click(object sender, EventArgs e)
        {
            aCalculator.firstNumber = Convert.ToDouble(firstNumberTextBox.Text);
            aCalculator.secoundNumber = Convert.ToDouble(secoundNumberTextBox.Text);
            aCalculator.result = aCalculator.Add();
            resultTextBox.Text = aCalculator.result.ToString();


        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            aCalculator.firstNumber = Convert.ToDouble(firstNumberTextBox.Text);
            aCalculator.secoundNumber = Convert.ToDouble(secoundNumberTextBox.Text);
            aCalculator.result = aCalculator.Subtract();
            resultTextBox.Text = aCalculator.result.ToString();

        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            aCalculator.firstNumber = Convert.ToDouble(firstNumberTextBox.Text);
            aCalculator.secoundNumber = Convert.ToDouble(secoundNumberTextBox.Text);
            aCalculator.result = aCalculator.Multiply();
            resultTextBox.Text = aCalculator.result.ToString();

        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            aCalculator.firstNumber = Convert.ToDouble(firstNumberTextBox.Text);
            aCalculator.secoundNumber = Convert.ToDouble(secoundNumberTextBox.Text);
            aCalculator.result = aCalculator.Divide();
            resultTextBox.Text = aCalculator.result.ToString();

        }
    }
}
