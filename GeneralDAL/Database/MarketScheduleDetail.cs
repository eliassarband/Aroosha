using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("MarketScheduleDetail", Schema = "Mrk")]
    public class MarketScheduleDetail
    {
        public int Id { get; set; }

        [ForeignKey("MarketScheduleId")]
        public int MarketScheduleId { get; set; }
        public virtual MarketSchedule MarketSchedule{ get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        public int WeekDay { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }

        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
