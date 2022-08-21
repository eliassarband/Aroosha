using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class UserSettingModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Display(Name = "نام و نام خانوادگی کاربر")]
        public string UserFullName { get; set; }

        [Required(ErrorMessage = "لطفا نوع صفحه اصلی را انتخاب کنید")]
        [Display(Name = "نوع صفحه اصلی")]
        public int HomeTypeId { get; set; }

        [Display(Name = "نوع صفحه اصلی")]
        public string HomeTypeName { get; set; }
    }
}
