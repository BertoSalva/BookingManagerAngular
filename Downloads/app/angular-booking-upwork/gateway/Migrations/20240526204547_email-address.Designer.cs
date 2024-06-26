﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gateway;

#nullable disable

namespace gateway.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20240526204547_email-address")]
    partial class emailaddress
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("gateway.BookingRequest", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestID"));

                    b.Property<int>("ChildID")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PreferredDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PsychologistID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestID");

                    b.HasIndex("ChildID");

                    b.HasIndex("ParentID");

                    b.HasIndex("PsychologistID");

                    b.ToTable("BookingRequest");
                });

            modelBuilder.Entity("gateway.Child", b =>
                {
                    b.Property<int>("ChildID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChildID"));

                    b.Property<string>("ChildName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChildID");

                    b.ToTable("Child");

                    b.HasData(
                        new
                        {
                            ChildID = 1,
                            ChildName = "Child 1"
                        },
                        new
                        {
                            ChildID = 2,
                            ChildName = "Child 2"
                        });
                });

            modelBuilder.Entity("gateway.Parent", b =>
                {
                    b.Property<int>("ParentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParentID"));

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParentID");

                    b.ToTable("Parent");

                    b.HasData(
                        new
                        {
                            ParentID = 1,
                            ParentName = "Parent 1"
                        },
                        new
                        {
                            ParentID = 2,
                            ParentName = "Parent 2"
                        });
                });

            modelBuilder.Entity("gateway.Psychologist", b =>
                {
                    b.Property<int>("PsychologistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PsychologistID"));

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PsychologistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PsychologistID");

                    b.ToTable("Psychologist");

                    b.HasData(
                        new
                        {
                            PsychologistID = 1,
                            PsychologistName = "Psychologist 1"
                        },
                        new
                        {
                            PsychologistID = 2,
                            PsychologistName = "Psychologist 2"
                        });
                });

            modelBuilder.Entity("gateway.BookingRequest", b =>
                {
                    b.HasOne("gateway.Child", "Child")
                        .WithMany()
                        .HasForeignKey("ChildID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gateway.Parent", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gateway.Psychologist", "Psychologist")
                        .WithMany()
                        .HasForeignKey("PsychologistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");

                    b.Navigation("Psychologist");
                });
#pragma warning restore 612, 618
        }
    }
}
