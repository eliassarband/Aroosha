using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeneralDAL.Database
{
    [Table("PrintTemplate", Schema = "Gnr")]
    public class PrintTemplate
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Code { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength]
        public string Content { get; set; }

        

    }
}
