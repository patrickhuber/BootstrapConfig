using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapConfig.Diagnostics
{
    public static class Assert
    {
        public static void IsNotNull(object instance, string paramName, string message)
        {
            if (instance == null)
                throw new ArgumentNullException(paramName, message);
        }

        public static void ArgumentIsTrue(bool test, string message)
        {
            if (!test)
                throw new ArgumentException(message);
        }
    }
}
