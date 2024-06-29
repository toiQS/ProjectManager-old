using DTO;
using System.Data;
using System.Data.SqlClient;

namespace query_test
{
    public class ProjectBUS_Test
    {
        private readonly string _connectionString;

        public ProjectBUS_Test()
        {
            _connectionString = "Data Source=AKAI\\SQLEXPRESS;Initial Catalog=Project_Manager;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        }

        public List<Projects> GetProjects()
        {
            var projects = new List<Projects>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT ProjectID, ProjectName, StartAt, EndAt, CreateID FROM Projects", conn);
                var adapter = new SqlDataAdapter(cmd);
                var dataTable = new DataTable();
                try
                {
                    conn.Open();
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        var data = new Projects
                        {
                            ProjectID = Convert.ToInt32(row["ProjectID"]),
                            ProjectName = row["ProjectName"].ToString(),
                            StartAt = Convert.ToDateTime(row["StartAt"]),
                            EndAt = Convert.ToDateTime(row["EndAt"]),
                            CreateID = row["CreateID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["CreateID"])
                        };
                        
                        projects.Add(data);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching projects: {ex.Message}");
                }
            }
            return projects;
        }



        public Project GetProject(int id)
        {
            Project project = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Projects WHERE ProjectID = @ProjectID", conn);
                cmd.Parameters.AddWithValue("@ProjectID", id);

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            project = new Project
                            {
                                ProjectID = reader.GetInt32(reader.GetOrdinal("ProjectID")),
                                ProjectName = reader.GetString(reader.GetOrdinal("ProjectName")),
                                StartAt = reader.GetDateTime(reader.GetOrdinal("StartAt")),
                                EndAt = reader.GetDateTime(reader.GetOrdinal("EndAt")),
                                Member = reader.GetInt32(reader.GetOrdinal("Member")),
                                CreateAt = reader.GetDateTime(reader.GetOrdinal("CreateAt")),
                                CreateID = reader.IsDBNull(reader.GetOrdinal("CreateID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CreateID")),
                                ProjectInfo = reader.IsDBNull(reader.GetOrdinal("ProjectInfo")) ? null : reader.GetString(reader.GetOrdinal("ProjectInfo")),
                                StatusID = reader.GetInt32(reader.GetOrdinal("StatusID")),
                                ProjectDescription = reader.IsDBNull(reader.GetOrdinal("ProjectDescription")) ? null : reader.GetString(reader.GetOrdinal("ProjectDescription")),
                                Progress = reader.GetFloat(reader.GetOrdinal("Progress"))
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching project: {ex.Message}");
                }
            }
            return project;
        }

        public bool AddProject(string projectName, DateTime startAt, DateTime endAt, int member, DateTime createAt, int createID, string projectInfo, int statusID, string projectDescription, float progress)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO Projects (ProjectName, StartAt, EndAt, Member, CreateAt, CreateID, ProjectInfo, StatusID, ProjectDescription, Progress) VALUES (@ProjectName, @StartAt, @EndAt, @Member, @CreateAt, @CreateID, @ProjectInfo, @StatusID, @ProjectDescription, @Progress)", conn);
                cmd.Parameters.AddWithValue("@ProjectName", projectName);
                cmd.Parameters.AddWithValue("@StartAt", startAt);
                cmd.Parameters.AddWithValue("@EndAt", endAt);
                cmd.Parameters.AddWithValue("@Member", member);
                cmd.Parameters.AddWithValue("@CreateAt", createAt);
                cmd.Parameters.AddWithValue("@CreateID", createID);
                cmd.Parameters.AddWithValue("@ProjectInfo", (object)projectInfo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StatusID", statusID);
                cmd.Parameters.AddWithValue("@ProjectDescription", (object)projectDescription ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Progress", progress);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding project: {ex.Message}");
                    return false;
                }
            }
        }

        public bool UpdateProject(int projectID, string projectName, DateTime startAt, DateTime endAt, int member, DateTime createAt, int createID, string projectInfo, int statusID, string projectDescription, float progress)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UPDATE Projects SET ProjectName = @ProjectName, StartAt = @StartAt, EndAt = @EndAt, Member = @Member, CreateAt = @CreateAt, CreateID = @CreateID, ProjectInfo = @ProjectInfo, StatusID = @StatusID, ProjectDescription = @ProjectDescription, Progress = @Progress WHERE ProjectID = @ProjectID", conn);
                cmd.Parameters.AddWithValue("@ProjectID", projectID);
                cmd.Parameters.AddWithValue("@ProjectName", projectName);
                cmd.Parameters.AddWithValue("@StartAt", startAt);
                cmd.Parameters.AddWithValue("@EndAt", endAt);
                cmd.Parameters.AddWithValue("@Member", member);
                cmd.Parameters.AddWithValue("@CreateAt", createAt);
                cmd.Parameters.AddWithValue("@CreateID", createID);
                cmd.Parameters.AddWithValue("@ProjectInfo", (object)projectInfo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StatusID", statusID);
                cmd.Parameters.AddWithValue("@ProjectDescription", (object)projectDescription ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Progress", progress);

                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating project: {ex.Message}");
                    return false;
                }
            }
        }

        public bool DeleteProject(int projectID)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DELETE FROM Projects WHERE ProjectID = @ProjectID", conn);
                cmd.Parameters.AddWithValue("@ProjectID", projectID);
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting project: {ex.Message}");
                    return false;
                }
            }
        }

    }
}
