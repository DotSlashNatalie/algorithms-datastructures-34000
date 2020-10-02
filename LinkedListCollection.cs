using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedListCollectionFA20
{
    class GenericNode<T>
    {
        public T value;
        public GenericNode<T> next = null;
    }
    class LinkedListCollection<T>
    {
        private GenericNode<T> _parent = null;

        public LinkedListCollection(T val)
        {
            _parent = new GenericNode<T>() {value = val};
        }

        public void Add(T val)
        {
            GenericNode<T> node = _parent.next;
            while (node != null)
                node = node.next;
            node.next = new GenericNode<T>() {value = val};
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListCollection<string> llcol = new LinkedListCollection<string>("hello world");
        }
    }
}
