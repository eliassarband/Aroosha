﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public int PersonId { get; set; }

        [Required(ErrorMessage = "لطفا کد کاربر وارد کنید")]
        [Display(Name = "کد کاربر")]
        [Range(1, Int32.MaxValue, ErrorMessage = "مقدار کد کاربر باید بیشتر از 1 باشد")]
        public int UserCode { get; set; }

        [Required(ErrorMessage = "لطفا کد کاراکتری کاربر وارد کنید")]
        [MaxLength(20, ErrorMessage = "کد کاراکتری کاربر نباید بیشتر از 20 کاراکتر باشد")]
        [MinLength(1, ErrorMessage = "کد کاراکتری کاربر باید حداقل یک کاراکتر باشد")]
        [Display(Name = "کد کاراکتری کاربر")]
        public string UserStrCode { get; set; }

        [Required(ErrorMessage = "لطفا نام کاربر وارد کنید")]
        [MaxLength(30, ErrorMessage = "نام کاربر نباید بیشتر از 30 کاراکتر باشد")]
        [Display(Name = "نام کاربر")]
        public string UserFirstName { get; set; }

        [Required(ErrorMessage = "لطفا نام خانوادگی کاربر وارد کنید")]
        [MaxLength(30, ErrorMessage = "نام خانوادگی کاربر نباید بیشتر از 30 کاراکتر باشد")]
        [Display(Name = "نام خانوادگی کاربر")]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        [MinLength(5, ErrorMessage = "نام کاربری حداقل باید پنج کاراکتر باشد")]
        [MaxLength(60,ErrorMessage ="طول نام کاربری نباید بیشتر از 60 کاراکتر باشد")]
        [Display(Name = "نام کاربری")]
        public string UserUsername { get; set; }

        //[Required(ErrorMessage = "لطفا کلمه عبور خود را وارد کنید")]
        [MinLength(8, ErrorMessage = "کلمه عبور حداقل باید هشت کاراکتر باشد")]
        [MaxLength(60, ErrorMessage = "طول کلمه عبور نباید بیشتر از 60 کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string UserPassword { get; set; }

        [Display(Name = "وضعیت کاربر")]
        public bool UserActive { get; set; }

        [Display(Name = "اجبار به تغییر کلمه عبور در اولین ورود")]
        public bool UserForceFirstLoginChange { get; set; }


        [MaxLength(200, ErrorMessage = "طول راهنمای کلمه عبور نباید بیشتر از 200 کاراکتر باشد")]
        [Display(Name = "راهنمای کلمه عبور")]
        public string UserPasswordHint { get; set; }

        public string UserFullName { get; set; }

        [Required(ErrorMessage = "لطفا بازار را انتخاب نمایید")]
        public int UserTenantId { get; set; }

        public string UserTenantName { get; set; }
    }
}
