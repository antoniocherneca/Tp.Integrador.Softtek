using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tp.Integrador.Softtek.Migrations
{
    public partial class change_isActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Services",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Roles",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ProjectStatuses",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Projects",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Jobs",
                newName: "IsDeleted");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 6,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 7,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 8,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 9,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 10,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 11,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 12,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 13,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProjectStatuses",
                keyColumn: "ProjectStatusId",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProjectStatuses",
                keyColumn: "ProjectStatusId",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProjectStatuses",
                keyColumn: "ProjectStatusId",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 6,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 7,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 8,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "IsDeleted",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Users",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Services",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Roles",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProjectStatuses",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Projects",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Jobs",
                newName: "IsActive");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 6,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 7,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 8,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 9,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 10,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 11,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 12,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 13,
                column: "IsActive",
                value: true);

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
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 5,
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

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 6,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 7,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 8,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "IsActive",
                value: true);
        }
    }
}
