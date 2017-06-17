using System;

namespace MatrixCalculator
{
    public class Menu 
    {
        public char command; 
        void Display()
        {
            
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
            while(true) 
            {
                switch(menu.command)
                {
                    case 'Q': return;                       
                }
            }
        }
    }
}
