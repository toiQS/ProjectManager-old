using Azure.Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class User_Services
    {
        private readonly ApplicationDbContext _context;

        public User_Services()
        {
            _context = new ApplicationDbContext();
        }

        // Retrieve all users
        public List<User> GetUsers()
        {
            var data = _context.Users.ToList();
            return data;
        }

        // Retrieve a specific user by ID
        public User GetUser(int id)
        {
            try
            {
                var data = _context.Users.FirstOrDefault(x => x.UserID == id);
                if (data == null)
                    throw new Exception("User not found");
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Check if a username exists
        public bool Check_Username_Exist(string username)
        {
            var check_username_exist = _context.Users
                    .Any(x => x.UserName.ToLower() == username.ToLower());
            return check_username_exist;
        }

        // Add a new user
        public bool AddUser(string username, string email, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Fields cannot be null or empty");
            }
            try
            {
                var data = new User()
                {
                    UserName = username,
                    Email = email,
                    Password = password
                };
                _context.Users.Add(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Update user information
        public bool UpdateUser(int id, string username, string email, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || id == 0)
            {
                throw new Exception("Fields cannot be null or empty");
            }
            try
            {
                var data = _context.Users.FirstOrDefault(x => x.UserID == id);
                if (data != null)
                {
                    data.UserName = username;
                    data.Email = email;
                    data.Password = password;
                    _context.Users.Update(data);
                    _context.SaveChanges();
                    return true;
                }
                throw new Exception("User not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Delete a user by ID
        public bool DeleteUser(int id)
        {
            if (id == 0)
            {
                throw new Exception("ID cannot be zero");
            }
            try
            {
                var data = _context.Users.FirstOrDefault(x => x.UserID == id);
                if (data != null)
                {
                    _context.Users.Remove(data);
                    _context.SaveChanges();
                    return true;
                }
                throw new Exception("User not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
