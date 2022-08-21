using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "لطفا کد مشتری وارد کنید")]
        [Display(Name = "کد مشتری")]
        [Range(1, int.MaxValue)]
        public int CustomerCode { get; set; }

        [Required(ErrorMessage = "لطفا نام مشتری وارد کنید")]
        [Display(Name = "نام مشتری")]
        [MaxLength(50)]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "لطفا نام خانوادگی مشتری وارد کنید")]
        [Display(Name = "نام خانوادگی مشتری")]
        [MaxLength(100)]
        public string CustomerLastName { get; set; }

        [Display(Name ="نام و نام خانوادگی مشتری")]
        public string CustomerFullName { get; set; }

        [Required(ErrorMessage = "لطفا کد ملی مشتری وارد کنید")]
        [Display(Name = "کد ملی مشتری")]
        [MaxLength(10)]
        public string CustomerNationalCode { get; set; }

        [Required(ErrorMessage = "لطفا شماره شناسنامه مشتری وارد کنید")]
        [Display(Name = "شماره شناسنامه مشتری")]
        public long CustomerIdentityNumber { get; set; }

        [Display(Name = "نام پدر مشتری")]
        [MaxLength(50)]
        public string? CustomerFatherName { get; set; }

        [Required(ErrorMessage = "لطفا شماره موبایل مشتری وارد کنید")]
        [Display(Name = "شماره موبایل مشتری")]
        [MaxLength(11)]
        public string? CustomerMobileNumber { get; set; }

        [Display(Name = "آدرس محل کار مشتری")]
        [MaxLength(1000)]
        public string? CustomerWorkAddress { get; set; }

        [Display(Name = "تلفن محل کار مشتری")]
        [MaxLength(11)]
        public string? CustomerWorkPhone { get; set; }

        [Display(Name = "آدرس منزل مشتری")]
        [MaxLength(1000)]
        public string? CustomerHomeAddress { get; set; }

        [Display(Name = "تلفن منزل مشتری")]
        [MaxLength(11)]
        public string? CustomerHomePhone { get; set; }

        [Display(Name = "جنسیت")]
        public bool CustomerGender { get; set; }


        [Display(Name = "جنسیت")]
        public string CustomerGenderName { get; set; }

        [Display(Name = "سال تولد مشتری")]
        [Range(1250, 1500)]
        public int? CustomerBirthYear { get; set; }

        [Display(Name = "شهر محل تولد مشتری")]
        public int? CustomerBirthCityId { get; set; }

        [Display(Name = "شهر محل تولد مشتری")]
        public string? CustomerBirthCityName { get; set; }

        [Display(Name = "شهر محل صدور مشتری")]
        public int? CustomerIssuanceCityId { get; set; }

        [Display(Name = "شهر محل صدور مشتری")]
        public string? CustomerIssuanceCityName { get; set; }

        [Required(ErrorMessage = "لطفا گروه شغلی را انتخاب نمایید")]
        [Display(Name = "گروه شغلی")]
        public int? CustomerJobGroupId { get; set; }

        [Display(Name = "نام گروه شغلی")]
        public  string? CustomerjobGroupName { get; set; }

        [Required(ErrorMessage = "لطفا شغل را انتخاب نمایید")]
        [Display(Name = "شغل")]
        public int? CustomerJobId { get; set; }

        [Display(Name = "نام شغل")]
        public string? CustomerJobName { get; set; }

        [Display(Name = "مانده اعتبار اولیه")]
        public int? CustomerAccountBalance { get; set; }

        [Display(Name = "مانده اعتبار نرم افزار قبل")]
        public int? CustomerAppAccountBalance { get; set; }

        [Display(Name = "مجموع مبالغ اجاره ها")]
        public int? CustomerTotalRentsAmount { get; set; }

        [Display(Name = "مجموع مبالغ پرداخت شده")]
        public int? CustomerTotalPaymentsAmount { get; set; }

        [Display(Name = "حداقل شارژ کارت عضویت")]
        public int? CustomerDebtCeiling { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1000)]
        public string? CustomerDescription { get; set; }

        public List<CustomerCardModel> CustomerCards { get; set; }

        [Display(Name = "مانده اعتبار")]
        public int CustomerBalance { get; set; }
    }
}
