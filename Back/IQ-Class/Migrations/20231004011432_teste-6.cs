using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IQ_Class.Migrations
{
    public partial class teste6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "schools",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "schools",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_created",
                table: "schools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_updated",
                table: "schools",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "logo",
                table: "schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "phone",
                table: "schools",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "schools");

            migrationBuilder.DropColumn(
                name: "dt_created",
                table: "schools");

            migrationBuilder.DropColumn(
                name: "dt_updated",
                table: "schools");

            migrationBuilder.DropColumn(
                name: "logo",
                table: "schools");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "schools");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
