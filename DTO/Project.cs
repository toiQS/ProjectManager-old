namespace DTO
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int Member { get; set; }
        public DateTime CreateAt { get; set; }
        public int CreateID { get; set; }
        public string ProjectInfo { get; set; }
        public int StatusID { get; set; }
        public string ProjectDescription { get; set; }
        public float Progress { get; set; }
    }
    public class Projects
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int CreateID { get; set; }
    }
    public class PushListOnView
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; } = string.Empty; 
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string PersionalCreate { get; set; } = string.Empty;
    }
}
