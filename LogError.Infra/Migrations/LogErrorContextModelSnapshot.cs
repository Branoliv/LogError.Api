﻿// <auto-generated />
using System;
using LogError.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogError.Infra.Migrations
{
    [DbContext(typeof(LogErrorContext))]
    partial class LogErrorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LogError.Domain.Entities.LogDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnName("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LogInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LogInfoId");

                    b.ToTable("LogDetail");
                });

            modelBuilder.Entity("LogError.Domain.Entities.LogInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnName("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnName("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TokenSource")
                        .IsRequired()
                        .HasColumnName("TokenSource")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LogInfo");
                });

            modelBuilder.Entity("LogError.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LogError.Domain.Entities.LogDetail", b =>
                {
                    b.HasOne("LogError.Domain.Entities.LogInfo", "LogInfo")
                        .WithMany("LogDetails")
                        .HasForeignKey("LogInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
