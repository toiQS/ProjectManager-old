using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS._role
{
    public class RoleBUS : IRoleBUS
    {
        private readonly SqlConnection conn;

        public RoleBUS()
        {
            conn = new SqlConnection("Data Source=AKAI\\SQLEXPRESS;Initial Catalog=Project_Manager;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        }

        public List<Role> GetRoles()
        {
            var roles = new List<Role>();
            try
            {
                conn.Open();
                SqlDataAdapter query = new SqlDataAdapter("SELECT * FROM Roles", conn);
                var getData = new DataTable();
                query.Fill(getData);

                foreach (DataRow row in getData.Rows)
                {
                    var role = new Role
                    {
                        RoleID = Convert.ToInt32(row["RoleId"]),
                        RoleName = row["RoleName"].ToString(),
                        RoleInfo = row["RoleInfo"].ToString()
                    };
                    roles.Add(role);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching roles: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return roles;
        }

        public bool AddRole(string rolename, string roleinfo)
        {
            bool success = false;
            try
            {
                conn.Open();

                // Use parameterized query to avoid SQL injection
                SqlCommand cmd = new SqlCommand("INSERT INTO Roles (RoleName, RoleInfo) VALUES (@RoleName, @RoleInfo)", conn);
                cmd.Parameters.AddWithValue("@RoleName", rolename);
                cmd.Parameters.AddWithValue("@RoleInfo", roleinfo);

                int rowsAffected = cmd.ExecuteNonQuery();

                success = rowsAffected > 0;
                Console.WriteLine(success ? "Insert successful." : "Insert failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding role: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return success;
        }

        public bool UpdateRole(int id, string rolename, string roleinfo)
        {
            bool success = false;
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Roles SET RoleName = @RoleName, RoleInfo = @RoleInfo WHERE RoleID = @RoleID", conn);
                cmd.Parameters.AddWithValue("@RoleID", id);
                cmd.Parameters.AddWithValue("@RoleName", rolename);
                cmd.Parameters.AddWithValue("@RoleInfo", roleinfo);

                int rowsAffected = cmd.ExecuteNonQuery();

                success = rowsAffected > 0;
                Console.WriteLine(success ? "Update successful." : "Update failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating role: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return success;
        }

        public bool DeleteRole(int id)
        {
            bool success = false;
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Roles WHERE RoleID = @RoleID", conn);
                cmd.Parameters.AddWithValue("@RoleID", id);

                int rowsAffected = cmd.ExecuteNonQuery();

                success = rowsAffected > 0;
                Console.WriteLine(success ? "Delete successful." : "Delete failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting role: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return success;
        }
    }
}
