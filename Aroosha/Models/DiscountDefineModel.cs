using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class DiscountDefineModel
    {
        public int DiscountDefineId { get; set; }

        [Display(Name ="کد تخفیف")]
        [Required(ErrorMessage = "لطفا کد تخفیف را وارد کنید")]
        [Range(0,Int32.MaxValue)]
        public int DiscountDefineCode { get; set; }

        [Display(Name = "عنوان تخفیف")]
        [Required(ErrorMessage = "لطفا عنوان تخفیف را وارد کنید")]
        [MaxLength(100)]
        public string DiscountDefineName { get; set; }

        [Display(Name = "درصد تخفیف")]
        [Required(ErrorMessage = "لطفا درصد تخفیف را وارد کنید")]
        [Range(0, 100)]
        public int DiscountDefineDefaultPercent { get; set; }

        [Display(Name = "مبلغ تخفیف")]
        [Required(ErrorMessage = "لطفا مبلغ تخفیف را وارد کنید")]
        [Range(0,Int32.MaxValue)]
        public int DiscountDefineDefaultPrice { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "لطفا تاریخ شروع را وارد کنید")]
        [MaxLength(10)]
        public string DiscountDefineStartDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = "لطفا تاریخ پایان را وارد کنید")]
        [MaxLength(10)]
        public string DiscountDefineEndDate { get; set; }

        [Display(Name = "وضعیت تخفیف")]
        public bool DiscountDefineActive { get; set; }

    }
}
