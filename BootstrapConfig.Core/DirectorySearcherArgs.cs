using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cfg = System.Configuration;

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
        private IDictionary<string, Cfg.Configuration> dictionary;

        private Cfg.Configuration configuration;
        private Cfg.ConfigurationSection configurationSection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectorySearcherArgs"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public DirectorySearcherArgs(
            Cfg.ConfigurationSection configurationSection,
            Cfg.Configuration configuration,
            IDictionary<string, Cfg.Configuration> dictionary)
        {
            this.configuration = configuration;
            this.configurationSection = configurationSection;

            // lets protect our dictionary
            this.dictionary = new ReadOnlyDictionary<string, Cfg.Configuration>(dictionary);
        }

        /// <summary>
        /// Gets the dictionary.
        /// </summary>
        /// <value>
        /// The dictionary.
        /// </value>
        public IDictionary<string, Cfg.Configuration> Dictionary 
        {
            get { return this.dictionary; }
        }

        /// <summary>
        /// Gets the configuration section.
        /// </summary>
        /// <value>
        /// The configuration section.
        /// </value>
        public Cfg.ConfigurationSection ConfigurationSection
        {
            get { return this.configurationSection; }
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public Cfg.Configuration Configuration 
        {
            get { return this.configuration; }
        }
    }
}
