using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class ReserveDefineModel
    {
        public int ReserveDefineId { get; set; }

        
        [Display(Name = "تاریخ رزرو")]
        [MaxLength(10)]
        public string ReserveDefineDate { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ رزرو را وارد نمایید")]
        [Display(Name = "تقویم")]
        public int ReserveDefineMarketScheduleDetailId { get; set; }

        [Display(Name = "شرح تقویم")]
        public string ReserveDefineMarketScheduleDescription { get; set; }

        [Required(ErrorMessage = "لطفا مشتری را انتخاب نمایید")]
        [Display(Name = "مشتری")]
        public int? ReserveDefineCustomerId { get; set; }

        [Display(Name = "نام مشتری")]
        public string ReserveDefineCustomerName { get; set; }

        [Display(Name = "مانده اعتبار مشتری")]
        public int ReserveDefineCustomerBalance { get; set; }

        [Display(Name = "غرفه")]
        public int? ReserveDefineShopId { get; set; }

        [Display(Name = "شناسه غرفه")]
        public string ReserveDefineShopIdentifier { get; set; }

        [Display(Name = "آدرس غرفه")]
        public string ReserveDefineShopAddress { get; set; }

        [Display(Name ="تعرفه")]
        public int? ReserveDefineTariffId { get; set; }

        [Display(Name = "نام تعرفه")]
        public string ReserveDefineTariffName { get; set; }

        [Display(Name ="مبلغ تعرفه")]
        public int ReserveDefineTariffAmount { get; set; }

        [Display(Name ="منبع تخفیف")]
        public int? ReserveDefineDiscountId { get; set; }

        [Display(Name ="نام منبع تخفیف")]
        public string ReserveDefineDiscountName { get; set; }

        [Display(Name ="مبلغ تخفیف")]
        public int ReserveDefineDiscountAmount { get; set; }

        [Display(Name = "درصد تخفیف")]
        public int ReserveDefineDiscounPercent { get; set; }

        [Display(Name ="مبلغ")]
        public int ReserveDefineAmount { get; set; }

        [Display(Name = "پرداخت")]
        public bool ReserveDefinePaid { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1000)]
        public string ReserveDefineDescription { get; set; }

        public List<PaymentModel> PaymentModels{ get; set; }
    }
}
