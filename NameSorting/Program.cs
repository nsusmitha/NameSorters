using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace NameSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("D:/unsorted-names-list.txt");

            List<string> UnSortedString = new List<string>();
            List<string> SortedString = new List<string>();
            List<string> FinalSortedString = new List<string>();
            string str;
            Console.WriteLine("============ UnSorted List =============");

            while ((str = sr.ReadLine()) != null)
            {
                UnSortedString.Add(str);
                Console.WriteLine(str);

                var words = str.Split(' ');
                var length = words.Length;
                SortedString.Add(words[length - 1] + " " + string.Join(" ", words, 0, length - 1));
            }
            SortedString.Sort();

            Console.WriteLine("============ Sorted List =============");

            foreach (string s in SortedString)
            {
                foreach (String ss in UnSortedString)
                {
                    var sss = s.Split(' ');
                    int len = sss.Length;
                    int i = 0;
                    int count = 0;
                    while (i < len)
                    {
                        if (ss.Contains(sss[i]))
                        {
                            count++;
                        }
                        i++;
                    }
                    if (count == len)
                    {
                        FinalSortedString.Add(ss);
                        Console.WriteLine(ss);

                    }

                }
            }
            ////=============================
            StreamWriter sw = new StreamWriter("D:/sorted-names-list.txt");
            {

                foreach (string s in FinalSortedString)
                {
                    sw.WriteLine(s);
                }
            }
            sw.Close();
            Console.ReadKey();


        }
    }
}
