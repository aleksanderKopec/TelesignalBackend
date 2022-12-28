using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Telesignal.Migrations
{
    public partial class ModifyMessageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Users",
                newName: "UsersForeingKey");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoomId",
                table: "Users",
                newName: "IX_Users_UsersForeingKey");

            migrationBuilder.AddColumn<int>(
                name: "AdminsForeingKey",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "KeyMapJson",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdminsForeingKey",
                table: "Users",
                column: "AdminsForeingKey");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Name",
                table: "Rooms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DateAdded",
                table: "Messages",
                column: "DateAdded");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rooms_AdminsForeingKey",
                table: "Users",
                column: "AdminsForeingKey",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rooms_UsersForeingKey",
                table: "Users",
                column: "UsersForeingKey",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_AdminsForeingKey",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_UsersForeingKey",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AdminsForeingKey",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_Name",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DateAdded",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "AdminsForeingKey",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "KeyMapJson",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UsersForeingKey",
                table: "Users",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UsersForeingKey",
                table: "Users",
                newName: "IX_Users_RoomId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
