using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace genericDynamicCollection
{
    class GenericCollection<T>
    {
        private T[] _collection = new T[5];
        public int Count { get; private set; } = 0;

        public void Add(T val)
        {
            if (_collection.Length < Count + 1)
            {
                Array.Resize(ref _collection, _collection.Length + 5);
            }

            _collection[Count] = val;
            Count++;
        }

        public T this[int idx]
        {
            get { Console.WriteLine( ((idx % Count) + Count) % Count); return _collection[((idx % Count) + Count) % Count]; }
            set { _collection[((idx % Count) + Count) % Count] = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericCollection<int> col1 = new GenericCollection<int>();
            for(int i = 0; i < 10; i++)
                col1.Add(i);

            Console.WriteLine(col1[99]);
        }
    }
}
