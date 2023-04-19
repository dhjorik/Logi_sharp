using LogiSim.util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSim.util
{
    public class StringUtil
    {
        private StringUtil() { }

        public static String capitalize(String a)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            TextInfo txi = ci.TextInfo;
            return txi.ToTitleCase(a); // upper(a[0]) + a.Substring(1);
        }

        public static String format(String fmt, String a1)
        {
            return format(fmt, a1, null, null);
        }

        public static String format(String fmt, String a1, String a2)
        {
            return format(fmt, a1, a2, null);
        }

        public static String format(String fmt, String a1, String a2,
                String a3)
        {
            StringBuilder ret = new StringBuilder();
            a1 ??= "(null)";
            a2 ??= "(null)";
            a3 ??= "(null)";
            int arg = 0;
            int pos = 0;
            int next = fmt.IndexOf('%');
            while (next >= 0)
            {
                ret.Append(fmt.Substring(pos, next));
                char c = fmt[next + 1];
                if (c == 's')
                {
                    pos = next + 2;
                    switch (arg)
                    {
                        case 0: ret.Append(a1); break;
                        case 1: ret.Append(a2); break;
                        default: ret.Append(a3); break;
                    }
                    ++arg;
                }
                else if (c == '$')
                {
                    switch (fmt[next + 2])
                    {
                        case '1': ret.Append(a1); pos = next + 3; break;
                        case '2': ret.Append(a2); pos = next + 3; break;
                        case '3': ret.Append(a3); pos = next + 3; break;
                        default: ret.Append("%$"); pos = next + 2; break;
                    }
                }
                else if (c == '%')
                {
                    ret.Append('%'); pos = next + 2;
                }
                else
                {
                    ret.Append('%'); pos = next + 1;
                }
                next = fmt.IndexOf('%', pos);
            }
            ret.Append(fmt.Substring(pos));
            return ret.ToString();
        }

        public static StringGetter formatter(StringGetter Base, String arg)
        {
            return new StringGetterImpl(Base.get(), arg);
        }

        public static StringGetter formatter(StringGetter Base, StringGetter arg)
        {
            return new StringGetterImpl(Base.get(), arg.get());
        }

        public static StringGetter constantGetter(String value)
        {
            return new StringGetterImpl(value, null);
        }

        static String toHexString(int bits, int value)
        {
            if (bits < 32) value &= (1 << bits) - 1;
            String ret = value.ToString("X");
            int len = (bits + 3) / 4;
            while (ret.Length < len) ret = "0" + ret;
            if (ret.Length > len) ret = ret.Substring(ret.Length - len);
            return ret;
        }
    }

    public class StringGetterImpl : StringGetter
    {
        private readonly string Base;
        private readonly string a1;
        public StringGetterImpl(string Base, string a1)
        {
            this.Base = Base;
            this.a1 = a1;
        }
        public string get()
        {
            if (this.a1 == null)
            {
                return this.Base;
            }
            else
            {
                return StringUtil.format(this.Base, this.a1);
            }
        }
    }
}
