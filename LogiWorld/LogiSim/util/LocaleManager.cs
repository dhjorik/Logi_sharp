using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace LogiSim.util
{
    public class LocaleManager
    {
        private static String SETTINGS_NAME = "settings";
        private static List<LocaleManager> managers = new List<LocaleManager>();

        private ResourceManager locale = null;
        private ResourceManager dflt_locale = null;

        private void loadLocale(Locale loc)
        {
            String bundleName = dir_name + "/" + loc.getLanguage() + "/" + file_start;
            locale = ResourceBundle.getBundle(bundleName, loc);
        }

        public String get(String key)
        {
            String ret;
            try
            {
                ret = locale.getString(key);
            }
            catch (MissingResourceException e)
            {
                ResourceBundle backup = dflt_locale;
                if (backup == null)
                {
                    Locale backup_loc = Locale.US;
                    backup = ResourceBundle.getBundle(dir_name + "/en/" + file_start, backup_loc);
                    dflt_locale = backup;
                }
                try
                {
                    ret = backup.getString(key);
                }
                catch (MissingResourceException e2)
                {
                    ret = key;
                }
            }
            HashMap<Character, String> repl = LocaleManager.repl;
            if (repl != null) ret = replaceAccents(ret, repl);
            return ret;
        }

        public StringGetter getter(String key)
        {
            return new LocaleGetter(this, key);
        }

        public StringGetter getter(String key, String arg)
        {
            return StringUtil.formatter(getter(key), arg);
        }

        public StringGetter getter(String key, StringGetter arg)
        {
            return StringUtil.formatter(getter(key), arg);
        }
    }

    public class LocaleGetter : StringGetter
    {
        private LocaleManager source;
        private String key;

        public LocaleGetter(LocaleManager source, String key)
        {
            this.source = source;
            this.key = key;
        }

        public String get()
        {
            return source.get(key);
        }

        public override string ToString()
        {
            return get();
        }
    }
}
