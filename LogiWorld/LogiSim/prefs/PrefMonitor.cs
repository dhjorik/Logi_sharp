using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSim.prefs
{
    public interface PrefMonitor<E>
    {
        public string getIdentifier();
        public bool isSource(PropertyChangedEventArgs e);

        public void addPropertyChangeListener(PropertyChangedEventHandler listener);
        public void removePropertyChangeListener(PropertyChangedEventHandler listener);

        public E get();
        public void set(E value);
        public bool getBoolean();
        public void setBoolean(bool value);
        public void preferenceChange(PropertyChangedEventArgs e);
    }
}
