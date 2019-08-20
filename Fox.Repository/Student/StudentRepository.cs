using Fox.Model.ViewModel.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Repository.Student
{
    public class StudentRepository
    {
        public IndexResVM SelectStudent (IndexReqVm model = null)
        {
            return null;
        }

        /// <summary>
        /// 存取db事件
        /// </summary>
        /// <param name="msg"></param>
        protected virtual void doEventLog(string msg)
        {
            //可存db事件
        }

        /// <summary>
        /// 存取log工具
        /// </summary>
        /// <param name="msg"></param>
        protected virtual void doLog(string msg)
        {
            //存取log工具
        }
    }
}
