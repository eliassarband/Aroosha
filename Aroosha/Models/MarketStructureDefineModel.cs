using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    
    public class MarketStructureDefineModel
    {
        public int MarketStructureDefineId { get; set; }

        [Required(ErrorMessage = "لطفا کد ساختار وارد کنید")]
        [Display(Name = "کد ساختار")]
        [Range(1, 999, ErrorMessage = "مقدار کد ساختار برای نوع ساختار فاز ، زون و تالار 2 کاراکتر و برای نوع ساختار غرفه 3 کاراکتر باشد")]
        public int MarketStructureDefineCode { get; set; }

        [Required(ErrorMessage = "لطفا نام ساختار وارد کنید")]
        [Display(Name = "نام ساختار")]
        [MaxLength(100)]
        public string MarketStructureDefineName { get; set; }

        [Required(ErrorMessage = "لطفا نوع ساختار را انتخاب کنید")]
        [Display(Name = "نوع ساختار")]
        public int MarketStructureDefineTypeId { get; set; }

        public string MarketStructureDefineTypeStrCode { get; set; }

        [Display(Name = "نوع ساختار")]
        public string MarketStructureDefineTypeName { get; set; }

        public int? MarketStructureDefineParentId { get; set; }

        public string? MarketStructureDefineParentName { get; set; }

        [Required(ErrorMessage = "لطفا بازار را انتخاب کنید")]
        [Display(Name = "بازار")]
        public int MarketId { get; set; }

        public string MarketName { get; set; }

        public string MarketStructureDefineAddress { get; set; }

        public string MarketStructureDefineDescription { get; set; }

        public List<MarketStructureModel> MarketStructureModels { get; set; }

    }
}
