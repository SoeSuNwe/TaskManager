using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "Description", "DueDate", "IsCompleted", "Title" },
                values: new object[,]
                {
                    { 1, "This is Task 1", new DateTime(2023, 9, 25, 8, 56, 20, 587, DateTimeKind.Local).AddTicks(7582), false, "Task 1" },
                    { 2, "This is Task 2", new DateTime(2023, 9, 25, 8, 56, 20, 587, DateTimeKind.Local).AddTicks(7595), true, "Task 2" },
                    { 3, "This is Task 3", new DateTime(2023, 9, 25, 8, 56, 20, 587, DateTimeKind.Local).AddTicks(7596), false, "Task 3" },
                    { 4, "This is Task 4", new DateTime(2023, 9, 25, 8, 56, 20, 587, DateTimeKind.Local).AddTicks(7597), true, "Task 4" },
                    { 5, "This is Task 5", new DateTime(2023, 9, 25, 8, 56, 20, 587, DateTimeKind.Local).AddTicks(7598), false, "Task 5" },
                    { 6, "This is Task 6", new DateTime(2023, 9, 25, 8, 56, 20, 587, DateTimeKind.Local).AddTicks(7599), true, "Task 6" },
                    { 7, "This is Task 7", new DateTime(2023, 9, 25, 8, 56, 20, 587, DateTimeKind.Local).AddTicks(7600), false, "Task 7" },
                    { 8, "This is Task 8", new DateTime(2023, 9, 25, 8, 56, 20, 587, DateTimeKind.Local).AddTicks(7602), true, "Task 8" },
                    { 9, "This is Task 9", new DateTime(2023, 9, 25, 8, 56, 20, 587, DateTimeKind.Local).AddTicks(7602), false, "Task 9" },
                    { 10, "This is Task 10", new DateTime(2023, 9, 25, 8, 56, 20, 587, DateTimeKind.Local).AddTicks(7604), true, "Task 10" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
