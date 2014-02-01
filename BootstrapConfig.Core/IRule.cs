using BootstrapConfig.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapConfig
{
    public interface IRule
    {
        bool Evaluate(IConfiguration configuration);
    }
}
