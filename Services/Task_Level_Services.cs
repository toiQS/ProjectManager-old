using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class Task_Level_Services
    {
        private readonly ApplicationDbContext _context;

        public Task_Level_Services()
        {
            _context = new ApplicationDbContext();
        }

        // Get all task levels
        public List<Task_Level> GetTask_Level()
        {
            return _context.Task_Level.ToList();
        }

        // Get a task level by ID
        public Task_Level GetTaskLevel(int id)
        {
            try
            {
                var taskLevel = _context.Task_Level.FirstOrDefault(x => x.TaskLevelID == id);
                if (taskLevel == null)
                    throw new Exception("Task Level Not Found");
                return taskLevel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Check if a task level with the same name exists
        public bool CheckTaskLevelNameExist(string name)
        {
            return _context.Task_Level.Any(x => x.TaskName.ToLower() == name.ToLower());
        }

        // Add a new task level
        public bool AddTaskLevel(string name, string info, int? taskParentId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Task level name cannot be null or empty");
            }

            try
            {
                var newTaskLevel = new Task_Level
                {
                    TaskName = name,
                    TaskInfo = info,
                    TaskParentID = taskParentId
                };

                _context.Task_Level.Add(newTaskLevel);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Update an existing task level
        public bool UpdateTaskLevel(int id, string name, string info, int? taskParentId)
        {
            if (string.IsNullOrEmpty(name) || id == 0)
            {
                throw new ArgumentException("Invalid task level details");
            }

            try
            {
                var taskLevel = _context.Task_Level
                    .Include(x => x.SubTasks)
                    .FirstOrDefault(x => x.TaskLevelID == id);
                if (taskLevel != null)
                {
                    taskLevel.TaskName = name;
                    taskLevel.TaskInfo = info;
                    taskLevel.TaskParentID = taskParentId;

                    _context.Task_Level.Update(taskLevel);
                    _context.SaveChanges();
                    return true;
                }
                throw new Exception("Task Level Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Delete a task level
        public bool DeleteTaskLevel(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Invalid task level ID");
            }

            try
            {
                var taskLevel = _context.Task_Level
                    .Include(x => x.SubTasks)
                    .FirstOrDefault(x => x.TaskLevelID == id);
                if (taskLevel != null)
                {
                    _context.Task_Level.Remove(taskLevel);
                    _context.SaveChanges();
                    return true;
                }
                throw new Exception("Task Level Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public int GetTaskIdByText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("Can be null here");
            }
            var data = _context.Task_Level
                .Where(x => x.TaskName.ToLower() == text.ToLower())
                .FirstOrDefault();
            if (data != null)
                return data.TaskLevelID;
            throw new Exception("Not Found");
        }
    }
}
