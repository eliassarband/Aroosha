using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GeneralDAL.Database
{
    [Table("UserDefaultForm", Schema = "Gnr")]
    public class UserDefaultForm
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("FormId")]
        public int FormId { get; set; }
        public virtual MenuItem Form { get; set; }
    }
}
