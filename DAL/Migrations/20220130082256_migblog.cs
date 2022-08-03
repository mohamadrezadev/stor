using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class migblog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image = table.Column<string>(nullable: true),
                    video = table.Column<string>(nullable: true),
                    titel = table.Column<string>(nullable: true),
                    intro = table.Column<string>(nullable: true),
                    text1 = table.Column<string>(nullable: true),
                    text2 = table.Column<string>(nullable: true),
                    text3 = table.Column<string>(nullable: true),
                    text4 = table.Column<string>(nullable: true),
                    foter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
