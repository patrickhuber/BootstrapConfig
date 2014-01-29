using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BootstrapConfig.Tests.Unit.Abstractions
{
    public class ExposedConfigurationSection : ConfigurationSection
    {
        public new object this[string name]
        {
            get { return base[name]; }
            set { base[name] = value;}
        }        
    }
}
