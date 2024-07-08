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
        }
    }
}