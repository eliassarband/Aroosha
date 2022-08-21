using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("MarketStructure", Schema = "Mrk")]
    public class MarketStructure
    {
        public int Id { get; set; }

        [ForeignKey("TenantId")]
        public int TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        [ForeignKey("TypeId")]
        public int TypeId { get; set; }
        public virtual BasicInformation Type{ get; set; }

        public int Code { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string StructureAddress { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        

        [ForeignKey("ParentId")]
        public int? ParentId { get; set; }
        public virtual MarketStructure Parent { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }

        public virtual ICollection<MarketStructure> MarketStructures { get; set; }
    }
}
