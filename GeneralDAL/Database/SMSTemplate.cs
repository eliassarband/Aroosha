using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeneralDAL.Database
{
    [Table("SMSTemplate", Schema = "Gnr")]
    public class SMSTemplate
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public  string Name { get; set; }

        [MaxLength(4000)]
        public string Query { get; set; }

        [MaxLength(4000)]
        public string TemplateText { get; set; }

        public virtual ICollection<SMSMessage> SMSMessages { get; set; }
    }
}
