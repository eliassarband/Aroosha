using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("Shop", Schema = "Mrk")]
    public class Shop
    {
        public int Id { get; set; }

        public int Code { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("TypeId")]
        public int? TypeId { get; set; }
        public virtual BasicInformation Type { get; set; }

        [ForeignKey("ShopGroupId")]
        public int? ShopGroupId { get; set; }
        public virtual ShopGroup ShopGroup{ get; set; }

        [ForeignKey("TenantId")]
        public int TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        [ForeignKey("MarketStructureId")]
        public int? MarketStructureId { get; set; }
        public virtual MarketStructure MarketStructure { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Area
        {
            get { return Length*Width; }
        }

        [MaxLength(20)]
        public string ShopIdentifier { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }

        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
