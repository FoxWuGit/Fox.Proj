using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Fox.Model.Config
{
    public static class SystemCodeHandler
    {
        private static string _configFilePath = HostingEnvironment.MapPath(@"~/Config/SystemCodes.json");
        private static JObject _codeTable = InitCodeTable();

        private static JObject InitCodeTable()
        {
            try
            {
                using (StreamReader r = new StreamReader(_configFilePath,Encoding.UTF8))
                {
                    string json = r.ReadToEnd();
                    JObject jObject = JObject.Parse(json);
                    _ReplaceVariablString(jObject);
                    return jObject;
                }
            }
            catch (Exception ex)
            {
                return new JObject();
            }
        }

        private static void _ReplaceVariablString(JObject jObject)
        {
            string generalMessageKey = "GeneralMessage";
            // 將 generalMessage 取出
            JObject generalMessage = jObject[generalMessageKey]?.ToObject<JObject>();
            // 移除 generalMessage 之 key
            jObject.Remove(generalMessageKey);
            if (generalMessage != null)
            {
                // 若有設置共通內容
                // 將要替換之內容進行替換
                // 格式為 {AKey} => AValue
                foreach (var systemCode in jObject.Values())
                {
                    foreach (var item in generalMessage)
                    {
                        systemCode["Message"] = systemCode["Message"].ToString().Replace($"{{{item.Key}}}", item.Value.ToString());
                    }
                }
            }
        }

        public static JObject CodeTable { get => _codeTable; }

        public static SystemCode GetSystemCode(SystemCodes.Codes errorCode, bool isThrowException = false)
        {
            // 搜尋錯誤訊息
            string message = "";
            string systemMessage = "";

            JToken codeMessages = null;
            if (SystemCodeHandler.CodeTable.TryGetValue(errorCode.ToString(), out codeMessages))
            {
                try
                {
                    SystemCode systemCode = codeMessages.ToObject<SystemCode>();

                    message = string.IsNullOrEmpty(systemCode.Message)
                        ? "" : systemCode.Message;
                    systemMessage = string.IsNullOrEmpty(systemCode.SystemMessage)
                        ? "" : systemCode.SystemMessage;
                }
                catch (Exception ex)
                {
                    if (isThrowException)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                // 無法找尋對應
                if (isThrowException)
                {
                    ArgumentException ex = new ArgumentException($"Can not parse errorCode: {errorCode}.");
                    throw ex;
                }
            }

            return new SystemCode()
            {
                ErrorCode = errorCode,
                Message = message,
                SystemMessage = systemMessage
            };
        }

    }
}
