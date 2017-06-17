using System;
using System.Collections.Generic;

namespace MatrixCalculator
{
	public class Matrix
	{
		public List<List<int>> values; // instantiate list
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
		public void SetValues()
		{
            this.rows = this.values.Count;
            this.columns = 0; 
			// get number of rows 
			// get number of columns 
			// check if they are equal, is the matrix square? 
			// make sure each list of integers in list of integers has an equal length, is the matrix valid?
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
	}
	public class Functions
	{
		public Matrix leftMatrix;
		public Matrix rightMatrix;

        public void DisplayMatrices() 
        {
            Console.WriteLine("Left Matrix:");
            this.leftMatrix.Display();

			Console.WriteLine("Right Matrix:");
			this.rightMatrix.Display();

		}
        /// <summary>
        /// Transpose the specified matrix.
        /// </summary>
        /// <returns>The transposed matrix.</returns>
        /// <param name="leftMatrix">If set to <c>true</c> left matrix is transposed. Else right.</param>
		public Matrix Transpose(bool leftMatrix)
		{
			var matrix = leftMatrix? this.leftMatrix : this.rightMatrix;
			var result = new Matrix(matrix.columns, matrix.rows);

			for (int i = 0; i < matrix.rows; ++i)
			{
				for (int j = 0; j < matrix.columns; ++j)
				{
					// every i x j value of transposed matrix is the j x i value of given matrix  
					result.values[j][i] = matrix.values[i][j];
				}
			}
			return result;
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
		public Matrix Add()
		{
            if (this.CannotCombine()) 
            {
                return null; 
            }

			var result = new Matrix(this.leftMatrix.rows, this.leftMatrix.columns);
            for (int i = 0; i < result.rows; ++i) 
            {
                var currentRow = new List<int>();  
                for (int j = 0; j < result.columns; ++j)
                {
                    currentRow.Add(this.leftMatrix.values[i][j] + this.rightMatrix.values[i][j]); 
                }
                result.values.Add(currentRow); 
            }

			return result;

		}
		public Matrix Subract()
		{
			if (this.CannotCombine())
			{
				return null;
			}

			var result = new Matrix(this.leftMatrix.rows, this.leftMatrix.columns);
			for (int i = 0; i < result.rows; ++i)
			{
				var currentRow = new List<int>();
				for (int j = 0; j < result.columns; ++j)
				{
					currentRow.Add(this.leftMatrix.values[i][j] - this.rightMatrix.values[i][j]);
				}
				result.values.Add(currentRow);
			}
			return result;
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
		public Matrix Multiply()
		{
            if (this.CannotMultiply()) 
            {
                return null; 
            }
			var result = new Matrix(this.leftMatrix.columns, this.rightMatrix.rows);

            for (int i = 0; i < result.rows; ++i)
            {
                int currentValue = 0;
                var currentRow = new List<int>(); 
                for (int j = 0; j < result.columns; ++j) 
                {
                    currentValue = this.MultiplyRowColumn(this.leftMatrix.values[i], this.rightMatrix.GetColumn(j));
                    currentRow.Add(currentValue); 
                }
                result.values.Add(currentRow); 
            }
			return result;
		}


	}
}
