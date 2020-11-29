using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mergeSortFA20
{
    class MergeSort<T> where T : IComparable
    {
        public List<T> sort(List<T> container)
        {
            return mergesort(container);
        }
        public List<T> mergesort(List<T> arr)
        {
            if (arr.Count <= 1)
                return arr;

            int middle = arr.Count / 2;
            List<T> left = arr.GetRange(0, middle);
            List<T> right = arr.GetRange(middle, arr.Count - middle);

            left = mergesort(left);
            right = mergesort(right);

            return merge(left, right);
        }

        public List<T> merge(List<T> left, List<T> right)
        {
            List<T> res = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0].CompareTo(right[0]) <= 0)
                    {
                        res.Add(left[0]);
                        left = left.Skip(1).ToList();
                    }
                    else
                    {
                        res.Add(right[0]);
                        right = right.Skip(1).ToList();
                    }
                    
                } else if (left.Count > 0)
                {
                    res.Add(left[0]);
                    left = left.Skip(1).ToList();
                } else if (right.Count > 0)
                {
                    res.Add(right[0]);
                    right = right.Skip(1).ToList();
                }
            }

            return res;
        }
    }

    public static class StopWatchExtension
    {
        public static void StartGC(this Stopwatch watch)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            watch.Start();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MergeSort<int> sort = new MergeSort<int>();
            List<int> test1 = new List<int>() {2,6,1,9,3,5};
            Console.WriteLine(String.Join(",", test1));
            test1 = sort.sort(test1);
            Console.WriteLine(String.Join(",", test1));
            Random r = new Random();

            List<int> test2 = new List<int>();
            for(int i = 0; i < 99999; i++)
                test2.Add(r.Next(0, 100));


            List<int> test3 = new List<int>();
            for (int i = 0; i < 9999999; i++)
                test3.Add(r.Next(0, 100));

            Stopwatch watch1 = new Stopwatch();
            watch1.StartGC();
            test2 = sort.sort(test2);
            watch1.Stop();
            Console.WriteLine(watch1.Elapsed);
        }
    }
}
