using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation_DAL.Migrations
{
    public partial class AddSeadData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "id", "finger_no", "floor_no" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "id", "finger_no", "floor_no", "is_vip" },
                values: new object[] { 4, 5, 2, true });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "Email", "name" },
                values: new object[,]
                {
                    { 1, "Amani.nabil@hotmail.com", "Amany Nabil" },
                    { 2, "Ahmed.M@hotmail.com", "Ahmed Mohamed" },
                    { 3, "Ali.Said@hotmail.com", "Ali Said" },
                    { 4, "Tamer.M@hotmail.com", "Tamed Mohamed" }
                });

            migrationBuilder.InsertData(
                table: "reservations",
                columns: new[] { "id", "reservationDate", "room_id", "user_id" },
                values: new object[] { 1, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "reservations",
                columns: new[] { "id", "reservationDate", "room_id", "user_id" },
                values: new object[] { 2, new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "reservations",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
