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
        [Required(ErrorMessage = "請輸入姓名")]
        [MaxLength(5, ErrorMessage = "姓名長度不符(5字)")]
        public string studentName { get; set; }

        /// <summary>
        /// 身份證
        /// </summary>
        [Required(ErrorMessage = "請輸入身份證")]
        [MaxLength(10, ErrorMessage = "身份證長度不符(10位大寫英文及數字)")]
        [RegularExpression(@"^[A-Z]\d{9}$", ErrorMessage = "請輸入正確身份證格式(10位大寫英文及數字)")]
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
