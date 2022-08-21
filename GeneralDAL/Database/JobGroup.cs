using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("JobGroup", Schema = "Gnr")]
    public class JobGroup
    {
        public int Id { get; set; }

        public int Code { get; set; }


        [MaxLength(100)]
        public string Name { get; set; }


        public virtual ICollection<Job> Jobs { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
