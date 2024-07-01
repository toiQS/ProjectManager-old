using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string StatusInfo { get; set; } = string.Empty;
        public List<Project> Projects { get; set; } = new List<Project> { };
    }
}
