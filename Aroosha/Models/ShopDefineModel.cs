using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class ShopDefineModel
    {
        public int ShopDefineId { get; set; }

        [Required(ErrorMessage = "لطفا کد غرفه وارد کنید")]
        [Display(Name = "کد غرفه")]
        [Range(1, Int32.MaxValue, ErrorMessage = "مقدار کد غرفه باید بیشتر از 1 باشد")]
        public int ShopDefineCode { get; set; }

        [Required(ErrorMessage = "لطفا نام غرفه وارد کنید")]
        [Display(Name = "نام غرفه")]
        [MaxLength(100)]
        public string ShopDefineName { get; set; }

        [Required(ErrorMessage = "لطفا نوع غرفه را انتخاب کنید")]
        [Display(Name = "نوع غرفه")]
        public int ShopDefineTypeId { get; set; }

        [Display(Name = "نوع غرفه")]
        public string ShopDefineTypeName { get; set; }

        public string ShopDefineTypeStrCode { get; set; }

        [Required(ErrorMessage = "لطفا گروه غرفه را انتخاب کنید")]
        [Display(Name = "گروه غرفه")]
        public int? ShopGroupId { get; set; }

        [Display(Name = "نام گروه غرفه")]
        public string ShopGroupName { get; set; }

        [Required(ErrorMessage = "لطفا ساختار را انتخاب کنید")]
        [Display(Name = "ساختار")]
        public int ShopDefineMarketStructureId { get; set; }

        [Display(Name = "نام ساختار")]
        public string ShopDefineMarketStructureName { get; set; }

        [Display(Name = "آدرس ساختار")]
        public string ShopDefineMarketStructureAddress { get; set; }

        [Required(ErrorMessage = "لطفا بازار را انتخاب کنید")]
        [Display(Name = "بازار")]
        public int TenantId { get; set; }

        [Display(Name = "نام بازار")]
        public string TenantName { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "مقدار طول غرفه باید بیشتر از 0 باشد")]
        [Display(Name = "طول غرفه")]
        public double ShopDefineLength { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "مقدار عرض غرفه باید بیشتر از 0 باشد")]
        [Display(Name = "عرض غرفه")]
        public double ShopDefineWidth { get; set; }

        [Display(Name = "متراژ غرفه")]
        public double ShopDefineArea { get; set; }

        [Display(Name = "شناسه غرفه")]
        public string ShopDefineIdentifier { get; set; }
    }
}
