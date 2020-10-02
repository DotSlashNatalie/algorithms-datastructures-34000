using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericStackFA20
{
    class Stack<T>
    {
        T[] elements = new T[5];
        private int count = -1;

        public void push(T val)
        {
            if (count == elements.Length)
                throw new Exception("stack is full");
            count++;
            elements[count] = val;
        }

        public T pop()
        {
            if (count == -1)
                return default(T);
            T value = elements[count];
            count--;
            return value;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> s = new Stack<int>();
            Console.WriteLine(s.pop());
            s.push(10);
            s.push(15);
            Console.WriteLine(s.pop());
            Console.WriteLine(s.pop());
            Console.WriteLine(s.pop());
        }
    }
}
