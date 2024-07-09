using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Services.Migrations
{
    /// <inheritdoc />
    public partial class PMseedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "member_In_Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleInfo", "RoleName" },
                values: new object[,]
                {
                    { 1, "Manages the project", "Manager" },
                    { 2, "Develops the project", "Developer" },
                    { 3, "Tests the project", "Tester" },
                    { 4, "Designs the project", "Designer" },
                    { 5, "Analyzes the project", "Analyst" }
                });

            migrationBuilder.InsertData(
                table: "Statuss",
                columns: new[] { "StatusID", "StatusInfo", "StatusName" },
                values: new object[,]
                {
                    { 1, "Project is open", "Open" },
                    { 2, "Project is in progress", "In Progress" },
                    { 3, "Project is completed", "Completed" },
                    { 4, "Project is on hold", "On Hold" }
                });

            migrationBuilder.InsertData(
                table: "Task_Level",
                columns: new[] { "TaskLevelID", "TaskInfo", "TaskName", "TaskParentID" },
                values: new object[,]
                {
                    { 1, "High priority", "High", null },
                    { 2, "Medium priority", "Medium", null },
                    { 3, "Low priority", "Low", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "password123", "john_doe" },
                    { 2, "jane.smith@example.com", "password123", "jane_smith" },
                    { 3, "alice.jones@example.com", "password123", "alice_jones" },
                    { 4, "bob.brown@example.com", "password123", "bob_brown" },
                    { 5, "charlie.davis@example.com", "password123", "charlie_davis" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "CreateAt", "EndAt", "ProjectDescription", "ProjectInfo", "ProjectName", "Quantity_Member_Requied", "StartAt", "StatusID", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1914), new DateTime(2024, 8, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1934), "Description for Project Alpha", "First project", "Project Alpha", 5, new DateTime(2024, 7, 9, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1927), 1, 1 },
                    { 2, new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1940), new DateTime(2024, 9, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1941), "Description for Project Beta", "Second project", "Project Beta", 4, new DateTime(2024, 7, 10, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1941), 2, 2 },
                    { 3, new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1944), new DateTime(2024, 10, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1945), "Description for Project Gamma", "Third project", "Project Gamma", 6, new DateTime(2024, 7, 11, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1944), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Task_In_Projects",
                columns: new[] { "TaskID", "CreateAt", "EndAt", "ProjectID", "StartAt", "TaskDescription", "TaskLevelID", "TaskName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1987), new DateTime(2024, 7, 15, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1989), 1, new DateTime(2024, 7, 9, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1988), "Setup project environment", 1, "Initial Setup" },
                    { 2, new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1991), new DateTime(2024, 7, 22, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1992), 2, new DateTime(2024, 7, 9, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1992), "Analyze requirements", 2, "Requirement Analysis" },
                    { 3, new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1994), new DateTime(2024, 7, 18, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1995), 1, new DateTime(2024, 7, 10, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1994), "Design the user interface", 3, "UI Design" },
                    { 4, new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1996), new DateTime(2024, 7, 28, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1997), 2, new DateTime(2024, 7, 11, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1997), "Develop the backend", 1, "Backend Development" },
                    { 5, new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1999), new DateTime(2024, 7, 23, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(2000), 3, new DateTime(2024, 7, 12, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1999), "Test the application", 2, "Testing" }
                });

            migrationBuilder.InsertData(
                table: "Member_In_Projects",
                columns: new[] { "MemberID", "ProjectID", "RoleID", "UserID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 2, 2 },
                    { 3, 1, 3, 3 },
                    { 4, 2, 2, 4 },
                    { 5, 2, 3, 5 },
                    { 6, 3, 4, 1 },
                    { 7, 3, 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "member_In_Tasks",
                columns: new[] { "Member_In_Task_ID", "MemberID", "ProjectID", "TaskID" },
                values: new object[,]
                {
                    { 1, 1, null, 1 },
                    { 2, 2, null, 1 },
                    { 3, 3, null, 2 },
                    { 4, 4, null, 3 },
                    { 5, 5, null, 4 },
                    { 6, 6, null, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_member_In_Tasks_ProjectID",
                table: "member_In_Tasks",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_member_In_Tasks_Projects_ProjectID",
                table: "member_In_Tasks",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_member_In_Tasks_Projects_ProjectID",
                table: "member_In_Tasks");

            migrationBuilder.DropIndex(
                name: "IX_member_In_Tasks_ProjectID",
                table: "member_In_Tasks");

            migrationBuilder.DeleteData(
                table: "Member_In_Projects",
                keyColumn: "MemberID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Statuss",
                keyColumn: "StatusID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "member_In_Tasks",
                keyColumn: "Member_In_Task_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "member_In_Tasks",
                keyColumn: "Member_In_Task_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "member_In_Tasks",
                keyColumn: "Member_In_Task_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "member_In_Tasks",
                keyColumn: "Member_In_Task_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "member_In_Tasks",
                keyColumn: "Member_In_Task_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "member_In_Tasks",
                keyColumn: "Member_In_Task_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Member_In_Projects",
                keyColumn: "MemberID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Member_In_Projects",
                keyColumn: "MemberID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Member_In_Projects",
                keyColumn: "MemberID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Member_In_Projects",
                keyColumn: "MemberID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Member_In_Projects",
                keyColumn: "MemberID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Member_In_Projects",
                keyColumn: "MemberID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Task_Level",
                keyColumn: "TaskLevelID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Task_Level",
                keyColumn: "TaskLevelID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Task_Level",
                keyColumn: "TaskLevelID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Statuss",
                keyColumn: "StatusID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuss",
                keyColumn: "StatusID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuss",
                keyColumn: "StatusID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "member_In_Tasks");
        }
    }
}
