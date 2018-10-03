using System;
using System.Collections.Generic;

namespace calc
{
    public class Side
    {
        private string subEquation; // The subequation of a particular side
        private List<string> operands = new List<string>(); // List of the operands of this subequation
        private List<string> operators = new List<string>(); // List of the operators of this subequation

        // Side Constructor - A side refers to a side of an equation seperated by "=" 
        public Side( string subEquation)
        {
            this.subEquation = subEquation;
        }

        // SortEquation Method - Sorts each subequation's character's into its respective list
        public void SortEquation()
        {
            foreach (var c in subEquation.Split(' '))
            {
                if (HasNumber(c) || IsX(c))
                {
                    Operands.Add(c);
                }
                else if (IsOperator(c))
                {
                    Operators.Add(c);
                }
            }
        }

        // Calculate Method - While there is more item in operands list, calculate according to operator precedence
        public void Calculate()
        {
            while (operands.Count > 1)
            {
                try
                {
                    if (operators.Contains("/"))
                    {
                        try
                        {
                            DoMath("/");
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Error: Cannot divide numbers by 0 as it will result in infinity.");
                            break;
                        }
                    }
                    else if (operators.Contains("*"))
                    {
                        DoMath("*");
                    }
                    else if (operators.Contains("-"))
                    {
                        DoMath("-");
                    }
                    else if (operators.Contains("+"))
                    {
                        DoMath("+");
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Integer is out of range.");
                    break;
                }
            }
        }
        // DoMath Method - Peforms basic math, adds result to list and removes unused elements
        private void DoMath(string o){
            int i = operators.IndexOf(o);
            int n1 = Convert.ToInt32(operands[i]);
            int n2 = Convert.ToInt32(operands[i + 1]);
            operands.Insert(i, Convert.ToString(Operation(o, n1, n2)));
            operands.RemoveRange(i + 1, 2);
            operators.RemoveAt(i);
        }
        // Operation Method - Selects appropriate math function and returns that value
        private int Operation(string o, int n1, int n2){
            switch(o){
                case "/":
                    return Divide(n1, n2);
                case "*":
                    return Multiply(n1, n2);
                case "-":
                    return Minus(n1, n2);
                case "+":
                    return Plus(n1, n2);
                default:
                    return 0;
            }
        }

        // HasNumber method - Checks if item has a number
        private bool HasNumber(string s)
        {
            foreach (var c in s)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
        // IsOperator method - Checks if item is a an Operator
        private bool IsOperator(string s)
        {
            return (s == "+" || s == "-" || s == "*" || s == "/");
        }
        // IsX method - Checks if the item is a x or X
        private bool IsX(string s)
        {
            return (s == "x" || s == "X");
        }
        // Basic operation Methods
        private int Plus(int a, int b)
        {
            return a + b;
        }
        private int Minus(int a, int b)
        {
            return a - b;
        }
        private int Multiply(int a, int b)
        {
            return a * b;
        }
        private int Divide(int a, int b)
        {
            return a / b;
        }
        // Properties
        public List<string> Operands { get => operands; set => operands = value; }
        public List<string> Operators { get => operators; set => operators = value; }

        // Test Methods
        public void showAllLists()
        {
            showList(operands, "Operands");
            showList(operators, "Operators");
        }
        private void showList(List<string> op, string desc)
        {
            Console.Write(desc + " contains" + ": ");
            foreach (var o in op)
            {
                Console.Write(o + " ");
            }
            Console.WriteLine();
        }
    }
}
