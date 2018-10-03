using System;
using System.Collections.Generic;

namespace calc
{
    public class Equation
    {
        private string equation; // The full equation
        private List<Side> sides = new List<Side>(); // A list sides, there are two sides in an equation, split by "="

        // Equation Constructor - forms the full equation from array of args, splits them and creates 2 new side objects
        public Equation(string[] args)
        {
            foreach (var a in args){
                this.equation += a + " ";
            }
 
            foreach(var s in equation.Split('=')){
                sides.Add(new Side(s));
            }
        }

        // Calculate Method - Calculates each side of equation
        public void Calculate()
        {
            foreach (var s in sides)
            {
                s.Calculate();
            }
        }
        // SortEquation Method - Sorts each sides subequation's characters
        public void SortEquation()
        {
            foreach (var s in sides)
            {
                s.SortEquation();
            }
        }
        // ShowResult Method - Shows the result of the calculation
        public void ShowResult()
        {
            // sides[0] is the left side, sides 1 is the right side
            // if the left side contains X AND if there is one Operand on both sides
            if ((sides[0].Operands.Contains("X") || sides[0].Operands.Contains("x"))
                && sides[0].Operands.Count == 1 && sides[1].Operands.Count == 1)
            {
                Console.WriteLine(sides[0].Operands[0] + " = " + sides[1].Operands[0]);
            }
            // if the right side contains X AND if there is one Operand on both sides
            if ((sides[1].Operands.Contains("X") || sides[1].Operands.Contains("x")) 
                && sides[0].Operands.Count == 1 && sides[1].Operands.Count == 1){
                Console.WriteLine(sides[1].Operands[0] + " = " + sides[0].Operands[0]);
            }
        }

        // Test
        public void showAllLists()
        {
            Console.WriteLine("Equation is: " + equation);

            Console.WriteLine("Left Side");
            sides[0].showAllLists();
            Console.WriteLine("Right Side");
            sides[1].showAllLists();
            Console.WriteLine();
        }
    }
}
