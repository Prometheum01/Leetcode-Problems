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
            Console.ReadKey();
        }
        public static int FindSpecialInteger(int[] arr)
        {
            if(arr.Length == 1)
            {
                return arr[0];
            }

            double countTimesPercentage25 = (arr.Length % 4.0 == 0 || arr.Length < 4.0) ? ((arr.Length / 4.0) + 1) : (arr.Length / 4.0);

            int countTimes = (int)Math.Ceiling(countTimesPercentage25);

            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == arr[i + countTimes - 1])
                {
                    return arr[i];
                }
            }

            return 0;
        }
    }
}
