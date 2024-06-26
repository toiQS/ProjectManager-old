using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace query_test
{
    public class RoleBus_Test
    {
        SqlConnection conn = new SqlConnection("Data Source=AKAI\\SQLEXPRESS;Initial Catalog=Project_Manager;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public RoleBus_Test() { }

        public List<Role> GetRoles()
        {
            var roles = new List<Role>();
            conn.Open();
            try
            {
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
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return roles;
        }

        public void AddRole(string rolename, string roleinfo)
        {
            conn.Open();
            try
            {
                // Get the current maximum RoleID and increment it
                SqlCommand getMaxIdCmd = new SqlCommand("SELECT ISNULL(MAX(RoleID), 0) + 1 FROM Roles", conn);
                int newRoleId = (int)getMaxIdCmd.ExecuteScalar();

                // Use parameterized query to avoid SQL injection
                SqlCommand cmd = new SqlCommand("INSERT INTO Roles ( RoleName, RoleInfo) VALUES ( @RoleName, @RoleInfo)", conn);
                
                cmd.Parameters.AddWithValue("@RoleName", rolename);
                cmd.Parameters.AddWithValue("@RoleInfo", roleinfo);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Insert successful.");
                }
                else
                {
                    Console.WriteLine("Insert failed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateRole(int id, string rolename, string roleinfo)
        {
            
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Roles SET RoleName = @RoleName, RoleInfo = @RoleInfo WHERE RoleID = @RoleID", conn);
                cmd.Parameters.AddWithValue("@RoleID", id);
                cmd.Parameters.AddWithValue("@RoleName", rolename);
                cmd.Parameters.AddWithValue("@RoleInfo", roleinfo);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Update successful.");
                }
                else
                {
                    Console.WriteLine("Update failed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void DeleteRole(int id)
        {
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("delete from roles where RoleID = @RoleID", conn);
                cmd.Parameters.AddWithValue("@RoleID", id);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("detete successful.");
                }
                else
                {
                    Console.WriteLine("delete failed.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
