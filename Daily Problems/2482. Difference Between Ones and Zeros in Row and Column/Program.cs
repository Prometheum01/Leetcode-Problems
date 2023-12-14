using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] mat = new int[3][];

            mat[0] =  new int[]{ 0, 1, 1 };
            mat[1] =  new int[]{ 1, 0, 1 };
            mat[2] =  new int[]{ 0, 0, 1 };

            int[][] resultDiff = OnesMinusZeros(mat);

            Console.ReadKey();
        }

        public static int[][] OnesMinusZeros(int[][] grid)
        {
            int rowCount = grid.Length;
            int columnCount = grid.First().Length;

            int[] rowSum = new int[rowCount];
            int[] columnSum = new int[columnCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    rowSum[i] += grid[i][j];
                    columnSum[j] += grid[i][j];
                }
            }

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    grid[i][j] = (rowSum[i] - (columnCount - rowSum[i])) + (columnSum[j] - (rowCount - columnSum[j]));
                }
            }

            return grid;
        }

    }
}
