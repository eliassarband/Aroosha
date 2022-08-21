using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class CreditModel
    {
        public int CreditId { get; set; }

        [Required(ErrorMessage = "لطفا مشتری را انتخاب کنید")]
        [Display(Name = "مشتری")]
        public int CreditCustomerId { get; set; }
        public string CreditCustomerName { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ را وارد کنید")]
        [Display(Name ="تاریخ")]
        [MaxLength(10)]
        public string CreditDate { get; set; }

        [Required(ErrorMessage = "لطفا نوع پرداخت را انتخاب کنید")]
        [Display(Name = "نوع پرداخت")]
        public int CreditPaymentTypeId { get; set; }
        public string CreditPaymentTypeName { get; set; }

        [Required(ErrorMessage = "لطفا مبلغ را وارد کنید")]
        [Display(Name = "مبلغ شارژ")]
        public int CreditAmount { get; set; }

        [Display(Name = "افزاینده/کاهنده")]
        public bool CreditType { get; set; }

        [Display(Name = "شماره فیش پرداخت")]
        public string CreditReceiptNumber { get; set; }

        [Display(Name = "توضیحات")]
        public string CreditDescription { get; set; }

        [Display(Name = "مانده اعتبار")]
        public int CreditBalance { get; set; }
    }
}
