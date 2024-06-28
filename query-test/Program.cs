// See https://aka.ms/new-console-template for more information
using query_test;
using DTO;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

TaskLevelBUS_Test _Test = new TaskLevelBUS_Test();

var get = _Test.GetTaskLevels();
foreach (var item in get)
{
    Console.WriteLine(item);
}
string taskname = Console.ReadLine();
string taskinfo = Console.ReadLine();
int parent = Convert.ToInt32(Console.ReadLine());

_Test.AddTaskLevel(taskname, taskinfo, null);
