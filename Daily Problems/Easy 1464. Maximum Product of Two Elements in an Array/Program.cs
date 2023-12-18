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
        }

        public int MaxProduct(int[] nums)
        {
            //Other way with sort function
            //Array.Sort(nums);
            //return (nums[nums.Length - 1] - 1) * (nums[nums.Length - 2] - 1);

            int maxValue = 0;
            int secondMaxValue = 0;

            foreach (int value in nums)
            {
                if(maxValue < value) {
                    secondMaxValue = maxValue;

                    maxValue = value;
                }else
                {
                    if(secondMaxValue < value) { 
                        secondMaxValue = value;
                    }
                }
            }

            return (maxValue - 1) * (secondMaxValue - 1);
        }
    }
}
