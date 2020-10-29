using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace bitFlagExampleFA20
{
    class Log
    {
        [Flags]
        public enum LogLevel
        {
            NONE = 1,
            WARN = 2,
            ERROR = 4,
            DEBUG = 8,
            EVERYTHING = NONE | WARN | ERROR | DEBUG
        }

        private LogLevel level = LogLevel.NONE;

        private static Log _instance;
        private static object syncRoot = new object();

        protected Log() { }

        public static Log Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = new Log();
                }

                return _instance;
            }
        }

        public void setLogLevel(LogLevel level)
        {
            this.level = level;
        }

        public void writeLog(LogLevel level, string msg)
        {
            if(level.HasFlag(this.level) || level <= this.level)
            //if ((level & this.level) == this.level || level <= this.level)
            {
                File.WriteAllText("c:/dev/log.txt", String.Format("[{0}:{1}] - {2}", DateTime.Now.ToString(), level, msg));
                Console.WriteLine("[{0}:{1}] - {2}", DateTime.Now.ToString(), level, msg);
            }
        }
    }
    class Program
    {

        static void method2()
        {
            Log l = Log.Instance;
        }
        static void Main(string[] args)
        {
            Log l = Log.Instance;
            l.setLogLevel(Log.LogLevel.DEBUG);
            l.writeLog(Log.LogLevel.ERROR, "TESTING");
        }
    }
}
