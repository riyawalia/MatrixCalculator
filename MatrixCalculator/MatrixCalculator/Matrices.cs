using System;
using System.Linq; 
using System.Collections.Generic;

namespace MatrixCalculator
{
	public class Matrix
	{
        private List<List<int>>_values; 
		public List<List<int>> values { get { return _values ?? (_values = new List<List<int>>()); } set { _values = value; } }
		public int rows;
		public int columns;
		public bool squareMatrix;
		public bool valid;

		public Matrix()
		{
			// do stuff 

		}
		public Matrix(int rows, int columns)
		{
			this.rows = rows;
			this.columns = columns;
			this.squareMatrix = (rows == columns);
			// if matrix is being created with known number of rows and columns, 
			// a function is creating it, and hence it is valid 
			this.valid = true;
		}
        public void IsValid()
        {
            foreach(List<int> row in this.values) 
            {
                if (this.columns != row.Count()) 
                {
                    this.valid = false; 
                }
            }
            this.valid = true; 
        }
		public void SetValues(string rawMatrix)
		{
            string[] rowSeperator = { "\t\t" };
            string[] numberSeperator = { "\t" }; 
            string[] rawRows = rawMatrix.Split(rowSeperator, StringSplitOptions.RemoveEmptyEntries);
   
            foreach(string rawRow in rawRows)
            {
                List<string> numbers = rawRow.Split(numberSeperator, StringSplitOptions.RemoveEmptyEntries).ToList(); 
                this.values.Add(numbers.Select(num => Convert.ToInt32(num)).ToList()); 
            }
            this.rows = this.values.Count;
            this.columns = (this.rows > 0) ? this.values[0].Count() : 0;
            this.IsValid();
            this.squareMatrix = (this.rows == this.columns); 
		}
        public void Display()
        {
            Console.WriteLine("Number of rows: {0}\n Number of columns: {1}", this.rows, this.columns); 
            values.ForEach(rows => {
                rows.ForEach(value =>
                {
                    Console.WriteLine("{0}\t", value);
                });
                Console.WriteLine("\n");                 
            });
        }
        public List<int> GetColumn(int columnNumber)
        {
            var column = new List<int>();
            for (int i = 0; i < this.rows; ++i) 
            {
                column.Add(this.values[i][columnNumber]); 
            }
            return column; 
        }
        public override string ToString()
        {
			string rawMatrix = "";

			this.values.ForEach(row =>
			{
				string rawRow = "";
				row.ForEach(value =>
				{
					rawRow += value.ToString() + "\t";
				});
				rawMatrix += rawRow + "\t\t";
			});
            return rawMatrix; 
        }
	}
	public class Calculator
	{
        private Matrix _leftMatrix;
		public Matrix leftMatrix { get { return _leftMatrix ?? (_leftMatrix = new Matrix()); } set { _leftMatrix = value; } }

        private Matrix _rightMatrix;
		public Matrix rightMatrix { get { return _rightMatrix ?? (_rightMatrix = new Matrix()); } set { _rightMatrix = value; } }

        private Matrix _resultMatrix; 
        public Matrix resultMatrix { get { return _resultMatrix ?? (_resultMatrix = new Matrix()); } set { _resultMatrix = value; } }

        public void DisplayMatrices() 
        {
            Console.WriteLine("Left Matrix:");
            this.leftMatrix.Display();

			Console.WriteLine("Right Matrix:");
			this.rightMatrix.Display();

		}
		protected bool CannotCombine()
		{
			return
				this.rightMatrix.rows != this.leftMatrix.rows || this.rightMatrix.columns != this.leftMatrix.columns;
		}
		protected bool CannotMultiply()
		{
			return
				this.leftMatrix.columns != this.rightMatrix.rows;

		}
		protected int MultiplyRowColumn(List<int> row, List<int> column)
		{
			int result = 0;
			for (int i = 0; i < row.Count; ++i)
			{
				result += row[i] * column[i];
			}
			return result;
		}
        /// <summary>
        /// Transpose the specified matrix.
        /// </summary>
        /// <returns>The transposed matrix.</returns>
        /// <param name="leftMatrix">If set to <c>true</c> left matrix is transposed. Else right.</param>
		public void Transpose(bool leftMatrix)
		{
			var matrix = leftMatrix? this.leftMatrix : this.rightMatrix;
			this.resultMatrix = new Matrix(matrix.columns, matrix.rows);

			for (int i = 0; i < matrix.rows; ++i)
			{
				for (int j = 0; j < matrix.columns; ++j)
				{
					// every i x j value of transposed matrix is the j x i value of given matrix  
					this.resultMatrix.values[j][i] = matrix.values[i][j];
				}
			}
		}
		public void Add()
		{
            if (this.CannotCombine()) 
            {
                // handle error
                return; 
            }

			this.resultMatrix = new Matrix(this.leftMatrix.rows, this.leftMatrix.columns);
            for (int i = 0; i < this.resultMatrix.rows; ++i) 
            {
                var currentRow = new List<int>();  
                for (int j = 0; j < this.resultMatrix.columns; ++j)
                {
                    currentRow.Add(this.leftMatrix.values[i][j] + this.rightMatrix.values[i][j]); 
                }
                this.resultMatrix.values.Add(currentRow); 
            }

		}
		public void Subract()
		{
			if (this.CannotCombine())
			{
                // handle error 
				return;
			}

			this.resultMatrix = new Matrix(this.leftMatrix.rows, this.leftMatrix.columns);
			for (int i = 0; i < this.resultMatrix.rows; ++i)
			{
				var currentRow = new List<int>();
				for (int j = 0; j < this.resultMatrix.columns; ++j)
				{
					currentRow.Add(this.leftMatrix.values[i][j] - this.rightMatrix.values[i][j]);
				}
				this.resultMatrix.values.Add(currentRow);
			}
		}
		public void Multiply()
		{
            if (this.CannotMultiply()) 
            {
                // handle error
                return; 
            }
			this.resultMatrix = new Matrix(this.leftMatrix.columns, this.rightMatrix.rows);

            for (int i = 0; i < this.resultMatrix.rows; ++i)
            {
                int currentValue = 0;
                var currentRow = new List<int>(); 
                for (int j = 0; j < this.resultMatrix.columns; ++j) 
                {
                    currentValue = this.MultiplyRowColumn(this.leftMatrix.values[i], this.rightMatrix.GetColumn(j));
                    currentRow.Add(currentValue); 
                }
                this.resultMatrix.values.Add(currentRow); 
            }
		}
        public void Reduce(bool leftMatrix)
        {
            // row reduce only if it can: handle errors otherwise
            // do stuff
            return; 
        }

	}
}
