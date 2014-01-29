using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using BootstrapConfig.Tests.Unit.Templates;

namespace BootstrapConfig.Tests.Unit
{
    [TestClass]
    public class RootBootstrapConfigurationBuilderTests : TestContextTest
    {
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
        public void Test_RootBootstrapConfigurationBuilder_PathResolver_Takes_Instance()
        {
            builder.PathResolver(mockPathResolver.Object);
        }

        [TestMethod]
        public void Test_RootBootstrapConfigurationBuilder_PathResolver_Takes_Generic_Type()
        {
            builder.PathResolver<ExePathResolver>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_RootBootstrapConfigurationBuilder_PathResolver_Throws_ArgumentException_On_Non_IPathResolver_Type()
        {
            builder.PathResolver(typeof(object));
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_RootBootstrapConfigurationBuilder_PathResolver_Throws_ArgumentException_On_Non_Class_Type()
        {
            builder.PathResolver(typeof(string));
            Assert.Fail();
        }

        [TestMethod]
        public void Test_RootBootstrapConfigurationBuilder_PathResolver_Takes_Type()
        {
            builder.PathResolver(typeof(ExePathResolver));
        }

        [TestMethod]
        public void Test_RootBootstrapConfigurationBuilder_PathResolver_LoadConfigurationDirectory_Creates_Valid_Root_Configuration()
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
