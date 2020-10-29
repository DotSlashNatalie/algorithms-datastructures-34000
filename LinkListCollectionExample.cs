using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedListTest
{
    class GenericNode<T>
    {
        public T value;
        public GenericNode<T> next = null;
    }
    class LinkedListCollection<T>
    {
        private GenericNode<T> _parent = null;
        private int[] collection = new int[5];

        /*public int Count
        {
            get
            {
                int counter = 0;
                if (_parent == null)
                    return counter;
                else
                {
                    GenericNode<T> node = _parent;
                    while (node != null)
                    {
                        node = _parent.next;
                        counter++;
                    }
                }

                return counter;
            }
            
        }*/
        public int Count { get; private set; } = 0;

        public int this[int x]
        {
            get { return collection[x]; }

            set { collection[x] = value; }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListCollection<int> test = new LinkedListCollection<int>();
            test[1] = 213;
            //test.Count = 123;
        }
    }
}
