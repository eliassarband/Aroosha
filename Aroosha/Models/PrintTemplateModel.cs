using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class PrintTemplateModel
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
