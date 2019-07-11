using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JiuFu.ViewModels
{
    public class PeersenVM
    {
        public Guid Id { get; set; }       
        public string Name { get; set; }       // 姓氏         
        public string UserName { get; set; }       // 姓氏       
        public bool Sex { get; set; }           //性别
        public DateTime Birthday { get; set; } // 生日 
        public string MobileNumber { get; set; }    // 移动电话，父类中的 PhoneNumber 用于固定电话            
        public string Email { get; set; }
        public string Floor { get; set; }     // 楼层       
        public string ApplicationRoleType { get; set; }  // 角色类型
    }
}
