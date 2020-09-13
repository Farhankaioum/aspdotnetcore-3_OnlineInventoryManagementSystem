using Microsoft.EntityFrameworkCore.Migrations;

namespace XYZ.InventoryManagementSystem.Web.Migrations
{
    public partial class StatusColumnAddedInGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Groups",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Groups");
        }
    }
}
