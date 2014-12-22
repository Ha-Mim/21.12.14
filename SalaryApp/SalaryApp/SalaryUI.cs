using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp
{
    public partial class SalaryUI : Form
    {
        public SalaryUI()
        {
            InitializeComponent();
        }

        private void showSalaryButton_Click(object sender, EventArgs e)
        {
            Salary aSalary = new Salary();
            aSalary.employeeName = nameTextBox.Text;
            aSalary.basicAmount = Convert.ToDouble(basicAmountTextBox.Text);
            aSalary.houseRent = Convert.ToDouble(houseRentTextBox.Text);
            aSalary.medicalAllowance = Convert.ToDouble(medicalAllowanceTextBox.Text);

            aSalary.givenAmount = aSalary.CalculateSalary();

            MessageBox.Show(aSalary.employeeName + ", Your Salary is " + aSalary.givenAmount + "Taka.");

        }
    }
}
