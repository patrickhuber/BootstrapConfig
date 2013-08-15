using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;

namespace BootstrapConfig.UnitTests
{
    [TestClass]
    public class FluentConfigurationLoaderTests
    {
        #region TestContext
        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #endregion TestContext

        private FluentConfigurationLoader fluentConfigurationLoader;
        private Mock<IPathResolver> mockPathResolver;

        [TestInitialize]
        public void Intitialize_FluentConfigurationLoaderTest()
        {
            fluentConfigurationLoader = new FluentConfigurationLoader();
            mockPathResolver = new Mock<IPathResolver>();
            mockPathResolver
                .Setup(resolver=>resolver.ResolvePath(It.IsAny<string>()))
                .Returns((string s)=> 
                    Path.GetFullPath(
                        Path.Combine(TestContext.TestDeploymentDir, s)));
        }

        [TestMethod]
        public void PathResolver_Should_Take_Instance()
        {
            fluentConfigurationLoader.PathResolver(mockPathResolver.Object);
        }

        [TestMethod]
        public void PathResolver_Should_Take_Generic_Type()
        {
            fluentConfigurationLoader.PathResolver<ExePathResolver>();
        }

        [TestMethod]
        public void PathResolver_Should_Take_Type()
        {
            fluentConfigurationLoader.PathResolver(typeof(ExePathResolver));
        }

        [TestMethod]
        public void LoadConfigurationDirectory_Should_Load_One_Configuration()
        {
            var result = fluentConfigurationLoader
                .PathResolver(mockPathResolver.Object)
                .LoadConfigurationDictionary();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("", result.Keys.First());
        }
    }
}
