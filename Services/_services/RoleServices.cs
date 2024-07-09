using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services._services
{
    public class RoleServices
    {
        private readonly ApplicationDbContext _context;
        public RoleServices()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Role> GetRoles()
        {
            var data = _context.Roles.ToList();
            return data;
        }
        public Role GetRole(int id)
        {
            var data = _context.Roles.FirstOrDefault(x => x.RoleID == id);
            return data;
        }
        public int GetByName(string name)
        {
            var data = _context.Roles.FirstOrDefault(x => x.RoleName.ToLower() ==  name.ToLower());
            if (data != null)
            {
                return data.RoleID;
            }
            return 0;
        }
        public bool AddRole(string roleName, string roleinfo)
        {
            var role = new Role()
            {
                RoleName = roleName,
                RoleInfo = roleinfo
            };
            try
            {
                _context.Roles.Add(role);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message},\n InnerException: {ex.InnerException},\n Source {ex.Source}");
                return false;
            }
        }
        public bool RemoveRole(int id)
        {
            try
            {
                var data = _context.Roles.FirstOrDefault(x => x.RoleID == id);
                if (data != null)
                {
                    _context.Roles.Remove(data);
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
        public bool UpdateRole(int  roleID, string rolename, string roleinfo)
        {
            try
            {
                var data = _context.Roles.FirstOrDefault(x => x.RoleID == roleID);
                if (data != null)
                {
                    data.RoleName = rolename;
                    data.RoleInfo = roleinfo;
                    _context.Roles.Update(data);
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
