using LogiSim.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSim
{
    public abstract class Attribute<V>
    {
        private string name;
        private StringGetter disp;

        public Attribute(String name, StringGetter disp)
        {
            this.name = name;
            this.disp = disp;
        }

        public override string ToString()
        {
            return this.name;
        }

        public string GetName() { return this.name; }

        public string GetDisplayName() { return this.disp.Get; }

        public string ToDisplayString(V value) { return value == null ? "" : value.ToString(); }
        public string ToStandardString(V value) { return value.ToString(); }
    }
}
