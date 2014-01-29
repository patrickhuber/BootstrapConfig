using BootstrapConfig.Abstractions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BootstrapConfig.Configuration
{
    /// <summary>
    /// defines the client config bootstrap configuration sections
    /// </summary>
    public sealed class BootstrapConfigurationSection : ConfigurationSection, IBootstrapConfiguration
    {        
        private const string KeyKey = "key";
                
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>      
        [ConfigurationProperty(KeyKey)]
        public string Key
        {
            get { return (string)this[KeyKey]; }
            set { this[KeyKey] = value; }
        }
    }
}
