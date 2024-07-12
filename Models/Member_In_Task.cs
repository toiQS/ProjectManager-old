using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Member_In_Task
    {
        [Key]
        public int Member_In_Task_ID { get; set; }

        [ForeignKey(nameof(Task_In_Project))]
        public int TaskID {  get; set; }
        public virtual Task_In_Project Task_In_Project { get; set; }

        [ForeignKey(nameof(Member_In_Project))]
        public int MemberID { get; set; }
        public virtual Member_In_Project Member_In_Project { get; set;}
    }
}
