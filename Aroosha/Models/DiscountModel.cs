using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class DiscountModel
    {
        public int DiscountId { get; set; }

        [Display(Name ="کد تخفیف")]
        [Required(ErrorMessage = "لطفا کد تخفیف را وارد کنید")]
        [Range(0,Int32.MaxValue)]
        public int DiscountCode { get; set; }

        [Display(Name = "عنوان تخفیف")]
        [Required(ErrorMessage = "لطفا عنوان تخفیف را وارد کنید")]
        [MaxLength(100)]
        public string DiscountName { get; set; }

        [Display(Name = "درصد تخفیف")]
        [Required(ErrorMessage = "لطفا درصد تخفیف را وارد کنید")]
        [Range(0, 100)]
        public int DiscountDefaultPercent { get; set; }

        [Display(Name = "مبلغ تخفیف")]
        [Required(ErrorMessage = "لطفا مبلغ تخفیف را وارد کنید")]
        [Range(0,Int32.MaxValue)]
        public int DiscountDefaultPrice { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "لطفا تاریخ شروع را وارد کنید")]
        [MaxLength(10)]
        public string DiscountStartDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = "لطفا تاریخ پایان را وارد کنید")]
        [MaxLength(10)]
        public string DiscountEndDate { get; set; }

        [Display(Name = "وضعیت تخفیف")]
        public bool DiscountActive { get; set; }

    }
}
