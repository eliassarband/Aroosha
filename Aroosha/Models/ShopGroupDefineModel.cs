using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class ShopGroupDefineModel
    {
        public int ShopGroupDefineId { get; set; }
        
        [Required(ErrorMessage = "لطفا کد گروه را وارد کنید")]
        [Range(1, Int32.MaxValue, ErrorMessage = "مقدار کد گروه باید بیشتر از 1 باشد")]
        [Display(Name = "کد گروه")]
        public int ShopGroupDefineCode { get; set; }

        [Required(ErrorMessage = "لطفا نام گروه را وارد کنید")]
        [MinLength(5, ErrorMessage = "نام گروه حداقل باید پنج کاراکتر باشد")]
        [MaxLength(100, ErrorMessage = "طول نام گروه نباید بیشتر از 100 کاراکتر باشد")]
        [Display(Name = "نام گروه")]
        public string ShopGroupDefineName { get; set; }

        [MaxLength(1000, ErrorMessage = "طول توضیحات نباید بیشتر از 1000 کاراکتر باشد")]
        [Display(Name = "توضیحات")]
        public string ShopGroupDefineDescription { get; set; }

        public int ShopGroupDefineShopCount { get; set; }

        
    }
}
