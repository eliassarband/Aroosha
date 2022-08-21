using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("Payment", Schema = "Mrk")]
    public class Payment
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        [ForeignKey("RentId")]
        public int? RentId { get; set; }
        public virtual Rent Rent { get; set; }

        [ForeignKey("ReserveId")]
        public int? ReserveId { get; set; }
        public virtual Reserve Reserve { get; set; }

        public int Amount { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
