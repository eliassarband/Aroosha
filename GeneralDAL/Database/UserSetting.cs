using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("UserSetting", Schema = "Gnr")]
    public class UserSetting
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("HomeTypeId")]
        public int HomeTypeId { get; set; }
        public virtual BasicInformation HomeType { get; set; }
    }
}
