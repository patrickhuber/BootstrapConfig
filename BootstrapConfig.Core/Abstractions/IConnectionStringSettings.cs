﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapConfig.Abstractions
{
    public interface IConnectionStringSettings
    {
        string ConnectionString { get; }
    }
}
