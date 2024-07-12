using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services._services
{
    public class ProjectServices
    {
        private readonly ApplicationDbContext _context;

        public ProjectServices()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Project> GetProjects()
        {
            var data = _context.Projects.ToList();
            return data;
        }

        public Project GetProject(int id)
        {
            var data = _context.Projects.FirstOrDefault(x => x.ProjectID == id);
            return data;
        }

        public int GetByName(string name)
        {
            var data = _context.Projects.FirstOrDefault(x => x.ProjectName.ToLower() == name.ToLower());
            if (data != null)
            {
                return data.ProjectID;
            }
            return 0;
        }

        public bool AddProject(string projectName, string projectInfo, string projectDescription, DateTime startAt, DateTime endAt, int quantityMemberRequired, int statusID, int userID)
        {
            var project = new Project()
            {
                ProjectName = projectName,
                ProjectInfo = projectInfo,
                ProjectDescription = projectDescription,
                CreateAt = DateTime.Now,
                StartAt = startAt,
                EndAt = endAt,
                Quantity_Member_Requied = quantityMemberRequired,
                StatusID = statusID,
                UserID = userID
            };
            try
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message},\n InnerException: {ex.InnerException},\n Source {ex.Source}");
                return false;
            }
        }

        public bool RemoveProject(int id)
        {
            try
            {
                var data = _context.Projects.FirstOrDefault(x => x.ProjectID == id);
                if (data != null)
                {
                    _context.Projects.Remove(data);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message},\n InnerException: {ex.InnerException},\n Source {ex.Source}");
                return false;
            }
        }

        public bool UpdateProject(int projectID, string projectName, string projectInfo, string projectDescription, DateTime startAt, DateTime endAt, int quantityMemberRequired, int statusID)
        {
            try
            {
                var data = _context.Projects.FirstOrDefault(x => x.ProjectID == projectID);
                if (data != null)
                {
                    data.ProjectName = projectName;
                    data.ProjectInfo = projectInfo;
                    data.ProjectDescription = projectDescription;
                    data.StartAt = startAt;
                    data.EndAt = endAt;
                    data.Quantity_Member_Requied = quantityMemberRequired;
                    data.StatusID = statusID;
                    _context.Projects.Update(data);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message},\n InnerException: {ex.InnerException},\n Source {ex.Source}");
                return false;
            }
        }
    }
}
