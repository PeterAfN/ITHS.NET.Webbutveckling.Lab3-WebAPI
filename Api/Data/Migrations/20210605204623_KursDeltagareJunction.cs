using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.data.Migrations
{
    public partial class KursDeltagareJunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KursDeltagare",
                columns: table => new
                {
                    KursId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeltagareId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursDeltagare", x => new { x.KursId, x.DeltagareId });
                    table.ForeignKey(
                        name: "FK_KursDeltagare_Deltagare_DeltagareId",
                        column: x => x.DeltagareId,
                        principalTable: "Deltagare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KursDeltagare_Kurser_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KursDeltagare_DeltagareId",
                table: "KursDeltagare",
                column: "DeltagareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KursDeltagare");
        }
    }
}
