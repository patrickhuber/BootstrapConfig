using BootstrapConfig.Abstractions;
using BootstrapConfig.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapConfig
{
    public class ConfigurationEnumerator : IConfigurationEnumerator
    {
        private IFileSystemProvider fileSystemProvider;
        private IConfigurationProvider configurationProvider;

        public ConfigurationEnumerator(IFileSystemProvider fileSystemProvider, IConfigurationProvider configurationProvider)
        {
            this.fileSystemProvider = fileSystemProvider;
        }

        public IEnumerable<IConfiguration> Crawl(CrawlSettings crawlerSettings)
        {
            foreach (var file in fileSystemProvider.EnumerateFiles(crawlerSettings))
            {
                var configuration = configurationProvider.OpenMappedConfiguration(file);
                if(AllRulesPass(configuration, crawlerSettings.Rules))
                    yield return configuration;
            }
        }

        private bool AllRulesPass(IConfiguration configuration, IEnumerable<IRule> rules)
        {
            return false;
        }

        public IConfiguration Current
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        object System.Collections.IEnumerator.Current
        {
            get { throw new NotImplementedException(); }
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
