//// See https://aka.ms/new-console-template for more information
//using query_test;
//using DTO;
//using System.Diagnostics;

//Console.WriteLine("Hello, World!");

//TaskLevelBUS_Test _Test = new TaskLevelBUS_Test();

//var get = _Test.GetTaskLevels();
//foreach (var item in get)
//{
//    Console.WriteLine(item);
//}
//string taskname = Console.ReadLine();
//string taskinfo = Console.ReadLine();
//int parent = Convert.ToInt32(Console.ReadLine());

//_Test.AddTaskLevel(taskname, taskinfo, null);

using DTO;
using query_test;

var projectBUS = new ProjectBUS_Test();

// Lấy danh sách các dự án từ database
List<Projects> projects = projectBUS.GetProjects();

// Hiển thị thông tin các dự án
if(projects.Count == 0)
{
    Console.WriteLine("không lấy được");
}
Console.WriteLine("Danh sách các dự án:");
foreach (var project in projects)
{
    Console.WriteLine($"ID: {project.ProjectID}, Name: {project.ProjectName}, StartAt: {project.StartAt}, EndAt: {project.EndAt}, CreateID: {project.CreateID}");
}

// Thêm một dự án mới (ví dụ)
//bool addSuccess = projectBUS.AddProject("New Project", DateTime.Now, DateTime.Now.AddDays(30), 5, DateTime.Now, 1, "New project information", 1, "New project description", 0.0f);
//if (addSuccess)
//{
//    Console.WriteLine("Thêm dự án mới thành công.");
//}
//else
//{
//    Console.WriteLine("Thêm dự án mới thất bại.");
//}

//// Cập nhật thông tin dự án (ví dụ)
//int projectIdToUpdate = 1; // ID của dự án cần cập nhật
//bool updateSuccess = projectBUS.UpdateProject(projectIdToUpdate, "Updated Project Name", DateTime.Now, DateTime.Now.AddDays(60), 10, DateTime.Now, 1, "Updated project information", 2, "Updated project description", 50.0f);
//if (updateSuccess)
//{
//    Console.WriteLine("Cập nhật thông tin dự án thành công.");
//}
//else
//{
//    Console.WriteLine("Cập nhật thông tin dự án thất bại.");
//}

//// Xóa dự án (ví dụ)
//int projectIdToDelete = 2; // ID của dự án cần xóa
//bool deleteSuccess = projectBUS.DeleteProject(projectIdToDelete);
//if (deleteSuccess)
//{
//    Console.WriteLine("Xóa dự án thành công.");
//}
//else
//{
//    Console.WriteLine("Xóa dự án thất bại.");
//}

//Console.ReadLine(); // Dừng console để hiển thị kết quả