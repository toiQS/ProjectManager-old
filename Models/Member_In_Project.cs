using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Member_In_Project
    {
        [Key]
        public int MemberID {  get; set; }
        [ForeignKey(nameof(Project))]
        public int ProjectID {  get; set; }
        public virtual Project Project { get; set; }
        [ForeignKey(nameof(Role))]
        public int RoleID {  get; set; }
        public virtual Role Role { get; set; }
        
        public int UserID { get; set; }
        
    }
    public class MemberResponse
    {
        public int MemberID { get; set; }
       
        public string UserName { get; set; } = string.Empty;
        public string RoleName {  get; set; } = string.Empty;
    }
}
