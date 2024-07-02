using Azure.Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Status_Services
    {
        private readonly ApplicationDbContext _context;
        public Status_Services()
        {
            _context = new ApplicationDbContext();
        }
        public List<Status> GetStatuses()
        {
            var data = _context.Statuss.ToList();
            return data;
        }
        public Status GetStatus(int id)
        {
            try
            {
                var data = _context.Statuss.Where(x => x.StatusID == id).FirstOrDefault();
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
        public bool Check_Name_Exist(string name)
        {
            var check_name_exist = _context.Statuss
                    .Any(x => x.StatusName.ToLower() == name.ToLower());
            return check_name_exist;
        }
        public bool AddStatus(string name, string info)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(info))
            {
                throw new Exception("Can be null here");
            }
            try
            {
                var data = new Role()
                {
                    RoleName = name,
                    RoleInfo = info
                };
                _context.Roles.Add(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdateStatus(int id, string name, string info)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(info) || id == 0)
            {
                throw new Exception("Can be null here");
            }
            try
            {
                var data = _context.Statuss.FirstOrDefault(x => x.StatusID == id);
                if (data != null)
                {
                    data.StatusInfo = info;
                    data.StatusName = name;
                    _context.Statuss.Update(data);
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
        public bool DeleteStaus(int id)
        {
            if (id == 0)
            {
                throw new Exception("Can be null here");
            }
            try
            {
                var data = _context.Statuss.FirstOrDefault(x => x.StatusID == id);
                if (data != null)
                {
                    _context.Statuss.Remove(data);
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
        public int GetIdByText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("Can be null here");
            }
            var data = _context.Statuss.FirstOrDefault(x => x.StatusName.ToLower() == text.ToLower());
            if (data != null)
                return data.StatusID;
            throw new Exception("Not Found");
        }
    }
}
