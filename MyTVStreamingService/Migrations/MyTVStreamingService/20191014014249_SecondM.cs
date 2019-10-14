using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTVStreamingService.Migrations.MyTVStreamingService
{
    public partial class SecondM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminNetwork",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminServiceID = table.Column<int>(nullable: false),
                    Network = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminNetwork", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdminNetwork_AdminService_AdminServiceID",
                        column: x => x.AdminServiceID,
                        principalTable: "AdminService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminNetwork_AdminServiceID",
                table: "AdminNetwork",
                column: "AdminServiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminNetwork");
        }
    }
}
