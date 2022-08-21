using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class TariffForComboModel
    {
        public int TariffId { get; set; }

        public string TariffName { get; set; }

        public int TariffPriority { get; set; }

        
    }
}
