using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneralDAL.Database
{
    [Table("MenuItem", Schema = "Sec")]
    public class MenuItem
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Code { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string ControllerName { get; set; }

        [MaxLength(50)]
        public string ActionName { get; set; }
        public bool ShowInMenu { get; set; }

        [MaxLength(20)]
        public string DialogSize { get; set; }
        public int Priority { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual MenuCategory Category { get; set; }

        public virtual ICollection<MenuAccess> MenuAccesses { get; set; }

        public virtual ICollection<MenuAction> MenuActions { get; set; }

        public virtual ICollection<UserDefaultForm> UserDefaultForms { get; set; }

    }
}
