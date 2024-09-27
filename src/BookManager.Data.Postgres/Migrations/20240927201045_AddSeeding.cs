using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookManager.Data.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.CreateTable(
                name: "BookGenreAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenreAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookGenreAssignments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenreAssignments_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("46b198cf-b755-474a-a9f3-7cc48280c29e"), "Eric", "Evans" },
                    { new Guid("6d8de046-82fa-4a5c-a5c4-5a94c4893b2e"), "Marc", "Elsberg" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b2d0376b-3e47-461a-8ddf-e830eaf888e8"), "Software Engineering" },
                    { new Guid("eb7f2840-b13e-4c62-ae44-b4d27ad1c251"), "Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "PageCount", "Title" },
                values: new object[,]
                {
                    { new Guid("c5537ac1-76d6-452b-9a45-f6aca18d0e70"), new Guid("6d8de046-82fa-4a5c-a5c4-5a94c4893b2e"), "Blackout is a techno-thriller novel by Austrian author Marc Elsberg. It was first published in 2012 in German as Blackout: Morgen ist es zu spät. The book deals with an entirely hypothetical blackout of the European electricity grid.", 416, "Blackout" },
                    { new Guid("ec7611bb-a7cf-4af3-a81d-1cf231894dff"), new Guid("46b198cf-b755-474a-a9f3-7cc48280c29e"), "Domain-Driven Design: Tackling Complexity in the Heart of Software is a book by Eric Evans that describes the approach to software development that aligns software design with an organization's business needs.", 529, "Domain-Driven Design" }
                });

            migrationBuilder.InsertData(
                table: "BookGenreAssignments",
                columns: new[] { "Id", "BookId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("0d8539bc-9ae8-402d-a24d-707dce1d7b1b"), new Guid("ec7611bb-a7cf-4af3-a81d-1cf231894dff"), new Guid("b2d0376b-3e47-461a-8ddf-e830eaf888e8") },
                    { new Guid("a425f7d4-6ec7-4eba-af20-811372cfb361"), new Guid("c5537ac1-76d6-452b-9a45-f6aca18d0e70"), new Guid("eb7f2840-b13e-4c62-ae44-b4d27ad1c251") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookGenreAssignments_BookId",
                table: "BookGenreAssignments",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenreAssignments_GenreId",
                table: "BookGenreAssignments",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenreAssignments");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c5537ac1-76d6-452b-9a45-f6aca18d0e70"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ec7611bb-a7cf-4af3-a81d-1cf231894dff"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b2d0376b-3e47-461a-8ddf-e830eaf888e8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("eb7f2840-b13e-4c62-ae44-b4d27ad1c251"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("46b198cf-b755-474a-a9f3-7cc48280c29e"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("6d8de046-82fa-4a5c-a5c4-5a94c4893b2e"));

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenresId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BooksId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresId",
                table: "BookGenre",
                column: "GenresId");
        }
    }
}
