using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class GroupUserModel
    {
        public int GroupUserId { get; set; }

        public int GroupUserUserId { get; set; }

        public string GroupUserFullName { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public bool GroupUserSelected { get; set; }
    }
}
