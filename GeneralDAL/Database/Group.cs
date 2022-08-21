using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("Group", Schema = "Sec")]
    public class Group
    {
        public int Id { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }


        public virtual ICollection<GroupUser> GroupUsers { get; set; }

        public virtual ICollection<MenuAccess> MenuAccesses { get; set; }

        public virtual ICollection<MenuActionAccess> MenuActionAccesses{ get; set; }
    }
}
