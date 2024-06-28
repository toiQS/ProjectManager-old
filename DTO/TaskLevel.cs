using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaskLevel
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public string Info { get; set; }
        public int? ParentID { get; set; }
    }
}
