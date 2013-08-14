using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BootstrapConfig
{
    public class FluentConfigurationLoader : IConfigurationLoader
    {
        private IDictionary<string, Configuration> dictionary;
        private IMasterDataConfigurationElement data;

        public FluentConfigurationLoader()
        {
            dictionary = new Dictionary<string, Configuration>();
        }
        
        public IDictionary<string, System.Configuration.Configuration> LoadConfigurationDictionary()
        {
            throw new NotImplementedException();
        }

        public FluentConfigurationLoader Data(Action<IMasterDataConfigurationElement> masterData)
        {
            data = new FluentMasterDataConfigurationElement();
            masterData(data);
            return this;
        }

        private class FluentMasterDataConfigurationElement : IMasterDataConfigurationElement
        {
            public string Path { get; set; }

            public string SearchPattern { get; set; }

            public bool Recursive { get; set; }
        }
    }
}
