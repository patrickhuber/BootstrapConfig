using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BootstrapConfig.Rules
{
    /// <summary>
    /// 
    /// </summary>
    public class BootstrapConfigurationSectionContainsKey : IIncludeConfigurationRule
    {
        /// <summary>
        /// Execute the rule. If All rules pass, the configuration section will be added.
        /// </summary>
        /// <param name="configurationSection"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public bool Execute(DirectorySearcherArgs args)
        {
            var bootstrapConfiguration = args.ConfigurationSection as BootstrapConfigurationSection;
            if (bootstrapConfiguration == null)
                return false;
            return !string.IsNullOrWhiteSpace(bootstrapConfiguration.Key);
        }
    }
}
