using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class MenuItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }
        public bool ShowInMenu { get; set; }
        public string DialogSize { get; set; }
        public int Priority { get; set; }

        public int CategoryId { get; set; }
    }
}
