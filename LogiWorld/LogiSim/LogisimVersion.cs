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

		public static LogisimVersion parse(String versionString)
		{
			String[] parts = versionString.split("\\.");
			int major = 0;
			int minor = 0;
			int release = 0;
			int revision = FINAL_REVISION;
			try
			{
				if (parts.length >= 1) major = Integer.parseInt(parts[0]);
				if (parts.length >= 2) minor = Integer.parseInt(parts[1]);
				if (parts.length >= 3) release = Integer.parseInt(parts[2]);
				if (parts.length >= 4) revision = Integer.parseInt(parts[3]);
			}
			catch (NumberFormatException e) { }
			return new LogisimVersion(major, minor, release, revision);
		}
	}
}
