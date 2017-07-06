using System;
namespace MatrixCalculator
{
	public class Menu
	{
		private char command;
		private TextFile file;

		public Menu(TextFile file)
		{
			this.file = file;
		}
		private void Display()
		{
			Console.WriteLine("N: New File \nD: Display Matrices \nA: Add Matrices \nS: Subract Matrices \n" +
							  "M: Multiply Matrices \nT: Transpose Matrices \nR: Row reduce to echolon form\nQ: Quit");
			string input = Console.ReadLine();
			this.command = (input.Length > 1) ? 'E' : Char.ToUpper(input[0]);
			// command is 'E' when user enters more than one character, this defaults to an error, try again message in the menu.
		}

		public void Execute()
		{
			while (true)
			{
				this.Display();
				switch (this.command)
				{
					case 'N':
						this.file = new TextFile();
						break;
					case 'D':
						this.file.calculator.DisplayMatrices();
						break;
					case 'A':
						this.file.calculator.Add();
						this.file.WriteResult('+');
						break;
					case 'S':
						this.file.calculator.Subract();
						this.file.WriteResult('+');
						break;
					case 'M':
						this.file.calculator.Multiply();
						this.file.WriteResult('*');
						break;
					case 'T':
						// ask User which matrix to transpose 
						this.file.calculator.Transpose();
						this.file.WriteResult("Transposed:");
						break;
					case 'R':
						// ask User which matrix to reduce 
						this.file.calculator.Reduce();
						this.file.WriteResult("Reduced to RREF:");
						break;
					case 'Q': return;
					default:
						Console.WriteLine("Invalid command, try again. Remember commands are single characters only.");
						break;
				}
			}
		}
	}
}
