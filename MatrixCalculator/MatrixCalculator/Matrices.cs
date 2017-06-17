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
			// get number of rows 
			// get number of columns 
			// check if they are equal, is the matrix square? 
			// make sure each list of integers in list of integers has an equal length, is the matrix valid?
		}
	}
	public class Functions
	{
		public Matrix leftMatrix;
		public Matrix rightMatrix;

		public Matrix Transpose(bool leftMatrixToTranspose)
		{
			var matrix = leftMatrixToTranspose ? leftMatrix : rightMatrix;
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
			var addedMatrix = new Matrix(leftMatrix.rows, leftMatrix.columns);
			// do stuff 
			return addedMatrix;

		}
		public Matrix Subract()
		{
			// check requirements 
			var subractedMatrix = new Matrix(leftMatrix.rows, leftMatrix.columns);
			// do stuff 
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
