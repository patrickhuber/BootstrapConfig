using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Moq;
using BootstrapConfig.Tests.Templates;
using BootstrapConfig.Abstractions;
using BootstrapConfig.IO;

namespace BootstrapConfig.Tests.Unit
{
    /// <summary>
    /// Make sure local.testsettings depoyment tab has deployment enabled and 
    /// the deployment must include App_Config directory and App.config file
    /// </summary>
    [TestClass]
    public class DirectorySearcherTests : TestContextTest
    {
        IConfigurationProvider provider;
        IPathResolver pathResolver;
        IKeyGenerator keyGenerator;
        IIncludeConfigurationRule isBootstrapConfigRule;
        IIncludeConfigurationRule boostrapConfigHasKeyRule;
        IFileSystemProvider fileProvider;

        [TestInitialize]
        public void Initialize_DirectorySearcherTests()
        {
            CreateMockConfigurationProvider();
            CreateMockPathResolver();
            CreateMockKeyGenerator();
            CreateMockIncludeConfigurationByKeyRule();
            CreateFileProvider();
        }

        private void CreateMockConfigurationProvider()
        {
            var moqConfigurationProvider = new Mock<IConfigurationProvider>();
            provider = moqConfigurationProvider.Object;
        }

        private void CreateMockPathResolver()
        {
            var moqPathResolver = new Mock<IPathResolver>();
            moqPathResolver
                .Setup(resolver => resolver.ResolvePath(It.IsAny<string>()))
                .Returns((string s) =>
                    Path.GetFullPath(
                        Path.Combine(this.CurrentDirectory.FullName, s)));
            pathResolver = moqPathResolver.Object;
        }

        private void CreateMockKeyGenerator()
        {
            // setup the key generator
            var moqKeyGenerator = new Mock<IKeyGenerator>();
            int index = 0;
            moqKeyGenerator
                .Setup(resolver => resolver.Generate())
                .Returns(() => (index++).ToString());
            keyGenerator = moqKeyGenerator.Object;
        }

        private void CreateMockIncludeConfigurationByKeyRule()
        {
            var moqIsBootstrapConfigRule = new Mock<IIncludeConfigurationRule>();
            moqIsBootstrapConfigRule.Setup(resolver => resolver.Execute(It.IsAny<DirectorySearcherArgs>()))
                .Returns<DirectorySearcherArgs>((ds) =>
                {
                    return ds.ConfigurationSection is IBootstrapConfiguration;
                });
            isBootstrapConfigRule = moqIsBootstrapConfigRule.Object;

            var moqBoostrapConfigHasKeyRule = new Mock<IIncludeConfigurationRule>();
            moqIsBootstrapConfigRule.Setup(resolver => resolver.Execute(It.IsAny<DirectorySearcherArgs>()))
                .Returns<DirectorySearcherArgs>((ds) =>
                {
                    var config = ds.ConfigurationSection as IBootstrapConfiguration;
                    return config != null && string.IsNullOrWhiteSpace(config.Key);
                });
            boostrapConfigHasKeyRule = moqBoostrapConfigHasKeyRule.Object;
        }

        private void CreateFileProvider()
        {
            var moqFileProvider = new Mock<IFileSystemProvider>();
            moqFileProvider
                .Setup(x => x.EnumerateFiles(
                    It.IsAny<SearchParameters>()))
                .Returns<IEnumerable<FileInfo>>(v => new string[]{});
        }

        [TestMethod]
        public void Test_DirectorySearcher_Loads_Nested_Files()
        {
            IDirectorySearcher directorySearcher = new DirectorySearcher(
                provider,
                pathResolver,
                keyGenerator,
                fileProvider,
                Path.Combine(this.CurrentDirectory.FullName, Paths.App_Config.HasNestedFiles.Path),
                "*.config",
                true);
            var configurationDictionary = directorySearcher.GetConfigurationDictionary();
            Assert.AreEqual(2, configurationDictionary.Keys.Count);
        }
                
        [TestMethod]
        public void Test_DirectorySearcher_Loads_Only_Files_With_Configuration_And_Key()
        {
            IDirectorySearcher directorySearcher = new DirectorySearcher(
                provider,
                pathResolver,
                keyGenerator,
                fileProvider,
                Path.Combine(this.CurrentDirectory.FullName, Paths.App_Config.HasNestedFiles.Path),
                "*.config",
                true);
            var configurationDictionary = directorySearcher.GetConfigurationDictionary();
            Assert.AreEqual(1, configurationDictionary.Keys.Count);
        }

        [TestMethod]
        public void Test_DirectorySearcher_Ignores_Configuration_Transforms()
        {

        }
    }
}
