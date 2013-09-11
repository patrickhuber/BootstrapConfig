using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace BootstrapConfig.UnitTests.Templates
{
    public class TestContextTest
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

        #region CurrentDirectory

        public DirectoryInfo CurrentDirectory
        {
            get 
            {
                return new DirectoryInfo(TestContext.TestDeploymentDir);
            }
        }
        #endregion CurrentDirectory
    }
}
