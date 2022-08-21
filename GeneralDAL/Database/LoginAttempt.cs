using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralDAL.Database
{
    [Table("LoginAttempt", Schema = "Sec")]
    public class LoginAttempt
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        [MaxLength(60)]
        public string Username { get; set; }

        public bool Logined { get; set; }

        [MaxLength(200)]
        public string LoginResult { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        [MaxLength(8)]
        public string Time { get; set; }

        [MaxLength(100)]
        public string DeviceName { get; set; }

        [MaxLength(20)]
        public string ClientIPAddr { get; set; }
    }
}
