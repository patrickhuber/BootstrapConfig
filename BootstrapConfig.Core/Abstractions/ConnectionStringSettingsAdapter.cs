using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BootstrapConfig.Abstractions
{
    public class ConnectionStringSettingsAdapter : IConnectionStringSettings
    {
        private ConnectionStringSettings connectionStringSettings;
        
        public ConnectionStringSettingsAdapter(ConnectionStringSettings connectionStringSettings)
        {
            this.connectionStringSettings = connectionStringSettings;            
        }

        public string ConnectionString
        {
            get { return this.connectionStringSettings.ConnectionString; }
        }
    }
}
