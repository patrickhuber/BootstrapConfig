using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cfg = System.Configuration;

namespace BootstrapConfig
{
    /// <summary>
    /// the bootstrap configuration provider implementation is responsible for fetching the configuration for the specific keys.
    /// </summary>
    public interface IBootstrapConfigurationProvider
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        Cfg.Configuration GetConfiguration(string key);

        /// <summary>
        /// Gets the configuration collection.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, Cfg.Configuration> GetConfigurationCollection();
    }
}
