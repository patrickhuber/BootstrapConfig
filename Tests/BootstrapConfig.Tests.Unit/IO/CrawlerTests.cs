using BootstrapConfig.Abstractions;
using BootstrapConfig.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BootstrapConfig.Tests.Unit.IO
{
    [TestClass]
    public class CrawlerTests
    {
        private IFileSystemProvider fileSystemProvider;
        private IConfigurationProvider configurationProvider;
        private IDictionary<string, IConfiguration> configurations;

        [TestInitialize]
        public void Initialize_Crawler_Tests()
        {
            SetupConfigurationProvider();
            SetupFileSystemProvider();            
        }

        private void SetupConfigurationProvider()
        {
            string[] files = new string[] { "a.config", "b.config", "c.config", "d.config"};
            configurations = new Dictionary<string, IConfiguration>();
            foreach (var file in files)
            {
                var mockConfiguration = new Mock<IConfiguration>();
                mockConfiguration.SetupProperty(x => x.Sections);
                configurations.Add(file, mockConfiguration.Object);
            }

            var mockConfigurationProvider = new Mock<IConfigurationProvider>();

            foreach (var file in configurations.Keys)
            {
                mockConfigurationProvider
                    .Setup(x => x.OpenMappedConfiguration(It.Is<string>(s => s == file)))
                    .Returns(configurations[file]);
            }
        }

        private void SetupFileSystemProvider()
        {
            var mockFileSystemProvider = new Mock<IFileSystemProvider>();
            mockFileSystemProvider
                .Setup(x => x.EnumerateFiles(It.IsAny<SearchParameters>()))
                .Returns<IEnumerable<string>>(r => configurations.Keys);
            fileSystemProvider = mockFileSystemProvider.Object;
        }

        [TestMethod]
        public void Test_Crawler_Returns_All_With_No_Filters()
        {
            IConfigurationEnumerator crawler = new ConfigurationEnumerator(fileSystemProvider, configurationProvider);
            CrawlSettings crawlerSettings = new CrawlSettings();
            var results = crawler.Crawl(crawlerSettings);
            var count = results.Count();
            Assert.AreEqual(configurations.Keys.Count, results.Count());
        }
    }
}
