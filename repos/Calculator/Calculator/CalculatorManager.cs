using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class CalculatorManager : Calculations
    {
        public double Divi(double num1, double num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException("You Cannot divide any number by zero");
            return num1 / num2;
        }

        public double Invert(double num1)
        {
            return 1 / num1;
        }

        public double Multi(double num1, double num2)
        {
            return num1 * num2;
        }
        
        public double Resta(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Sqrt(double num1)
        {
            return Math.Sqrt(num1);
        }

        public double Square(double num1)
        {
            return num1 * num1;
        }

        public double Suma(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}
