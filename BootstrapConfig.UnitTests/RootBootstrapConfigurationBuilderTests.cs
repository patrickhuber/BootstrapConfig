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
    public class RootBootstrapConfigurationBuilderTests
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

        private RootBootstrapConfigurationBuilder builder;
        private Mock<IPathResolver> mockPathResolver;

        [TestInitialize]
        public void Intitialize_FluentConfigurationLoaderTest()
        {
            builder = new RootBootstrapConfigurationBuilder(
                new RootBootstrapConfiguration());
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
            builder.PathResolver(mockPathResolver.Object);
        }

        [TestMethod]
        public void PathResolver_Should_Take_Generic_Type()
        {
            builder.PathResolver<ExePathResolver>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PathResolver_Should_Throw_ArgumentNullException_On_Non_IPathResolver_Type()
        {
            builder.PathResolver(typeof(object));
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PathResolver_Should_Throw_ArgumentException_On_Non_Class_Type()
        {
            builder.PathResolver(typeof(string));
            Assert.Fail();
        }

        [TestMethod]
        public void PathResolver_Should_Take_Type()
        {
            builder.PathResolver(typeof(ExePathResolver));
        }

        [TestMethod]
        public void LoadConfigurationDirectory_Should_Create_Valid_Root_Configuration()
        {
            var result = builder
                .PathResolver(mockPathResolver.Object)
                .DirectorySearcher<DefaultDirectorySearcher>(
                    "App_Config",
                    "*.config",
                    true)
                .Configuration();
            Assert.AreEqual("App_Config", result.Path);
            Assert.AreEqual("*.config", result.SearchPattern);
            Assert.AreEqual(true, result.Recursive);
            Assert.AreEqual(result.PathResolver, mockPathResolver.Object);
        }
    }
}
