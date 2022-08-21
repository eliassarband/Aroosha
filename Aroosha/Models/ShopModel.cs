using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class ShopModel
    {
        public int ShopId { get; set; }

        [Required(ErrorMessage = "لطفا کد غرفه وارد کنید")]
        [Display(Name = "کد غرفه")]
        [Range(1, Int32.MaxValue, ErrorMessage = "مقدار کد غرفه باید بیشتر از 1 باشد")]
        public int ShopCode { get; set; }

        [Required(ErrorMessage = "لطفا نام غرفه وارد کنید")]
        [Display(Name = "نام غرفه")]
        [MaxLength(100)]
        public string ShopName { get; set; }

        [Required(ErrorMessage = "لطفا نوع غرفه را انتخاب کنید")]
        [Display(Name = "نوع غرفه")]
        public int ShopTypeId { get; set; }

        [Display(Name = "نوع غرفه")]
        public string ShopTypeName { get; set; }

        public string ShopTypeStrCode { get; set; }

        [Required(ErrorMessage = "لطفا گروه غرفه را انتخاب کنید")]
        [Display(Name = "گروه غرفه")]
        public int? ShopGroupId { get; set; }

        [Display(Name = "نام گروه غرفه")]
        public string ShopGroupName { get; set; }

        [Required(ErrorMessage = "لطفا ساختار را انتخاب کنید")]
        [Display(Name = "ساختار")]
        public int ShopMarketStructureId { get; set; }

        [Display(Name = "نام ساختار")]
        public string ShopMarketStructureName { get; set; }

        [Display(Name = "آدرس ساختار")]
        public string ShopMarketStructureAddress { get; set; }

        [Required(ErrorMessage = "لطفا بازار را انتخاب کنید")]
        [Display(Name = "بازار")]
        public int TenantId { get; set; }

        [Display(Name = "نام بازار")]
        public string TenantName { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "مقدار طول غرفه باید بیشتر از 0 باشد")]
        [Display(Name = "طول غرفه")]
        public double ShopLength { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "مقدار عرض غرفه باید بیشتر از 0 باشد")]
        [Display(Name = "عرض غرفه")]
        public double ShopWidth { get; set; }

        [Display(Name = "متراژ غرفه")]
        public double ShopArea { get; set; }

        [Display(Name = "شناسه غرفه")]
        public string ShopIdentifier { get; set; }
    }
}
