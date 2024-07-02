using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class Member_In_Project_Services
    {
        private readonly ApplicationDbContext _context;

        public Member_In_Project_Services()
        {
            _context = new ApplicationDbContext();
        }

        public List<Member_In_Project> GetMembersInProject(int projectID)
        {
            return _context.Member_In_Projects.Where(x => x.ProjectID == projectID).ToList();
        }

        public Member_In_Project GetMemberInProject(int memberId, int projectId)
        {
            try
            {
                var data = _context.Member_In_Projects
                    .FirstOrDefault(x => x.MemberID == memberId && x.ProjectID == projectId);
                if (data == null)
                    throw new Exception("Not Found");
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool CheckMemberExistInProject(int memberId, int projectId)
        {
            return _context.Member_In_Projects
                .Any(x => x.MemberID == memberId && x.ProjectID == projectId);
        }

        public bool AddMemberToProject(int memberId, int projectId, int roleId)
        {
            try
            {
                if (memberId == 0 || projectId == 0 || roleId == 0)
                    throw new ArgumentException("Invalid parameters");

                var newMemberInProject = new Member_In_Project
                {
                    MemberID = memberId,
                    ProjectID = projectId,
                    RoleID = roleId
                };

                _context.Member_In_Projects.Add(newMemberInProject);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateMemberInProject(int memberId, int projectId, int roleId)
        {
            try
            {
                if (memberId == 0 || projectId == 0 || roleId == 0)
                    throw new ArgumentException("Invalid parameters");

                var memberInProject = _context.Member_In_Projects
                    .FirstOrDefault(x => x.MemberID == memberId && x.ProjectID == projectId);

                if (memberInProject != null)
                {
                    memberInProject.RoleID = roleId;
                    _context.Member_In_Projects.Update(memberInProject);
                    _context.SaveChanges();
                    return true;
                }

                throw new Exception("Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteMemberFromProject(int memberId, int projectId)
        {
            try
            {
                if (memberId == 0 || projectId == 0)
                    throw new ArgumentException("Invalid parameters");

                var memberInProject = _context.Member_In_Projects
                    .FirstOrDefault(x => x.MemberID == memberId && x.ProjectID == projectId);

                if (memberInProject != null)
                {
                    _context.Member_In_Projects.Remove(memberInProject);
                    _context.SaveChanges();
                    return true;
                }

                throw new Exception("Not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
