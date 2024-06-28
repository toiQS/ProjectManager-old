using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace query_test
{
    internal class StatusTest_BUS
    {
    }
    public class StatusBUS
    {
        private readonly string _connectionString;

        public StatusBUS()
        {
            _connectionString = "Data Source=AKAI\\SQLEXPRESS;Initial Catalog=Project_Manager;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        }

        public List<Status> GetStatuses()
        {
            var statuses = new List<Status>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Status", conn);
                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        statuses.Add(new Status
                        {
                            StatusID = reader.GetInt32(reader.GetOrdinal("StatusID")),
                            StatusName = reader.GetString(reader.GetOrdinal("StatusName")),
                            StatusInfo = reader.GetString(reader.GetOrdinal("StatusInfo"))
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching statuses: {ex.Message}");
                }
            }
            return statuses;
        }

        public Status GetStatus(int id)
        {
            Status status = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Status WHERE StatusID = @StatusID", conn);
                cmd.Parameters.AddWithValue("@StatusID", id);

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            status = new Status
                            {
                                StatusID = reader.GetInt32(reader.GetOrdinal("StatusID")),
                                StatusName = reader.GetString(reader.GetOrdinal("StatusName")),
                                StatusInfo = reader.GetString(reader.GetOrdinal("StatusInfo"))
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching status: {ex.Message}");
                }
            }
            return status;
        }

        public bool AddStatus(string statusName, string statusInfo)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO Status (StatusName, StatusInfo) VALUES (@StatusName, @StatusInfo)", conn);
                cmd.Parameters.AddWithValue("@StatusName", statusName);
                cmd.Parameters.AddWithValue("@StatusInfo", statusInfo);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding status: {ex.Message}");
                    return false;
                }
            }
        }

        public bool UpdateStatus(int id, string statusName, string statusInfo)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UPDATE Status SET StatusName = @StatusName, StatusInfo = @StatusInfo WHERE StatusID = @StatusID", conn);
                cmd.Parameters.AddWithValue("@StatusID", id);
                cmd.Parameters.AddWithValue("@StatusName", statusName);
                cmd.Parameters.AddWithValue("@StatusInfo", statusInfo);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating status: {ex.Message}");
                    return false;
                }
            }
        }

        public bool DeleteStatus(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DELETE FROM Status WHERE StatusID = @StatusID", conn);
                cmd.Parameters.AddWithValue("@StatusID", id);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting status: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
