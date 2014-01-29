using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Cfg = System.Configuration;

namespace BootstrapConfig
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDirectorySearcher
    {
        /// <summary>
        /// Gets the rules.
        /// </summary>
        /// <value>
        /// The rules.
        /// </value>
        IIncludeConfigurationRule[] Rules { get; }

        /// <summary>
        /// Gets the key generator.
        /// </summary>
        /// <value>
        /// The key generator.
        /// </value>
        IKeyGenerator KeyGenerator { get;}

        /// <summary>
        /// Gets the configuration dictionary.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, Cfg.Configuration> GetConfigurationDictionary();
    }
}
