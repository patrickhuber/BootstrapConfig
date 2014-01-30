﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BootstrapConfig
{
    public class FileSystemProvider : IFileSystemProvider
    {
        public IEnumerable<string> EnumerateFiles(string path, string pattern, bool recursive)
        {           
            return Directory.EnumerateFiles(
                path,
                pattern, 
                recursive 
                    ? SearchOption.AllDirectories 
                    : SearchOption.TopDirectoryOnly);
        }
    }
}