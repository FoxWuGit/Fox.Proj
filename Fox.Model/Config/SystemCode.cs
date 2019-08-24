using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Model.Config
{
    public class SystemCode
    {
        public SystemCodes.Codes ErrorCode { get; set; }
        public string DisplayCode { get; set; }
        public string Message { get; set; }
        public string SystemMessage { get; set; } = "系統執行成功";
    }
}
