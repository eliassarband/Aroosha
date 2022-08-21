using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aroosha.Models
{
    public class LoginInformation
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        [MinLength(5, ErrorMessage = "نام کاربری حداقل باید پنج کاراکتر باشد")]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "لطفا کلمه عبور خود را وارد کنید")]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "رمز باید حداقل 8 رقم، و دارای حداقل یک حرف، یک عدد و یک کاراکتر ویژه باشد")]
        [MinLength(8, ErrorMessage = "کلمه عبور حداقل باید هشت کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

    }
}
