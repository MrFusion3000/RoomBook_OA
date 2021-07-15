using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class ChangeRoomTimeSlotBooker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Bookers_BookerID",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "TBookerID",
                table: "TimeSlots");

            migrationBuilder.RenameColumn(
                name: "BookerID",
                table: "TimeSlots",
                newName: "BookerId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSlots_BookerID",
                table: "TimeSlots",
                newName: "IX_TimeSlots_BookerId");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomID",
                table: "Bookers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookers_RoomID",
                table: "Bookers",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookers_Rooms_RoomID",
                table: "Bookers",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Bookers_BookerId",
                table: "TimeSlots",
                column: "BookerId",
                principalTable: "Bookers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookers_Rooms_RoomID",
                table: "Bookers");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Bookers_BookerId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_Bookers_RoomID",
                table: "Bookers");

            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "Bookers");

            migrationBuilder.RenameColumn(
                name: "BookerId",
                table: "TimeSlots",
                newName: "BookerID");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSlots_BookerId",
                table: "TimeSlots",
                newName: "IX_TimeSlots_BookerID");

            migrationBuilder.AddColumn<Guid>(
                name: "TBookerID",
                table: "TimeSlots",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Bookers_BookerID",
                table: "TimeSlots",
                column: "BookerID",
                principalTable: "Bookers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
