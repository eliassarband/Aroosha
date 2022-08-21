using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("MenuAction", Schema = "Sec")]
    public class MenuAction
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public bool ShowInToolbar { get; set; }
        public int Priority { get; set; }

        [ForeignKey("MenuItemId")]
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem{ get; set; }

        public virtual ICollection<MenuActionAccess> MenuActionAccesses { get; set; }

    }
}
