using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class UserBUS
    {
        private readonly string _connectionString;

        public UserBUS()
        {
            _connectionString = "Data Source=AKAI\\SQLEXPRESS;Initial Catalog=Project_Manager;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Users", conn);
                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            UserName = reader.GetString(reader.GetOrdinal("UserName")),
                            Password = reader.GetString(reader.GetOrdinal("PassWord"))
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching users: {ex.Message}");
                }
            }
            return users;
        }

        public bool AddUser(string username, string password)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO Users (UserName, PassWord) VALUES (@UserName, @PassWord)", conn);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@PassWord", password);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding user: {ex.Message}");
                    return false;
                }
            }
        }

        public bool UpdateUser(int id, string username, string password)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UPDATE Users SET UserName = @UserName, PassWord = @PassWord WHERE UserID = @UserID", conn);
                cmd.Parameters.AddWithValue("@UserID", id);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@PassWord", password);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating user: {ex.Message}");
                    return false;
                }
            }
        }

        public bool DeleteUser(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DELETE FROM Users WHERE UserID = @UserID", conn);
                cmd.Parameters.AddWithValue("@UserID", id);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting user: {ex.Message}");
                    return false;
                }
            }
        }

        public User GetUser(int id)
        {
            User user = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserID", conn);
                cmd.Parameters.AddWithValue("@UserID", id);

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                Password = reader.GetString(reader.GetOrdinal("PassWord"))
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching user: {ex.Message}");
                }
            }
            return user;
        }
    }
}
