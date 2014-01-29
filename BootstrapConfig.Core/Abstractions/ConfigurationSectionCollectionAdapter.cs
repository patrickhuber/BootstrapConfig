using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BootstrapConfig.Abstractions
{
    public class ConfigurationSectionCollectionAdapter : IConfigurationSectionCollection
    {
        private ConfigurationSectionCollection configurationSectionCollection;
        public ConfigurationSectionCollectionAdapter(ConfigurationSectionCollection collection)
        {
            this.configurationSectionCollection = collection;
        }

        public IEnumerator<IConfigurationSection> GetEnumerator()
        {
            var enumerator = configurationSectionCollection.GetEnumerator();
            while (enumerator.MoveNext())
                yield return new ConfigurationSectionAdapter(enumerator.Current as ConfigurationSection);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            var enumerator = configurationSectionCollection.GetEnumerator();
            while (enumerator.MoveNext())
                yield return new ConfigurationSectionAdapter(enumerator.Current as ConfigurationSection);
        }
    }
}
