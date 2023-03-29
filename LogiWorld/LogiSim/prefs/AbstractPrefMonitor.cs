using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogiSim.prefs
{
    public abstract class AbstractPrefMonitor<E> : PrefMonitor<E>
    {
        private string name;

        AbstractPrefMonitor(string name)
        {
            this.name = name;
        }

        public string getIdentifier()
        {
            return name;
        }

        public bool isSource(PropertyChangedEventArgs e)
        {
            return name.Equals(e.PropertyName);
        }

        public void addPropertyChangeListener(PropertyChangedEventHandler listener)
        {
            AppPreferences.addPropertyChangeListener(name, listener);
        }

        public void removePropertyChangeListener(PropertyChangedEventHandler listener)
        {
            AppPreferences.removePropertyChangeListener(name, listener);
        }

        public bool getBoolean()
        {
            return ((bool)get()).booleanValue();
        }

        public void setBoolean(bool value)
        {
            E valObj = (E)bool.valueOf(value);
            set(valObj);
        }

        public abstract E get();
        public abstract void set(E value);
        public abstract void preferenceChange(PropertyChangedEventArgs e);
    }
}
