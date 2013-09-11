using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapConfig.Rules
{
    /// <summary>
    /// rule that determines if a configuration is a bootstrap configuration section
    /// </summary>
    public class IsBoostrapConfigurationSectionRuleRule : IIncludeConfigurationRule
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
            return bootstrapConfiguration != null;
        }
    }
}
