using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class updateseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 9, 27, 7, 33, 3, 730, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 9, 28, 7, 33, 3, 730, DateTimeKind.Local).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 9, 29, 7, 33, 3, 730, DateTimeKind.Local).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2023, 9, 30, 7, 33, 3, 730, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2023, 10, 1, 7, 33, 3, 730, DateTimeKind.Local).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 6,
                column: "DueDate",
                value: new DateTime(2023, 10, 2, 7, 33, 3, 730, DateTimeKind.Local).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 7,
                column: "DueDate",
                value: new DateTime(2023, 10, 3, 7, 33, 3, 730, DateTimeKind.Local).AddTicks(6203));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 8,
                column: "DueDate",
                value: new DateTime(2023, 10, 4, 7, 33, 3, 730, DateTimeKind.Local).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 9,
                column: "DueDate",
                value: new DateTime(2023, 10, 5, 7, 33, 3, 730, DateTimeKind.Local).AddTicks(6205));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 10,
                column: "DueDate",
                value: new DateTime(2023, 10, 6, 7, 33, 3, 730, DateTimeKind.Local).AddTicks(6207));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 9, 25, 16, 0, 34, 58, DateTimeKind.Local).AddTicks(6805));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 9, 25, 16, 0, 34, 58, DateTimeKind.Local).AddTicks(6818));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 9, 25, 16, 0, 34, 58, DateTimeKind.Local).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2023, 9, 25, 16, 0, 34, 58, DateTimeKind.Local).AddTicks(6820));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2023, 9, 25, 16, 0, 34, 58, DateTimeKind.Local).AddTicks(6821));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 6,
                column: "DueDate",
                value: new DateTime(2023, 9, 25, 16, 0, 34, 58, DateTimeKind.Local).AddTicks(6823));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 7,
                column: "DueDate",
                value: new DateTime(2023, 9, 25, 16, 0, 34, 58, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 8,
                column: "DueDate",
                value: new DateTime(2023, 9, 25, 16, 0, 34, 58, DateTimeKind.Local).AddTicks(6848));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 9,
                column: "DueDate",
                value: new DateTime(2023, 9, 25, 16, 0, 34, 58, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 10,
                column: "DueDate",
                value: new DateTime(2023, 9, 25, 16, 0, 34, 58, DateTimeKind.Local).AddTicks(6851));
        }
    }
}
