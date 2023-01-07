using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Repository.Migrations
{
    public partial class editCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "CartProducts",
                newName: "Quantity");

            migrationBuilder.AddColumn<double>(
                name: "TotalCost",
                table: "Carts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CartProducts",
                newName: "Count");
        }
    }
}
