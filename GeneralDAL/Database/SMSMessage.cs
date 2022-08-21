using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeneralDAL.Database
{
    [Table("SMSMessage", Schema = "Gnr")]
    public class SMSMessage
    {
        public int Id { get; set; }

        [ForeignKey("SMSTemplateId")]
        public int? SMSTemplateId { get; set; }
        public virtual SMSTemplate SMSTemplate{ get; set; }

        [MaxLength(4000)]
        public string SMSMessageText { get; set; }

        [MaxLength(20)]
        public  string ReceiverMobile { get; set; }

        [MaxLength(1)]
        public string Status { get; set; }

        public DateTime RegisterDateTime { get; set; }

        public DateTime FetchDateTime { get; set; }

        public DateTime SendDateTime { get; set; }

        public DateTime DeliveryDateTime { get; set; }

        [MaxLength(20)]
        public string TrackingNumber { get; set; }
    }
}
