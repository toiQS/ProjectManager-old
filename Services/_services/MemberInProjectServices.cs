using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services._services
{
    public class MemberInProjectServices
    {
        private readonly ApplicationDbContext _context;
        public MemberInProjectServices()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Member_In_Project> GetMembersInProject()
        {
            var data = _context.Member_In_Projects.ToList();
            return data;
        }

        public Member_In_Project GetMemberInProject(int memberId)
        {
            var data = _context.Member_In_Projects.FirstOrDefault(x => x.MemberID == memberId);
            return data;
        }

        public IEnumerable<Member_In_Project> GetMembersByProjectId(int projectId)
        {
            var data = _context.Member_In_Projects.Where(x => x.ProjectID == projectId).ToList();
            return data;
        }

        public bool AddMemberToProject(int projectId, int roleId, int userId)
        {
            var memberInProject = new Member_In_Project()
            {
                ProjectID = projectId,
                RoleID = roleId,
                UserID = userId
            };
            try
            {
                _context.Member_In_Projects.Add(memberInProject);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message},\n InnerException: {ex.InnerException},\n Source {ex.Source}");
                return false;
            }
        }

        public bool RemoveMemberFromProject(int memberId)
        {
            try
            {
                var data = _context.Member_In_Projects.FirstOrDefault(x => x.MemberID == memberId);
                if (data != null)
                {
                    _context.Member_In_Projects.Remove(data);
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

        public bool UpdateMemberInProject(int memberId, int projectId, int roleId, int userId)
        {
            try
            {
                var data = _context.Member_In_Projects.FirstOrDefault(x => x.MemberID == memberId);
                if (data != null)
                {
                    data.ProjectID = projectId;
                    data.RoleID = roleId;
                    data.UserID = userId;
                    _context.Member_In_Projects.Update(data);
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
