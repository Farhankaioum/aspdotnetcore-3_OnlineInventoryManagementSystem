using Microsoft.EntityFrameworkCore.Migrations;

namespace XYZ.InventoryManagementSystem.Web.Migrations
{
    public partial class CompanyTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ChargeAmount = table.Column<decimal>(nullable: false),
                    VatCharge = table.Column<decimal>(nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    Currentcy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
