using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services._services
{
    public class TaskLevelServices
    {
        private readonly ApplicationDbContext _context;

        public TaskLevelServices()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Task_Level> GetTaskLevels()
        {
            var data = _context.Task_Level.ToList();
            return data;
        }

        public Task_Level GetTaskLevel(int id)
        {
            var data = _context.Task_Level.FirstOrDefault(x => x.TaskLevelID == id);
            return data;
        }
        public Task_Level GetTaskLevelParent(int? id)
        {
            var data = _context.Task_Level.FirstOrDefault(x => x.TaskLevelID == id);
            return data;
        }

        public int GetByName(string name)
        {
            var data = _context.Task_Level.FirstOrDefault(x => x.TaskName.ToLower() == name.ToLower());
            if (data != null)
            {
                return data.TaskLevelID;
            }
            return 0;
        }

        public bool AddTaskLevel(string taskName, string taskInfo, int? taskParentID)
        {
            var taskLevel = new Task_Level()
            {
                TaskName = taskName,
                TaskInfo = taskInfo,
                TaskParentID = taskParentID
            };
            try
            {
                _context.Task_Level.Add(taskLevel);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message},\n InnerException: {ex.InnerException},\n Source {ex.Source}");
                return false;
            }
        }

        public bool RemoveTaskLevel(int id)
        {
            try
            {
                var data = _context.Task_Level.FirstOrDefault(x => x.TaskLevelID == id);
                if (data != null)
                {
                    _context.Task_Level.Remove(data);
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

        public bool UpdateTaskLevel(int taskLevelID, string taskName, string taskInfo, int? taskParentID)
        {
            try
            {
                var data = _context.Task_Level.FirstOrDefault(x => x.TaskLevelID == taskLevelID);
                if (data != null)
                {
                    data.TaskName = taskName;
                    data.TaskInfo = taskInfo;
                    data.TaskParentID = taskParentID;
                    _context.Task_Level.Update(data);
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
