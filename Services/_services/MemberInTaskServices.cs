using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services._services
{
    public class MemberInTaskServices
    {
        private readonly ApplicationDbContext _context;

        public MemberInTaskServices()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Member_In_Task> GetMembersInTasks()
        {
            var data = _context.Member_In_Tasks.ToList();
            return data;
        }

        public Member_In_Task GetMemberInTask(int memberInTaskId)
        {
            var data = _context.Member_In_Tasks.FirstOrDefault(x => x.Member_In_Task_ID == memberInTaskId);
            return data;
        }

        public IEnumerable<Member_In_Task> GetMembersByTaskId(int taskId)
        {
            var data = _context.Member_In_Tasks.Where(x => x.TaskID == taskId).ToList();
            return data;
        }

        public bool AddMemberToTask(int taskId, int memberId)
        {
            var memberInTask = new Member_In_Task()
            {
                TaskID = taskId,
                MemberID = memberId
            };
            try
            {
                _context.Member_In_Tasks.Add(memberInTask);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message},\n InnerException: {ex.InnerException},\n Source {ex.Source}");
                return false;
            }
        }

        public bool RemoveMemberFromTask(int memberInTaskId)
        {
            try
            {
                var data = _context.Member_In_Tasks.FirstOrDefault(x => x.Member_In_Task_ID == memberInTaskId);
                if (data != null)
                {
                    _context.Member_In_Tasks.Remove(data);
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

        public bool UpdateMemberInTask(int memberInTaskId, int taskId, int memberId)
        {
            try
            {
                var data = _context.Member_In_Tasks.FirstOrDefault(x => x.Member_In_Task_ID == memberInTaskId);
                if (data != null)
                {
                    data.TaskID = taskId;
                    data.MemberID = memberId;
                    _context.Member_In_Tasks.Update(data);
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
