using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapConfig
{
    public interface IMasterDataConfigurationElement
    {
        string Path { get; set; }
        string SearchPattern { get; set; }
        bool Recursive { get; set; }
    }
}
