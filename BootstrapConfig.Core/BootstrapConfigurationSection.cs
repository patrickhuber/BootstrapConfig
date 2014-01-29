﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using BootstrapConfig.Abstractions;

namespace BootstrapConfig
{
    /// <summary>
    /// defines the client config bootstrap configuration sections
    /// </summary>
    public sealed class BootstrapConfigurationSection : ConfigurationSection, IConfigurationSection, IBootstrapConfiguration
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
