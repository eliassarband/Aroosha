using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class CustomerDefineModel
    {
        public int CustomerDefineId { get; set; }

        [Required(ErrorMessage = "لطفا کد مشتری وارد کنید")]
        [Display(Name = "کد مشتری")]
        [Range(1, int.MaxValue)]
        public int CustomerDefineCode { get; set; }

        [Required(ErrorMessage = "لطفا نام مشتری وارد کنید")]
        [Display(Name = "نام مشتری")]
        [MaxLength(50)]
        public string CustomerDefineFirstName { get; set; }

        [Required(ErrorMessage = "لطفا نام خانوادگی مشتری وارد کنید")]
        [Display(Name = "نام خانوادگی مشتری")]
        [MaxLength(100)]
        public string CustomerDefineLastName { get; set; }

        [Display(Name ="نام و نام خانوادگی مشتری")]
        public string CustomerDefineFullName { get; set; }

        [Required(ErrorMessage = "لطفا کد ملی مشتری وارد کنید")]
        [Display(Name = "کد ملی مشتری")]
        [MaxLength(10)]
        public string CustomerDefineNationalCode { get; set; }

        //[Required(ErrorMessage = "لطفا شماره شناسنامه مشتری وارد کنید")]
        [Display(Name = "شماره شناسنامه مشتری")]
        public long CustomerDefineIdentityNumber { get; set; }

        [Display(Name = "نام پدر مشتری")]
        [MaxLength(50)]
        public string? CustomerDefineFatherName { get; set; }

        [Required(ErrorMessage = "لطفا شماره موبایل مشتری وارد کنید")]
        [Display(Name = "شماره موبایل مشتری")]
        [MaxLength(11)]
        public string? CustomerDefineMobileNumber { get; set; }

        [Display(Name = "آدرس محل کار مشتری")]
        [MaxLength(1000)]
        public string? CustomerDefineWorkAddress { get; set; }

        [Display(Name = "تلفن محل کار مشتری")]
        [MaxLength(11)]
        public string? CustomerDefineWorkPhone { get; set; }

        [Display(Name = "آدرس منزل مشتری")]
        [MaxLength(1000)]
        public string? CustomerDefineHomeAddress { get; set; }

        [Display(Name = "تلفن منزل مشتری")]
        [MaxLength(11)]
        public string? CustomerDefineHomePhone { get; set; }

        [Display(Name = "جنسیت")]
        public bool CustomerDefineGender { get; set; }


        [Display(Name = "جنسیت")]
        public string CustomerDefineGenderName { get; set; }

        [Display(Name = "سال تولد مشتری")]
        [Range(1250, 1500)]
        public int? CustomerDefineBirthYear { get; set; }

        [Display(Name = "شهر محل تولد مشتری")]
        public int? CustomerDefineBirthCityId { get; set; }

        [Display(Name = "شهر محل تولد مشتری")]
        public string? CustomerDefineBirthCityName { get; set; }

        [Display(Name = "شهر محل صدور مشتری")]
        public int? CustomerDefineIssuanceCityId { get; set; }

        [Display(Name = "شهر محل صدور مشتری")]
        public string? CustomerDefineIssuanceCityName { get; set; }

        [Required(ErrorMessage = "لطفا گروه شغلی را انتخاب نمایید")]
        [Display(Name = "گروه شغلی")]
        public int? CustomerDefineJobGroupId { get; set; }

        [Display(Name = "نام گروه شغلی")]
        public  string? CustomerDefinejobGroupName { get; set; }

        [Required(ErrorMessage = "لطفا شغل را انتخاب نمایید")]
        [Display(Name = "شغل")]
        public int? CustomerDefineJobId { get; set; }

        [Display(Name = "نام شغل")]
        public string? CustomerDefineJobName { get; set; }

        [Display(Name = "مانده اعتبار اولیه")]
        public int? CustomerDefineAccountBalance { get; set; }

        [Display(Name = "مانده اعتبار نرم افزار قبل")]
        public int? CustomerDefineAppAccountBalance { get; set; }

        [Display(Name = "مجموع مبالغ اجاره ها")]
        public int? CustomerDefineTotalRentsAmount { get; set; }

        [Display(Name = "مجموع مبالغ پرداخت شده")]
        public int? CustomerDefineTotalPaymentsAmount { get; set; }

        [Display(Name = "حداقل شارژ کارت عضویت")]
        public int? CustomerDefineDebtCeiling { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1000)]
        public string? CustomerDefineDescription { get; set; }

        public List<CustomerCardModel> CustomerCards { get; set; }

        [Display(Name = "مانده اعتبار")]
        public int CustomerDefineBalance { get; set; }
    }
}
