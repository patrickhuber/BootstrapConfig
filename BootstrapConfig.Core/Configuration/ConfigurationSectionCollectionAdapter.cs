﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BootstrapConfig.Configuration
{
    public class ConfigurationSectionCollectionAdapter : IConfigurationSectionCollection
    {
        private ConfigurationSectionCollection configurationSectionCollection;
        public ConfigurationSectionCollectionAdapter(ConfigurationSectionCollection collection)
        {
            this.configurationSectionCollection = collection;
        }
    }
}
