using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("Tariff", Schema = "Mrk")]
    public class Tariff
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public int Priority { get; set; }

        [MaxLength(200)]
        public string Formula { get; set; }

        [MaxLength(10)]
        public string StartDate { get; set; }

        [MaxLength(10)]
        public string EndDate { get; set; }

        public int RentAmount { get; set; }

        public int ReserveAmount { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }

        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
