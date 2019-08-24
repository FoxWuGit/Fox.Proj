using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Model.ViewModel.Student
{
    public class IndexVM
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(5, ErrorMessage = "姓名長度不符(5字)")]
        public string studentName { get; set; }

        /// <summary>
        /// 身份證
        /// </summary>
        [MaxLength(10, ErrorMessage = "身份證長度不符(10位大寫英文及數字)")]
        [RegularExpression(@"^[A-Z]\d{9}$", ErrorMessage = "請輸入正確身份證格式(10位大寫英文及數字)")]
        public string studentId { get; set; }
        /// <summary>
        /// 學生資訊
        /// </summary>
        public IList<IndexStudentItem> lstStudentInfo { get; set; }
    }

    public class IndexStudentItem
    {
        /// <summary>
        /// 流水編號
        /// </summary>
        public System.Guid id { get; set; }
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
        /// </summary>
        public string studentSex { get; set; }
        public string studentSexDesc => (this.studentSex ?? "").Equals("1") ? "男" : ((this.studentSex ?? "").Equals("2") ? "女" : "");
        /// <summary>
        /// 生日
        /// </summary>
        public System.DateTime? studentBirth { get; set; }
        public string studentBirthDesc => this.studentBirth.HasValue ? this.studentBirth.Value.ToString("yyyy/MM/dd") : "";
    }
}
