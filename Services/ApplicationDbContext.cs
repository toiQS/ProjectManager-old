using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Member_In_Project> Member_In_Projects { get; set; }
        public DbSet<Member_In_Task> Member_In_Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuss { get; set; }
        public DbSet<Task_In_Project> Task_In_Projects { get; set; }
        public DbSet<Task_Level> Task_Level { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
            @"Server=AKAI\SQLEXPRESS;Database=PM;Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=true;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Users
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, UserName = "john_doe", Email = "john.doe@example.com", Password = "password123" },
                new User { UserID = 2, UserName = "jane_smith", Email = "jane.smith@example.com", Password = "password123" },
                new User { UserID = 3, UserName = "alice_jones", Email = "alice.jones@example.com", Password = "password123" },
                new User { UserID = 4, UserName = "bob_brown", Email = "bob.brown@example.com", Password = "password123" },
                new User { UserID = 5, UserName = "charlie_davis", Email = "charlie.davis@example.com", Password = "password123" }
            );

            // Seed data for Status
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusID = 1, StatusName = "Open", StatusInfo = "Project is open" },
                new Status { StatusID = 2, StatusName = "In Progress", StatusInfo = "Project is in progress" },
                new Status { StatusID = 3, StatusName = "Completed", StatusInfo = "Project is completed" },
                new Status { StatusID = 4, StatusName = "On Hold", StatusInfo = "Project is on hold" }
            );

            // Seed data for Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 1, RoleName = "Manager", RoleInfo = "Manages the project" },
                new Role { RoleID = 2, RoleName = "Developer", RoleInfo = "Develops the project" },
                new Role { RoleID = 3, RoleName = "Tester", RoleInfo = "Tests the project" },
                new Role { RoleID = 4, RoleName = "Designer", RoleInfo = "Designs the project" },
                new Role { RoleID = 5, RoleName = "Analyst", RoleInfo = "Analyzes the project" }
            );

            // Seed data for Projects
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectID = 1,
                    ProjectName = "Project Alpha",
                    ProjectInfo = "First project",
                    ProjectDescription = "Description for Project Alpha",
                    CreateAt = DateTime.Now,
                    StartAt = DateTime.Now.AddDays(1),
                    EndAt = DateTime.Now.AddMonths(1),
                    Quantity_Member_Requied = 5,
                    StatusID = 1,
                    UserID = 1
                },
                new Project
                {
                    ProjectID = 2,
                    ProjectName = "Project Beta",
                    ProjectInfo = "Second project",
                    ProjectDescription = "Description for Project Beta",
                    CreateAt = DateTime.Now,
                    StartAt = DateTime.Now.AddDays(2),
                    EndAt = DateTime.Now.AddMonths(2),
                    Quantity_Member_Requied = 4,
                    StatusID = 2,
                    UserID = 2
                },
                new Project
                {
                    ProjectID = 3,
                    ProjectName = "Project Gamma",
                    ProjectInfo = "Third project",
                    ProjectDescription = "Description for Project Gamma",
                    CreateAt = DateTime.Now,
                    StartAt = DateTime.Now.AddDays(3),
                    EndAt = DateTime.Now.AddMonths(3),
                    Quantity_Member_Requied = 6,
                    StatusID = 3,
                    UserID = 3
                }
            );

            // Seed data for Task Levels
            modelBuilder.Entity<Task_Level>().HasData(
                new Task_Level { TaskLevelID = 1, TaskName = "High", TaskInfo = "High priority" },
                new Task_Level { TaskLevelID = 2, TaskName = "Medium", TaskInfo = "Medium priority" },
                new Task_Level { TaskLevelID = 3, TaskName = "Low", TaskInfo = "Low priority" }
            );

            // Seed data for Tasks in Projects
            modelBuilder.Entity<Task_In_Project>().HasData(
                new Task_In_Project
                {
                    TaskID = 1,
                    TaskName = "Initial Setup",
                    TaskDescription = "Setup project environment",
                    CreateAt = DateTime.Now,
                    StartAt = DateTime.Now.AddDays(1),
                    EndAt = DateTime.Now.AddDays(7),
                    ProjectID = 1,
                    TaskLevelID = 1
                },
                new Task_In_Project
                {
                    TaskID = 2,
                    TaskName = "Requirement Analysis",
                    TaskDescription = "Analyze requirements",
                    CreateAt = DateTime.Now,
                    StartAt = DateTime.Now.AddDays(1),
                    EndAt = DateTime.Now.AddDays(14),
                    ProjectID = 2,
                    TaskLevelID = 2
                },
                new Task_In_Project
                {
                    TaskID = 3,
                    TaskName = "UI Design",
                    TaskDescription = "Design the user interface",
                    CreateAt = DateTime.Now,
                    StartAt = DateTime.Now.AddDays(2),
                    EndAt = DateTime.Now.AddDays(10),
                    ProjectID = 1,
                    TaskLevelID = 3
                },
                new Task_In_Project
                {
                    TaskID = 4,
                    TaskName = "Backend Development",
                    TaskDescription = "Develop the backend",
                    CreateAt = DateTime.Now,
                    StartAt = DateTime.Now.AddDays(3),
                    EndAt = DateTime.Now.AddDays(20),
                    ProjectID = 2,
                    TaskLevelID = 1
                },
                new Task_In_Project
                {
                    TaskID = 5,
                    TaskName = "Testing",
                    TaskDescription = "Test the application",
                    CreateAt = DateTime.Now,
                    StartAt = DateTime.Now.AddDays(4),
                    EndAt = DateTime.Now.AddDays(15),
                    ProjectID = 3,
                    TaskLevelID = 2
                }
            );

            // Seed data for Members in Projects
            modelBuilder.Entity<Member_In_Project>().HasData(
                new Member_In_Project { MemberID = 1, ProjectID = 1, RoleID = 1, UserID = 1 },
                new Member_In_Project { MemberID = 2, ProjectID = 1, RoleID = 2, UserID = 2 },
                new Member_In_Project { MemberID = 3, ProjectID = 1, RoleID = 3, UserID = 3 },
                new Member_In_Project { MemberID = 4, ProjectID = 2, RoleID = 2, UserID = 4 },
                new Member_In_Project { MemberID = 5, ProjectID = 2, RoleID = 3, UserID = 5 },
                new Member_In_Project { MemberID = 6, ProjectID = 3, RoleID = 4, UserID = 1 },
                new Member_In_Project { MemberID = 7, ProjectID = 3, RoleID = 5, UserID = 2 }
            );

            // Seed data for Members in Tasks
            modelBuilder.Entity<Member_In_Task>().HasData(
                new Member_In_Task { Member_In_Task_ID = 1, TaskID = 1, MemberID = 1 },
                new Member_In_Task { Member_In_Task_ID = 2, TaskID = 1, MemberID = 2 },
                new Member_In_Task { Member_In_Task_ID = 3, TaskID = 2, MemberID = 3 },
                new Member_In_Task { Member_In_Task_ID = 4, TaskID = 3, MemberID = 4 },
                new Member_In_Task { Member_In_Task_ID = 5, TaskID = 4, MemberID = 5 },
                new Member_In_Task { Member_In_Task_ID = 6, TaskID = 5, MemberID = 6 }
            );
        }

    }
}