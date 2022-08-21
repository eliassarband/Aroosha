using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("Setting", Schema = "Gnr")]
    public class Setting
    {
        public int Id { get; set; }
        
        [MaxLength(200)]
        public string KeyName { get; set; }

        [MaxLength(2000)]
        public string KeyValue { get; set; }
        
        public bool Active { get; set; }
    }
}
