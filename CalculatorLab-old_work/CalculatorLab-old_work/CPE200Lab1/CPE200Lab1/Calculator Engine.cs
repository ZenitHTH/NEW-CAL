using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class Calculator_Engine
    {
        private char first_operator;
        private char second_operator;
        private double first, second, percent;

        public string calculate(string operater, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            first_operator = Convert.ToChar(operater.Substring(0, 1));

            if (operater.Length == 2) second_operator = Convert.ToChar(operater.Substring(1, 1));

            string first_operate = Convert.ToString(first_operator);

            first = Convert.ToDouble(firstOperand);
            second = Convert.ToDouble(secondOperand);

            if (second_operator == '%')
            {
               
                

                percent = (first / 100) * second;

                switch (first_operate)
                {
                    case "+":
                        return (first + percent).ToString();
                    case "-":
                        return (first - percent).ToString();
                    case "X":
                        return (first * percent).ToString();
                    case "÷":
                        // Not allow devide be zero
                        if (secondOperand != "0")
                        {
                            double result;
                            string[] parts;
                            int remainLength;

                            result = (first / percent);
                            // split between integer part and fractional part
                            parts = result.ToString().Split('.');
                            // if integer part length is already break max output, return error
                            if (parts[0].Length > maxOutputSize)
                            {
                                return "E";
                            }
                            // calculate remaining space for fractional part.
                            remainLength = maxOutputSize - parts[0].Length - 1;
                            // trim the fractional part gracefully. =
                            return result.ToString("N" + remainLength);
                        }
                        break;

                }


            }

            switch (first_operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
                    //case "%":
                    //your code here






                    //    break;
            }
            return "E";
        }
    }
}

