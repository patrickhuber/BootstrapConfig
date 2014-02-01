using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BootstrapConfig.IO
{
    public class FileSystemProvider : IFileSystemProvider
    {
        public IEnumerable<string> EnumerateFiles(SearchParameters searchParameters)
        {
            return Directory.EnumerateFiles(
                searchParameters.Path,
                searchParameters.Pattern,
                searchParameters.Recursive
                    ? SearchOption.AllDirectories
                    : SearchOption.TopDirectoryOnly);
        }
    }
}
