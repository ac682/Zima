﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zima.Data;

namespace Zima.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200119113249_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Zima.Data.Packet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Dependencies")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("char(36)");

                    b.Property<long>("UploadDate")
                        .HasColumnType("bigint");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProjectId");

                    b.ToTable("Packets");
                });

            modelBuilder.Entity("Zima.Data.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LatestVersionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("OperationKey")
                        .IsRequired()
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("LatestVersionId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Zima.Data.Packet", b =>
                {
                    b.HasOne("Zima.Data.Project", "Project")
                        .WithMany("Versions")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Zima.Data.Project", b =>
                {
                    b.HasOne("Zima.Data.Packet", "LatestVersion")
                        .WithMany()
                        .HasForeignKey("LatestVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
