using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectInfo { get; set; } = string.Empty;
        public string ProjectDescription { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public DateTime StartAt {  get; set; }
        public DateTime EndAt { get; set; }
        public int Quantity_Member_Requied { get; set; } 

        [ForeignKey(nameof(Status))]
        public int StatusID {  get; set; }
        public virtual Status Status { get; set; }

        public int UserID { get; set; }
        
        public List<Member_In_Project> Members { get; set; } = new List<Member_In_Project> { };
        public List<Member_In_Task> Tasks { get; set; } = new List<Member_In_Task> { };

    }

    public class ProjectResponse
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectDescription { get; set; } = string.Empty;
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string PersonalCreated { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
