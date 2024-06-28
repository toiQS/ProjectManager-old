using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace query_test
{
    public class TaskLevelBUS_Test
    {
        private readonly string _connectionString;

        public TaskLevelBUS_Test()
        {
            _connectionString = "Data Source=AKAI\\SQLEXPRESS;Initial Catalog=Project_Manager;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        }

        public List<TaskLevel> GetTaskLevels()
        {
            var taskLevels = new List<TaskLevel>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Task_Levels", conn);
                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        taskLevels.Add(new TaskLevel
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            TaskName = reader.GetString(reader.GetOrdinal("TaskName")),
                            Info = reader.IsDBNull(reader.GetOrdinal("Info")) ? null : reader.GetString(reader.GetOrdinal("Info")),
                            ParentID = reader.IsDBNull(reader.GetOrdinal("ParentID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ParentID"))
                        });
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching task levels: {ex.Message}");
                }
            }
            return taskLevels;
        }

        public TaskLevel GetTaskLevel(int id)
        {
            TaskLevel taskLevel = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Task_Levels WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            taskLevel = new TaskLevel
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                TaskName = reader.GetString(reader.GetOrdinal("TaskName")),
                                Info = reader.IsDBNull(reader.GetOrdinal("Info")) ? null : reader.GetString(reader.GetOrdinal("Info")),
                                ParentID = reader.IsDBNull(reader.GetOrdinal("ParentID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ParentID"))
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching task level: {ex.Message}");
                }
            }
            return taskLevel;
        }

        public bool AddTaskLevel(string taskName, string info, int? parentID)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO Task_Levels (TaskName, Info, ParentID) VALUES (@TaskName, @Info, @ParentID)", conn);
                cmd.Parameters.AddWithValue("@TaskName", taskName);
                cmd.Parameters.AddWithValue("@Info", (object)info ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ParentID", (object)parentID ?? DBNull.Value);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding task level: {ex.Message}");
                    return false;
                }
            }
        }

        public bool UpdateTaskLevel(int id, string taskName, string info, int? parentID)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UPDATE Task_Levels SET TaskName = @TaskName, Info = @Info, ParentID = @ParentID WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@TaskName", taskName);
                cmd.Parameters.AddWithValue("@Info", (object)info ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ParentID", (object)parentID ?? DBNull.Value);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating task level: {ex.Message}");
                    return false;
                }
            }
        }

        public bool DeleteTaskLevel(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DELETE FROM Task_Levels WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting task level: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
