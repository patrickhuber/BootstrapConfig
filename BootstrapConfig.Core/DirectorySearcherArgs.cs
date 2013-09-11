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
    public class DirectorySearcherArgs
    {
        /// <summary>
        /// The dictionary
        /// </summary>
        private IDictionary<string, Configuration> dictionary;

        private Configuration configuration;
        private ConfigurationSection configurationSection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectorySearcherArgs"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public DirectorySearcherArgs(
            ConfigurationSection configurationSection,
            Configuration configuration,
            IDictionary<string, Configuration> dictionary)
        {
            this.configuration = configuration;
            this.configurationSection = configurationSection;

            // lets protect our dictionary
            this.dictionary = new ReadOnlyDictionary<string, Configuration>(dictionary);
        }

        /// <summary>
        /// Gets the dictionary.
        /// </summary>
        /// <value>
        /// The dictionary.
        /// </value>
        public IDictionary<string, Configuration> Dictionary 
        {
            get { return this.dictionary; }
        }

        /// <summary>
        /// Gets the configuration section.
        /// </summary>
        /// <value>
        /// The configuration section.
        /// </value>
        public ConfigurationSection ConfigurationSection
        {
            get { return this.configurationSection; }
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public Configuration Configuration 
        {
            get { return this.configuration; }
        }
    }
}
