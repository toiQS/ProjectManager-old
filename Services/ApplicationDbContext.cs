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

            // Seeding Users
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, UserName = "admin", Email = "admin@example.com", Password = "password" },
                new User { UserID = 2, UserName = "jdoe", Email = "jdoe@example.com", Password = "password" }
            );

            // Seeding Statuses
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusID = 1, StatusName = "Not Started", StatusInfo = "Project has not started yet." },
                new Status { StatusID = 2, StatusName = "In Progress", StatusInfo = "Project is currently in progress." },
                new Status { StatusID = 3, StatusName = "Completed", StatusInfo = "Project is completed." }
            );

            // Seeding Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 1, RoleName = "Developer", RoleInfo = "Works on development tasks." },
                new Role { RoleID = 2, RoleName = "Manager", RoleInfo = "Oversees the project." }
            );

            // Seeding Projects
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectID = 1,
                    ProjectName = "Website Redesign",
                    ProjectInfo = "Redesigning the corporate website.",
                    ProjectDescription = "A complete overhaul of the corporate website.",
                    CreateAt = DateTime.Now.AddMonths(-3),
                    StartAt = DateTime.Now.AddMonths(-2),
                    EndAt = DateTime.Now.AddMonths(1),
                    Quantity_Member_Requied = 5,
                    StatusID = 2,
                    UserID = 1
                }
            );

            // Seeding Task Levels
            modelBuilder.Entity<Task_Level>().HasData(
                new Task_Level { TaskLevelID = 1, TaskName = "Basic", TaskInfo = "Basic level tasks." },
                new Task_Level { TaskLevelID = 2, TaskName = "Intermediate", TaskInfo = "Intermediate level tasks." },
                new Task_Level { TaskLevelID = 3, TaskName = "Advanced", TaskInfo = "Advanced level tasks.", TaskParentID = 2 }
            );

            // Seeding Tasks in Project
            modelBuilder.Entity<Task_In_Project>().HasData(
                new Task_In_Project
                {
                    TaskID = 1,
                    TaskName = "Design Mockups",
                    TaskDescription = "Create design mockups for the new website.",
                    ProjectID = 1,
                    CreateAt = DateTime.Now.AddMonths(-2),
                    StartAt = DateTime.Now.AddMonths(-1),
                    EndAt = DateTime.Now.AddMonths(1),
                    TaskLevelID = 1
                }
            );

            // Seeding Members in Project
            modelBuilder.Entity<Member_In_Project>().HasData(
                new Member_In_Project { MemberID = 1, ProjectID = 1, RoleID = 1 },
                new Member_In_Project { MemberID = 2, ProjectID = 1, RoleID = 2 }
            );
        }
    }
}