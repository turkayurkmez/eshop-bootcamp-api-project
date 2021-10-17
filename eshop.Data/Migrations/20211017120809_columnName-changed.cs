using Microsoft.EntityFrameworkCore.Migrations;

namespace eshop.Data.Migrations
{
    public partial class columnNamechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedSate",
                table: "Products",
                newName: "CreatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Products",
                newName: "CreatedSate");
        }
    }
}
