using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IQ_Class.Migrations
{
    public partial class teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "guid",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "guid_active",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "online",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "schoolid",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_schoolid",
                table: "users",
                column: "schoolid");

            migrationBuilder.AddForeignKey(
                name: "FK_users_schools_schoolid",
                table: "users",
                column: "schoolid",
                principalTable: "schools",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_schools_schoolid",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_schoolid",
                table: "users");

            migrationBuilder.DropColumn(
                name: "guid_active",
                table: "users");

            migrationBuilder.DropColumn(
                name: "online",
                table: "users");

            migrationBuilder.DropColumn(
                name: "schoolid",
                table: "users");

            migrationBuilder.AlterColumn<Guid>(
                name: "guid",
                table: "users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
