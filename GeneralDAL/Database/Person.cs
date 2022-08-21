
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeneralDAL.Database
{
    [Table("Person", Schema = "Gnr")]
    public class Person
    {
        public int Id { get; set; }

        public int Code { get; set; }

        [MaxLength(20)]
        public string StrCode { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<User> PersonUser { get; set; }


        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string RevFullName
        {
            get { return LastName + " " + FirstName; }
        }

    }
}
