using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace FA20BubbleSort
{
    public static class StopWatchExtension
    {
        public static void StartGC(this Stopwatch watch)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            watch.Start();
        }
    }
    class BubbleSort1<T> where T : IComparable
    {
        public void Swap(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        public void Sort(T[] container, bool debug = false)
        {
            int steps = 0;
            if (debug)
                Console.WriteLine();

            for (int outer = container.Length - 1; outer >= 1; outer--)
            {
                for (int inner = 0; inner <= outer - 1; inner++)
                {
                    //if (container[inner] > container[inner + 1])
                    if(container[inner].CompareTo(container[inner + 1]) > 0)
                    {
                        // swap
                        Swap(ref container[inner], ref container[inner + 1]);
                    }

                    steps++;
                }
                if (debug)
                    Console.WriteLine(String.Join(",", container));
            }

            if (debug)
                Console.WriteLine($"Steps = {steps}\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*BubbleSort1<int> sort1 = new BubbleSort1<int>();
            int[] arr1 = new int[] {1,2,3,4,5};
            int[] arr2 = new int[] {2,5,1,3,5};
            int[] arr3 = new int[] {10, 40, 2, 7, 9, 1, 0};
            Random r = new Random();
            int[] arr4 = new[] 
                { r.Next(0, 100), r.Next(0, 100), r.Next(0, 100), r.Next(0, 100), r.Next(0, 100), r.Next(0, 100)};

            Console.WriteLine(String.Join(",", arr1));
            sort1.Sort(arr1);
            Console.WriteLine(String.Join(",", arr1));

            Console.WriteLine(String.Join(",", arr2));
            sort1.Sort(arr2);
            Console.WriteLine(String.Join(",", arr2));

            Console.WriteLine(String.Join(",", arr3));
            sort1.Sort(arr3);
            Console.WriteLine(String.Join(",", arr3));

            Console.WriteLine(String.Join(",", arr4));
            sort1.Sort(arr4);
            Console.WriteLine(String.Join(",", arr4));*/

            /*BubbleSort1<string> sort2 = new BubbleSort1<string>();
            string[] str1 = new[] {"hello", "world", "0", "10", "100", "22", "300", "20"};
            string[] str2 = new[] {"I", "wonder", "how", "this", "will", "sort", "?"};

            //Console.WriteLine(String.Join(",", str1));
            //sort2.Sort(str1);
            //Console.WriteLine(String.Join(",", str1));

            Console.WriteLine(String.Join(",", str2));
            sort2.Sort(str2);
            Console.WriteLine(String.Join(",", str2));*/

            Random r = new Random();
            BubbleSort1<int> sort3 = new BubbleSort1<int>();
            Stopwatch stop1 = new Stopwatch();

            int[] test1 = new int[999];
            int[] test2 = new int[99999];
            int[] test3 = new int[9999999];

            for (int i = 0; i < test1.Length; i++)
                test1[i] = r.Next(0, 100);

            for (int i = 0; i < test2.Length; i++)
                test2[i] = r.Next(0, 100);

            for (int i = 0; i < test3.Length; i++)
                test3[i] = r.Next(0, 100);

            stop1.StartGC();
            sort3.Sort(test1);
            stop1.Stop();
            Console.WriteLine(stop1.Elapsed.ToString());

            stop1 = Stopwatch.StartNew();
            stop1.StartGC();
            List<int> sortedTest = test2.ToList();
            sortedTest.Sort();
            stop1.Stop();
            Console.WriteLine(stop1.Elapsed.ToString());

            /*stop1.StartGC();
            sort3.Sort(test2);
            stop1.Stop();
            Console.WriteLine(stop1.Elapsed.ToString());*/
        }
    }
}
