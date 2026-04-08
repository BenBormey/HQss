using System;

namespace unt_bingoo.Class
{
    public class UserItem
    {

        public int Id { get; set; }

        public string Username { get; set; } 
        public string PasswordHash { get; set; }

        public string FullName { get; set; }
        public string FullNameKh { get; set; } 

        public int RoleId { get; set; }
        public string RoleName { get; set; } 
        public string Phone { get; set; }
        public string address { get; set; }
        public string addressKh { get; set; }
        public string Email { get; set; }

        public bool IsActive { get; set; } = true;

        public int outLetId { get; set; }
        public string outLetName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
    }
}
