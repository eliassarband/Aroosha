using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aroosha.Models
{
    public class ChangePasswordModel
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string UserFullName { get; set; }

        [Required(ErrorMessage = "لطفا کلمه عبور جاری را وارد کنید")]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "رمز باید حداقل 8 رقم، و دارای حداقل یک حرف، یک عدد و یک کاراکتر ویژه باشد")]
        [MinLength(8, ErrorMessage = "کلمه عبور حداقل باید هشت کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور جاری")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "لطفا کلمه عبور جدید را وارد کنید")]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "رمز باید حداقل 8 رقم، و دارای حداقل یک حرف، یک عدد و یک کاراکتر ویژه باشد")]
        [MinLength(8, ErrorMessage = "کلمه عبور حداقل باید هشت کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور جدید")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "لطفا تکرار کلمه عبور جدید را وارد کنید")]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "رمز باید حداقل 8 رقم، و دارای حداقل یک حرف، یک عدد و یک کاراکتر ویژه باشد")]
        [MinLength(8, ErrorMessage = "کلمه عبور حداقل باید هشت کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور جدید")]
        public string NewPasswordRepetition { get; set; }

        [MaxLength(200, ErrorMessage = "طول راهنمای کلمه عبور نباید بیشتر از 200 کاراکتر باشد")]
        [Display(Name = "راهنمای کلمه عبور")]
        public string PasswordHint { get; set; }
    }
}
