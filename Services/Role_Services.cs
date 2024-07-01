using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Role_Services
    {
        private readonly ApplicationDbContext _context;

        public Role_Services()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Role> GetRoles()
        {
            var data =  _context.Roles.ToList();
            return data;
        }
        public  Role GetRole(int id)
        {
            try
            {
                var data =  _context.Roles.Where(x => x.RoleID == id).FirstOrDefault();
                if (data != null)
                {
                    return data;
                }
                throw new Exception("Not Found");
            }
            catch( Exception ex)
            {
                throw new Exception(ex.GetBaseException().Message);
            }
        }
        public bool AddRole(RoleRequest role)
        {
            if (role == null)
            {
                throw new Exception("Can be null here");
            }
            try
            {
                
                var data = new Role()
                {
                    RoleInfo = role.RoleInfo,
                    RoleName = role.RoleName
                };
                _context.Roles.Add(data);
                _context.SaveChanges();
                return true;
            }
            catch( Exception ex )
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdateRole(int id, RoleRequest role)
        {
            if (role == null || id == 0)
            {
                throw new Exception("Can be null here");
            }
            try
            {
                var data = _context.Roles.Where(x => x.RoleID == id).FirstOrDefault();
                if (data != null)
                {
                    data.RoleName = role.RoleName;
                    data.RoleInfo = role.RoleInfo;
                    _context.Roles.Update(data);
                    _context.SaveChanges();
                    return true;
                }
                throw new Exception("Not Found");
                
            }
            catch( Exception ex )
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteRole(int id)
        {
            if ( id == 0)
            {
                throw new Exception("Can be null here");
            }
            try
            {
                var data = _context.Roles.Where(x => x.RoleID == id).FirstOrDefault();
                if (data != null)
                {
                    _context.Roles.Remove(data);
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
        public bool Check_Name_Exist(string name)
        {
            var check_name_exist = _context.Roles
                    .Any(x => x.RoleName.ToLower() == name.ToLower());
            return check_name_exist;
        }
    }
}
