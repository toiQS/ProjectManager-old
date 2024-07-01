using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class Project_Services
    {
        private readonly ApplicationDbContext _context;

        public Project_Services()
        {
            _context = new ApplicationDbContext();
        }

        // Get all projects
        public List<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }

        // Get a project by ID
        public Project GetProject(int id)
        {
            try
            {
                var project = _context.Projects
                    .FirstOrDefault(x => x.ProjectID == id);
                if (project == null)
                    throw new Exception("Project Not Found");
                return project;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Check if a project with the same name exists
        public bool CheckNameExist(string name)
        {
            return _context.Projects
                .Any(x => x.ProjectName.ToLower() == name.ToLower());
        }

        // Add a new project
        public bool AddProject(string name, string info, string description, DateTime createAt, DateTime startAt, DateTime endAt, int quantityMemberRequired, int statusId, int userId)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(info) || quantityMemberRequired <= 0)
            {
                throw new ArgumentException("Invalid project details");
            }

            try
            {
                var newProject = new Project
                {
                    ProjectName = name,
                    ProjectInfo = info,
                    ProjectDescription = description,
                    CreateAt = createAt,
                    StartAt = startAt,
                    EndAt = endAt,
                    Quantity_Member_Requied = quantityMemberRequired,
                    StatusID = statusId,
                    UserID = userId
                };

                _context.Projects.Add(newProject);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Update an existing project
        public bool UpdateProject(int id, string name, string info, string description, DateTime startAt, DateTime endAt, int quantityMemberRequired, int statusId, int userId)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(info) || id == 0 || quantityMemberRequired <= 0)
            {
                throw new ArgumentException("Invalid project details");
            }

            try
            {
                var project = _context.Projects
                    .FirstOrDefault(x => x.ProjectID == id);

                if (project != null)
                {
                    project.ProjectName = name;
                    project.ProjectInfo = info;
                    project.ProjectDescription = description;
                    project.StartAt = startAt;
                    project.EndAt = endAt;
                    project.Quantity_Member_Requied = quantityMemberRequired;
                    project.StatusID = statusId;
                    project.UserID = userId;

                    _context.Projects.Update(project);
                    _context.SaveChanges();
                    return true;
                }
                throw new Exception("Project Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Delete a project
        public bool DeleteProject(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Invalid project ID");
            }

            try
            {
                var project = _context.Projects
                    .FirstOrDefault(x => x.ProjectID == id);

                if (project != null)
                {
                    _context.Projects.Remove(project);
                    _context.SaveChanges();
                    return true;
                }
                throw new Exception("Project Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
