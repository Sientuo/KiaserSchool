using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiaserMid
{
    public class ServiceAttribute: Attribute
    {
        public string Name { get; set; }

        public ServiceAttribute(string name)
        {
            Name = name;
        }
    }
}
