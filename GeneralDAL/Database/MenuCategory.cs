using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneralDAL.Database
{
    [Table("MenuCategory", Schema = "Sec")]
    public class MenuCategory
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public bool ShowInMenu { get; set; }

        public int Priority { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
