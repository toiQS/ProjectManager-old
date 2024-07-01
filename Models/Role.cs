using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Role
    {
        [Key]   
        public int RoleID { get; set; }
        [Required]
        public string RoleName { get; set; } = string.Empty;
        [Required]
        public string RoleInfo { get; set; } = string.Empty;
        public List<User> Users = new List<User> { };
    }
    public class RoleRequest
    {
        [Required]
        public string RoleName { get; set; } = string.Empty;
        [Required]
        public string RoleInfo { get; set; } = string.Empty;
    }
    
}
