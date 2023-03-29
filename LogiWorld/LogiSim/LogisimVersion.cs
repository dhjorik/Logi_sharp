using System;
using System.Collections.Generic;
using System.Text;

namespace LogiSim
{
    public class LogisimVersion
    {
        private static int FINAL_REVISION = Int32.MaxValue / 4;

        public static LogisimVersion get(int major, int minor, int release)
        {
            return get(major, minor, release, FINAL_REVISION);
        }

        public static LogisimVersion get(int major, int minor, int release, int revision)
        {
            return new LogisimVersion(major, minor, release, revision);
        }

        public static LogisimVersion parse(string versionString)
        {
            string[] parts = versionString.Split("\\.");
            int major = 0;
            int minor = 0;
            int release = 0;
            int revision = FINAL_REVISION;
            try
            {
                if (parts.Length >= 1) major = Int32.Parse(parts[0]);
                if (parts.Length >= 2) minor = Int32.Parse(parts[1]);
                if (parts.Length >= 3) release = Int32.Parse(parts[2]);
                if (parts.Length >= 4) revision = Int32.Parse(parts[3]);
            }
            catch (Exception e) { }
            return new LogisimVersion(major, minor, release, revision);
        }

        private int major;
        private int minor;
        private int release;
        private int revision;
        private string repr;

        private LogisimVersion(int major, int minor, int release, int revision)
        {
            this.major = major;
            this.minor = minor;
            this.release = release;
            this.revision = revision;
            this.repr = null;
        }

        public override int GetHashCode()
        {
            int ret = major * 31 + minor;
            ret = ret * 31 + release;
            ret = ret * 31 + revision;
            return ret;
        }

        public override bool Equals(object other)
        {
            if (other is LogisimVersion)
            {
                LogisimVersion o = (LogisimVersion)other;
                return this.major == o.major && this.minor == o.minor
                    && this.release == o.release && this.revision == o.revision;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string ret = repr;
            if (ret == null)
            {
                ret = major + "." + minor + "." + release;
                if (revision != FINAL_REVISION) ret += "." + revision;
                repr = ret;
            }
            return ret;
        }

        public int compareTo(LogisimVersion other) {
            int ret = this.major - other.major;
            if (ret != 0)
            {
                return ret;
            }
            else
            {
                ret = this.minor - other.minor;
                if (ret != 0)
                {
                    return ret;
                }
                else
                {
                    ret = this.release - other.release;
                    if (ret != 0)
                    {
                        return ret;
                    }
                    else
                    {
                        return this.revision - other.revision;
                    }
                }
            }
        }
    }
}
