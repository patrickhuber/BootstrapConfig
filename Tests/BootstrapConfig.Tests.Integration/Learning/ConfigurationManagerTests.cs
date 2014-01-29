using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using BootstrapConfig.Tests.Templates;

namespace BootstrapConfig.Tests.Unit
{
    [TestClass]
    public class ConfigurationManagerTests : TestContextTest
    {
        [TestMethod]
        public void Test_Changing_Config_Value_Persists()
        {
            const string ACTUAL = "this works";
            const string KEY = "test1234";
            ConfigurationManager.AppSettings[KEY] = ACTUAL;
            var value = ConfigurationManager.AppSettings[KEY] as string;
            Assert.IsNotNull(value);
            Assert.AreEqual(ACTUAL,value);
        }

        [TestMethod][Ignore]
        public void Test_Can_Overwrite_ServiceModel_Xml()
        {
            const string SYSTEM_SERVICE_MODEL = "system.serviceModel";

            // load the wcf config file
            var configurationFileMap = new ExeConfigurationFileMap();
            configurationFileMap.ExeConfigFilename = Path.Combine(CurrentDirectory.FullName, Paths.App_Config.HasWcf.Wcf);
            var wcfConfiguration = ConfigurationManager.OpenMappedExeConfiguration(
                configurationFileMap,
                ConfigurationUserLevel.None);            
            var wcfConfigurationSectionGroup = wcfConfiguration.GetSectionGroup(SYSTEM_SERVICE_MODEL);
            Assert.IsNotNull(wcfConfigurationSectionGroup);

            // get the xml for the wcf configuration
            foreach (ConfigurationSection section in wcfConfigurationSectionGroup.Sections)
            {
                string rawXml = section.SectionInformation.GetRawXml();                
            }

            // load the app.config
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);            
            
            
            Assert.IsNotNull(configuration.GetSectionGroup(SYSTEM_SERVICE_MODEL));
        }

        [TestMethod]
        public void Test_SecurityProvider()
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        }
    }
}
