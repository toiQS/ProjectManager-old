using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Services.Migrations
{
    /// <inheritdoc />
    public partial class PMaddmigrationmodelseedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Statuss",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuss", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Task_Level",
                columns: table => new
                {
                    TaskLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_Level", x => x.TaskLevelID);
                    table.ForeignKey(
                        name: "FK_Task_Level_Task_Level_TaskParentID",
                        column: x => x.TaskParentID,
                        principalTable: "Task_Level",
                        principalColumn: "TaskLevelID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity_Member_Requied = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_Statuss_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuss",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task_In_Projects",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskLevelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_In_Projects", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Task_In_Projects_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_In_Projects_Task_Level_TaskLevelID",
                        column: x => x.TaskLevelID,
                        principalTable: "Task_Level",
                        principalColumn: "TaskLevelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Member_In_Projects",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Task_In_ProjectTaskID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member_In_Projects", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Member_In_Projects_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Member_In_Projects_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Member_In_Projects_Task_In_Projects_Task_In_ProjectTaskID",
                        column: x => x.Task_In_ProjectTaskID,
                        principalTable: "Task_In_Projects",
                        principalColumn: "TaskID");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleInfo", "RoleName" },
                values: new object[,]
                {
                    { 1, "Works on development tasks.", "Developer" },
                    { 2, "Oversees the project.", "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Statuss",
                columns: new[] { "StatusID", "StatusInfo", "StatusName" },
                values: new object[,]
                {
                    { 1, "Project has not started yet.", "Not Started" },
                    { 2, "Project is currently in progress.", "In Progress" },
                    { 3, "Project is completed.", "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Task_Level",
                columns: new[] { "TaskLevelID", "TaskInfo", "TaskName", "TaskParentID" },
                values: new object[,]
                {
                    { 1, "Basic level tasks.", "Basic", null },
                    { 2, "Intermediate level tasks.", "Intermediate", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "password", "admin" },
                    { 2, "jdoe@example.com", "password", "jdoe" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "CreateAt", "EndAt", "ProjectDescription", "ProjectInfo", "ProjectName", "Quantity_Member_Requied", "StartAt", "StatusID", "UserID" },
                values: new object[] { 1, new DateTime(2024, 4, 1, 12, 47, 38, 96, DateTimeKind.Local).AddTicks(8529), new DateTime(2024, 8, 1, 12, 47, 38, 96, DateTimeKind.Local).AddTicks(8547), "A complete overhaul of the corporate website.", "Redesigning the corporate website.", "Website Redesign", 5, new DateTime(2024, 5, 1, 12, 47, 38, 96, DateTimeKind.Local).AddTicks(8546), 2, 1 });

            migrationBuilder.InsertData(
                table: "Task_Level",
                columns: new[] { "TaskLevelID", "TaskInfo", "TaskName", "TaskParentID" },
                values: new object[] { 3, "Advanced level tasks.", "Advanced", 2 });

            migrationBuilder.InsertData(
                table: "Member_In_Projects",
                columns: new[] { "MemberID", "ProjectID", "RoleID", "Task_In_ProjectTaskID" },
                values: new object[,]
                {
                    { 1, 1, 1, null },
                    { 2, 1, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Task_In_Projects",
                columns: new[] { "TaskID", "CreateAt", "EndAt", "ProjectID", "StartAt", "TaskDescription", "TaskLevelID", "TaskName" },
                values: new object[] { 1, new DateTime(2024, 5, 1, 12, 47, 38, 96, DateTimeKind.Local).AddTicks(8590), new DateTime(2024, 8, 1, 12, 47, 38, 96, DateTimeKind.Local).AddTicks(8593), 1, new DateTime(2024, 6, 1, 12, 47, 38, 96, DateTimeKind.Local).AddTicks(8592), "Create design mockups for the new website.", 1, "Design Mockups" });

            migrationBuilder.CreateIndex(
                name: "IX_Member_In_Projects_ProjectID",
                table: "Member_In_Projects",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_In_Projects_RoleID",
                table: "Member_In_Projects",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_In_Projects_Task_In_ProjectTaskID",
                table: "Member_In_Projects",
                column: "Task_In_ProjectTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusID",
                table: "Projects",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserID",
                table: "Projects",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_In_Projects_ProjectID",
                table: "Task_In_Projects",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_In_Projects_TaskLevelID",
                table: "Task_In_Projects",
                column: "TaskLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Level_TaskParentID",
                table: "Task_Level",
                column: "TaskParentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member_In_Projects");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Task_In_Projects");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Task_Level");

            migrationBuilder.DropTable(
                name: "Statuss");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
