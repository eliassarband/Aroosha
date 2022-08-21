using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("Credit", Schema = "Mrk")]
    public class Credit
    {
        public int Id { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        [ForeignKey("PaymentTypeId")]
        public int PaymentTypeId { get; set; }
        public virtual BasicInformation PaymentType { get; set; }

        public int Amount { get; set; }

        public bool Type { get; set; }

        [MaxLength(20)]
        public string ReceiptNumber { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
