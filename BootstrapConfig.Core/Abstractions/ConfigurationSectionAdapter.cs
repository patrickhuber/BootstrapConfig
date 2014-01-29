using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BootstrapConfig.Abstractions
{
    public class ConfigurationSectionAdapter : IConfigurationSection
    {
        private ConfigurationSection configurationSection;

        public ConfigurationSectionAdapter(ConfigurationSection configurationSection)
        {
            this.configurationSection = configurationSection;            
        } 
    }
}
