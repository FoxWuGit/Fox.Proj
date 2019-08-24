using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Fox.Model.ViewModel.Student
{
    public class InsertVm
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "請輸入姓名")]
        [MaxLength(5, ErrorMessage = "姓名長度不符(5字)")]
        public string studentName { get; set; }

        /// <summary
        /// 身份證
        /// </summary>
        [Required(ErrorMessage = "請輸入身份證")]
        [MaxLength(10, ErrorMessage = "身份證長度不符(10位大寫英文及數字)")]
        [RegularExpression(@"^[A-Z]\d{9}$", ErrorMessage = "請輸入正確身份證格式(10位大寫英文及數字)")]
        public string studentId { get; set; }

        /// <summary>
        /// 姓別
        /// </summary>
        [MaxLength(1, ErrorMessage ="請選擇姓別")]
        public string studentSex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "請輸入正確日期格式(yyyy/mm/dd)")]
        public string studentBirth { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(250, ErrorMessage = "地址長度不符(250字)")]
        public string studentAddr { get; set; }

        /// <summary>
        /// 姓別List
        /// </summary>
        public IList<SelectListItem> lstSex {
            get {
                IList<SelectListItem> selectListItems = new List<SelectListItem>();
                selectListItems.Add(new SelectListItem() { Text = "男", Value = "1", Selected = "1".Equals(this.studentSex) });
                selectListItems.Add(new SelectListItem() { Text = "女", Value = "2", Selected = "2".Equals(this.studentSex) });
                return selectListItems;
            }
        }
    }
}
