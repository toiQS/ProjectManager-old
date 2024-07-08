using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Task_In_Project
    {
        [Key]
        public int TaskID { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string TaskDescription { get; set; } = string.Empty;

       
        public int ProjectID { get; set; }
        

        public DateTime CreateAt { get; set; }
        public DateTime StartAt {  get; set; }
        public DateTime EndAt { get; set; }

        [ForeignKey(nameof(Task_Level))]
        public int TaskLevelID { get; set; }
        public virtual Task_Level TaskLevel { get; set; }
        
        
    }
}
