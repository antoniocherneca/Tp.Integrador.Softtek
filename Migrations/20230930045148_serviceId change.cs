using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tp.Integrador.Softtek.Migrations
{
    public partial class serviceIdchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeviceId",
                table: "Services",
                newName: "ServiceId");

            migrationBuilder.UpdateData(
                table: "ProjectStatuses",
                keyColumn: "ProjectStatusId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProjectStatuses",
                keyColumn: "ProjectStatusId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProjectStatuses",
                keyColumn: "ProjectStatusId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Services",
                newName: "SeviceId");

            migrationBuilder.UpdateData(
                table: "ProjectStatuses",
                keyColumn: "ProjectStatusId",
                keyValue: 1,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProjectStatuses",
                keyColumn: "ProjectStatusId",
                keyValue: 2,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProjectStatuses",
                keyColumn: "ProjectStatusId",
                keyValue: 3,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "IsActive",
                value: false);
        }
    }
}
