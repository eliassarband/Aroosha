﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class JobDefineModel
    {
        public int JobDefineId { get; set; }

        [Required(ErrorMessage = "لطفا کد شغل وارد کنید")]
        [Display(Name = "کد شغل")]
        [Range(1, Int32.MaxValue, ErrorMessage = "مقدار کد شغل باید بیشتر از 1 باشد")]
        public int JobDefineCode { get; set; }

        [Required(ErrorMessage = "لطفا نام شغل وارد کنید")]
        [Display(Name = "نام شغل")]
        [MaxLength(100)]
        public string JobDefineName { get; set; }

        [Required(ErrorMessage = "لطفا گروه شغل را انتخاب کنید")]
        [Display(Name = "گروه شغل")]
        public int JobGroupId { get; set; }

        [MaxLength(100)]
        public string JobGroupName { get; set; }
    }
}
