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

        [TestInitialize]
        public void Initialize_DirectorySearcherTests()
        {
            var moqPathResolver = new Mock<IPathResolver>();
            moqPathResolver
                .Setup(resolver => resolver.ResolvePath(It.IsAny<string>()))
                .Returns((string s) =>
                    Path.GetFullPath(
                        Path.Combine(this.CurrentDirectory.FullName, s)));
            pathResolver = moqPathResolver.Object;
        }

        [TestMethod]
        public void Test_DirectorySearcher_Loads_Nested_Files()
        {
            IDirectorySearcher directorySearcher = new DefaultDirectorySearcher(
                Path.Combine(this.CurrentDirectory.FullName, Paths.App_Config.HasNestedFiles.Path),
                "*.config",
                true,
                pathResolver);
            var configurationDictionary = directorySearcher.GetConfigurationDictionary();
            Assert.AreEqual(2, configurationDictionary.Keys.Count);
        }

        [TestMethod]
        public void Test_DirectorySearcher_Loads_Only_Files_With_Configuration()
        {
            IDirectorySearcher directorySearcher = new DefaultDirectorySearcher(
                Path.Combine(this.CurrentDirectory.FullName, Paths.App_Config.HasOneFile.Path),
                "*.config",
                false,
                pathResolver);
            var configurationDictionary = directorySearcher.GetConfigurationDictionary();
            Assert.AreEqual(1, configurationDictionary.Keys.Count);
        }

        [TestMethod]
        public void Test_DirectorySearcher_Ignores_Configuration_Transforms()
        {

        }
    }
}
