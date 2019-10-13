using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTVStreamingService.Migrations.User
{
    public partial class UserCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userName = table.Column<string>(maxLength: 60, nullable: false),
                    userPassword = table.Column<string>(maxLength: 60, nullable: false),
                    firstName = table.Column<string>(maxLength: 60, nullable: false),
                    lastName = table.Column<string>(maxLength: 60, nullable: false),
                    emailAddress = table.Column<string>(maxLength: 60, nullable: false),
                    accCreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
