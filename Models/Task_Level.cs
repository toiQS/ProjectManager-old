using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Task_Level
    {
        [Key]
        public int TaskLevelID { get; set; }  // Corrected the primary key name to avoid confusion

        [Required]
        public string TaskName { get; set; } = string.Empty;
        public string TaskInfo { get; set; } = string.Empty;

        [ForeignKey(nameof(TaskParent))]
        public int? TaskParentID { get; set; }
        public virtual Task_Level? TaskParent { get; set; }
            
        public List<Task_Level> SubTasks { get; set; } = new List<Task_Level>();  // Corrected the type and added the primary key
    }
}
