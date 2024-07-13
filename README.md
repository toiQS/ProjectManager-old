# Project Manager

## Overview

**Project:** Project Manager

**Programming Language:** C#

**Framework:** WPF (Windows Presentation Foundation)

**Database:** SQL Server

**ORM:** Entity Framework

**Purpose:** This project is designed to manage personal and team projects, including tracking progress, managing resources, and tasks.

## Key Features

1. **Project Management:**
   - Create, edit, and delete projects.
   - Track progress and status of each project.
   
2. **Task Management:**
   - Add, edit, and delete tasks.
   - Assign tasks to project members.
   - Set priority and deadlines for tasks.

3. **Member Management:**
   - Add, edit, and delete members.
   - Manage roles and permissions of each project member.

4. **Reporting:**
   - Generate project progress reports.
   - Export reports as PDF or Excel files.

## Installation and Running the Project

1. **System Requirements:**
   - .NET Framework 4.7.2 or higher
   - SQL Server 2017 or higher

2. **Installation:**
   - Clone the repository from GitHub: `git clone https://github.com/toiQS/ProjectManager.git`
   - Open the solution in Visual Studio.
   - Configure the connection string to SQL Server in the file `\Services\ApplicationDbContext.cs`.
   - Run the command `update-database` to create the database and necessary tables.
   - Build and run the project.

3. **Configuration:**
   - Update the connection string in `\Services\ApplicationDbContext.cs`:
     ```cs
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
         base.OnConfiguring(optionsBuilder);
         optionsBuilder.UseSqlServer(
         @"Server={your-sql-server-name};Database=PM;Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=true;");
     }
     ```

4. **Running the Project:**
   - Press F5 in Visual Studio to build and run the project.

## Development and Contributions

- **Fork the repository** on GitHub.
- **Create a new branch** for features or bug fixes.
- **Submit a pull request** with a detailed description of the changes.

## Contact

- **Author:** Nguyen Quoc Sieu
- **Email:** nguyensieu12112002@gmail.com
- **Address:** Long An, Viet Nam
