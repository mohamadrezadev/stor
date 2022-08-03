using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ordermig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "totalpric",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<bool>(
                name: "statustpayment",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "statustpayment",
                table: "Orders");

            migrationBuilder.AlterColumn<float>(
                name: "totalpric",
                table: "Orders",
                type: "real",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
