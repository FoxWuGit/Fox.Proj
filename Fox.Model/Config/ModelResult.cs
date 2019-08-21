using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Model.Config
{
    public class ModelResult : IModelResult
    {
        public ModelResult()
        {

        }
        public ModelResult(IModelResult modelResult)
        {
            this.isOK = modelResult.isOK;
            this.ErrorCodee = modelResult.ErrorCodee;
            this.Message = modelResult.Message;
            this.SystemMessage = modelResult.SystemMessage;
        }
        public bool isOK { get; set; }
        public SystemCodes.Codes ErrorCodee { get; set; }
        public string Message { get; set; }
        public string SystemMessage { get; set; }

    }
}
