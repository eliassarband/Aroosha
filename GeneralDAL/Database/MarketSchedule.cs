using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("MarketSchedule", Schema = "Mrk")]
    public class MarketSchedule
    {
        public int Id { get; set; }

        [ForeignKey("MarketId")]
        public int MarketId { get; set; }
        public virtual Tenant Market { get; set; }

        [MaxLength(10)]
        public string StartDate { get; set; }

        [MaxLength(10)]
        public string EndDate { get; set; }

        public int WeekDay { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<MarketScheduleDetail> MarketScheduleDetails { get; set; }
    }
}
