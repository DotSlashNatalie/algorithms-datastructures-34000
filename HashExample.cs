using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashExampleFA20
{
    public class HashTest<T>
    {
        T[] container = new T[10];

        public int getHash(int a)
        {
            return a % container.Length;
        }

        public T get(int key)
        {
            key = getHash(key);
            return container[key];
        }

        public void put(int key, T value)
        {
            key = getHash(key);
            container[key] = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HashTest<int> hashTest = new HashTest<int>();
            hashTest.put(5000, 5000);
            Console.WriteLine(hashTest.get(5000));
            hashTest.put(1, 1);
            hashTest.put(202, 202);
            hashTest.put(900007, 900007);
            Console.WriteLine(hashTest.get(5000));
            hashTest.put(1000, 1000);
            Console.WriteLine(hashTest.get(5000));
        }
    }
}
