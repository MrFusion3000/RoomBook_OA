using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddTokenToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10abc28b-0223-4705-9a1f-01ecab424e82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c1e588f-4f29-413a-a81c-ccbad8a55dab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52110437-75af-4b2f-8736-8c134769fed0", "065f042a-bd5c-49f4-8cbc-7f4774557295", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9aa7f4fb-811d-4636-ab79-8f8f5f9f0527", "d3a0ca20-aadf-428d-b3be-26386151f2f5", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52110437-75af-4b2f-8736-8c134769fed0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa7f4fb-811d-4636-ab79-8f8f5f9f0527");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "10abc28b-0223-4705-9a1f-01ecab424e82", "a2d68462-711e-41f2-a1e5-fc9877082ac3", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c1e588f-4f29-413a-a81c-ccbad8a55dab", "0f25d8a9-9941-403f-b14b-b57288c08850", "Administrator", "ADMINISTRATOR" });
        }
    }
}
