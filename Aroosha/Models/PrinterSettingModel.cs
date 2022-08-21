using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class PrinterSettingModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string ComputerName { get; set; }

        [MaxLength(200)]
        public string PrinterName { get; set; }
    }
}
