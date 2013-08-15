using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace BootstrapConfig
{
    public class DefaultDirectorySearcher : IDirectorySearcher
    {
        public IPathResolver PathResolver { get; set; }

        public string Path { get; set; }

        public string SearchPattern { get; set; }

        public bool Recursive { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultDirectorySearcher"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <param name="pathResolver">The path resolver.</param>
        public DefaultDirectorySearcher(string path, string pattern, bool recursive, IPathResolver pathResolver)
        {
            this.Path = path ?? "App_Config";
            this.SearchPattern = pattern ?? "*.config";
            this.Recursive = recursive;
            this.PathResolver = pathResolver;
        }

        /// <summary>
        /// Gets the configuration list.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, Configuration> GetConfigurationDictionary()
        {
            string rootPath = PathResolver.ResolvePath(this.Path);
            var files = Directory.EnumerateFiles(
                rootPath, 
                SearchPattern, 
                this.Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

            var configurationDictionary = new Dictionary<string, Configuration>();

            // iterate over the files returning each configuration that passes as it is found
            foreach (var file in files)
            {
                var configurationFileMap = new ExeConfigurationFileMap();
                configurationFileMap.ExeConfigFilename = file;
                
                var configuration = ConfigurationManager.OpenMappedExeConfiguration(
                    configurationFileMap, 
                    ConfigurationUserLevel.None);

                // iterate over the configuration sections searching for the bootstrap configuration section
                foreach (var section in configuration.Sections)
                {
                    var bootstrapConfiguration = section as BootstrapConfigurationSection;
                    if (bootstrapConfiguration != null)
                    {
                        string key = bootstrapConfiguration.Key;
                        if (!string.IsNullOrWhiteSpace(key))
                        {                            
                            configurationDictionary.Add(key, configuration);
                            break;
                        }
                        // todo: tracewarning 
                    }
                }
            }

            return configurationDictionary;
        }
    }
}
