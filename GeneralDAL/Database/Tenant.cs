using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("Tenant", Schema = "Gnr")]
    public class Tenant
    {
        public int Id { get; set; }

        public int Code { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("ParentId")]
        public int? ParentId { get; set; }
        public virtual Tenant Parent{ get; set; }

        public virtual ICollection<Tenant> Tenants { get; set; }

        public virtual ICollection<User> Users{ get; set; }

        public virtual ICollection<Shop> Shops{ get; set; }

        public virtual ICollection<MarketStructure> MarketStructures { get; set; }

        public virtual ICollection<MarketSchedule> MarketSchedules { get; set; }
    }
}
