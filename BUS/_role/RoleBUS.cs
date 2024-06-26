using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace BUS._role
{
    public class RoleBUS
    {
        private readonly string _connectionString;

        public RoleBUS()
        {
            _connectionString = "Data Source=AKAI\\SQLEXPRESS;Initial Catalog=Project_Manager;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        }

        public List<Role> GetRoles()
        {
            
            var roles = new List<Role>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Roles", conn);
                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        roles.Add(new Role
                        {
                            RoleID = reader.GetInt32(reader.GetOrdinal("RoleId")),
                            RoleName = reader.GetString(reader.GetOrdinal("RoleName")),
                            RoleInfo = reader.GetString(reader.GetOrdinal("RoleInfo"))
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching roles: {ex.Message}");
                }
            }
            return roles;
        }

        public bool AddRole(string rolename, string roleinfo)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO Roles (RoleName, RoleInfo) VALUES (@RoleName, @RoleInfo)", conn);
                cmd.Parameters.AddWithValue("@RoleName", rolename);
                cmd.Parameters.AddWithValue("@RoleInfo", roleinfo);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding role: {ex.Message}");
                    return false;
                }
            }
        }

        public bool UpdateRole(int id, string rolename, string roleinfo)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UPDATE Roles SET RoleName = @RoleName, RoleInfo = @RoleInfo WHERE RoleID = @RoleID", conn);
                cmd.Parameters.AddWithValue("@RoleID", id);
                cmd.Parameters.AddWithValue("@RoleName", rolename);
                cmd.Parameters.AddWithValue("@RoleInfo", roleinfo);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating role: {ex.Message}");
                    return false;
                }
            }
        }

        public bool DeleteRole(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DELETE FROM Roles WHERE RoleID = @RoleID", conn);
                cmd.Parameters.AddWithValue("@RoleID", id);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting role: {ex.Message}");
                    return false;
                }
            }
        }
        public Role GetRole(int id)
        {
            Role role = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Roles WHERE RoleID = @RoleID", conn);
                cmd.Parameters.AddWithValue("@RoleID", id);

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            role = new Role
                            {
                                RoleID = reader.GetInt32(reader.GetOrdinal("RoleId")),
                                RoleName = reader.GetString(reader.GetOrdinal("RoleName")),
                                RoleInfo = reader.GetString(reader.GetOrdinal("RoleInfo"))
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching role: {ex.Message}");
                }
            }
            return role;
        }

    }
}
