using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("Rent", Schema = "Mrk")]
    public class Rent
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        [ForeignKey("CustomerId")]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("MarketScheduleDetailId")]
        public int? MarketScheduleDetailId { get; set; }
        public virtual MarketScheduleDetail MarketScheduleDetail { get; set; }

        [ForeignKey("ShopId")]
        public int? ShopId { get; set; }
        public virtual Shop Shop { get; set; }

        [ForeignKey("TariffId")]
        public int? TariffId { get; set; }
        public virtual Tariff Tariff { get; set; }

        public  int TariffAmount { get; set; }

        [ForeignKey("DiscountId")]
        public int? DiscountId { get; set; }
        public virtual Discount Discount { get; set; }

        public int DiscountAmount { get; set; }

        public int DiscountPercent { get; set; }

        public int Amount { get; set; }

        public bool Paid { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
