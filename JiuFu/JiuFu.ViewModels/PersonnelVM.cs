using JiuFu.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JiuFu.ViewModels
{
    public class PersonnelVM
    {
        public Guid Id { get; set; }
        //[Display(Name = "显示名称")]
        //[StringLength(100, ErrorMessage = "显示名称超过了100字符。")]
        //[Required(ErrorMessage = "用户名称不能为空值。")]
        public string Name { get; set; }       // 姓氏     
        //[Required(ErrorMessage = "用户名不能为空值。")]
        //[Display(Name = "用户名")]
        //[StringLength(100, ErrorMessage = "你输入的数据超出限制100个字符的长度。")]
        public string UserName { get; set; }       // 姓氏       
        public bool Sex { get; set; }           //性别
        public DateTime Birthday { get; set; } // 生日  

        //[Display(Name = "移动电话")]
        //[RegularExpression(@"((^13[0-9]{1}[0-9]{8}|^15[0-9]{1}[0-9]{8}|^14[0-9]{1}[0-9]{8}|^16[0-9]{1}[0-9]{8}|^17[0-9]{1}[0-9]{8}|^18[0-9]{1}[0-9]{8}|^19[0-9]{1}[0-9]{8})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)", ErrorMessage = "电话号码数据不合规！"),
        //Required(ErrorMessage = "移动电话号码数据是必须的。"),
        //MaxLength(11, ErrorMessage = "电话号码超过11位数！"),
        //MinLength(11, ErrorMessage = "电话号码长度不足11位数！")]
        public string MobileNumber { get; set; }    // 移动电话，父类中的 PhoneNumber 用于固定电话    
     
        //[Display(Name = "登录邮件")]
        //[Required(ErrorMessage = "电子邮件数据是必须的。")]
        //[EmailAddress(ErrorMessage = "请输入合法的电子邮件地址。")]
        public string Email { get; set; }
        public string floor { get; set; }     // 楼层
        //[Display(Name = "密码")]
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "密码是必须的。")]
        //[RegularExpression(@"((^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,})$)", ErrorMessage = "密码至少8个字符，至少1个小写字母，一个大写字母，1个数字和1个特殊字符！")]
        public string Password { get; set; }
        //[Display(Name = "重复密码")]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "密码必须一致")]
        public string PasswordComfirm { get; set; }
        public string ApplicationRoleType { get; set; }  // 角色类型
    }
}
