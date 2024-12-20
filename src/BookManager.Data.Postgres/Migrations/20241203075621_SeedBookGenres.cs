using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookManager.Data.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class SeedBookGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("c5537ac1-76d6-452b-9a45-f6aca18d0e70"), new Guid("eb7f2840-b13e-4c62-ae44-b4d27ad1c251") },
                    { new Guid("ec7611bb-a7cf-4af3-a81d-1cf231894dff"), new Guid("b2d0376b-3e47-461a-8ddf-e830eaf888e8") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { new Guid("c5537ac1-76d6-452b-9a45-f6aca18d0e70"), new Guid("eb7f2840-b13e-4c62-ae44-b4d27ad1c251") });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { new Guid("ec7611bb-a7cf-4af3-a81d-1cf231894dff"), new Guid("b2d0376b-3e47-461a-8ddf-e830eaf888e8") });
        }
    }
}
