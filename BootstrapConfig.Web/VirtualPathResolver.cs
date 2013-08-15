using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BootstrapConfig.Web
{
    public class VirtualPathResolver : IPathResolver
    {
        public string ResolvePath(string relativePath)
        {
            string path = HttpContext.Current.Server.MapPath(relativePath);
            return path;
        }
    }
}
