using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class CreditDefineModel
    {
        public int CreditDefineId { get; set; }

        [Required(ErrorMessage = "لطفا مشتری را انتخاب کنید")]
        [Display(Name = "مشتری")]
        public int CreditDefineCustomerId { get; set; }
        public string CreditDefineCustomerName { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ را وارد کنید")]
        [Display(Name ="تاریخ")]
        [MaxLength(10)]
        public string CreditDefineDate { get; set; }

        [Required(ErrorMessage = "لطفا نوع پرداخت را انتخاب کنید")]
        [Display(Name = "نوع پرداخت")]
        public int CreditDefinePaymentTypeId { get; set; }
        public string CreditDefinePaymentTypeName { get; set; }

        [Required(ErrorMessage = "لطفا مبلغ را وارد کنید")]
        [Display(Name = "مبلغ شارژ")]
        public int CreditDefineAmount { get; set; }

        [Display(Name = "افزاینده/کاهنده")]
        public bool CreditDefineType { get; set; }

        [Display(Name = "شماره فیش پرداخت")]
        public string CreditDefineReceiptNumber { get; set; }

        [Display(Name = "توضیحات")]
        public string CreditDefineDescription { get; set; }

        [Display(Name = "مانده اعتبار")]
        public int CreditDefineBalance { get; set; }
    }
}
