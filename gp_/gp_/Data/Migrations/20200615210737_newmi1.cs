using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gp_.Data.Migrations
{
    public partial class newmi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "user");

            migrationBuilder.DropColumn(
                name: "EmailConfirmationDate",
                table: "user");

            migrationBuilder.DropColumn(
                name: "IsEmailConfirmed",
                table: "user");

            migrationBuilder.DropColumn(
                name: "password",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "doctor");

            migrationBuilder.DropColumn(
                name: "EmailConfirmationDate",
                table: "doctor");

            migrationBuilder.DropColumn(
                name: "IsEmailConfirmed",
                table: "doctor");

            migrationBuilder.DropColumn(
                name: "password",
                table: "doctor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmailConfirmationDate",
                table: "user",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailConfirmed",
                table: "user",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmailConfirmationDate",
                table: "doctor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailConfirmed",
                table: "doctor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
