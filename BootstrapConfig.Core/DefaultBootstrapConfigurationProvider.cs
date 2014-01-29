using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cfg = System.Configuration;

namespace BootstrapConfig
{
    /// <summary>
    /// provides an adapter layer around the dictionary configuration so that no one can mutate its state.
    /// </summary>
    public class DefaultBootstrapConfigurationProvider : IBootstrapConfigurationProvider
    {
        private readonly IDictionary<string, Cfg.Configuration> configurationDictionary;

        private IRootBootstrapConfiguration rootBootstrapConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultBootstrapConfigurationProvider"/> class.
        /// </summary>
        /// <param name="configurationLoader">The configuration loader.</param>
        public DefaultBootstrapConfigurationProvider(IRootBootstrapConfiguration rootBootstrapConfiguration)
        {
            this.rootBootstrapConfiguration = rootBootstrapConfiguration;
            this.configurationDictionary = new Dictionary<string, Cfg.Configuration>();
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Cfg.Configuration GetConfiguration(string key)
        {
            return configurationDictionary[key];
        }

        /// <summary>
        /// Gets the configuration collection.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, Cfg.Configuration> GetConfigurationCollection()
        {
            return new Dictionary<string, Cfg.Configuration>(configurationDictionary);
        }
    }
}
