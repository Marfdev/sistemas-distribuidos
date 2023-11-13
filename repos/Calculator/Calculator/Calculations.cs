using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal interface Calculations
    {
        double Suma(double num1, double num2 );
        double Resta(double num1, double num2);
        double Multi(double num1, double num2);
        double Divi(double num1, double num2);
        double Square(double num1);
        double Invert(double num1);
        double Sqrt(double num1);


    }
}
