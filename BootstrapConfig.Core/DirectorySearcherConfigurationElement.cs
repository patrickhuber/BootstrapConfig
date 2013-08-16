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
    public class DirectorySearcherConfigurationElement : TypeContainerConfigurationElement
    {
        private const string PathKey = "path";
        [ConfigurationProperty(PathKey)]
        public string Path
        {
            get { return this[PathKey] as string; }
            set { this[PathKey] = value; }
        }

        private const string SearchPatternKey = "searchPattern";
        [ConfigurationProperty(SearchPatternKey)]
        public string SearchPattern
        {
            get { return this[SearchPatternKey] as string; }
            set { this[SearchPatternKey] = value; }
        }

        private const string RecursiveKey = "recursive";
        [ConfigurationProperty(RecursiveKey)]
        public bool Recursive
        {
            get { return (bool)this[RecursiveKey]; }
            set { this[RecursiveKey] = value; }
        }
    }
}
