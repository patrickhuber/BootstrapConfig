using BootstrapConfig.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BootstrapConfig.IO
{
    public interface IFileSystemProvider
    {
        IEnumerable<string> EnumerateFiles(SearchParameters searchParameters);
    }
}
