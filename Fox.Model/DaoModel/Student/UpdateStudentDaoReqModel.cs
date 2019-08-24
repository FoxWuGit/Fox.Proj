using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Model.DaoModel.Student
{
    public class UpdateStudentDaoReqModel
    {
        /// <summary>
        /// 流水編號
        /// </summary>
        public Guid id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string studentName { get; set; }

        /// <summary
        /// 身份證
        /// </summary>
        public string studentId { get; set; }

        /// <summary>
        /// 姓別
        /// </summary>)]
        public string studentSex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? studentBirth { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string studentAddr { get; set; }
    }
}
