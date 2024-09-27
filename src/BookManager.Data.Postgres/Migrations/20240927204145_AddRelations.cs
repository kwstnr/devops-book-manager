using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManager.Data.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c5537ac1-76d6-452b-9a45-f6aca18d0e70"),
                column: "Description",
                value: "Blackout is a techno-thriller novel by Marc Elsberg.");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ec7611bb-a7cf-4af3-a81d-1cf231894dff"),
                column: "Description",
                value: "Domain-Driven Design: Tackling Complexity in the Heart of Software is a book by Eric Evans.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c5537ac1-76d6-452b-9a45-f6aca18d0e70"),
                column: "Description",
                value: "Blackout is a techno-thriller novel by Austrian author Marc Elsberg. It was first published in 2012 in German as Blackout: Morgen ist es zu spät. The book deals with an entirely hypothetical blackout of the European electricity grid.");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ec7611bb-a7cf-4af3-a81d-1cf231894dff"),
                column: "Description",
                value: "Domain-Driven Design: Tackling Complexity in the Heart of Software is a book by Eric Evans that describes the approach to software development that aligns software design with an organization's business needs.");
        }
    }
}
