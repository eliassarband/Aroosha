using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class CustomerCardModel
    {
        public int CustomerCardId { get; set; }

        [Required(ErrorMessage = "لطفا مشتری را انتخاب نمایید")]
        [Display(Name = "مشتری")]
        public int CustomerCardCustomerId { get; set; }

        [Display(Name ="نام مشتری")]
        public string CustomerCardCustomerName { get; set; }

        [Required(ErrorMessage = "لطفا شماره کارت را وارد نمایید")]
        [Display(Name = "شماره کارت عضویت")]
        [MaxLength(20)]
        public string CustomerCardCardCode { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ شروع را وارد نمایید")]
        [Display(Name = "تاریخ شروع")]
        [MaxLength(10)]
        public string CustomerCardStartDate { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ پایان را وارد نمایید")]
        [Display(Name = "تاریخ پایان")]
        [MaxLength(10)]
        public string CustomerCardEndDate { get; set; }

        [Display(Name = "وضعیت کارت عضویت")]
        public bool CustomerCardActive { get; set; }

       
    }
}
