using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adler32FA20
{
    class Program
    {
        public static int adler32(string buffer)
        {
            int s1 = 1;
            int s2 = 0;

            for (int i = 0; i < buffer.Length; i++)
            {
                s1 = (s1 + buffer[i]) % 65521;
                s2 = (s2 + s1) % 65521;
            }

            return (s2 << 16) | s1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(adler32("test"));
            Console.WriteLine(adler32("1000"));
            Console.WriteLine(adler32("5000"));
            Console.WriteLine(adler32("sdalkfjsdiejdkfjei94894985"));
            Console.WriteLine(adler32("hello world world hello"));
            Console.WriteLine(adler32("hello world 2012-02-02 world hello"));
            Console.WriteLine(adler32("hello world 2012-01-30 world hello"));
            Console.WriteLine(adler32("hello world 2012-02-11 world hello"));
            Console.WriteLine(adler32("hello world 2012-10-30 world hello"));
        }
    }
}
