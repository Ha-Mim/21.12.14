using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CircleApp
{
    internal class Circle
    {
        private double pi = 3.1416;
        public double radius;

        public double GetDiameter()
        {
            return radius*2;
        }

        public double GetPerimeter()
        {
            return 2*radius*pi;
        }

        public double GetArea()
        {
            return pi*radius*radius;
        }

    }
}
