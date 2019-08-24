using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fox.Model.ViewModel.Student
{
    public class InsertVm
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage ="請輸入姓名")]
        [MaxLength(5, ErrorMessage = "姓名長度不符(5字)")]
        public string studentName { get; set; }

        /// <summary>
        /// 身份證
        /// </summary>
        [Required(ErrorMessage ="請輸入身份證")]
        [MaxLength(10, ErrorMessage = "身份證長度不符(10位英數字)")]
        [RegularExpression(@"/^[A-Z]\d{9}$/", ErrorMessage = "請輸入正確身份證格式(10位英數字)")]
        public string studentId { get; set; }

        /// <summary>
        /// 姓別
        /// </summary>
        [MaxLength(1, ErrorMessage ="請選擇姓別")]
        public string studentSex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? studentBirth { get; set; }
    }
}
