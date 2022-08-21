using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class RentModel
    {
        public int RentId { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ اجاره را وارد نمایید")]
        [Display(Name = "تاریخ اجاره")]
        [MaxLength(10)]
        public string RentDate { get; set; }

        [Display(Name = "تقویم")]
        public int RentMarketScheduleDetailId { get; set; }

        [Display(Name = "شرح تقویم")]
        public string RentMarketScheduleDescription { get; set; }

        [Required(ErrorMessage = "لطفا مشتری را انتخاب نمایید")]
        [Display(Name = "مشتری")]
        public int? RentCustomerId { get; set; }

        [Display(Name = "نام مشتری")]
        public string RentCustomerName { get; set; }

        [Display(Name = "غرفه")]
        public int? RentShopId { get; set; }

        [Display(Name = "شناسه غرفه")]
        public string RentShopIdentifier { get; set; }

        [Display(Name = "آدرس غرفه")]
        public string RentShopAddress { get; set; }

        [Display(Name ="تعرفه")]
        public int? RentTariffId { get; set; }

        [Display(Name = "نام تعرفه")]
        public string RentTariffName { get; set; }

        [Display(Name ="مبلغ تعرفه")]
        public int RentTariffAmount { get; set; }

        [Display(Name ="منبع تخفیف")]
        public int? RentDiscountId { get; set; }

        [Display(Name ="نام منبع تخفیف")]
        public string RentDiscountName { get; set; }

        [Display(Name ="مبلغ تخفیف")]
        public int RentDiscountAmount { get; set; }

        [Display(Name ="مبلغ")]
        public int RentAmount { get; set; }

        [Display(Name = "پرداخت")]
        public bool RentPaid { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1000)]
        public string RentDescription { get; set; }

        public List<PaymentModel> PaymentModels{ get; set; }
    }
}
