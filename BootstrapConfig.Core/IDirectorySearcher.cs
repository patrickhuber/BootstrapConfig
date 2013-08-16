using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BootstrapConfig
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDirectorySearcher
    {
        /// <summary>
        /// Gets the configuration dictionary.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, Configuration> GetConfigurationDictionary();
    }
}
