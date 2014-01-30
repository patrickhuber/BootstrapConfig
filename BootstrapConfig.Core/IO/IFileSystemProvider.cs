using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BootstrapConfig
{
    public interface IFileSystemProvider
    {
        IEnumerable<string> EnumerateFiles(string path, string pattern, bool recursive);
    }
}
