﻿// <auto-generated />
using System;
using Konyvtar.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Konyvtar.Migrations
{
    [DbContext(typeof(KonyvtarContext))]
    [Migration("20240207090037_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Konyvtar.Model.Kolcsonzes", b =>
                {
                    b.Property<int>("KolcsonzesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Elvitel")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("KonyvID")
                        .HasColumnType("int");

                    b.Property<int?>("TanuloID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Visszahozas")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Visszahozta")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("KolcsonzesID");

                    b.HasIndex("KonyvID");

                    b.HasIndex("TanuloID");

                    b.ToTable("Kolcsonzes");
                });

            modelBuilder.Entity("Konyvtar.Model.Konyv", b =>
                {
                    b.Property<int>("KonyvID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cim")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Oldalszam")
                        .HasColumnType("int");

                    b.Property<int?>("Pontszam")
                        .HasColumnType("int");

                    b.Property<int?>("SzerzoID")
                        .HasColumnType("int");

                    b.Property<int?>("TipusID")
                        .HasColumnType("int");

                    b.HasKey("KonyvID");

                    b.HasIndex("SzerzoID");

                    b.HasIndex("TipusID");

                    b.ToTable("Konyv");

                    b.HasData(
                        new
                        {
                            KonyvID = 1,
                            Cim = "Ember a fellegvárban",
                            Oldalszam = 550,
                            Pontszam = 9,
                            SzerzoID = 2,
                            TipusID = 1
                        },
                        new
                        {
                            KonyvID = 2,
                            Cim = "Egri Csillagok",
                            Oldalszam = 520,
                            Pontszam = 6,
                            SzerzoID = 3,
                            TipusID = 3
                        });
                });

            modelBuilder.Entity("Konyvtar.Model.Szerzo", b =>
                {
                    b.Property<int>("szerzoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Keresztnev")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Vezeteknev")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("szerzoID");

                    b.ToTable("Szerzo");

                    b.HasData(
                        new
                        {
                            szerzoID = 1,
                            Keresztnev = "Isaac",
                            Vezeteknev = "Asimov"
                        },
                        new
                        {
                            szerzoID = 2,
                            Keresztnev = "Dick",
                            Vezeteknev = "Philip"
                        },
                        new
                        {
                            szerzoID = 3,
                            Keresztnev = "Géza",
                            Vezeteknev = "Gárdonyi"
                        });
                });

            modelBuilder.Entity("Konyvtar.Model.Tanulo", b =>
                {
                    b.Property<int>("TanuloID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Keresztnev")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("No")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Osztaly")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("SzulDatum")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Vezeteknev")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TanuloID");

                    b.ToTable("Tanulo");
                });

            modelBuilder.Entity("Konyvtar.Model.Tipus", b =>
                {
                    b.Property<int>("TipusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nev")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TipusID");

                    b.ToTable("Tipus");

                    b.HasData(
                        new
                        {
                            TipusID = 1,
                            Nev = "Sci-Fi"
                        },
                        new
                        {
                            TipusID = 2,
                            Nev = "Fantasy"
                        },
                        new
                        {
                            TipusID = 3,
                            Nev = "Documentary"
                        });
                });

            modelBuilder.Entity("Konyvtar.Model.Kolcsonzes", b =>
                {
                    b.HasOne("Konyvtar.Model.Konyv", "Konyv")
                        .WithMany("Kolcsonzesek")
                        .HasForeignKey("KonyvID");

                    b.HasOne("Konyvtar.Model.Tanulo", "Tanulo")
                        .WithMany("Kolcsonzesek")
                        .HasForeignKey("TanuloID");

                    b.Navigation("Konyv");

                    b.Navigation("Tanulo");
                });

            modelBuilder.Entity("Konyvtar.Model.Konyv", b =>
                {
                    b.HasOne("Konyvtar.Model.Szerzo", "Szerzo")
                        .WithMany("Konyvek")
                        .HasForeignKey("SzerzoID");

                    b.HasOne("Konyvtar.Model.Tipus", "Tipus")
                        .WithMany()
                        .HasForeignKey("TipusID");

                    b.Navigation("Szerzo");

                    b.Navigation("Tipus");
                });

            modelBuilder.Entity("Konyvtar.Model.Konyv", b =>
                {
                    b.Navigation("Kolcsonzesek");
                });

            modelBuilder.Entity("Konyvtar.Model.Szerzo", b =>
                {
                    b.Navigation("Konyvek");
                });

            modelBuilder.Entity("Konyvtar.Model.Tanulo", b =>
                {
                    b.Navigation("Kolcsonzesek");
                });
#pragma warning restore 612, 618
        }
    }
}
