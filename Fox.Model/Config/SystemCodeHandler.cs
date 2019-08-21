using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Fox.Model.Config
{
    public class SystemCodeHandler
    {
        private static string _configFilePath = HostingEnvironment.MapPath(@"~/Config/SystemCodes");
    }
}
