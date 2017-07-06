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

        private string fileDirectory; 
        private string filePath { get; set; }
        // file path is saved in app config, user can select which file to use 
        private bool EnterFileName()
        {
			Console.WriteLine("Enter file name:");
			string fileName = Console.ReadLine();

            if (fileName == "M")
            {
                return false; 
            }
            this.filePath = Path.Combine(this.fileDirectory, Path.GetFileName(fileName)); 
            return true; 
		}
        private string GetFolderPath()
        {
            string solutionPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))); 
            return solutionPath; 
        }
		public TextFile()
		{
            var rawText = new List<string>();
            //this.fileDirectory = ConfigurationManager.AppSettings["fileDirectory"];
            this.fileDirectory = this.GetFolderPath(); 
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

            calculator.leftMatrix.SetValues(rawText[0]);
            calculator.rightMatrix.SetValues(rawText[2]); 
             
			// prepare for error if format of text file is unexpected
		}

        public void WriteResult(char operation)
        {
            string resultPath = Path.Combine(this.fileDirectory, Path.GetFileName("result.txt")); 
            StreamWriter resultFile = File.AppendText(resultPath);

            string resultMessage = "-----------------------------\n" + 
                                   calculator.leftMatrix.ToString() + "\n\n" + operation + "\n\n" + calculator.rightMatrix.ToString() + "\n\n=\n\n" + calculator.resultMatrix.ToString() + '\n';

            resultFile.WriteLine(resultMessage);
            resultFile.Close(); 
        }
        public void WriteResult(string operation)
        {
            string resultPath = Path.Combine(this.fileDirectory, Path.GetFileName("result.txt")); 
            StreamWriter resultFile = File.AppendText(resultPath);

            resultFile.WriteLine("-----------------------------\n" + operation + "\n" +
                                 calculator.resultMatrix.ToString());
            resultFile.Close(); 
        }
	}
}
