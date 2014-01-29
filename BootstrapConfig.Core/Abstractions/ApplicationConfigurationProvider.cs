using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BootstrapConfig.Abstractions
{
    public class ApplicationConfigurationProvider  : IConfigurationProvider
    {
        public ApplicationConfigurationProvider()
        {
            //var appSettings = ConfigurationManager.AppSettings;
            //var x = ConfigurationManager.ConnectionStrings;
            //var y = ConfigurationManager.GetSection("");
            //var z = ConfigurationManager.OpenExeConfiguration("");
            //var a = ConfigurationManager.OpenMachineConfiguration();
            //var b = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap(), ConfigurationUserLevel.None);
            //var c = ConfigurationManager.OpenMappedMachineConfiguration(new ConfigurationFileMap());
        }

        public IConnectionStringSettingsCollection ConnectionStrings
        {
            get { return new ConnectionStringSettingsCollectionAdapter(ConfigurationManager.ConnectionStrings);  }
        }

        public NameValueCollection AppSettings
        {
            get { return ConfigurationManager.AppSettings; }
        }

        public IConfiguration OpenMappedConfiguration(string file)
        {
            ExeConfigurationFileMap exeMap = new ExeConfigurationFileMap();
            exeMap.ExeConfigFilename = file;
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(exeMap, ConfigurationUserLevel.None);
            return new ConfigurationAdapter(configuration);
        }
    }
}
