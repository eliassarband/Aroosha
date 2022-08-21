using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("BasicInformation", Schema = "Gnr")]
    public class BasicInformation
    {

        public int Id { get; set; }

        public int Code { get; set; }

        [MaxLength(50)]
        public string StrCode { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual BasicInformationCategory Category { get; set; }

        public int Priority { get; set; }

        [ForeignKey("RelatedBasicInformationId")]
        public int? RelatedBasicInformationId { get; set; }
        public virtual BasicInformation RelatedBasicInformation { get; set; }

        public bool Active { get; set; }

        public bool IsDeleted { get; set; }

        public bool AllowChange { get; set; }

        public bool AllowDelete { get; set; }

        public virtual ICollection<BasicInformation> BasicInformations { get; set; }

        public virtual ICollection<Region> Regions { get; set; }

        public virtual ICollection<MarketStructure> MarketStructures { get; set; }

        public virtual ICollection<Credit> Credits { get; set; }

        public virtual ICollection<UserSetting> UserSettings { get; set; }
    }
}