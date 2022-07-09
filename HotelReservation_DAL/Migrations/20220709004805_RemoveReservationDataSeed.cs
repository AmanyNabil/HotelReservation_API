using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation_DAL.Migrations
{
    public partial class RemoveReservationDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "reservations",
                columns: new[] { "id", "reservationDate", "room_id", "user_id" },
                values: new object[] { 1, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "reservations",
                columns: new[] { "id", "reservationDate", "room_id", "user_id" },
                values: new object[] { 2, new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 });
        }
    }
}
