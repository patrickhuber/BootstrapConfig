using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using BootstrapConfig.Abstractions;

namespace BootstrapConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class DirectorySearcherArgs
    {
        /// <summary>
        /// The dictionary
        /// </summary>
        private IDictionary<string, IConfiguration> dictionary;

        private IConfiguration configuration;
        private IConfigurationSection configurationSection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectorySearcherArgs"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public DirectorySearcherArgs(
            IConfigurationSection configurationSection,
            IConfiguration configuration,
            IDictionary<string, IConfiguration> dictionary)
        {
            this.configuration = configuration;
            this.configurationSection = configurationSection;

            // lets protect our dictionary
            this.dictionary = new ReadOnlyDictionary<string, IConfiguration>(dictionary);
        }

        /// <summary>
        /// Gets the dictionary.
        /// </summary>
        /// <value>
        /// The dictionary.
        /// </value>
        public IDictionary<string, IConfiguration> Dictionary 
        {
            get { return this.dictionary; }
        }

        /// <summary>
        /// Gets the configuration section.
        /// </summary>
        /// <value>
        /// The configuration section.
        /// </value>
        public IConfigurationSection ConfigurationSection
        {
            get { return this.configurationSection; }
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration 
        {
            get { return this.configuration; }
        }
    }
}
