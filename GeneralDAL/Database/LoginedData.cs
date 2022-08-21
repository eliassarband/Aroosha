using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("LoginedData", Schema = "Sec")]
    public class LoginedData
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        
        [MaxLength(10)]
        public string Date { get; set; }

        [MaxLength(8)]
        public string Time { get; set; }

        [MaxLength(100)]
        public string DeviceName { get; set; }

        [MaxLength(20)]
        public string ClientIPAddr { get; set; }

        [MaxLength(10)]
        public string LogoutDate { get; set; }

        [MaxLength(8)]
        public string LogoutTime { get; set; }
    }
}
