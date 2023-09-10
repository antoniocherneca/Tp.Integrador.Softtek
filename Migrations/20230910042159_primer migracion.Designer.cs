﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tp.Integrador.Softtek.DataAccess;

#nullable disable

namespace Tp.Integrador.Softtek.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230910042159_primer migracion")]
    partial class primermigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("HourValue")
                        .HasColumnType("MONEY");

                    b.Property<DateTime>("JobDate")
                        .HasColumnType("DATE");

                    b.Property<int>("NumberOfHours")
                        .HasColumnType("INT");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INT");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INT");

                    b.HasKey("JobId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("VARCHAR(100)");

                    b.Property<int>("ProjectStatusId")
                        .HasColumnType("INT");

                    b.HasKey("ProjectId");

                    b.HasIndex("ProjectStatusId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.ProjectStatus", b =>
                {
                    b.Property<int>("ProjectStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectStatusId"), 1L, 1);

                    b.Property<string>("ProjectStatusDescription")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("ProjectStatusId");

                    b.ToTable("ProjectStatuses");
                });

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.Service", b =>
                {
                    b.Property<int>("SeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeviceId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<decimal>("HourValue")
                        .HasColumnType("MONEY");

                    b.Property<bool>("ServiceStatus")
                        .HasColumnType("BIT");

                    b.HasKey("SeviceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("VARCHAR(9)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Type")
                        .HasColumnType("INT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Dni = "12356789",
                            Password = "123456",
                            Type = 1,
                            UserName = "test"
                        });
                });

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.Job", b =>
                {
                    b.HasOne("Tp.Integrador.Softtek.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tp.Integrador.Softtek.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.Project", b =>
                {
                    b.HasOne("Tp.Integrador.Softtek.Entities.ProjectStatus", "ProjectStatus")
                        .WithMany()
                        .HasForeignKey("ProjectStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
