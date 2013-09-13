using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapConfig
{
    /// <summary>
    /// 
    /// </summary>
    public interface IKeyGenerator
    {
        /// <summary>
        /// Generates a key.
        /// </summary>
        /// <returns></returns>
        string Generate();

        /// <summary>
        /// Rests this instance.
        /// </summary>
        void Rest();
    }
}
