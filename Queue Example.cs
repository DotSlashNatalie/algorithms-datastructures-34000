using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queueExampleFA20
{
    class Queue
    {
        private int[] elements = new int[5];
        private int count = -1;

        public void push(int val)
        {
            if (count == elements.Length)
                throw new Exception("queue is full");
            count++;
            elements[count] = val;
        }

        public int? pop()
        {
            if (count == -1)
                return null;
            int value = elements[0];
            elements = elements.Skip(1).ToArray();
            count--;
            return value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue();
            Console.WriteLine(q.pop());
            q.push(10);
            q.push(15);
            q.push(20);
            Console.WriteLine(q.pop());
            Console.WriteLine(q.pop());
            Console.WriteLine(q.pop());
        }
    }
}
