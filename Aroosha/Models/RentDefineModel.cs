using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class RentDefineModel
    {
        public int RentDefineId { get; set; }

        
        [Display(Name = "تاریخ اجاره")]
        [MaxLength(10)]
        public string RentDefineDate { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ اجاره را وارد نمایید")]
        [Display(Name = "تقویم")]
        public int RentDefineMarketScheduleDetailId { get; set; }

        [Display(Name = "شرح تقویم")]
        public string RentDefineMarketScheduleDescription { get; set; }

        [Required(ErrorMessage = "لطفا مشتری را انتخاب نمایید")]
        [Display(Name = "مشتری")]
        public int? RentDefineCustomerId { get; set; }

        [Display(Name = "نام مشتری")]
        public string RentDefineCustomerName { get; set; }

        [Display(Name = "مانده اعتبار مشتری")]
        public int RentDefineCustomerBalance { get; set; }

        [Display(Name = "غرفه")]
        public int? RentDefineShopId { get; set; }

        [Display(Name = "شناسه غرفه")]
        public string RentDefineShopIdentifier { get; set; }

        [Display(Name = "آدرس غرفه")]
        public string RentDefineShopAddress { get; set; }

        [Display(Name ="تعرفه")]
        public int? RentDefineTariffId { get; set; }

        [Display(Name = "نام تعرفه")]
        public string RentDefineTariffName { get; set; }

        [Display(Name ="مبلغ تعرفه")]
        public int RentDefineTariffAmount { get; set; }

        [Display(Name ="منبع تخفیف")]
        public int? RentDefineDiscountId { get; set; }

        [Display(Name ="نام منبع تخفیف")]
        public string RentDefineDiscountName { get; set; }

        [Display(Name ="مبلغ تخفیف")]
        public int RentDefineDiscountAmount { get; set; }

        [Display(Name = "درصد تخفیف")]
        public int RentDefineDiscounPercent { get; set; }

        [Display(Name ="مبلغ")]
        public int RentDefineAmount { get; set; }

        [Display(Name = "پرداخت")]
        public bool RentDefinePaid { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1000)]
        public string RentDefineDescription { get; set; }

        public List<PaymentModel> PaymentModels{ get; set; }
    }
}
