using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taanka.DataAccess.Migrations
{
    public partial class OrderAndOrderDetailsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Orders");
        }
    }
}
