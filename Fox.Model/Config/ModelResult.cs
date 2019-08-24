using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Model.Config
{
    /// <summary>
    /// 回傳制式格式
    /// </summary>
    public class ModelResult: IModelResult
    {
        public ModelResult()
        {
            this.IsOk = true;
            this.ErrorCode = null;
            this.Message = null;
            this.SystemMessage = null;
        }

        public ModelResult(SystemCodes.Codes errorCode)
        {
            this.IsOk = false;
            this.ErrorCode = errorCode;
            SystemCode systemCode = SystemCodeHandler.GetSystemCode(errorCode);
            this.SystemMessage = systemCode.SystemMessage;
            this.Message = systemCode.Message;
            this.DisplayCode = systemCode.DisplayCode;
        }

        public ModelResult(IModelResult modelResult)
        {
            this.IsOk = modelResult.IsOk;
            this.ErrorCode = modelResult.ErrorCode;
            this.Message = modelResult.Message;
            this.SystemMessage = modelResult.SystemMessage;
        }

        /// <summary>
		/// 給定 errorCode 自動從Config帶入對應 SystemMessage & Message 並加上額外 extendMessage
		/// </summary>
		/// <param name="errorCode">系統錯誤碼</param>
		/// <param name="extendMessage">額外顯示訊息</param>
		public ModelResult(SystemCodes.Codes errorCode, string extendMessage) : this(errorCode)
        {
            _ExtendMessage(extendMessage);
        }

        protected void _ExtendMessage(string message)
        {
            if (string.IsNullOrEmpty(this.Message))
            {
                this.Message = message;
            }
            else
            {
                this.Message += message;
            }
        }

        public bool IsOk { get; set; }
        public SystemCodes.Codes? ErrorCode { get; set; }
        public string DisplayCode { get; set; }
        public string SystemMessage { get; set; } = "系統執行成功";
        public string Message { get; set; }
    }

	public class ModelResult<T> : ModelResult, IModelResult<T>, IModelResult
    {

        /// <summary>
        /// 實際執行結果資料
        /// </summary>
        public T ResultData { get; set; }

        public ModelResult(IModelResult modelResult) : base(modelResult) { }

        public ModelResult() : base() { }

        /// <summary>
        /// 給定 errorCode 自動從Config帶入對應 SystemMessage & Message
        /// </summary>
        /// <param name="errorCode">系統錯誤碼</param>
        public ModelResult(SystemCodes.Codes errorCode) : base(errorCode) { }

        /// <summary>
        /// 給定 errorCode 自動從Config帶入對應 SystemMessage & Message 並加上額外 extendMessage
        /// </summary>
        /// <param name="errorCode">系統錯誤碼</param>
        /// <param name="extendMessage">額外顯示訊息</param>
        public ModelResult(SystemCodes.Codes errorCode, string extendMessage) : base(errorCode, extendMessage) { }
    }
}
