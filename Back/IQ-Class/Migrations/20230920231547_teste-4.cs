using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IQ_Class.Migrations
{
    public partial class teste4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "guid",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "guid_active",
                table: "users",
                newName: "verification_code_active");

            migrationBuilder.AddColumn<string>(
                name: "verification_code",
                table: "users",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "000000");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "verification_code",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "verification_code_active",
                table: "users",
                newName: "guid_active");

            migrationBuilder.AddColumn<Guid>(
                name: "guid",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
