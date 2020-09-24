using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericsEx1FA20
{
    class Program
    {
        static void swap1(int lhs, int rhs)
        {
            int temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        static void swap2(ref int lhs, ref int rhs)
        {
            int temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        static void swap3<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        

        static void Main(string[] args)
       {
            int left;
            int right = 10;
            left = 10;
            right = 20;
            Console.WriteLine("{0} - {1}", left, right);
            swap2(ref left, ref right);
            Console.WriteLine("{0} - {1}", left, right);
        }
    }
}
