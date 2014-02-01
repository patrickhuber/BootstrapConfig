using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapConfig.IO
{
    public class SearchParameters
    {
        public SearchParameters()
        { }

        public SearchParameters(string path, string pattern, bool recursive)
        {
            this.Path = path;
            this.Pattern = pattern;
            this.Recursive = recursive;
        }

        public string Path { get; set; }
        public string Pattern { get; set; }
        public bool Recursive { get; set; }
    }
}
