using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace BootstrapConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultDirectorySearcher : IDirectorySearcher
    {
        public string Path{get;set;}
        public string SearchPattern{get;set;}
        public bool Recursive{get;set;}
        public IPathResolver PathResolver{get;set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultDirectorySearcher"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <param name="pathResolver">The path resolver.</param>
        public DefaultDirectorySearcher(string path, string searchPattern, bool recursive, IPathResolver pathResolver)
        {
            Path = path;
            SearchPattern = searchPattern;
            Recursive = recursive;
            PathResolver = pathResolver;
        }

        /// <summary>
        /// Gets the configuration list.
        /// </summary>
        /// <returns></returns>
        public virtual IDictionary<string, Configuration> GetConfigurationDictionary()
        {
            string rootPath = this.PathResolver.ResolvePath(this.Path);
            var files = Directory.EnumerateFiles(
                rootPath,
                this.SearchPattern,
                this.Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

            var configurationDictionary = new Dictionary<string, Configuration>();

            // iterate over the files returning each configuration that passes as it is found
            foreach (var file in files)
            {
                var keyAndConfiguration = ProcessFile(file);
                if (keyAndConfiguration.HasValue)
                    configurationDictionary.Add(
                        keyAndConfiguration.Value.Key, 
                        keyAndConfiguration.Value.Value);
            }

            return configurationDictionary;
        }

        /// <summary>
        /// Processes the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>null if no configuration found</returns>
        protected virtual KeyValuePair<string, Configuration>? ProcessFile(string file)
        {
            var configurationFileMap = new ExeConfigurationFileMap();
            configurationFileMap.ExeConfigFilename = file;

            var configuration = ConfigurationManager.OpenMappedExeConfiguration(
                configurationFileMap,
                ConfigurationUserLevel.None);
                        
            // iterate over the configuration sections searching for the bootstrap configuration section
            foreach (var section in configuration.Sections)
            {
                var keyAndConfiguration = ProcessSection(section as ConfigurationSection, configuration);
                if (keyAndConfiguration.HasValue)
                    return keyAndConfiguration;
            }

            return null;
        }

        /// <summary>
        /// Processes the section.
        /// </summary>
        /// <param name="sectconfigurationSectionion">The section.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        protected virtual KeyValuePair<string, Configuration>? ProcessSection(ConfigurationSection sectconfigurationSectionion, Configuration configuration)
        {
            var bootstrapConfiguration = sectconfigurationSectionion as BootstrapConfigurationSection;
            if (bootstrapConfiguration != null)
            {
                string key = bootstrapConfiguration.Key;
                if (!string.IsNullOrWhiteSpace(key))
                {
                    return new KeyValuePair<string, Configuration>(key, configuration);
                }
                // todo: tracewarning 
            }
            return null;
        }
    }
}
