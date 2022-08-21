using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class MenuActionModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Title { get; set; }
        public bool ShowInToolbar { get; set; }
        public int Priority { get; set; }
        public int MenuItemId { get; set; }

        
    }
}
