using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class Task_In_Project_Services
    {
        private readonly ApplicationDbContext _context;

        public Task_In_Project_Services()
        {
            _context = new ApplicationDbContext();
        }

        // Get all tasks
        public List<Task_In_Project> GetTasks()
        {
            return _context.Task_In_Projects.ToList();
        }

        // Get a task by ID
        public Task_In_Project GetTask(int id)
        {
            try
            {
                var task = _context.Task_In_Projects.FirstOrDefault(x => x.TaskID == id);
                if (task == null)
                    throw new Exception("Task Not Found");
                return task;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Check if a task with the same name exists within a project
        public bool CheckTaskNameExist(int projectId, string name)
        {
            return _context.Task_In_Projects
                .Any(x => x.ProjectID == projectId && x.TaskName.ToLower() == name.ToLower());
        }

        // Add a new task to a project
        public bool AddTask(string name, string description, DateTime createAt, DateTime startAt, DateTime endAt, int taskLevelId, int projectId)
        {
            if (string.IsNullOrEmpty(name) || projectId == 0 || taskLevelId == 0)
            {
                throw new ArgumentException("Invalid task details");
            }

            try
            {
                var newTask = new Task_In_Project
                {
                    TaskName = name,
                    TaskDescription = description,
                    CreateAt = createAt,
                    StartAt = startAt,
                    EndAt = endAt,
                    TaskLevelID = taskLevelId,
                    ProjectID = projectId
                };

                _context.Task_In_Projects.Add(newTask);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Update an existing task
        public bool UpdateTask(int id, string name, string description, DateTime startAt, DateTime endAt, int taskLevelId)
        {
            if (string.IsNullOrEmpty(name) || id == 0 || taskLevelId == 0)
            {
                throw new ArgumentException("Invalid task details");
            }

            try
            {
                var task = _context.Task_In_Projects.FirstOrDefault(x => x.TaskID == id);
                if (task != null)
                {
                    task.TaskName = name;
                    task.TaskDescription = description;
                    task.StartAt = startAt;
                    task.EndAt = endAt;
                    task.TaskLevelID = taskLevelId;

                    _context.Task_In_Projects.Update(task);
                    _context.SaveChanges();
                    return true;
                }
                throw new Exception("Task Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Delete a task
        public bool DeleteTask(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Invalid task ID");
            }

            try
            {
                var task = _context.Task_In_Projects.FirstOrDefault(x => x.TaskID == id);
                if (task != null)
                {
                    _context.Task_In_Projects.Remove(task);
                    _context.SaveChanges();
                    return true;
                }
                throw new Exception("Task Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
