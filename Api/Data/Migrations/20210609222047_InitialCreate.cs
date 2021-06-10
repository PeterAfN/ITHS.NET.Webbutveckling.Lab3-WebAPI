using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deltagare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Förnamn = table.Column<string>(type: "TEXT", nullable: true),
                    Efternamn = table.Column<string>(type: "TEXT", nullable: true),
                    Epost = table.Column<string>(type: "TEXT", nullable: true),
                    Mobilnummer = table.Column<string>(type: "TEXT", nullable: true),
                    Adress = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    StateProvince = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<int>(type: "INTEGER", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deltagare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kurser",
                columns: table => new
                {
                    KursnummerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", false),
                    Kurstitel = table.Column<string>(type: "TEXT", nullable: true),
                    Kursbeskrivning = table.Column<string>(type: "TEXT", nullable: true),
                    Kurslängd = table.Column<int>(type: "INTEGER", nullable: false),
                    Nivå = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurser", x => x.KursnummerId);
                });

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
                        principalColumn: "KursnummerId",
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

            migrationBuilder.DropTable(
                name: "Deltagare");

            migrationBuilder.DropTable(
                name: "Kurser");
        }
    }
}
