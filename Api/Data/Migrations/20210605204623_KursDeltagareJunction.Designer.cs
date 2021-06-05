﻿// <auto-generated />
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210605204623_KursDeltagareJunction")]
    partial class KursDeltagareJunction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Api.Entities.Deltagare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Efternamn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Epost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Förnamn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mobilnummer")
                        .HasColumnType("TEXT");

                    b.Property<int>("PostalCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StateProvince")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Deltagare");
                });

            modelBuilder.Entity("Api.Entities.Kurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kursbeskrivning")
                        .HasColumnType("TEXT");

                    b.Property<int>("Kurslängd")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kursnummer")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kurstitel")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nivå")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Kurser");
                });

            modelBuilder.Entity("Api.Entities.KursDeltagare", b =>
                {
                    b.Property<int>("KursId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeltagareId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KursId", "DeltagareId");

                    b.HasIndex("DeltagareId");

                    b.ToTable("KursDeltagare");
                });

            modelBuilder.Entity("Api.Entities.KursDeltagare", b =>
                {
                    b.HasOne("Api.Entities.Deltagare", "Deltagare")
                        .WithMany("KursDeltagare")
                        .HasForeignKey("DeltagareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Entities.Kurs", "Kurs")
                        .WithMany("KursDeltagare")
                        .HasForeignKey("KursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deltagare");

                    b.Navigation("Kurs");
                });

            modelBuilder.Entity("Api.Entities.Deltagare", b =>
                {
                    b.Navigation("KursDeltagare");
                });

            modelBuilder.Entity("Api.Entities.Kurs", b =>
                {
                    b.Navigation("KursDeltagare");
                });
#pragma warning restore 612, 618
        }
    }
}
