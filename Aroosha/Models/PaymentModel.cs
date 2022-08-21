using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ اجاره را وارد نمایید")]
        [Display(Name = "تاریخ اجاره")]
        [MaxLength(10)]
        public string Date { get; set; }

        [Display(Name ="اجاره")]
        public int? RentId { get; set; }

        [Display(Name = "رزرو")]
        public int? ReserveId { get; set; }

        [Display(Name = "مبلغ")]
        public int Amount { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
