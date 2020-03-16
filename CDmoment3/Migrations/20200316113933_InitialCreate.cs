using Microsoft.EntityFrameworkCore.Migrations;

namespace CDmoment3.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistData",
                columns: table => new
                {
                    ArtistDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artistnamn = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistData", x => x.ArtistDataId);
                });

            migrationBuilder.CreateTable(
                name: "CdData",
                columns: table => new
                {
                    CdDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skivnamn = table.Column<string>(nullable: false),
                    Detaljer = table.Column<string>(nullable: false),
                    ArtistDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdData", x => x.CdDataId);
                    table.ForeignKey(
                        name: "FK_CdData_ArtistData_ArtistDataId",
                        column: x => x.ArtistDataId,
                        principalTable: "ArtistData",
                        principalColumn: "ArtistDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CdData_ArtistDataId",
                table: "CdData",
                column: "ArtistDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CdData");

            migrationBuilder.DropTable(
                name: "ArtistData");
        }
    }
}
