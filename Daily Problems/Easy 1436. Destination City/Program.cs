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

        public string DestCity(IList<IList<string>> paths)
        {
            //Brute Force
            /*            for (int i = 0; i < paths.Count; i++)
                        {
                            string to = paths[i][1];

                            string from = "";

                            bool flag = false;

                            for (int j = 0; j < i; j++)
                            {
                                from = paths[j][0];

                                if (from == to)
                                {
                                    flag = true;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            for (int j = i + 1; j < paths.Count; j++)
                            {
                                from = paths[j][0];

                                if (from == to)
                                {
                                    flag = true;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            if (!flag)
                            {
                                return to;
                            }
                        }
                        return "";*/

            HashSet<string> hashSetFrom = new HashSet<string>();

            for (int i = 0; i < paths.Count; i++)
            {
                string from = paths[i][0];

                hashSetFrom.Add(from);
            }

            for (int i = 0; i < paths.Count; i++)
            {
                string from = paths[i][0];

                if (!hashSetFrom.Contains(from))
                {
                    return from;
                }
            }

            return "";
        }

    }
}
