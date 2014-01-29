using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using BootstrapConfig.Abstractions;

namespace BootstrapConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class DirectorySearcher : IDirectorySearcher
    {
        /// <summary>
        /// Gets the configuration provider.
        /// </summary>
        /// <value>
        /// The configuration provider.
        /// </value>
        public IConfigurationProvider ConfigurationProvider { get; private set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path{get;set;}

        /// <summary>
        /// Gets or sets the search pattern.
        /// </summary>
        /// <value>
        /// The search pattern.
        /// </value>
        public string SearchPattern{get;set;}

        /// <summary>
        /// Gets or sets a value indicating whether the search will be recursive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [recursive]; otherwise, <c>false</c>.
        /// </value>
        public bool Recursive{get;set;}

        /// <summary>
        /// Gets or sets the path resolver.
        /// </summary>
        /// <value>
        /// The path resolver.
        /// </value>
        public IPathResolver PathResolver{get;set;}

        /// <summary>
        /// Gets the rules for include and exclude.
        /// </summary>
        /// <value>
        /// The rules.
        /// </value>
        public IIncludeConfigurationRule[] Rules { get; protected set; }

        /// <summary>
        /// Gets or sets the generator.
        /// </summary>
        /// <value>
        /// The generator.
        /// </value>
        public IKeyGenerator KeyGenerator { get; protected set; }

        /// <summary>
        /// Gets or sets the file provider.
        /// </summary>
        /// <value>
        /// The file provider.
        /// </value>
        public IFileProvider FileProvider { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectorySearcher" /> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <param name="pathResolver">The path resolver.</param>
        /// <param name="keyGenerator">The key generator.</param>
        /// <param name="rules">The rules.</param>
        public DirectorySearcher(
            IConfigurationProvider configurationProvider,
            IPathResolver pathResolver, 
            IKeyGenerator keyGenerator,
            IFileProvider fileProvider,
            string path,
            string searchPattern,
            bool recursive, 
            params IIncludeConfigurationRule[] rules)
        {
            this.ConfigurationProvider = configurationProvider;
            this.Path = path;
            this.SearchPattern = searchPattern;
            this.Recursive = recursive;
            this.PathResolver = pathResolver;
            this.KeyGenerator = keyGenerator;
            this.Rules = rules;
        }

        /// <summary>
        /// Gets the configuration list.
        /// </summary>
        /// <returns></returns>
        public virtual IDictionary<string, IConfiguration> GetConfigurationDictionary()
        {
            // resolve the path using the built in path resolver
            string rootPath = this.PathResolver.ResolvePath(this.Path);

            // enumerators are a bit faster on startup and the same on processing time.
            var files = FileProvider.EnumerateFiles(
                rootPath,
                this.SearchPattern,
                this.Recursive);

            IDictionary<string, IConfiguration> configurationDictionary = new Dictionary<string, IConfiguration>();
            
            // iterate over the files returning each configuration that passes as it is found
            foreach (var file in files)
            {
                configurationDictionary = ProcessFile(file, configurationDictionary);
            }

            return configurationDictionary;
        }

        /// <summary>
        /// Processes the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>null if no configuration found</returns>
        protected virtual IDictionary<string, IConfiguration> ProcessFile(FileInfo file, IDictionary<string, IConfiguration> dictionary)
        {
            IDictionary<string, IConfiguration> workingDicionaryCopy = new Dictionary<string, IConfiguration>(dictionary);
            var configuration = ConfigurationProvider.OpenMappedConfiguration(file.FullName);

            // iterate over the configuration sections use the rules to process the files
            foreach (IConfigurationSection section in configuration.Sections)
            {
                var keyAndConfiguration = ProcessSection(
                    new DirectorySearcherArgs(
                        section, 
                        configuration,
                        new ReadOnlyDictionary<string, IConfiguration>(workingDicionaryCopy)), 
                    this.KeyGenerator,
                    this.Rules);

                // if a value was returned, then use it
                if (keyAndConfiguration.HasValue)
                {
                    workingDicionaryCopy.Add(keyAndConfiguration.Value);
                    break;
                }
            }

            // don't mutate state, return a copy
            return workingDicionaryCopy;
        }

        /// <summary>
        /// Processes the section.
        /// </summary>
        /// <param name="sectconfigurationSectionion">The section.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        protected virtual KeyValuePair<string, IConfiguration>? ProcessSection(
            DirectorySearcherArgs args,
            IKeyGenerator keyGenerator,
            IIncludeConfigurationRule[] rules)
        {
            // check if we have a valid configuration section
            var bootstrapConfiguration = args.ConfigurationSection as IBootstrapConfiguration;
            if (bootstrapConfiguration != null)
            {
                string key = bootstrapConfiguration.Key;
                if (!string.IsNullOrWhiteSpace(key))
                {
                    // loop over the rules. if a rule fails, return null.
                    foreach (var rule in rules)
                    {
                        if (!rule.Execute(args))
                            return null;
                    }
                    return new KeyValuePair<string, IConfiguration>(key, args.Configuration);
                }
                // todo: tracewarning 
            }                

            // let the rules determine what the kick out condition is. For that reason we should allow any config section and use the key generator.
            return null;
        }
    }
}
