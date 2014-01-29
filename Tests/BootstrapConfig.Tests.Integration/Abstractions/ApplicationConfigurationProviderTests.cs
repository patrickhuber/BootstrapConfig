using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootstrapConfig.Abstractions;
using System.Configuration;

namespace BootstrapConfig.Tests.Integration.Abstractions
{
    [TestClass]
    public class ApplicationConfigurationProviderTests
    {
        [TestMethod]
        public void Test_ApplicationConfigurationProvider_Changing_Config_Value_Persists()
        {
            const string ACTUAL = "this works";
            const string KEY = "test1234";
            IConfigurationProvider provider = new ApplicationConfigurationProvider();
            provider.AppSettings[KEY] = ACTUAL;
            var value = provider.AppSettings[KEY] as string;
            Assert.IsNotNull(value);
            Assert.AreEqual(ACTUAL, value);
        }

        [TestMethod]
        public void Test_ApplicationConfigurationProvider_Reads_ConnectionStrings()
        {
            const string ConnectionStringsValue = "{E848B94E-F9C0-49B9-8A6F-7B858DC61615}";
            const string ConnectionStringsKey = "Test_ApplicationConfigurationProvider_Reads_ConnectionStrings";

            IConfigurationProvider provider = new ApplicationConfigurationProvider();
            var connectionStringSettings = provider.ConnectionStrings[ConnectionStringsKey];
            Assert.IsNotNull(connectionStringSettings);
            Assert.AreEqual(ConnectionStringsValue, connectionStringSettings.ConnectionString);
        }
    }
}
