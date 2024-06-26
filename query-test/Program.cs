// See https://aka.ms/new-console-template for more information
using query_test;
using DTO;

Console.WriteLine("Hello, World!");

RoleBus_Test roleBus_Test = new RoleBus_Test();

// Fetch and display roles
Console.WriteLine("Fetching roles...");
var roles = roleBus_Test.GetRoles();
foreach (var role in roles)
{
    Console.WriteLine(role);
}

// Add a new role
Console.WriteLine("Enter the new role name:");
string rolename = Console.ReadLine();
Console.WriteLine("Enter the new role info:");
string roleinfo = Console.ReadLine();

roleBus_Test.AddRole(rolename, roleinfo);

// Fetch and display roles again to see the new entry
Console.WriteLine("Fetching roles after adding a new role...");
roles = roleBus_Test.GetRoles();
foreach (var role in roles)
{
    Console.WriteLine(role);
}
