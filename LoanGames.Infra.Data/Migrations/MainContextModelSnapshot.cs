﻿// <auto-generated />
using System;
using LoanGames.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoanGames.Infra.Data.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("LoanGames.Domain.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("LoanGames.Domain.Entities.Loan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateReturn")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Game_Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Person_Id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Game_Id");

                    b.HasIndex("Person_Id");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("LoanGames.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("LoanGames.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce6883ad-8ddb-4cbd-903a-f7a7ce13a928"),
                            Active = true,
                            Name = "Admin",
                            Password = "123456",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("LoanGames.Domain.Entities.Loan", b =>
                {
                    b.HasOne("LoanGames.Domain.Entities.Game", "Game")
                        .WithMany("Loans")
                        .HasForeignKey("Game_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoanGames.Domain.Entities.Person", "Person")
                        .WithMany("Loans")
                        .HasForeignKey("Person_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
