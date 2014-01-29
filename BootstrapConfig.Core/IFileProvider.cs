using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BootstrapConfig
{
    public interface IFileProvider
    {
        IEnumerable<FileInfo> EnumerateFiles(string path, string pattern, bool recursive);
    }
}
