using System;

namespace MatrixCalculator
{
    public class Menu 
    {
        public char command;
        public TextFile file; 
        public void Display()
        {
            Console.WriteLine("N: New File \nD: Display Matrices \nA: Add Matrices \nS: Subract Matrices \n" +
                              "M: Multiply Matrices \nT: Transpose Matrices \nR: Row reduce to echolon form\nQ: Quit");
            string input = Console.ReadLine();
            this.command = (input.Length > 1) ? 'E' : Char.ToUpper(input[0]); 
            // command is 'E' when user enters more than one character, this defaults to an error, try again message in the menu.
        }
        void NewFile() 
        {
            
        }
        void MatrixOperations() 
        {
            
        }

    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            var menu = new Menu();
            var file = new TextFile(); 
            while(true) 
            {
                menu.Display(); 
                switch(menu.command)
                {
                    case 'N': 
                        file = new TextFile();
                        break;
                    case 'D': 
                        file.calculator.DisplayMatrices(); 
                        break;
                    case 'A': 
                        file.calculator.Add();
                        file.WriteResult('+');
                        break;
                    case 'S':
                        file.calculator.Subract();
                        file.WriteResult('+');
                        break;
                    case 'M':
                        file.calculator.Multiply();
                        file.WriteResult('*');
                        break;
                    case 'T':
                        // ask User which matrix to transpose 
                        file.calculator.Transpose(true);
                        file.WriteResult(); 
                        break;
                    case 'R':
                        // ask User which matrix to reduce 
                        file.calculator.Reduce(true);
                        file.WriteResult();
                        break; 
                    case 'Q': return;
                    default: Console.WriteLine("Invalid command, try again. Remember commands are single characters only.");
                        break; 
                }
            }
        }
    }
}
