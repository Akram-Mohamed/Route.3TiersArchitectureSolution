using Microsoft.EntityFrameworkCore.Migrations;

namespace Route._3TiersArchitecture.DAL.Data.Migrations
{
    public partial class ImageNameForEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Employees",
                newName: "ISActive");


            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ISActive",
                table: "Employees",
                newName: "IsActive");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
