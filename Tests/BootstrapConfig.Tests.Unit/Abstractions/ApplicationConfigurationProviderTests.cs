using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootstrapConfig.Abstractions;

namespace BootstrapConfig.Tests.Unit.Abstractions
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
    }
}
