using BootstrapConfig.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapConfig
{
    public class CrawlSettings : SearchParameters
    {
        public ICollection<IRule> Rules { get; set; }
    }
}
