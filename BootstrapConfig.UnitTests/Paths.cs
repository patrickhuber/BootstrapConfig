using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapConfig.UnitTests
{
    public static class Paths
    {
        public const string Seperator = "/";
        public static class App_Config
        {
            public const string Path = "App_Config";

            public static class HasNestedFiles
            {
                public const string Path = App_Config.Path + Seperator + "HasNestedFiles";

                public static class Nested
                {
                    public const string Path = HasNestedFiles.Path + Seperator + "Nested";
                    public const string HasSectionAndKey = Path + Seperator + "HasSectionAndKey.config";
                    public const string HasSectionNoKey = Path + Seperator + "HasSectionNoKey.config";
                    public const string NoSectionNoKey = Path + Seperator + "NoSectionNoKey.config";
                }

                public const string HasSectionAndKey = Path + Seperator + "HasSectionAndKey.config";
                public const string HasSectionNoKey = Path + Seperator + "HasSectionNoKey.config";
                public const string NoSectionNoKey = Path + Seperator + "NoSectionNoKey.config";
            }

            public static class HasOneFile
            {
                public const string Path = App_Config.Path + Seperator + "HasOneFile";
                public const string HasSectionAndKey = Path + Seperator + "HasSectionAndKey.config";
                public const string HasSectionNoKey = Path + Seperator + "HasSectionNoKey.config";
                public const string NoSectionNoKey = Path + Seperator + "NoSectionNoKey.config";
            }

            public static class HasTransforms
            {
                public const string Path = App_Config.Path + Seperator + "HasTransforms";
                public const string ConfigTransforms = Path + Seperator + "ConfigTransforms.config";
                public const string ConfigTransformsDebug = Path + Seperator + "ConfigTransforms.Debug.config";
                public const string ConfigTransformsRelease = Path + Seperator + "ConfigTransforms.Release.config";
            }
        }
    }
}
