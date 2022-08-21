using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class ReserveModel
    {
        public int ReserveId { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ رزرو را وارد نمایید")]
        [Display(Name = "تاریخ رزرو")]
        [MaxLength(10)]
        public string ReserveDate { get; set; }

        [Display(Name = "تقویم")]
        public int ReserveMarketScheduleDetailId { get; set; }

        [Display(Name = "شرح تقویم")]
        public string ReserveMarketScheduleDescription { get; set; }

        [Required(ErrorMessage = "لطفا مشتری را انتخاب نمایید")]
        [Display(Name = "مشتری")]
        public int? ReserveCustomerId { get; set; }

        [Display(Name = "نام مشتری")]
        public string ReserveCustomerName { get; set; }

        [Display(Name = "غرفه")]
        public int? ReserveShopId { get; set; }

        [Display(Name = "شناسه غرفه")]
        public string ReserveShopIdentifier { get; set; }

        [Display(Name = "آدرس غرفه")]
        public string ReserveShopAddress { get; set; }

        [Display(Name ="تعرفه")]
        public int? ReserveTariffId { get; set; }

        [Display(Name = "نام تعرفه")]
        public string ReserveTariffName { get; set; }

        [Display(Name ="مبلغ تعرفه")]
        public int ReserveTariffAmount { get; set; }

        [Display(Name ="منبع تخفیف")]
        public int? ReserveDiscountId { get; set; }

        [Display(Name ="نام منبع تخفیف")]
        public string ReserveDiscountName { get; set; }

        [Display(Name ="مبلغ تخفیف")]
        public int ReserveDiscountAmount { get; set; }

        [Display(Name ="مبلغ")]
        public int ReserveAmount { get; set; }

        [Display(Name = "پرداخت")]
        public bool ReservePaid { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1000)]
        public string ReserveDescription { get; set; }

        public List<PaymentModel> PaymentModels{ get; set; }
    }
}
