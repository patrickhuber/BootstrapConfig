using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace BootstrapConfig.Abstractions
{
    public interface IConfigurationProvider
    {
        NameValueCollection AppSettings { get; }
    }
}
