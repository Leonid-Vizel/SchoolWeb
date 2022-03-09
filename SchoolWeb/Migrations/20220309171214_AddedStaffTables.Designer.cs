﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolWeb.Data;

#nullable disable

namespace SchoolWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220309171214_AddedStaffTables")]
    partial class AddedStaffTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SchoolWeb.Models.Administration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SchoolAdministration");
                });

            modelBuilder.Entity("SchoolWeb.Models.EgeResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Biology")
                        .HasColumnType("real");

                    b.Property<float>("Chemistry")
                        .HasColumnType("real");

                    b.Property<float>("English")
                        .HasColumnType("real");

                    b.Property<float>("Geography")
                        .HasColumnType("real");

                    b.Property<float>("History")
                        .HasColumnType("real");

                    b.Property<float>("Informatics")
                        .HasColumnType("real");

                    b.Property<float>("Literature")
                        .HasColumnType("real");

                    b.Property<float>("MathBase")
                        .HasColumnType("real");

                    b.Property<float>("MathProfi")
                        .HasColumnType("real");

                    b.Property<float>("Physics")
                        .HasColumnType("real");

                    b.Property<float>("Russian")
                        .HasColumnType("real");

                    b.Property<float>("SocialStudies")
                        .HasColumnType("real");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EgeResults");
                });

            modelBuilder.Entity("SchoolWeb.Models.OgeResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Biology")
                        .HasColumnType("real");

                    b.Property<float>("Chemistry")
                        .HasColumnType("real");

                    b.Property<float>("English")
                        .HasColumnType("real");

                    b.Property<float>("Geography")
                        .HasColumnType("real");

                    b.Property<float>("History")
                        .HasColumnType("real");

                    b.Property<float>("Informatics")
                        .HasColumnType("real");

                    b.Property<float>("Math")
                        .HasColumnType("real");

                    b.Property<float>("Physics")
                        .HasColumnType("real");

                    b.Property<float>("Russian")
                        .HasColumnType("real");

                    b.Property<float>("SocialStudies")
                        .HasColumnType("real");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OgeResults");
                });

            modelBuilder.Entity("SchoolWeb.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HasFirstQuality")
                        .HasColumnType("int");

                    b.Property<int>("HasHighEdu")
                        .HasColumnType("int");

                    b.Property<int>("HasHighQuality")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SchoolStaff");
                });
#pragma warning restore 612, 618
        }
    }
}
