using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace BootstrapConfig.UnitTests
{
    /// <summary>
    /// Make sure local.testsettings depoyment tab has deployment enabled and 
    /// the deployment must include App_Config directory and App.config file
    /// </summary>
    [TestClass]
    public class DirectorySearcherTests
    {
        [TestInitialize]
        public void Initialize_DirectorySearcherTests()
        {
        }

        [TestMethod]
        public void Test_DirectorySearcher_Loads_Nested_Files()
        {
        }

        [TestMethod]
        public void Test_DirectorySearcher_Loads_Only_Files_With_Configuration()
        {

        }

        [TestMethod]
        public void Test_DirectorySearcher_Ignores_Configuration_Transforms()
        {

        }
    }
}
