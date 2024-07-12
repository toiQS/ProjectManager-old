using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services._services
{
    public class TaskInProjectServices
    {
        private readonly ApplicationDbContext _context;

        public TaskInProjectServices()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Task_In_Project> GetTasks()
        {
            var data = _context.Task_In_Projects.ToList();
            return data;
        }public IEnumerable<Task_In_Project> GetTasksInProject(int projectId)
        {
            var data = _context.Task_In_Projects
                .Where(x => x.ProjectID == projectId)
                .ToList();
            return data;
        }

        public Task_In_Project GetTask(int id)
        {
            var data = _context.Task_In_Projects.FirstOrDefault(x => x.TaskID == id);
            return data;
        }

        public int GetByName(string name)
        {
            var data = _context.Task_In_Projects.FirstOrDefault(x => x.TaskName.ToLower() == name.ToLower());
            if (data != null)
            {
                return data.TaskID;
            }
            return 0;
        }

        public bool AddTask(string taskName, string taskDescription, int projectID, DateTime startAt, DateTime endAt, int taskLevelID)
        {
            var task = new Task_In_Project()
            {
                TaskName = taskName,
                TaskDescription = taskDescription,
                ProjectID = projectID,
                CreateAt = DateTime.Now,
                StartAt = startAt,
                EndAt = endAt,
                TaskLevelID = taskLevelID
            };
            try
            {
                _context.Task_In_Projects.Add(task);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message},\n InnerException: {ex.InnerException},\n Source {ex.Source}");
                return false;
            }
        }

        public bool RemoveTask(int id)
        {
            try
            {
                var data = _context.Task_In_Projects.FirstOrDefault(x => x.TaskID == id);
                if (data != null)
                {
                    _context.Task_In_Projects.Remove(data);
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

        public bool UpdateTask(int taskID, string taskName, string taskDescription, int projectID, DateTime startAt, DateTime endAt, int taskLevelID)
        {
            try
            {
                var data = _context.Task_In_Projects.FirstOrDefault(x => x.TaskID == taskID);
                if (data != null)
                {
                    data.TaskName = taskName;
                    data.TaskDescription = taskDescription;
                    data.ProjectID = projectID;
                    data.CreateAt = DateTime.Now;
                    data.StartAt = startAt;
                    data.EndAt = endAt;
                    data.TaskLevelID = taskLevelID;
                    _context.Task_In_Projects.Update(data);
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
