using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS._role
{
    public interface IRoleBUS
    {
        public List<Role> GetRoles();
        public bool AddRole(string rolename, string roleinfo);
        public bool UpdateRole(int id, string rolename, string roleinfo);
        public bool DeleteRole(int id);
    }
}
