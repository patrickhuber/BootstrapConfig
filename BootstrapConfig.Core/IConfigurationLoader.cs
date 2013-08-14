using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BootstrapConfig
{
    public interface IConfigurationLoader
    {
        IDictionary<string, Configuration> LoadConfigurationDictionary();
    }
}
