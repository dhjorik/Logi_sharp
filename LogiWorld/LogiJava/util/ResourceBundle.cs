using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiJava.util
{
    public abstract class ResourceBundle
    {
        private static readonly int INITIAL_CACHE_SIZE = 32;

        private static ResourceBundle NONEXISTENT_BUNDLE = new ResourceBundle_NoExist();

    }

    public class ResourceBundle_NoExist : ResourceBundle {
        public IEnumerable<string>? GetKeys() { return null; }
        protected object? handleGetObject(string  key) { return null; }
        public override string ToString()
        {
            return "NONEXISTENT_BUNDLE";
        }
    }
}
