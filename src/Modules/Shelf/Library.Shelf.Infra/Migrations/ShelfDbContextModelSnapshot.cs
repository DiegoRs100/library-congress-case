﻿// <auto-generated />
using System;
using Library.Shelf.Infra.Databases.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Shelf.Infra.Migrations
{
    [DbContext(typeof(ShelfDbContext))]
    partial class ShelfDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.Rent.Domain.Books.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Shelf.Domain.Aggregates.Shelf", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("ShelfAggregate", (string)null);
                });

            modelBuilder.Entity("Library.Shelf.Domain.Entities.ShelfItems.ShelfItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("Decimal");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("ShelfId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ShelfId");

                    b.ToTable("ShelfItem", (string)null);
                });

            modelBuilder.Entity("Library.Shelf.Domain.Aggregates.Shelf", b =>
                {
                    b.OwnsOne("Library.Shelf.Domain.ValueObjects.Locations.Location", "Location", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<int>("Bookcase")
                                .HasColumnType("int");

                            b1.Property<int>("Hall")
                                .HasColumnType("int");

                            b1.Property<string>("Session")
                                .IsRequired()
                                .HasMaxLength(100)
                                .IsUnicode(false)
                                .HasColumnType("varchar(100)");

                            b1.Property<int>("Shelf")
                                .HasColumnType("int");

                            b1.Property<Guid>("ShelfId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("ShelfId")
                                .IsUnique();

                            b1.ToTable("Location", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ShelfId");
                        });

                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Shelf.Domain.Entities.ShelfItems.ShelfItem", b =>
                {
                    b.HasOne("Library.Shelf.Domain.Aggregates.Shelf", "Shelf")
                        .WithMany("Items")
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Library.Shelf.Domain.ValueObjects.Books.Book", "Book", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Author")
                                .IsRequired()
                                .HasMaxLength(100)
                                .IsUnicode(false)
                                .HasColumnType("varchar(100)");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(500)
                                .IsUnicode(false)
                                .HasColumnType("varchar(500)");

                            b1.Property<string>("Language")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(200)
                                .IsUnicode(false)
                                .HasColumnType("varchar(200)");

                            b1.Property<int>("Pages")
                                .HasColumnType("int");

                            b1.Property<DateTime>("PublicationAt")
                                .HasColumnType("datetime2");

                            b1.Property<string>("PublishingCompany")
                                .IsRequired()
                                .HasMaxLength(100)
                                .IsUnicode(false)
                                .HasColumnType("varchar(100)");

                            b1.Property<Guid>("ShelfItemId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("ShelfItemId")
                                .IsUnique();

                            b1.ToTable("Book", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ShelfItemId");
                        });

                    b.Navigation("Book")
                        .IsRequired();

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("Library.Shelf.Domain.Aggregates.Shelf", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
