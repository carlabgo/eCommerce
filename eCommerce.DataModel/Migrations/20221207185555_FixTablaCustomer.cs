using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class FixTablaCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoice_costumer_costumer_id",
                table: "invoice");

            migrationBuilder.DropTable(
                name: "costumer");

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(max)", nullable: false),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zipcode = table.Column<string>(name: "zip_code", type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<string>(name: "phone_number", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_invoice_customer_costumer_id",
                table: "invoice",
                column: "costumer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoice_customer_costumer_id",
                table: "invoice");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.CreateTable(
                name: "costumer",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<string>(name: "phone_number", type: "nvarchar(max)", nullable: false),
                    zipcode = table.Column<string>(name: "zip_code", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_costumer", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_invoice_costumer_costumer_id",
                table: "invoice",
                column: "costumer_id",
                principalTable: "costumer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
