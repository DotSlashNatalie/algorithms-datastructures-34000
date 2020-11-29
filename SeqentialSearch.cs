using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sequentialSearchFA20
{
    class MergeSort<T> where T : IComparable
    {

        public List<T> Sort(List<T> arr)
        {
            if (arr.Count <= 1)
                return arr;

            int middle = arr.Count / 2;
            List<T> left = arr.GetRange(0, middle);
            List<T> right = arr.GetRange(middle, arr.Count - middle);

            left = Sort(left);
            right = Sort(right);

            return merge(left, right);
        }

        public List<T> merge(List<T> left, List<T> right)
        {
            List<T> res = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0].CompareTo(right[0]) >= 0)
                    {
                        res.Add(left[0]);
                        left = left.Skip(1).ToList();
                    }
                    else
                    {
                        res.Add(right[0]);
                        right = right.Skip(1).ToList();
                    }
                }
                else if (left.Count > 0)
                {
                    res.Add(left[0]);
                    left = left.Skip(1).ToList();
                }
                else if (right.Count > 0)
                {
                    res.Add(right[0]);
                    right = right.Skip(1).ToList();
                }
            }

            return res;
        }
    }

    class BinarySearch<T> where T : IComparable
    {
        public int Search(T item, List<T> arr)
        {
            int low = 0;
            int high = arr.Count - 1;
            int idx;
            while (low <= high)
            {
                idx = (low + high) / 2;
                if (item.CompareTo(arr[idx]) == 0)
                {
                    return idx;
                }
                else if (item.CompareTo(arr[idx]) > 0)
                {
                    high = idx - 1;
                }
                else
                {
                    low = idx + 1;
                }

            }

            return -1;
        }
    }


    class Program
    {
        public static bool search(List<int> arr, int val)
        {
            for (int index = 0; index < arr.Count - 1; index++)
            {
                if (arr[index] == val)
                    return true;
            }

            return false;
        }
        static void Main(string[] args)
        {
            Random r = new Random();
            MergeSort<int> sort1 = new MergeSort<int>();
            BinarySearch<int> search1 = new BinarySearch<int>();
            List<int> test1 = new List<int>();
            for (int i = 0; i < 999999; i++)
                test1.Add(r.Next(0, 100));

            int valueToFind = r.Next(0, 100);
            //int middle = test1.Count / 2;
            //int valueToFind = test1[middle];
            Console.WriteLine(valueToFind);
            Console.WriteLine(search(test1, valueToFind));
            //Console.WriteLine(search(test1, valueToFind));
            Console.WriteLine("Before sort");
            //test1 = sort1.Sort(test1);
            test1.Sort();
            Console.WriteLine("After sort");
            //Console.WriteLine(String.Join(",", test1));
            Console.WriteLine(search1.Search(valueToFind, test1));
            
        }
    }
}
