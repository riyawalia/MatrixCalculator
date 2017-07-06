using System;

namespace MatrixCalculator
{
   
    class MainClass
    {
        public static void Main(string[] args)
        {
			var menu = new Menu(new TextFile());

            menu.Execute(); 
        }
    }
}
