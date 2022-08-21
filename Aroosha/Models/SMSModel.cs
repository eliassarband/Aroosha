using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class SMSModel
    {
        public string SmsText { get; set; }
        public string Receivers { get; set; }
        public string SenderId { get; set; }
        public bool IsUnicode { get; set; } = true;
        public bool IsFlash { get; set; } = false;
        public Guid CheckId { get; set; }
    }
}
