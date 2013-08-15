using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BootstrapConfig
{
    /// <summary>
    /// Searches for files using exe rules where the file system is defined
    /// </summary>
    public class ExePathResolver : IPathResolver
    {
        /// <summary>
        /// Resolves the path.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <returns></returns>
        public string ResolvePath(string relativePath)
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, relativePath);
            path = System.IO.Path.GetFullPath(path);            
            return path;
        }
    }
}
