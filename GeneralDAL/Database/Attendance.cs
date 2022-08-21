using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("Attendance", Schema = "Mrk")]
    public class Attendance
    {
        public int Id { get; set; }

        [ForeignKey("RentId")]
        public int? RentId { get; set; }
        public virtual Rent Rent { get; set; }

        [ForeignKey("ReserveId")]
        public int? ReserveId { get; set; }
        public virtual Reserve Reserve { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        [MaxLength(8)]
        public string Time { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
