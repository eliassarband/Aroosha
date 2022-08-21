using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("MenuActionAccess", Schema = "Sec")]
    public class MenuActionAccess
    {
        public int Id { get; set; }

        [ForeignKey("MenuActionId")]
        public int MenuActionId { get; set; }
        public virtual MenuAction MenuAction { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("GroupId")]
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
