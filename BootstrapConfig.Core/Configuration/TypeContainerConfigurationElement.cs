using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BootstrapConfig
{
    public class TypeContainerConfigurationElement : ConfigurationElement, BootstrapConfig.ITypeContainerConfiguration
    {
        public const string TypeKey = "type";

        [ConfigurationProperty(TypeKey)]
        public Type Type
        {
            get { return this[TypeKey] as Type; }
            set { this[TypeKey] = value; }
        }
    }
}
