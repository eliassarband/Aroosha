using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class MarketModel
    { 
        public int MarketId { get; set; }

        public int MarketCode { get; set; }

        public string MarketName { get; set; }

        public string MarketType { get; set; }

        public int? MarketParentId { get; set; }

        public string? MarketParentName { get; set; }

        public List<MarketModel> MarketModels { get; set; }

        public List<MarketStructureModel> MarketStructureModels { get; set; }
    }
    public class MarketStructureModel
    {
        public int MarketStructureId { get; set; }

        [Required(ErrorMessage = "لطفا کد ساختار وارد کنید")]
        [Display(Name = "کد ساختار")]
        [Range(1, 999, ErrorMessage = "مقدار کد ساختار برای نوع ساختار فاز ، زون و تالار 2 کاراکتر و برای نوع ساختار غرفه 3 کاراکتر باشد")]
        public int MarketStructureCode { get; set; }

        [Required(ErrorMessage = "لطفا نام ساختار وارد کنید")]
        [Display(Name = "نام ساختار")]
        [MaxLength(100)]
        public string MarketStructureName { get; set; }

        [Required(ErrorMessage = "لطفا نوع ساختار را انتخاب کنید")]
        [Display(Name = "نوع ساختار")]
        public int MarketStructureTypeId { get; set; }

        public string MarketStructureTypeStrCode { get; set; }

        [Display(Name = "نوع ساختار")]
        public string MarketStructureTypeName { get; set; }

        public int? MarketStructureParentId { get; set; }

        public string? MarketStructureParentName { get; set; }

        [Required(ErrorMessage = "لطفا بازار را انتخاب کنید")]
        [Display(Name = "بازار")]
        public int MarketId { get; set; }

        public string MarketName { get; set; }

        public string MarketStructureAddress { get; set; }

        public string MarketStructureDescription { get; set; }

        public List<MarketStructureModel> MarketStructureModels { get; set; }

    }
}
