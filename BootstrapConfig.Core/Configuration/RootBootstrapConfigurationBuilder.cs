using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using BootstrapConfig.Diagnostics;

namespace BootstrapConfig
{
    /// <summary>
    /// a fluent interface for building configuration
    /// </summary>
    public class RootBootstrapConfigurationBuilder
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private IRootBootstrapConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="RootBootstrapConfigurationBuilder"/> class.
        /// </summary>
        public RootBootstrapConfigurationBuilder(IRootBootstrapConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// sets the path resolver type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public RootBootstrapConfigurationBuilder PathResolver<T>()
            where T : IPathResolver
        {
            return PathResolver(typeof(T));
        }

        /// <summary>
        /// sets the path resolver type
        /// </summary>
        /// <param name="resolverType">Type of the resolver.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">resolverType must be an instance of IPathResolver.;resolverType</exception>
        /// <exception cref="System.ArgumentException">resolverType must have a value.;resolverType</exception>
        /// <exception cref="System.ArgumentException">resolverType be a class type.;resolverType</exception>
        public RootBootstrapConfigurationBuilder PathResolver(Type resolverType)
        {
            Assert.IsNotNull(resolverType, "resolverType", "parmeter resolverType must have a value.");
            Assert.ArgumentIsTrue(typeof(IPathResolver).IsAssignableFrom(resolverType), "resolverType must implement IPathResolver");
            var pathResolver = Activator.CreateInstance(resolverType) as IPathResolver;
            
            return PathResolver(pathResolver);
        }

        /// <summary>
        /// sets the path resolver instance
        /// </summary>
        /// <param name="pathResolver">The path resolver.</param>
        /// <returns></returns>
        public RootBootstrapConfigurationBuilder PathResolver(IPathResolver pathResolver)
        {
            this.configuration.PathResolver = pathResolver;
            return this;
        }

        /// <summary>
        /// Sets the path
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public RootBootstrapConfigurationBuilder DirectorySearcher<T>(string path)
            where T : IDirectorySearcher
        {
            return DirectorySearcher(typeof(T), path);
        }

        /// <summary>
        /// Pathes the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <returns></returns>
        public RootBootstrapConfigurationBuilder DirectorySearcher<T>(string path, string searchPattern)
            where T : IDirectorySearcher
        {
            return DirectorySearcher(typeof(T), path, searchPattern);
        }

        /// <summary>
        /// Pathes the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <returns></returns>
        public RootBootstrapConfigurationBuilder DirectorySearcher<T>(string path, string searchPattern, bool recursive)
            where T : IDirectorySearcher
        {
            return DirectorySearcher(typeof(T), path, searchPattern, recursive);
        }

        /// <summary>
        /// Sets the path
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public RootBootstrapConfigurationBuilder DirectorySearcher(Type directorySearcherType, string path)
        {
            return DirectorySearcher(directorySearcherType, path, null);
        }

        /// <summary>
        /// Pathes the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <returns></returns>
        public RootBootstrapConfigurationBuilder DirectorySearcher(Type directorySearcherType, string path, string searchPattern)
        {
            return DirectorySearcher(directorySearcherType, path, searchPattern, false);
        }

        /// <summary>
        /// Pathes the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <returns></returns>
        public RootBootstrapConfigurationBuilder DirectorySearcher(Type directorySearcherType, string path, string searchPattern, bool recursive)
        {
            this.configuration.DirectorySearcherType = directorySearcherType;
            this.configuration.Path = path;
            this.configuration.SearchPattern = searchPattern;
            this.configuration.Recursive = recursive;
            return this;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <returns></returns>
        public IRootBootstrapConfiguration Configuration()
        {
            return this.configuration;
        }
    }
}
