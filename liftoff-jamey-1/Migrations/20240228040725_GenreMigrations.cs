using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace liftoff_jamey_1.Migrations
{
    public partial class GenreMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookClubGenre_BookClubs_BookClubsId",
                table: "BookClubGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_BookClubGenre_Genres_GenresId",
                table: "BookClubGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookClubGenre",
                table: "BookClubGenre");

            migrationBuilder.RenameTable(
                name: "BookClubGenre",
                newName: "ClubGenres");

            migrationBuilder.RenameIndex(
                name: "IX_BookClubGenre_GenresId",
                table: "ClubGenres",
                newName: "IX_ClubGenres_GenresId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubGenres",
                table: "ClubGenres",
                columns: new[] { "BookClubsId", "GenresId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClubGenres_BookClubs_BookClubsId",
                table: "ClubGenres",
                column: "BookClubsId",
                principalTable: "BookClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubGenres_Genres_GenresId",
                table: "ClubGenres",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubGenres_BookClubs_BookClubsId",
                table: "ClubGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubGenres_Genres_GenresId",
                table: "ClubGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubGenres",
                table: "ClubGenres");

            migrationBuilder.RenameTable(
                name: "ClubGenres",
                newName: "BookClubGenre");

            migrationBuilder.RenameIndex(
                name: "IX_ClubGenres_GenresId",
                table: "BookClubGenre",
                newName: "IX_BookClubGenre_GenresId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookClubGenre",
                table: "BookClubGenre",
                columns: new[] { "BookClubsId", "GenresId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookClubGenre_BookClubs_BookClubsId",
                table: "BookClubGenre",
                column: "BookClubsId",
                principalTable: "BookClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookClubGenre_Genres_GenresId",
                table: "BookClubGenre",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
