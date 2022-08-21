using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class TariffDefineModel
    {
        public int TariffDefineId { get; set; }

        [Required(ErrorMessage = "لطفا نام تعرفه وارد کنید")]
        [Display(Name = "نام تعرفه")]
        [MaxLength(200)]
        public string TariffDefineName { get; set; }

        [Required(ErrorMessage = "لطفا اولویت تعرفه وارد کنید")]
        [Display(Name = "اولویت تعرفه")]
        public int TariffDefinePriority { get; set; }

        [Required(ErrorMessage = "لطفا فرمول تعرفه وارد کنید")]
        [Display(Name = "فرمول تعرفه")]
        [MaxLength(200)]
        public string TariffDefineFormula { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ شروع وارد کنید")]
        [Display(Name = "تاریخ شروع")]
        [MaxLength(10)]
        public string TariffDefineStartDate { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ پایان وارد کنید")]
        [Display(Name = "تاریخ پایان")]
        [MaxLength(10)]
        public string TariffDefineEndDate { get; set; }

        [Required(ErrorMessage = "لطفا مبلغ اجازه وارد کنید")]
        [Display(Name = "مبلغ اجاره")]
        public int TariffDefineRentAmount { get; set; }

        [Required(ErrorMessage = "لطفا مبلغ رزرو وارد کنید")]
        [Display(Name = "مبلغ رزرو")]
        public int TariffDefineReserveAmount { get; set; }

        
        [Display(Name = "توضیحات")]
        [MaxLength(1000)]
        public string TariffDefineDescription { get; set; }
    }
}
