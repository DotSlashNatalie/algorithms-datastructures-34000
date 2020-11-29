using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashtableFA20
{
    public class HashNode<K, V> where K : IComparable
    {
        public K key;
        public V val;

        public HashNode<K, V> next;

        public HashNode(K key, V val, HashNode<K, V> next)
        {
            this.key = key;
            this.val = val;
            this.next = next;
        }
    }

    public class HashTable<K, V> where K : IComparable
    {
        private const int CONTAINER_SIZE = 10;
        private HashNode<K,V>[] container = new HashNode<K, V>[CONTAINER_SIZE];

        public V this[K idx]
        {
            get
            {
                int i = hash(idx);
                for (HashNode<K, V> x = container[i]; x != null; x = x.next)
                {
                    if (idx.CompareTo(x.key) == 0)
                        return x.val;
                }

                return default(V);
            }
            set
            {
                int i = hash(idx);
                for (HashNode<K, V> x = container[i]; x != null; x = x.next)
                {
                    if (idx.CompareTo(x.key) == 0)
                    {
                        x.val = value;
                        return;
                    }
                }
                container[i] = new HashNode<K, V>(idx, value, container[i]);
            }
        }

        private int hash(K key)
        {
            return (key.GetHashCode() & Int32.MaxValue) % CONTAINER_SIZE;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, string> htable = new HashTable<string, string>();
            htable["test3"] = "t3";
            htable["test"] = "t";
            htable["test1"] = "t1";
            htable["test2"] = "t2";

            for (int i = 0; i < 9999; i++)
            {
                htable["newtest" + i.ToString()] = i.ToString();
            }

            Console.WriteLine(htable["test"]);
            Console.WriteLine(htable["test1"]);
            Console.WriteLine(htable["test2"]);
            Console.WriteLine(htable["test3"]);

            Console.WriteLine(htable["newtest1"]);
            Console.WriteLine(htable["newtest2"]);
            Console.WriteLine(htable["newtest3"]);
        }
    }
}
