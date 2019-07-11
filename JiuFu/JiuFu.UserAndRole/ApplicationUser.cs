using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace JiuFu.UserAndRole
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [StringLength(100)]
        public string Name { get; set; }       // 姓氏
        [StringLength(100)]
        public bool Sex { get; set; }           //性别
        public DateTime Birthday { get; set; } // 生日
        [StringLength(50)]
        public string MobileNumber { get; set; }    // 移动电话，父类中的 PhoneNumber 用于固定电话     
        public string AvatarPath { get; set; }      // 人员头像路径
        public string floor { get; set; }     // 楼层       

        public ApplicationUser() : base()
        {
            this.Id = Guid.NewGuid();
        }
        public ApplicationUser(string userName) : base(userName)
        {
            this.Id = Guid.NewGuid();
            this.UserName = userName;
        }
    }
}
