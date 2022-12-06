using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
