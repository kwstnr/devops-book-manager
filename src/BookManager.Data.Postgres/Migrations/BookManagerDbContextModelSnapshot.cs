﻿// <auto-generated />
using System;
using BookManager.Data.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookManager.Data.Postgres.Migrations
{
    [DbContext(typeof(BookManagerDbContext))]
    partial class BookManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uuid");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenre");

                    b.HasData(
                        new
                        {
                            BookId = new Guid("ec7611bb-a7cf-4af3-a81d-1cf231894dff"),
                            GenreId = new Guid("b2d0376b-3e47-461a-8ddf-e830eaf888e8")
                        },
                        new
                        {
                            BookId = new Guid("c5537ac1-76d6-452b-9a45-f6aca18d0e70"),
                            GenreId = new Guid("eb7f2840-b13e-4c62-ae44-b4d27ad1c251")
                        });
                });

            modelBuilder.Entity("BookManager.Domain.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("46b198cf-b755-474a-a9f3-7cc48280c29e"),
                            FirstName = "Eric",
                            LastName = "Evans"
                        },
                        new
                        {
                            Id = new Guid("6d8de046-82fa-4a5c-a5c4-5a94c4893b2e"),
                            FirstName = "Marc",
                            LastName = "Elsberg"
                        });
                });

            modelBuilder.Entity("BookManager.Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PageCount")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ec7611bb-a7cf-4af3-a81d-1cf231894dff"),
                            AuthorId = new Guid("46b198cf-b755-474a-a9f3-7cc48280c29e"),
                            Description = "Domain-Driven Design: Tackling Complexity in the Heart of Software is a book by Eric Evans.",
                            PageCount = 529,
                            Title = "Domain-Driven Design"
                        },
                        new
                        {
                            Id = new Guid("c5537ac1-76d6-452b-9a45-f6aca18d0e70"),
                            AuthorId = new Guid("6d8de046-82fa-4a5c-a5c4-5a94c4893b2e"),
                            Description = "Blackout is a techno-thriller novel by Marc Elsberg.",
                            PageCount = 416,
                            Title = "Blackout"
                        });
                });

            modelBuilder.Entity("BookManager.Domain.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b2d0376b-3e47-461a-8ddf-e830eaf888e8"),
                            Name = "Software Engineering"
                        },
                        new
                        {
                            Id = new Guid("eb7f2840-b13e-4c62-ae44-b4d27ad1c251"),
                            Name = "Fiction"
                        });
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("BookManager.Domain.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookManager.Domain.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookManager.Domain.Book", b =>
                {
                    b.HasOne("BookManager.Domain.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BookManager.Domain.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
