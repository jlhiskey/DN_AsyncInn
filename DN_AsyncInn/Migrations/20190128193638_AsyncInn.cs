using Microsoft.EntityFrameworkCore.Migrations;

namespace DN_AsyncInn.Migrations
{
    public partial class AsyncInn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Air Conditioning" },
                    { 2, "Coffee Maker" },
                    { 3, "Mini Bar" },
                    { 4, "Jacuzzi" },
                    { 5, "Ocean View" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "12345 1st Street Seattle, WA 98101", "Seattle", "206-206-2006" },
                    { 2, "4567 2nd St Redmond, WA 98052", "Redmond", "425-425-4225" },
                    { 3, "7894 8th Ave Los Angeles, CA 90001", "Los Angeles", "323-323-3223" },
                    { 4, "5678 109th St New York City, NY 10001", "New York", "646-646-6446" },
                    { 5, "6447 89th Ave Miami, FL 33101", "Miami", "786-786-7886" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Standard Studio" },
                    { 2, 1, "Standard One Bedroom" },
                    { 3, 2, "Standard Two Bedroom" },
                    { 4, 2, "Restful Rainier" },
                    { 5, 0, "Seahawks Snooze" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
