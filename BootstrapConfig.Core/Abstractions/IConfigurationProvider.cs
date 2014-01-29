using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BootstrapConfig.Abstractions
{
    public interface IConfigurationProvider
    {
        NameValueCollection AppSettings { get; }
        IConnectionStringSettingsCollection ConnectionStrings { get; }
        IConfiguration OpenMappedConfiguration(string file);
    }
}
