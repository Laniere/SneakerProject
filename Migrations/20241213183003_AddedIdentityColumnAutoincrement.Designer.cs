﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SneakerServer.Migrations
{
    [DbContext(typeof(SneakerContext))]
    [Migration("20241213183003_AddedIdentityColumnAutoincrement")]
    partial class AddedIdentityColumnAutoincrement
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SneakerServer.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            BrandId = 1,
                            Name = "Adidas"
                        },
                        new
                        {
                            BrandId = 2,
                            Name = "New Balance"
                        },
                        new
                        {
                            BrandId = 3,
                            Name = "Saucony"
                        },
                        new
                        {
                            BrandId = 4,
                            Name = "Asics"
                        },
                        new
                        {
                            BrandId = 5,
                            Name = "Timberland"
                        });
                });

            modelBuilder.Entity("SneakerServer.Models.Sneaker", b =>
                {
                    b.Property<int>("SneakerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SneakerId")
                        .HasName("PrimaryKey_SneakerId");

                    b.HasIndex("Model");

                    b.ToTable("Sneakers");
                });

            modelBuilder.Entity("SneakerServer.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastAccess")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.HasIndex("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SneakerServer.Models.Sneaker", b =>
                {
                    b.HasOne("SneakerServer.Models.Brand", "Brand")
                        .WithMany("Sneakers")
                        .HasForeignKey("SneakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("SneakerServer.Models.Brand", b =>
                {
                    b.Navigation("Sneakers");
                });
#pragma warning restore 612, 618
        }
    }
}