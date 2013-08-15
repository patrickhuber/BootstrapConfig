using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BootstrapConfig
{
    public interface IDirectorySearcher
    {
        string Path { get; set; }
        string SearchPattern { get; set; }
        bool Recursive { get; set; }
        IPathResolver PathResolver { get; }

        IDictionary<string, Configuration> GetConfigurationDictionary();
    }
}
