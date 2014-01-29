using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BootstrapConfig
{
    public class ConfigurationSectionCollectionAdapter : IConnectionStringSettingsCollection
    {
        private ConfigurationSectionCollection configurationSectionCollection;
        public ConfigurationSectionCollectionAdapter(ConfigurationSectionCollection collection)
        {
            this.configurationSectionCollection = collection;
        }
    }
}
