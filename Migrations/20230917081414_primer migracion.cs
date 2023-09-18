using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tp.Integrador.Softtek.Migrations
{
    public partial class primermigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    SeviceId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    HourValue = table.Column<decimal>(type: "MONEY", nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.SeviceId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Dni = table.Column<string>(type: "VARCHAR(9)", nullable: false),
                    Type = table.Column<short>(type: "SMALLINT", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    NumberOfHours = table.Column<int>(type: "INT", nullable: false),
                    HourValue = table.Column<decimal>(type: "MONEY", nullable: false),
                    Cost = table.Column<decimal>(type: "MONEY", nullable: false),
                    ProjectId = table.Column<int>(type: "INT", nullable: false),
                    ServiceId = table.Column<int>(type: "INT", nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Jobs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "SeviceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Address", "IsActive", "ProjectName", "Status" },
                values: new object[,]
                {
                    { 1, "Dirección 1", true, "Proyecto 1", (short)1 },
                    { 2, "Dirección 2", true, "Proyecto 2", (short)1 },
                    { 3, "Dirección 3", true, "Proyecto 3", (short)2 },
                    { 4, "Dirección 4", true, "Proyecto 4", (short)2 },
                    { 5, "Dirección 5", true, "Proyecto 5", (short)3 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "SeviceId", "Description", "HourValue", "IsActive" },
                values: new object[,]
                {
                    { 1, "Descripción 1", 25.87m, true },
                    { 2, "Descripción 2", 31.5m, true },
                    { 3, "Descripción 3", 12.41m, true },
                    { 4, "Descripción 4", 16.05m, true },
                    { 5, "Descripción 5", 8.79m, true },
                    { 6, "Descripción 6", 20.33m, true },
                    { 7, "Descripción 7", 13.5m, true },
                    { 8, "Descripción 8", 22.89m, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Dni", "IsActive", "Password", "Type", "UserName" },
                values: new object[,]
                {
                    { 1, "11111111", true, "123456", (short)1, "test Admin" },
                    { 2, "22222222", true, "123456", (short)2, "test User" },
                    { 3, "33333333", true, "123456", (short)2, "test otro User" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Cost", "HourValue", "IsActive", "JobDate", "NumberOfHours", "ProjectId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 138.6m, 19.8m, true, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 3, 1 },
                    { 2, 1257.6m, 26.2m, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 3, 2 },
                    { 3, 369.6m, 16.8m, true, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 3, 3 },
                    { 4, 396.9m, 18.9m, true, new DateTime(2016, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 4, 1 },
                    { 5, 718.75m, 31.25m, true, new DateTime(2017, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 4, 2 },
                    { 6, 338.28m, 28.19m, true, new DateTime(2019, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 5, 1 },
                    { 7, 387.47m, 29.89m, true, new DateTime(2018, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 5, 2 },
                    { 8, 722.88m, 30.12m, true, new DateTime(2017, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 3 },
                    { 9, 560.04m, 21.54m, true, new DateTime(2019, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 5, 4 },
                    { 10, 971.2m, 30.35m, true, new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 4, 3 },
                    { 11, 471.2m, 24.8m, true, new DateTime(2020, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 4, 4 },
                    { 12, 530.1m, 29.45m, true, new DateTime(2021, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 3, 4 },
                    { 13, 937.44m, 30.24m, true, new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ProjectId",
                table: "Jobs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ServiceId",
                table: "Jobs",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
