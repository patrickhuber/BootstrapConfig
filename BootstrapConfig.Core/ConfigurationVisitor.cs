using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;

namespace BootstrapConfig
{
    public abstract class ConfigurationVisitor
    {
        public abstract void VisitRoot(XDocument document);
        public abstract void VisitElement(XElement element);
        public abstract void VisitConfigurationSection(ConfigurationSection section);
        public abstract void VisitConfigurationSectionGroup(ConfigurationSectionGroup group);
        public abstract void VisitAttribute(XAttribute attribute);
    }
}
