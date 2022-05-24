﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Data;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220523213307_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("LoserHamsterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOfPost")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WinnerHamsterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoserHamsterId");

                    b.HasIndex("WinnerHamsterId");

                    b.ToTable("Battle");
                });

            modelBuilder.Entity("Domain.Entities.Hamster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FavFood")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("Games")
                        .HasColumnType("int");

                    b.Property<string>("ImgName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Losses")
                        .HasColumnType("int");

                    b.Property<string>("Loves")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hamster");
                });

            modelBuilder.Entity("Domain.Entities.Battle", b =>
                {
                    b.HasOne("Domain.Entities.Hamster", "LoserHamster")
                        .WithMany("BattlesLost")
                        .HasForeignKey("LoserHamsterId");

                    b.HasOne("Domain.Entities.Hamster", "WinnerHamster")
                        .WithMany("BattlesWon")
                        .HasForeignKey("WinnerHamsterId");

                    b.Navigation("LoserHamster");

                    b.Navigation("WinnerHamster");
                });

            modelBuilder.Entity("Domain.Entities.Hamster", b =>
                {
                    b.Navigation("BattlesLost");

                    b.Navigation("BattlesWon");
                });
#pragma warning restore 612, 618
        }
    }
}