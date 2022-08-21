using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class GroupDefineModel
    {
        public int GroupDefineId { get; set; }

        [Required(ErrorMessage = "لطفا نام گروه را وارد کنید")]
        [MinLength(5, ErrorMessage = "نام گروه حداقل باید پنج کاراکتر باشد")]
        [MaxLength(60, ErrorMessage = "طول نام گروه نباید بیشتر از 60 کاراکتر باشد")]
        [Display(Name = "نام گروه")]
        public string GroupDefineName { get; set; }

        public int GroupDefineUserCount { get; set; }

        public List<GroupUserModel> GroupUserModels { get; set; }
    }
}
