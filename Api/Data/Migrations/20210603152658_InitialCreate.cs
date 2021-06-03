using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.data.Migrations
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Kursnummer = table.Column<int>(type: "INTEGER", nullable: false),
                    Kurstitel = table.Column<string>(type: "TEXT", nullable: true),
                    Kursbeskrivning = table.Column<string>(type: "TEXT", nullable: true),
                    Kurslängd = table.Column<int>(type: "INTEGER", nullable: false),
                    Nivå = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurser", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deltagare");

            migrationBuilder.DropTable(
                name: "Kurser");
        }
    }
}
