using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class JobGroupDefineModel
    {
        public int JobGroupDefineId { get; set; }

        [Required(ErrorMessage = "لطفا کد شغل وارد کنید")]
        [Display(Name = "کد شغل")]
        [Range(1, Int32.MaxValue, ErrorMessage = "مقدار کد گروه شغلی باید بیشتر از 1 باشد")]
        public int JobGroupDefineCode { get; set; }

        [Required(ErrorMessage = "لطفا نام شغل وارد کنید")]
        [Display(Name = "نام شغل")]
        [MaxLength(100)]
        public string JobGroupDefineName { get; set; }

        public int JobGroupDefineJobCount { get; set; }

        public List<JobModel> JobModels { get; set; }
    }
}
