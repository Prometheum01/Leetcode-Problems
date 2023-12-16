using System;
using System.Collections;
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
            string s = "anagram";
            string t = "nagaram";
            
            bool result = IsAnagram(s, t);

            Console.ReadKey();
        }

        public static bool IsAnagram(string s, string t)
        {
            Dictionary<char, int> wordTable = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (wordTable.ContainsKey(c))
                {
                    int value = wordTable.GetValueOrDefault(c);

                    wordTable[c] = value + 1;
                }
                else
                {
                    wordTable.Add(c, 1);
                }
            }

            foreach (char c in t)
            {
                if (wordTable.ContainsKey(c))
                {
                    int value = wordTable.GetValueOrDefault(c);

                    if (value == 1)
                    {
                        wordTable.Remove(c);
                    }else
                    {
                        wordTable[c] = value - 1;
                    }
                }
                else
                {
                    return false;
                }
            }

            return wordTable.Count == 0;
        }
    }
}
