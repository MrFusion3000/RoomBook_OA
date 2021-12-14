using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddTokenToDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52110437-75af-4b2f-8736-8c134769fed0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa7f4fb-811d-4636-ab79-8f8f5f9f0527");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleting",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66a93d70-0495-4ce9-a74e-7789c4c72f09", "29fe8cd0-115b-423e-8d5e-42b4ffb7ec40", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab3c2865-49bc-44f8-8ef6-d55ad16b30ec", "cf303153-7b94-4746-b420-48cf1c471070", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66a93d70-0495-4ce9-a74e-7789c4c72f09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab3c2865-49bc-44f8-8ef6-d55ad16b30ec");

            migrationBuilder.DropColumn(
                name: "IsDeleting",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52110437-75af-4b2f-8736-8c134769fed0", "065f042a-bd5c-49f4-8cbc-7f4774557295", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9aa7f4fb-811d-4636-ab79-8f8f5f9f0527", "d3a0ca20-aadf-428d-b3be-26386151f2f5", "Administrator", "ADMINISTRATOR" });
        }
    }
}
