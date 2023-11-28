using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_Net104_ShoppingCard.Migrations
{
    public partial class db06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "productVariants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "productVariants");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");
        }
    }
}
