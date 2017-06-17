using System;
using System.Collections.Generic;
namespace MatrxCalculator
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
		public void GetValues()
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
	}
	public class Functions
	{
		public Matrix leftMatrix;
		public Matrix rightMatrix;

		public Matrix Transpose(bool leftMatrixToTranspose)
		{
			var matrix = leftMatrixToTranspose ? this.leftMatrix : this.rightMatrix;
			var transposedMatrix = new Matrix(matrix.columns, matrix.rows);

			for (int i = 0; i < matrix.rows; ++i)
			{
				for (int j = 0; j < matrix.columns; ++j)
				{
					// every i x j value of transposed matrix is the j x i value of given matrix  
					transposedMatrix.values[j][i] = matrix.values[i][j];
				}
			}
			return transposedMatrix;
		}
		public Matrix Add()
		{
			// check requirements

			var addedMatrix = new Matrix(this.leftMatrix.rows, this.leftMatrix.columns);
            for (int i = 0; i < this.leftMatrix.rows; ++i) 
            {
                var currentRow = new List<int>();  
                for (int j = 0; j < this.leftMatrix.columns; ++j)
                {
                    currentRow.Add(this.leftMatrix.values[i][j] + this.rightMatrix.values[i][j]); 
                }
                addedMatrix.values.Add(currentRow); 
            }

			return addedMatrix;

		}
		public Matrix Subract()
		{
			// check requirements 

			var subractedMatrix = new Matrix(this.leftMatrix.rows, this.leftMatrix.columns);
			for (int i = 0; i < subractedMatrix.rows; ++i)
			{
				var currentRow = new List<int>();
				for (int j = 0; j < subractedMatrix.columns; ++j)
				{
					currentRow.Add(this.leftMatrix.values[i][j] - this.rightMatrix.values[i][j]);
				}
				subractedMatrix.values.Add(currentRow);
			}
			return subractedMatrix;
		}
		public Matrix Multiply()
		{
			// check requirements 
			var mulitpliedMatrix = new Matrix(leftMatrix.rows, leftMatrix.columns);
			// do stuff 
			return mulitpliedMatrix;
		}


	}
}
