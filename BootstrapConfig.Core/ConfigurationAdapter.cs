using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace BootstrapConfig
{
    public class ConfigurationAdapter : IConfiguration
    {
        private Configuration configuration;

        public ConfigurationAdapter(Configuration configuration)
        {
            this.configuration = configuration;            
        }

        public IConnectionStringSettingsCollection Sections
        {
            get { return new ConfigurationSectionCollectionAdapter(configuration.Sections); }
        }
    }
}
