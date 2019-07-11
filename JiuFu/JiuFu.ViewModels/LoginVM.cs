using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JiuFu.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "用户名是必须的。")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "密码是必须的。")]
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}
