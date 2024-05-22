using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeAnWebThongMinh.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Products");
        }
    }
}
