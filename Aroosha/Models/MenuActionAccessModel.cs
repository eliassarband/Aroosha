using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class MenuActionAccessModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        public int MenuItemId { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public bool Selected { get; set; }
    }
}
