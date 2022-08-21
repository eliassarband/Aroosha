using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class TenantModel
    {

        public int Id { get; set; }

      public int Code { get; set; }

        public string Name { get; set; }

        public int?ParentId { get; set; }

        
    }
}
