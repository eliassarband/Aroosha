using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class DiscountForComboModel
    {
        public int DiscountId { get; set; }

        public int DiscountCode { get; set; }

        public string DiscountName { get; set; }

        public bool DiscountActive { get; set; }

    }
}
