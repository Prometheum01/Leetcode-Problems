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

            mat[0] =  new int[]{ 1, 0, 0 };
            mat[1] =  new int[]{ 0, 0, 1 };
            mat[2] =  new int[]{ 1, 0, 0 };

            int result = NumSpecial(mat);

            Console.ReadKey();
        }
        public static int NumSpecial(int[][] mat)
        {

            /*//Brute Force

            int specialCounter = 0;

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat.First().Length; j++)
                {
                    if (mat[i][j] != 1)
                    {
                        continue;
                    }
                    else
                    {
                        int otherValue = 0;

                        for (int k = 0; k < mat.First().Length; k++)
                        {
                            if (mat[i][k] == 1 && k != j)
                            {
                                otherValue = 1;
                                break;
                            }
                        }

                        for (int k = 0; k < mat.Length; k++)
                        {
                            if (mat[k][j] == 1 && k != i)
                            {
                                otherValue = 1;
                                break;
                            }
                        }

                        if (otherValue == 1)
                        {
                            break;
                        }
                        else
                        {
                            specialCounter++;
                        }
                    }

                }

            }

            return specialCounter;*/

            //Precompute sum of row and column way
            int speacialCounter = 0;

            int[] rowSum = new int[mat.Length];
            int[] columnSum = new int[mat.First().Length];

            for (int i = 0; i < rowSum.Length; i++)
            {
                for (int j = 0; j < columnSum.Length; j++)
                {
                    if (mat[i][j] == 1)
                    {

                        rowSum[i] += mat[i][j];
                        columnSum[j] += mat[i][j];

                    }
                }
            }

            for (int i = 0; i < mat.Length; i++)
            {
                if (rowSum[i] == 1)
                {
                    for (int j = 0; j < mat.First().Length; j++)
                    {
                        if (columnSum[j] == 1 && mat[i][j] == 1)
                        {
                            speacialCounter++;
                        }
                    }
                }
            }
            
            return speacialCounter;
        }
    }
}
