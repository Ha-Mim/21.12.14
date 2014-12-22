using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryApp
{
    class Salary
    {
        public string employeeName;
        public double basicAmount;
        public double houseRent;
        public double medicalAllowance;
        public double givenAmount;
       

        public double CalculateSalary()
        {
            return basicAmount + basicAmount*houseRent/100 + basicAmount*medicalAllowance/100;
        }
    }
}
