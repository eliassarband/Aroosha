using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class JobGroupModel
    {
        public int JobGroupId { get; set; }

        [Required(ErrorMessage = "لطفا کد شغل وارد کنید")]
        [Display(Name = "کد شغل")]
        [Range(1, Int32.MaxValue, ErrorMessage = "مقدار کد گروه شغلی باید بیشتر از 1 باشد")]
        public int JobGroupCode { get; set; }

        [Required(ErrorMessage = "لطفا نام شغل وارد کنید")]
        [Display(Name = "نام شغل")]
        [MaxLength(100)]
        public string JobGroupName { get; set; }

        public int JobGroupJobCount { get; set; }

        public List<JobModel> JobModels { get; set; }
    }
}
