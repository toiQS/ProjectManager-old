using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services._services
{
    public class UserServices
    {
        private readonly ApplicationDbContext _context;

        public UserServices()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<User> GetUsers()
        {
            var data = _context.Users.ToList();
            return data;
        }

        public User GetUser(int id)
        {
            var data = _context.Users.FirstOrDefault(x => x.UserID == id);
            return data;
        }

        public int GetByEmail(string email)
        {
            var data = _context.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            if (data != null)
            {
                return data.UserID;
            }
            return 0;
        }

        public bool AddUser(string userName, string email, string password)
        {
            var user = new User()
            {
                UserName = userName,
                Email = email,
                Password = password
            };
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message},\n InnerException: {ex.InnerException},\n Source {ex.Source}");
                return false;
            }
        }

        public bool RemoveUser(int id)
        {
            try
            {
                var data = _context.Users.FirstOrDefault(x => x.UserID == id);
                if (data != null)
                {
                    _context.Users.Remove(data);
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

        public bool UpdateUser(int userID, string userName, string email, string password)
        {
            try
            {
                var data = _context.Users.FirstOrDefault(x => x.UserID == userID);
                if (data != null)
                {
                    data.UserName = userName;
                    data.Email = email;
                    data.Password = password;
                    _context.Users.Update(data);
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
