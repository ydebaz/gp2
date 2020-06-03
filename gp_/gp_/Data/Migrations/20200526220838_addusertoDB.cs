using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gp_.Data.Migrations
{
    public partial class addusertoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    EmailConfirmationDate = table.Column<DateTime>(nullable: true),
                    graduation_uni = table.Column<string>(nullable: true),
                    isActivated = table.Column<bool>(nullable: false),
                    workplace = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    personalphonenumber = table.Column<int>(nullable: false),
                    workphonenumber = table.Column<int>(nullable: false),
                    ispart1comp = table.Column<bool>(nullable: false),
                    jma_number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    EmailConfirmationDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
