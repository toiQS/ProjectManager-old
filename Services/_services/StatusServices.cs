using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services._services
{
    public class StatusServices
    {
        private readonly ApplicationDbContext _context;

        public StatusServices()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Status> GetStatuss()
        {
            var data = _context.Statuss.ToList();
            return data;
        }

        public Status GetStatus(int id)
        {
            var data = _context.Statuss.FirstOrDefault(x => x.StatusID == id);
            return data;
        }

        public int GetByName(string name)
        {
            var data = _context.Statuss.FirstOrDefault(x => x.StatusName.ToLower() == name.ToLower());
            if (data != null)
            {
                return data.StatusID;
            }
            return 0;
        }

        public bool AddStatus(string statusName, string statusInfo)
        {
            var status = new Status()
            {
                StatusName = statusName,
                StatusInfo = statusInfo
            };
            try
            {
                _context.Statuss.Add(status);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message},\n InnerException: {ex.InnerException},\n Source {ex.Source}");
                return false;
            }
        }

        public bool RemoveStatus(int id)
        {
            try
            {
                var data = _context.Statuss.FirstOrDefault(x => x.StatusID == id);
                if (data != null)
                {
                    _context.Statuss.Remove(data);
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

        public bool UpdateStatus(int statusID, string statusName, string statusInfo)
        {
            try
            {
                var data = _context.Statuss.FirstOrDefault(x => x.StatusID == statusID);
                if (data != null)
                {
                    data.StatusName = statusName;
                    data.StatusInfo = statusInfo;
                    _context.Statuss.Update(data);
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
