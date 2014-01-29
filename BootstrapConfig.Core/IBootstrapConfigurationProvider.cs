using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using BootstrapConfig.Abstractions;

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
        IConfiguration GetConfiguration(string key);

        /// <summary>
        /// Gets the configuration collection.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, IConfiguration> GetConfigurationCollection();
    }
}
