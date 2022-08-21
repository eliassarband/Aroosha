using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("Job", Schema = "Gnr")]
    public class Job
    {
        public int Id { get; set; }

        public int Code { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }


        [ForeignKey("JobGroupId")]
        public int JobGroupId { get; set; }
        public virtual JobGroup JobGroup { get; set; }
    }
}
