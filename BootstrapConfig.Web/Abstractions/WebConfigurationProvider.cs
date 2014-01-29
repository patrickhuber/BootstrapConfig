using BootstrapConfig.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;

namespace BootstrapConfig.Web.Abstractions
{
    public class WebConfigurationProvider : IConfigurationProvider
    {
        public WebConfigurationProvider()
        {
            
        }

        public System.Collections.Specialized.NameValueCollection AppSettings
        {
            get { return WebConfigurationManager.AppSettings; }
        }
        
        public IConnectionStringSettingsCollection ConnectionStrings
        {
            get { return new ConnectionStringSettingsCollectionAdapter(WebConfigurationManager.ConnectionStrings); }
        }
    }
}
