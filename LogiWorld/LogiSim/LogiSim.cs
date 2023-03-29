using System;

namespace LogiSim
{
    public class LogiSim
    {
        public static LogisimVersion VERSION = LogisimVersion.get(3, 0, 0);
        public static string VERSION_NAME = VERSION.ToString();
        public static int COPYRIGHT_YEAR = 2023;

        //public LogiSim(String[] args)
        //{
        //    Startup startup = Startup.parseArgs(args);
        //    if (startup == null)
        //    {
        //        System.exit(0);
        //    }
        //    else
        //    {
        //        startup.run();
        //    }
        //}
    }
}
