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
    public interface IRootBootstrapConfiguration
    {
        /// <summary>
        /// Gets or sets the path resolver.
        /// </summary>
        /// <value>
        /// The path resolver.
        /// </value>
        IPathResolver PathResolver { get; set; }
        
        /// <summary>
        /// Gets or sets the directory searcher.
        /// </summary>
        /// <value>
        /// The directory searcher.
        /// </value>
        Type DirectorySearcherType { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        string Path { get; set; }

        /// <summary>
        /// Gets or sets the search pattern.
        /// </summary>
        /// <value>
        /// The search pattern.
        /// </value>
        string SearchPattern { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [recursive].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [recursive]; otherwise, <c>false</c>.
        /// </value>
        bool Recursive { get; set; }
    }
}
