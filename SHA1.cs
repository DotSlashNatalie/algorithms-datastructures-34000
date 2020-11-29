using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace sha1FA20
{
    public static class StringExtensions
    {
        public static string SHA1(this string msg)
        {
            using (SHA1 sha1Hash = System.Security.Cryptography.SHA1.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(msg);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string stringToHash = "Hello World123";
            using (SHA1 sha1Hash = SHA1.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(stringToHash);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                Console.WriteLine(hash);
            }
            
            Console.WriteLine("Hello World123".SHA1());

            Console.WriteLine("Hello World".SHA1());
            Console.WriteLine(File.ReadAllText("TextFile1.txt").SHA1());

            using (FileStream fs = File.OpenRead("TextFile1.txt"))
            {
                using (SHA1 sha1Hash = SHA1.Create())
                {
                    byte[] fileHash = sha1Hash.ComputeHash(fs);
                    Console.WriteLine(BitConverter.ToString(fileHash).Replace("-", "").ToLower());
                }
            }
        }
    }
}
