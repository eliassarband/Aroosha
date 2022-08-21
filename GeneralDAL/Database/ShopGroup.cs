using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("ShopGroup", Schema = "Mrk")]
    public class ShopGroup
    {
        public int Id { get; set; }

        public int Code { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }

       
    }
}
