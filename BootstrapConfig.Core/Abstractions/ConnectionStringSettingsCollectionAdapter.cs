using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BootstrapConfig.Abstractions
{
    public class ConnectionStringSettingsCollectionAdapter : IConnectionStringSettingsCollection
    {
        private ConnectionStringSettingsCollection collection;
        public ConnectionStringSettingsCollectionAdapter(ConnectionStringSettingsCollection settingsCollection)        
        {
            this.collection = settingsCollection;
        }

        public IConnectionStringSettings this[string name]
        {
            get { return new ConnectionStringSettingsAdapter(collection[name]); }
        }
    }
}
