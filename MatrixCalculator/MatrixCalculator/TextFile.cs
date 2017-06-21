using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;

namespace MatrixCalculator
{
	public class TextFile
	{
        protected Calculator _calculator; 
        public Calculator calculator { get { return _calculator ?? (_calculator = new Calculator());  } set { _calculator = value;  }}
        public string fileDirectory; 
        public string filePath { get; set; }
        // file path is saved in app config, user can select which file to use 
        protected bool EnterFileName()
        {
			Console.WriteLine("Enter file name:");
			string fileName = Console.ReadLine();

            if (fileName == "M")
            {
                return false; 
            }
            this.filePath = this.fileDirectory + "\\" + fileName;
            return true; 
		}
		public TextFile()
		{
            var rawText = new List<string>(); 
            this.fileDirectory = ConfigurationManager.AppSettings["fileDirectory"];
            string[] matrixSeperator = { "" }; 
            if (!Directory.Exists(fileDirectory))
            {
                Console.WriteLine("Directory does not exist. Go to App Config to change file directory");
                return; 
            }
            EnterFileName(); 
            while(!File.Exists(this.filePath))
            {
				Console.WriteLine("Invalid file name! Try again. Enter M to exit to Main Menu.");
                if (!EnterFileName())
                {
                    return; 
                }
			}
            foreach (string line in File.ReadLines(this.filePath))
            {
                rawText.Add(line); 
            }

            this.calculator.leftMatrix.SetValues(rawText[0]);
            this.calculator.rightMatrix.SetValues(rawText[1]); 
             
			// prepare for error if format of text file is unexpected
		}

        public void WriteResult(string operation)
        {
            StreamWriter resultFile = File.AppendText("..\\Text Files\\result.txt");

            string resultMessage = this.calculator.leftMatrix.ToString() + operation + this.calculator.rightMatrix.ToString() + " = " + this.calculator.resultMatrix.ToString(); 

            resultFile.WriteLine(resultMessage);
        }
        public void WriteResult()
        {
            StreamWriter resultFile = File.AppendText("..\\Flat Files\\result.txt");

            resultFile.WriteLine(this.calculator.resultMatrix.ToString()); 
        }
	}
}
