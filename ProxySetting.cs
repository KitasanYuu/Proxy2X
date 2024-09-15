using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2x
{
    public class ProxySetting
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Port { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Address}:{Port})";
        }
    }

}
