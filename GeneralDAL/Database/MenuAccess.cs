using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneralDAL.Database
{
    [Table("MenuAccess", Schema = "Sec")]
    public class MenuAccess
    {
        public int Id { get; set; }

        [ForeignKey("MenuId")]
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("GroupId")]
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }





    }
}
