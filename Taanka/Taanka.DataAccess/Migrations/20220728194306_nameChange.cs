using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taanka.DataAccess.Migrations
{
    public partial class nameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSuperAdmin",
                table: "Users",
                newName: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "IsSuperAdmin");
        }
    }
}
