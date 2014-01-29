using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using BootstrapConfig.Configuration;

namespace BootstrapConfig
{
    /// <summary>
    /// The root file configuration section register in the web.config or app.config
    /// </summary>
    public class RootBootstrapConfigurationSection : ConfigurationSection
    {        
        public RootBootstrapConfigurationSection()
        { 
        }

        private const string DirectorySearcherKey = "directorySearcher";
        [ConfigurationProperty(DirectorySearcherKey)]
        public IDirectorySearcherConfiguration DirectorySearcher 
        {
            get { return this[DirectorySearcherKey] as DirectorySearcherConfigurationElement; }
            set { this[DirectorySearcherKey] = value; } 
        }

        private const string PathResolverKey = "pathResolver";
        [ConfigurationProperty(PathResolverKey)]
        public TypeContainerConfigurationElement PathResolver
        {
            get { return this[PathResolverKey] as TypeContainerConfigurationElement; }
            set { this[PathResolverKey] = value; }
        }

        /// <summary>
        /// Gets the configuration for this configuration section
        /// </summary>
        /// <returns></returns>
        public IRootBootstrapConfiguration Configuration()
        {
            var rootConfiguration = new RootBootstrapConfiguration();
            var builder = new RootBootstrapConfigurationBuilder(rootConfiguration);
            return builder
                .PathResolver(PathResolver.Type)
                .DirectorySearcher(
                    DirectorySearcher.Type, 
                    DirectorySearcher.Path, 
                    DirectorySearcher.SearchPattern, 
                    DirectorySearcher.Recursive)
                .Configuration();
        }
    }
}
