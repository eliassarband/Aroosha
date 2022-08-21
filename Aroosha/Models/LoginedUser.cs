using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class LoginedUser
    {
        public int UserID { get; set; }
        public int PersonCode { get; set; }
        public string PersonName { get; set; }
        public string UserRole { get; set; }
        public string LoginMessage { get; set; }
        public bool LoginStatus { get; set; }
        public int LoginedDataId { get; set; }


    }
}
