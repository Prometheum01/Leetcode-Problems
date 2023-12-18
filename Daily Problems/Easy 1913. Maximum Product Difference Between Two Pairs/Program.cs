using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{

    class Program
    {
        static void Main(string[] args)
        {

            int[] nums = { 5, 6, 2, 7, 4 };

            int result = MaxProductDifference(nums);

            Console.ReadKey();
        }

        //There are 2 diffrent solution ways.
        public static int MaxProductDifference(int[] nums)
        {
            /*
            //Sort Way
            int len = nums.Length;
            Array.Sort(nums);

            return (nums[len - 1] * nums[len - 2]) - (nums[0] * nums[1]);
            */

            //Other way
            int high = 0;
            int secondHigh = 0;
            int low = int.MaxValue;
            int secondLow = int.MaxValue;

            for (int i = 0; i < nums.Length; i++)
            {
                
                int value = nums[i];

                if(high < value)
                {
                    secondHigh = high;
                    high = value;
                }
                else
                {
                    secondHigh = Math.Max(secondHigh, value);
                }

                if(low > value)
                {
                    secondLow = low;
                    low = value;
                }
                else
                {
                    secondLow = Math.Min(secondLow, value);
                }
            }

            return (high * secondHigh) - (low * secondLow);
        }
    }
}
