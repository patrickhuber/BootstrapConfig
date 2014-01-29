using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BootstrapConfig
{
    public class FileInfoProvider : IFileProvider
    {
        public IEnumerable<FileInfo> EnumerateFiles(string path, string pattern, bool recursive)
        {
            var directoryInfo = new DirectoryInfo(path);
            return directoryInfo.EnumerateFiles(
                pattern, 
                recursive 
                    ? SearchOption.AllDirectories 
                    : SearchOption.TopDirectoryOnly);
        }
    }
}
