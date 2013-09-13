using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Moq;
using BootstrapConfig.UnitTests.Templates;

namespace BootstrapConfig.UnitTests
{
    /// <summary>
    /// Make sure local.testsettings depoyment tab has deployment enabled and 
    /// the deployment must include App_Config directory and App.config file
    /// </summary>
    [TestClass]
    public class DirectorySearcherTests : TestContextTest
    {
        IPathResolver pathResolver;
        IKeyGenerator keyGenerator;
        IIncludeConfigurationRule isBootstrapConfigRule;
        IIncludeConfigurationRule boostrapConfigHasKeyRule;

        [TestInitialize]
        public void Initialize_DirectorySearcherTests()
        {
            // setup the path resolver
            var moqPathResolver = new Mock<IPathResolver>();
            moqPathResolver
                .Setup(resolver => resolver.ResolvePath(It.IsAny<string>()))
                .Returns((string s) =>
                    Path.GetFullPath(
                        Path.Combine(this.CurrentDirectory.FullName, s)));
            pathResolver = moqPathResolver.Object;

            // setup the key generator
            var moqKeyGenerator = new Mock<IKeyGenerator>();
            int index = 0;
            moqKeyGenerator
                .Setup(resolver=> resolver.Generate())
                .Returns(()=>(index++).ToString());
            keyGenerator = moqKeyGenerator.Object;

            // setup the boostrap config rule
            var moqIsBootstrapConfigRule = new Mock<IIncludeConfigurationRule>();
            moqIsBootstrapConfigRule.Setup(resolver => resolver.Execute(It.IsAny<DirectorySearcherArgs>()))
                .Returns<DirectorySearcherArgs>((ds) => 
                {
                    return ds.ConfigurationSection is BootstrapConfigurationSection;
                });
            isBootstrapConfigRule = moqIsBootstrapConfigRule.Object;

            // setup the boostrap config has key rule
            var moqBoostrapConfigHasKeyRule = new Mock<IIncludeConfigurationRule>();
            moqIsBootstrapConfigRule.Setup(resolver => resolver.Execute(It.IsAny<DirectorySearcherArgs>()))
                .Returns<DirectorySearcherArgs>((ds) =>
                {
                    var config = ds.ConfigurationSection as BootstrapConfigurationSection;
                    return config != null && string.IsNullOrWhiteSpace(config.Key);
                });
            boostrapConfigHasKeyRule = moqBoostrapConfigHasKeyRule.Object;
        }

        [TestMethod]
        public void Test_DirectorySearcher_Loads_Nested_Files()
        {
            IDirectorySearcher directorySearcher = new DefaultDirectorySearcher(
                Path.Combine(this.CurrentDirectory.FullName, Paths.App_Config.HasNestedFiles.Path),
                "*.config",
                true,                
                pathResolver,
                keyGenerator);
            var configurationDictionary = directorySearcher.GetConfigurationDictionary();
            Assert.AreEqual(2, configurationDictionary.Keys.Count);
        }
                
        [TestMethod]
        public void Test_DirectorySearcher_Loads_Only_Files_With_Configuration_And_Key()
        {
            IDirectorySearcher directorySearcher = new DefaultDirectorySearcher(
                Path.Combine(this.CurrentDirectory.FullName, Paths.App_Config.HasOneFile.Path),
                "*.config",
                false,
                pathResolver,
                keyGenerator);
            var configurationDictionary = directorySearcher.GetConfigurationDictionary();
            Assert.AreEqual(1, configurationDictionary.Keys.Count);
        }

        [TestMethod]
        public void Test_DirectorySearcher_Ignores_Configuration_Transforms()
        {

        }
    }
}
