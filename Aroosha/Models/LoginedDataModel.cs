using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aroosha.Models
{
    public class LoginedDataModel
    {
        public int LoginedDataId { get; set; }

        public int UserId { get; set; }

        public int PersonId { get; set; }

        public string PersonName { get; set; }

        public string Username { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string DeviceName { get; set; }

        public int TenantId { get; set; }

        public int TenantCode { get; set; }

        public string TenantName { get; set; }

        public int HomeTypeId { get; set; }

        public string HomeTypeStrCode { get; set; }

        public bool ForceFirstLoginChange { get; set; }
    }
}
