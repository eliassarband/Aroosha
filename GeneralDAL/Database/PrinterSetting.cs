using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeneralDAL.Database
{
    [Table("PrinterSetting", Schema = "Gnr")]
    public class PrinterSetting
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string ComputerName { get; set; }

        [MaxLength(200)]
        public string PrinterName { get; set; }

        

    }
}
