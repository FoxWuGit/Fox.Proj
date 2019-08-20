using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Model.ViewModel.Student
{
    public class IndexResVM
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string studentName { get; set; }
        /// <summary>
        /// 身份證
        /// </summary>
        public string studentId { get; set; }
        /// <summary>
        /// 學生資訊
        /// </summary>
        IList <IndexStudentItem> lstStudentInfo { get; set; }
    }

    public class IndexStudentItem
    {

    }
}
