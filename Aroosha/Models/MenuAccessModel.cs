using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class MenuAccessModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }
        public int GroupId { get; set; }

        public bool Selected { get; set; }

        public List<MenuActionAccessModel> MenuActionAccessModels { get; set; }
    }
}
