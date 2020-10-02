using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicCollectionFA20
{
    class DynamicCollection
    {
        private int[] _collection = new int[5];
        public int Count { get; private set; } = 0;


        public void Add(int val)
        {
            if (_collection.Length < Count + 1)
            {
                Array.Resize(ref _collection, _collection.Length + 5);
                Console.WriteLine("Resizing collection....");
            }

            _collection[Count] = val;
            Count++;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _collection[i];
            }
        }

        public void RemoveAt(uint idx)
        {
            for (uint i = idx; i < _collection.Length - 1; i++)
            {
                _collection[i] = _collection[i + 1];
            }
            Count--;
        }

        public int this[uint idx]
        {
            get
            {
                if(idx >= _collection.Length)
                    throw new Exception("Can't access past the size of the collection");
                return _collection[idx];
            }

            set
            {
                if(idx >= _collection.Length)
                    throw new Exception("Can't access past the size of the collection");
                _collection[idx] = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DynamicCollection col = new DynamicCollection();
            col.Add(10);
            col.Add(20);
            col.Add(2);
            col.Add(5);

            foreach (int i in col)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(col[2]);
            col[2] = 999;
            Console.WriteLine(col[2]);
            Console.WriteLine("---------");
            foreach (int i in col)
            {
                Console.WriteLine(i);
            }
            col.RemoveAt(2);
            Console.WriteLine("---------");
            foreach (int i in col)
            {
                Console.WriteLine(i);
            }

        }
    }
}
