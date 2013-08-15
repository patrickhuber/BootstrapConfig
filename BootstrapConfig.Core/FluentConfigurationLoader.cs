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
    public class FluentConfigurationLoader : IConfigurationLoader
    {
        private IDictionary<string, Configuration> dictionary;
        private IPathResolver pathResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentConfigurationLoader"/> class.
        /// </summary>
        public FluentConfigurationLoader()
        {
            dictionary = new Dictionary<string, Configuration>();
        }

        /// <summary>
        /// Loads the configuration dictionary.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IDictionary<string, System.Configuration.Configuration> LoadConfigurationDictionary()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Pathes the resolver.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public FluentConfigurationLoader PathResolver<T>() where T : IPathResolver
        {
            return PathResolver(typeof(T));
        }

        /// <summary>
        /// Pathes the resolver.
        /// </summary>
        /// <param name="pathResolverType">Type of the path resolver.</param>
        /// <returns></returns>
        public FluentConfigurationLoader PathResolver(Type pathResolverType)
        {
            return PathResolver(Activator.CreateInstance(pathResolverType) as IPathResolver);
        }

        /// <summary>
        /// Pathes the resolver.
        /// </summary>
        /// <param name="pathResolver">The path resolver.</param>
        /// <returns></returns>
        public FluentConfigurationLoader PathResolver(IPathResolver pathResolver)
        {
            this.pathResolver = pathResolver;
            return this;
        }
    }
}
