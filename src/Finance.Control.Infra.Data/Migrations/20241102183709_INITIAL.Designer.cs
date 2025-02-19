﻿// <auto-generated />
using System;
using Finance.Control.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Finance.Control.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241102183709_INITIAL")]
    partial class INITIAL
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Finance.Control.Domain.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppRole");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f39b093c-9887-4a86-bba5-48be3c1466e4"),
                            Name = "Administrator"
                        });
                });

            modelBuilder.Entity("Finance.Control.Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppRoleId");

                    b.ToTable("AppUser");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1e8b965f-a2ec-408b-a949-9f7fb137b3c4"),
                            AppRoleId = new Guid("f39b093c-9887-4a86-bba5-48be3c1466e4"),
                            Email = "admin@admin.com",
                            IsActive = true,
                            Name = "Admin",
                            PasswordHash = "$2a$11$Dek/UjfM88NP6dtESR0tTe05bClGjxbMY5fZM34NR9DvlMWr51aHW",
                            PasswordSalt = "$2a$11$Dek/UjfM88NP6dtESR0tTe"
                        });
                });

            modelBuilder.Entity("Finance.Control.Domain.Entities.AppUser", b =>
                {
                    b.HasOne("Finance.Control.Domain.Entities.AppRole", "Role")
                        .WithMany("appUsers")
                        .HasForeignKey("AppRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Finance.Control.Domain.Entities.AppRole", b =>
                {
                    b.Navigation("appUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
