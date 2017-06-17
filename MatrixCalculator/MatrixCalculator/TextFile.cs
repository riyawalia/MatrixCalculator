using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;

namespace MatrixCalculator
{
	public class TextFile
	{
		public Functions functions;
        public string fileDirectory; 
        public string filePath = null;
        public List<string> rawText; 
        // file path is saved in app config, user can select while file to use 
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
                this.rawText.Add(line); 
            }

            this.functions.leftMatrix.SetValues(this.rawText[0]);
            this.functions.rightMatrix.SetValues(this.rawText[1]); 
             
			// prepare for error if format of text file is unexpected
		}
	}
}
