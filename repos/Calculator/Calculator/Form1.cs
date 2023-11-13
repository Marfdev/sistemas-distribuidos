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
        CalculatorManager calc = new CalculatorManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(ResultsBox.Text);
        }

        private void n9_Click(object sender, EventArgs e)
        {
            addToBox(n9.Text);
        }
        private void n8_Click(object sender, EventArgs e)
        {
            addToBox(n8.Text);
        }
        private void n7_Click(object sender, EventArgs e)
        {
            addToBox(n7.Text);
        }
        private void n6_Click(object sender, EventArgs e)
        {
            addToBox(n6.Text);
        }
        private void n5_Click(object sender, EventArgs e)
        {
            addToBox(n5.Text);
        }
        private void n4_Click(object sender, EventArgs e)
        {
            addToBox(n4.Text);
        }
        private void n3_Click(object sender, EventArgs e)
        {
            addToBox(n3.Text);
        }
        private void n2_Click(object sender, EventArgs e)
        {
            addToBox(n2.Text);
        }
        private void n1_Click(object sender, EventArgs e)
        {
            addToBox(n1.Text);
        }
        private void n0_Click(object sender, EventArgs e)
        {
            addToBox(n0.Text);
        }
        private void addToBox(string ch)
        {
            ResultsBox.Text+= ch;
        }

        private void processCalculations(object sender, EventArgs e)
        {
            string[] numbers = ResultsBox.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("This is the array");
            foreach (string number in numbers)
            {
                Console.Write(number+", ");
            }
            int result = 0;
            int temp = 0;
            string operation = "";
            foreach (char number in ResultsBox.Text)
            {
                Console.WriteLine("enters loop");
                if (int.TryParse(number.ToString() , out temp))
                {
                    Console.WriteLine("parses number");
                    if (operation == "")
                    {
                        Console.WriteLine("reads as no operation");
                        result = temp;
                    }
                    else
                    {
                        Console.WriteLine("finds operation");
                        switch (operation)
                        {
                            case "+":
                                result = (int) calc.Suma(result, temp);
                                break;
                            case "-":
                                result = (int) calc.Resta(result, temp);
                                break;
                            case "×":
                                result = (int) calc.Multi(result, temp);
                                break;
                            case "÷":
                                calc.Divi(result, temp);
                                break;

                            default:
                                break;
                        }
                        operation = "";
                    }
                }
                else
                {
                    Console.WriteLine("cannot parse");
                    operation = number.ToString();
                }
            }
            ResultsBox.Text = result.ToString();
        }

        private void multButton_Click(object sender, EventArgs e)
        {
            addToBox(multButton.Text);
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            addToBox(minusButton.Text);
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            addToBox(plusButton.Text);
        }

        private void divButton_Click(object sender, EventArgs e)
        {
            addToBox(divButton.Text);
        }
    }
}
