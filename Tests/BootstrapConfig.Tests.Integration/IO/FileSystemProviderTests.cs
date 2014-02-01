using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootstrapConfig.Tests.Templates;
using System.IO;
using BootstrapConfig.Tests.Unit;
using BootstrapConfig.IO;

namespace BootstrapConfig.Tests.Integration.IO
{
    [TestClass]
    public class FileSystemProviderTests : TestContextTest
    {
        [TestMethod]
        public void FileSystemProvider_Test_Enumerate_Returns_All_Files()
        {
            var path = Path.Combine(CurrentDirectory.FullName, Paths.App_Config.Path);
            IFileSystemProvider fileSystemProvider = new FileSystemProvider();
            var parameters = new SearchParameters(path, "*.*", true);
            var result = fileSystemProvider.EnumerateFiles(parameters);
            var count = 0;
            foreach(var item in result)
                count += 1;
            Assert.IsTrue(3 < count);
        }
    }
}
