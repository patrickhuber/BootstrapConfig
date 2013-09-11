using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BootstrapConfig
{
    /// <summary>
    /// allows for pipelineing of the include rules
    /// </summary>
    public interface IIncludeConfigurationRule
    {
        /// <summary>
        /// Execute the rule. If All rules pass, the configuration section will be added.
        /// </summary>
        /// <param name="configurationSection"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        bool Execute(DirectorySearcherArgs args);
    }
}
