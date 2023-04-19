using LogiSim.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSim.instance
{
    public class Strings
    {
		private static LocaleManager source;

        public static String get(String key)
        {
            return source.get(key);
        }
        public static StringGetter getter(String key)
        {
            return source.getter(key);
        }
    }
}
