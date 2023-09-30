﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tp.Integrador.Softtek.DataAccess;

#nullable disable

namespace Tp.Integrador.Softtek.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BIT");

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

                    b.HasData(
                        new
                        {
                            JobId = 1,
                            Cost = 138.6m,
                            HourValue = 19.8m,
                            IsDeleted = false,
                            JobDate = new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfHours = 7,
                            ProjectId = 3,
                            ServiceId = 1
                        },
                        new
                        {
                            JobId = 2,
                            Cost = 1257.6m,
                            HourValue = 26.2m,
                            IsDeleted = false,
                            JobDate = new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfHours = 18,
                            ProjectId = 3,
                            ServiceId = 2
                        },
                        new
                        {
                            JobId = 3,
                            Cost = 369.6m,
                            HourValue = 16.8m,
                            IsDeleted = false,
                            JobDate = new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfHours = 22,
                            ProjectId = 3,
                            ServiceId = 3
                        },
                        new
                        {
                            JobId = 4,
                            Cost = 396.9m,
                            HourValue = 18.9m,
                            IsDeleted = false,
                            JobDate = new DateTime(2016, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfHours = 21,
                            ProjectId = 4,
                            ServiceId = 1
                        },
                        new
                        {
                            JobId = 5,
                            Cost = 718.75m,
                            HourValue = 31.25m,
                            IsDeleted = false,
                            JobDate = new DateTime(2017, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfHours = 23,
                            ProjectId = 4,
                            ServiceId = 2
                        },
                        new
                        {
                            JobId = 6,
                            Cost = 338.28m,
                            HourValue = 28.19m,
                            IsDeleted = false,
                            JobDate = new DateTime(2019, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfHours = 12,
                            ProjectId = 5,
                            ServiceId = 1
                        },
                        new
                        {
                            JobId = 7,
                            Cost = 387.47m,
                            HourValue = 29.89m,
                            IsDeleted = false,
                            JobDate = new DateTime(2018, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfHours = 23,
                            ProjectId = 5,
                            ServiceId = 2
                        },
                        new
                        {
                            JobId = 8,
                            Cost = 722.88m,
                            HourValue = 30.12m,
                            IsDeleted = false,
                            JobDate = new DateTime(2017, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfHours = 24,
                            ProjectId = 5,
                            ServiceId = 3
                        },
                        new
                        {
                            JobId = 9,
                            Cost = 560.04m,
                            HourValue = 21.54m,
                            IsDeleted = false,
                            JobDate = new DateTime(2019, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfHours = 26,
                            ProjectId = 5,
                            ServiceId = 4
                        },
                        new
                        {
                            JobId = 10,
                            Cost = 971.2m,
                            HourValue = 30.35m,
                            IsDeleted = false,
                            JobDate = new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfHours = 32,
                            ProjectId = 4,
                            ServiceId = 3
                        },
                        new
                        {
                            JobId = 11,
                            Cost = 471.2m,
                            HourValue = 24.8m,
                            IsDeleted = false,
                            JobDate = new DateTime(2020, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfHours = 19,
                            ProjectId = 4,
                            ServiceId = 4
                        },
                        new
                        {
                            JobId = 12,
                            Cost = 530.1m,
                            HourValue = 29.45m,
                            IsDeleted = false,
                            JobDate = new DateTime(2021, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfHours = 18,
                            ProjectId = 3,
                            ServiceId = 4
                        },
                        new
                        {
                            JobId = 13,
                            Cost = 937.44m,
                            HourValue = 30.24m,
                            IsDeleted = false,
                            JobDate = new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfHours = 31,
                            ProjectId = 5,
                            ServiceId = 5
                        });
                });

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BIT");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("ProjectStatusId")
                        .HasColumnType("INT");

                    b.HasKey("ProjectId");

                    b.HasIndex("ProjectStatusId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            Address = "Dirección 1",
                            IsDeleted = false,
                            ProjectName = "Proyecto 1",
                            ProjectStatusId = 1
                        },
                        new
                        {
                            ProjectId = 2,
                            Address = "Dirección 2",
                            IsDeleted = false,
                            ProjectName = "Proyecto 2",
                            ProjectStatusId = 1
                        },
                        new
                        {
                            ProjectId = 3,
                            Address = "Dirección 3",
                            IsDeleted = false,
                            ProjectName = "Proyecto 3",
                            ProjectStatusId = 2
                        },
                        new
                        {
                            ProjectId = 4,
                            Address = "Dirección 4",
                            IsDeleted = false,
                            ProjectName = "Proyecto 4",
                            ProjectStatusId = 2
                        },
                        new
                        {
                            ProjectId = 5,
                            Address = "Dirección 5",
                            IsDeleted = false,
                            ProjectName = "Proyecto 5",
                            ProjectStatusId = 3
                        });
                });

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.ProjectStatus", b =>
                {
                    b.Property<int>("ProjectStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectStatusId"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BIT");

                    b.Property<string>("ProjectStatusName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("ProjectStatusId");

                    b.ToTable("ProjectStatuses");

                    b.HasData(
                        new
                        {
                            ProjectStatusId = 1,
                            IsDeleted = false,
                            ProjectStatusName = "Pendiente"
                        },
                        new
                        {
                            ProjectStatusId = 2,
                            IsDeleted = false,
                            ProjectStatusName = "Confirmado"
                        },
                        new
                        {
                            ProjectStatusId = 3,
                            IsDeleted = false,
                            ProjectStatusName = "Terminado"
                        });
                });

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BIT");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            IsDeleted = false,
                            RoleName = "Administrador"
                        },
                        new
                        {
                            RoleId = 2,
                            IsDeleted = false,
                            RoleName = "Consultor"
                        });
                });

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.Property<decimal>("HourValue")
                        .HasColumnType("MONEY");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BIT");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            ServiceId = 1,
                            Description = "Descripción 1",
                            HourValue = 25.87m,
                            IsDeleted = false
                        },
                        new
                        {
                            ServiceId = 2,
                            Description = "Descripción 2",
                            HourValue = 31.5m,
                            IsDeleted = false
                        },
                        new
                        {
                            ServiceId = 3,
                            Description = "Descripción 3",
                            HourValue = 12.41m,
                            IsDeleted = false
                        },
                        new
                        {
                            ServiceId = 4,
                            Description = "Descripción 4",
                            HourValue = 16.05m,
                            IsDeleted = false
                        },
                        new
                        {
                            ServiceId = 5,
                            Description = "Descripción 5",
                            HourValue = 8.79m,
                            IsDeleted = false
                        },
                        new
                        {
                            ServiceId = 6,
                            Description = "Descripción 6",
                            HourValue = 20.33m,
                            IsDeleted = false
                        },
                        new
                        {
                            ServiceId = 7,
                            Description = "Descripción 7",
                            HourValue = 13.5m,
                            IsDeleted = false
                        },
                        new
                        {
                            ServiceId = 8,
                            Description = "Descripción 8",
                            HourValue = 22.89m,
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("VARCHAR(9)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BIT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR(250)");

                    b.Property<int>("RoleId")
                        .HasColumnType("INT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Dni = "11111111",
                            Email = "jperez@gmail.com",
                            IsDeleted = false,
                            Password = "3d8fb61d411f3b764e6d3a0134afa7ace88b5608475522853f847e3115ddc1e3",
                            RoleId = 1,
                            UserName = "Juan Perez"
                        },
                        new
                        {
                            UserId = 2,
                            Dni = "22222222",
                            Email = "mlopez@gmail.com",
                            IsDeleted = false,
                            Password = "1b6eec4d5d6507ba4b936d2c4a8f33fc06c8b1236688fe46ba7f2d681b9180a2",
                            RoleId = 2,
                            UserName = "Maria Lopez"
                        },
                        new
                        {
                            UserId = 3,
                            Dni = "33333333",
                            Email = "pramirez@gmail.com",
                            IsDeleted = false,
                            Password = "f2a29e834c644fb43fdd2b69c67a3e0c9a9b6a060803d4ccc5e39746d4889f35",
                            RoleId = 2,
                            UserName = "Pedro Ramirez"
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

            modelBuilder.Entity("Tp.Integrador.Softtek.Entities.User", b =>
                {
                    b.HasOne("Tp.Integrador.Softtek.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
