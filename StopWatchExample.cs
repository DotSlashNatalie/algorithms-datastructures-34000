using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace stopwatchExampleFA20
{
    public static class StopWatchExtension
    {
        public static void StartGC(this Stopwatch watch)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            watch.Start();
        }
    }
    class GCStopWatch
    {
        private Stopwatch watch = new Stopwatch();

        public void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            watch.Start();
        }

        public void Stop()
        {
            watch.Stop();
        }

        public TimeSpan Elapsed()
        {
            return watch.Elapsed;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch1 = new Stopwatch();
            watch1.Start();
            for (int i = 0; i < 999999; i++)
            {
                int x = new int();
                x++;
            }
            Thread.Sleep(1000);
            watch1.Stop();
            Console.WriteLine(watch1.Elapsed.ToString());

            GCStopWatch watch2 = new GCStopWatch();
            watch2.Start();
            for (int i = 0; i < 999999; i++)
            {
                int x = new int();
                x++;
            }
            Thread.Sleep(1000);
            watch2.Stop();
            Console.WriteLine(watch2.Elapsed().ToString());

            Stopwatch watch3 = new Stopwatch();
            watch3.StartGC();
            for (int i = 0; i < 999999; i++)
            {
                int x = new int();
                x++;
            }
            Thread.Sleep(1000);
            watch3.Stop();
            Console.WriteLine(watch3.Elapsed.ToString());

        }
    }
}
