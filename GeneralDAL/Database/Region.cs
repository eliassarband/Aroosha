using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("Region", Schema = "Gnr")]
    public class Region
    {
        public int Id { get; set; }

        public int Code { get; set; }

        [ForeignKey("TypeId")]
        public int TypeId { get; set; }
        public virtual BasicInformation Type { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("ParentId")]
        public int? ParentId { get; set; }
        public virtual Region Parent { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}