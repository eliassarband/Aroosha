using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("Discount", Schema = "Mrk")]
    public class Discount
    {
        public int Id { get; set; }

        public int Code { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0,100)]
        public int DefaultPercent { get; set; }

        public int DefaultPrice { get; set; }

        [MaxLength(10)]
        public string StartDate { get; set; }

        [MaxLength(10)]
        public string EndDate { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }

        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
