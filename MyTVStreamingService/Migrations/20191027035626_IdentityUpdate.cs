using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTVStreamingService.Migrations
{
    public partial class IdentityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "userPassword",
                table: "User",
                newName: "UserPassword");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "User",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "User",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "User",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "emailAddress",
                table: "User",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "accCreationDate",
                table: "User",
                newName: "AccCreationDate");

            migrationBuilder.RenameColumn(
                name: "userPassword",
                table: "AspNetUsers",
                newName: "UserPassword");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "AspNetUsers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "emailAddress",
                table: "AspNetUsers",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "accCreationDate",
                table: "AspNetUsers",
                newName: "AccCreationDate");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 60);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "User",
                newName: "userPassword");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "User",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "User",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "User",
                newName: "emailAddress");

            migrationBuilder.RenameColumn(
                name: "AccCreationDate",
                table: "User",
                newName: "accCreationDate");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "AspNetUsers",
                newName: "userPassword");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "AspNetUsers",
                newName: "emailAddress");

            migrationBuilder.RenameColumn(
                name: "AccCreationDate",
                table: "AspNetUsers",
                newName: "accCreationDate");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "User",
                type: "TEXT",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "User",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 256,
                nullable: true);
        }
    }
}
