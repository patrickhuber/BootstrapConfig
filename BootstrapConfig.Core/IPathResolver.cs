﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapConfig
{
    public interface IPathResolver
    {
        string ResolvePath(string relativePath);
    }
}
