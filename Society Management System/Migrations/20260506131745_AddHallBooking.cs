using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Society_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddHallBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HallBookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallBookings", x => x.BookingId);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 6, 18, 47, 44, 414, DateTimeKind.Local).AddTicks(384));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HallBookings");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 6, 16, 28, 44, 95, DateTimeKind.Local).AddTicks(3416));
        }
    }
}
