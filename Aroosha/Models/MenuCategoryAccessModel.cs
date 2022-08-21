using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{

    public class SaveMenuAccessModel
    { 
        public string Mode { get; set; }

        public int UserId { get; set; }

        public int GroupId { get; set; }

        public List<MenuCategoryAccessModel> MenuCategoryAccessModels { get; set; }
    }
    public class MenuCategoryAccessModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }

        public int UserId { get; set; }
        public int GroupId { get; set; }

        public bool Selected { get; set; }

        public List<MenuAccessModel> MenuAccessModels { get; set; }
    }
}
