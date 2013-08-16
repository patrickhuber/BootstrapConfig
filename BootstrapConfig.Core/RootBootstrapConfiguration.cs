using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class RootBootstrapConfiguration : IRootBootstrapConfiguration
    {
        /// <summary>
        /// Gets or sets the path resolver.
        /// </summary>
        /// <value>
        /// The path resolver.
        /// </value>
        public IPathResolver PathResolver { get; set; }

        /// <summary>
        /// Gets or sets the directory searcher.
        /// </summary>
        /// <value>
        /// The directory searcher.
        /// </value>
        public Type DirectorySearcherType { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the search pattern.
        /// </summary>
        /// <value>
        /// The search pattern.
        /// </value>
        public string SearchPattern { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [recursive].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [recursive]; otherwise, <c>false</c>.
        /// </value>
        public bool Recursive { get; set; }
    }
}
