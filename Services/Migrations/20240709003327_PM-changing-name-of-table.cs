using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.Migrations
{
    /// <inheritdoc />
    public partial class PMchangingnameoftable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_member_In_Tasks_Member_In_Projects_MemberID",
                table: "member_In_Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_member_In_Tasks_Projects_ProjectID",
                table: "member_In_Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_member_In_Tasks_Task_In_Projects_TaskID",
                table: "member_In_Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_member_In_Tasks",
                table: "member_In_Tasks");

            migrationBuilder.RenameTable(
                name: "member_In_Tasks",
                newName: "Member_In_Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_member_In_Tasks_TaskID",
                table: "Member_In_Tasks",
                newName: "IX_Member_In_Tasks_TaskID");

            migrationBuilder.RenameIndex(
                name: "IX_member_In_Tasks_ProjectID",
                table: "Member_In_Tasks",
                newName: "IX_Member_In_Tasks_ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_member_In_Tasks_MemberID",
                table: "Member_In_Tasks",
                newName: "IX_Member_In_Tasks_MemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member_In_Tasks",
                table: "Member_In_Tasks",
                column: "Member_In_Task_ID");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 1,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 9, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7192), new DateTime(2024, 8, 9, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7213), new DateTime(2024, 7, 10, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7205) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 2,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 9, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7221), new DateTime(2024, 9, 9, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7222), new DateTime(2024, 7, 11, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7221) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 3,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 9, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7223), new DateTime(2024, 10, 9, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7224), new DateTime(2024, 7, 12, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7224) });

            migrationBuilder.UpdateData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 1,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 9, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7260), new DateTime(2024, 7, 16, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7262), new DateTime(2024, 7, 10, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7261) });

            migrationBuilder.UpdateData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 2,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 9, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7263), new DateTime(2024, 7, 23, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7265), new DateTime(2024, 7, 10, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7264) });

            migrationBuilder.UpdateData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 3,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 9, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7266), new DateTime(2024, 7, 19, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7267), new DateTime(2024, 7, 11, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7266) });

            migrationBuilder.UpdateData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 4,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 9, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7268), new DateTime(2024, 7, 29, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7269), new DateTime(2024, 7, 12, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7269) });

            migrationBuilder.UpdateData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 5,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 9, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7270), new DateTime(2024, 7, 24, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7271), new DateTime(2024, 7, 13, 7, 33, 27, 270, DateTimeKind.Local).AddTicks(7271) });

            migrationBuilder.AddForeignKey(
                name: "FK_Member_In_Tasks_Member_In_Projects_MemberID",
                table: "Member_In_Tasks",
                column: "MemberID",
                principalTable: "Member_In_Projects",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_In_Tasks_Projects_ProjectID",
                table: "Member_In_Tasks",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_In_Tasks_Task_In_Projects_TaskID",
                table: "Member_In_Tasks",
                column: "TaskID",
                principalTable: "Task_In_Projects",
                principalColumn: "TaskID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_In_Tasks_Member_In_Projects_MemberID",
                table: "Member_In_Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_In_Tasks_Projects_ProjectID",
                table: "Member_In_Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_In_Tasks_Task_In_Projects_TaskID",
                table: "Member_In_Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member_In_Tasks",
                table: "Member_In_Tasks");

            migrationBuilder.RenameTable(
                name: "Member_In_Tasks",
                newName: "member_In_Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_Member_In_Tasks_TaskID",
                table: "member_In_Tasks",
                newName: "IX_member_In_Tasks_TaskID");

            migrationBuilder.RenameIndex(
                name: "IX_Member_In_Tasks_ProjectID",
                table: "member_In_Tasks",
                newName: "IX_member_In_Tasks_ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_Member_In_Tasks_MemberID",
                table: "member_In_Tasks",
                newName: "IX_member_In_Tasks_MemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_member_In_Tasks",
                table: "member_In_Tasks",
                column: "Member_In_Task_ID");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 1,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1914), new DateTime(2024, 8, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1934), new DateTime(2024, 7, 9, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1927) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 2,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1940), new DateTime(2024, 9, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1941), new DateTime(2024, 7, 10, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1941) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 3,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1944), new DateTime(2024, 10, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1945), new DateTime(2024, 7, 11, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1944) });

            migrationBuilder.UpdateData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 1,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1987), new DateTime(2024, 7, 15, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1989), new DateTime(2024, 7, 9, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1988) });

            migrationBuilder.UpdateData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 2,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1991), new DateTime(2024, 7, 22, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1992), new DateTime(2024, 7, 9, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1992) });

            migrationBuilder.UpdateData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 3,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1994), new DateTime(2024, 7, 18, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1995), new DateTime(2024, 7, 10, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1994) });

            migrationBuilder.UpdateData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 4,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1996), new DateTime(2024, 7, 28, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1997), new DateTime(2024, 7, 11, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1997) });

            migrationBuilder.UpdateData(
                table: "Task_In_Projects",
                keyColumn: "TaskID",
                keyValue: 5,
                columns: new[] { "CreateAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 7, 8, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1999), new DateTime(2024, 7, 23, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(2000), new DateTime(2024, 7, 12, 22, 38, 30, 805, DateTimeKind.Local).AddTicks(1999) });

            migrationBuilder.AddForeignKey(
                name: "FK_member_In_Tasks_Member_In_Projects_MemberID",
                table: "member_In_Tasks",
                column: "MemberID",
                principalTable: "Member_In_Projects",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_member_In_Tasks_Projects_ProjectID",
                table: "member_In_Tasks",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_member_In_Tasks_Task_In_Projects_TaskID",
                table: "member_In_Tasks",
                column: "TaskID",
                principalTable: "Task_In_Projects",
                principalColumn: "TaskID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
