using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;

namespace BootstrapConfig
{
    public class ConfigurationVisitor
    {
        public virtual void VisitRoot(XDocument document);
        public virtual void VisitElement(XElement element);
        public virtual void VisitConfigurationSection(ConfigurationSection section);
        public virtual void VisitConfigurationSectionGroup(ConfigurationSectionGroup group);
        public virtual void VisitAttribute(XAttribute attribute);
    }
}
