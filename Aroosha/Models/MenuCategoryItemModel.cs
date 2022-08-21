using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class MenuCategoryItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool ShowInMenu { get; set; }

        public int Priority { get; set; }

        public List<MenuItemModel> MenuItems { get; set; }
    }
}
