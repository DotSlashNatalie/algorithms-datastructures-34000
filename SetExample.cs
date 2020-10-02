using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace setExampleFA20
{
    class Set
    {
        public int?[] container = new int?[5] {null, null, null, null, null};
        public Set(int?[] container)
        {
            this.container = container;
        }

        public override string ToString()
        {
            string returnString = "";
            foreach(int? i in container)
            {
                if (i == null)
                    break;
                returnString += i + ",";
            }

            return returnString.Trim(',');
        }

        public Set add(Set other)
        {
            int? [] returnContainer = new int?[5];
            int lastIndex = 0;
            for (int i = 0; i < container.Length; i++)
            {
                lastIndex = i;
                if(container[i] == null)
                    break;
                returnContainer[i] = container[i];
            }

            lastIndex++;
            foreach (int? i in other.container)
            {
                if(i == null)
                    break;
                returnContainer[lastIndex] = i;
                lastIndex++;
            }

            return new Set(returnContainer);
        }

        public Set del(Set other)
        {
            int?[] returnContainer = new int?[5];
            for (int i = 0; i < container.Length; i++)
            {
                if(container[i] == null)
                    break;
                if (!other.container.Contains(container[i]))
                    returnContainer[i] = container[i];
            }

            return new Set(returnContainer);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Set set1 = new Set(new int?[] {6,2,1});
            Set set2 = new Set(new int?[] {3,1});
            Console.WriteLine(set1);
            Console.WriteLine(set1.add(set2));
            Console.WriteLine(set1.del(set2));
        }
    }
}
