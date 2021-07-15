﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using vhec.SkillInventory.DAL.DataContext;

namespace vhec.SkillInventory.DAL.Migrations
{
    [DbContext(typeof(SkillIManagerDbContext))]
    [Migration("20210714222809_DbV3")]
    partial class DbV3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("vhec.SkillInventory.DAL.Entities.DetailSkill", b =>
                {
                    b.Property<int>("IdDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid>("EmployeeID")
                        .HasColumnType("uuid");

                    b.Property<int>("SkillID")
                        .HasColumnType("integer");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.HasKey("IdDetail", "EmployeeID", "SkillID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("SkillID");

                    b.ToTable("detailSkills");
                });

            modelBuilder.Entity("vhec.SkillInventory.DAL.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DayCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<int>("JobPosition")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("vhec.SkillInventory.DAL.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DayCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("skills");
                });

            modelBuilder.Entity("vhec.SkillInventory.DAL.Entities.DetailSkill", b =>
                {
                    b.HasOne("vhec.SkillInventory.DAL.Entities.Employee", "Employee")
                        .WithMany("detailSkills")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vhec.SkillInventory.DAL.Entities.Skill", "Skill")
                        .WithMany("detailSkills")
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("vhec.SkillInventory.DAL.Entities.Employee", b =>
                {
                    b.Navigation("detailSkills");
                });

            modelBuilder.Entity("vhec.SkillInventory.DAL.Entities.Skill", b =>
                {
                    b.Navigation("detailSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
