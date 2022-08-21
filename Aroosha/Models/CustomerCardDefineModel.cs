using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class CustomerCardDefineModel
    {
        public int CustomerCardDefineId { get; set; }

        [Required(ErrorMessage = "لطفا مشتری را انتخاب نمایید")]
        [Display(Name = "مشتری")]
        public int CustomerCardDefineCustomerId { get; set; }

        [Display(Name ="نام مشتری")]
        public string CustomerCardDefineCustomerName { get; set; }

        [Required(ErrorMessage = "لطفا شماره کارت را وارد نمایید")]
        [Display(Name = "شماره کارت عضویت")]
        [MaxLength(20)]
        public string CustomerCardDefineCardCode { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ شروع را وارد نمایید")]
        [Display(Name = "تاریخ شروع")]
        [MaxLength(10)]
        public string CustomerCardDefineStartDate { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ پایان را وارد نمایید")]
        [Display(Name = "تاریخ پایان")]
        [MaxLength(10)]
        public string CustomerCardDefineEndDate { get; set; }

        [Display(Name = "وضعیت کارت عضویت")]
        public bool CustomerCardDefineActive { get; set; }

       
    }
}
