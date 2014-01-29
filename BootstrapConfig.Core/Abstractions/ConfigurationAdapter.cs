using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Cfg = System.Configuration;

namespace BootstrapConfig.Abstractions
{
    public class ConfigurationAdapter : IConfiguration
    {
        private Cfg.Configuration configuration;

        public ConfigurationAdapter(Cfg.Configuration configuration)
        {
            this.configuration = configuration;            
        }

        public IConfigurationSectionCollection Sections
        {
            get { return new ConfigurationSectionCollectionAdapter(configuration.Sections); }
        }
    }
}
