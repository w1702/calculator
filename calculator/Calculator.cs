using System;

/*
 * NOTE: THIS PROGRAM IS COMPILED WITH .NET CORE ON MAC OS
 * 
 * 1. PASS IN SINGLE EQUATION ARGUMENT ENCLOSED IN QUOTATION MARKS 
 * OR 
 * PASS IN EQUATION AS MULTIPLE ARGUMENTS WITH THE MULTIPLICATION "*" CHARACTER ENCLOSED IN QUOTES
 * OTHERWISE USING THE * CHARACTER IN THE COMMAND LINEWITHOUT QUOTES WILL RETURN A LIST OF 
 * FILES IN PRESENT DIRECTORY (IN MAC OS)
 * 
 * 2. EACH CHARACTER MUST BE SEPERATED BY SPACES
 * 
 * E.G. 
 * "X = 5 + 22 * 3" 
 * OR 
 * X = 5 + 22 "*" 3
 */

namespace calc
{
    class Calculator
    {
        private Equation equation;

        static void Main(string[] args)
        {
            // Initialise a new Calculator object and pass in args
            Calculator c = new Calculator(args);
            // Calculate the equation
            c.Calculate();
            Console.ReadKey();
        }

        // Calculator Constructor - Create a new equation object by passing in an array of arguments
        public Calculator(string[] args)
        {
            equation = new Equation(args);
        }

        // Calculate
        public void Calculate(){
            equation.SortEquation();
            equation.Calculate();
            equation.ShowResult();

            // Test - Show all lists
            //equation.showAllLists();
        }
    }
}
