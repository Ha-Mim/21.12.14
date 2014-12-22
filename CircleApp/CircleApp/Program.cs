using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleApp
{
    class Program
    {
        static void Main(string[] args)
        { 
            Circle aCircle = new Circle();
            Console.WriteLine("Please Enter radius of the Circle = ");
            aCircle.radius = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Diameter = " + aCircle.GetDiameter() + "\nPerimeter = " + aCircle.GetPerimeter() +
                              "\nArea = " + aCircle.GetArea());
            Console.ReadLine();

        }
    }
}
