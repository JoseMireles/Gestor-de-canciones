using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReproductorMusical.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablasCancionyPlaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    Playlist_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Playlist_Id);
                });

            migrationBuilder.CreateTable(
                name: "Cancion",
                columns: table => new
                {
                    Cancion_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Productor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Playlist_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancion", x => x.Cancion_Id);
                    table.ForeignKey(
                        name: "FK_Cancion_Playlist_Playlist_Id",
                        column: x => x.Playlist_Id,
                        principalTable: "Playlist",
                        principalColumn: "Playlist_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cancion_Playlist_Id",
                table: "Cancion",
                column: "Playlist_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cancion");

            migrationBuilder.DropTable(
                name: "Playlist");
        }
    }
}
