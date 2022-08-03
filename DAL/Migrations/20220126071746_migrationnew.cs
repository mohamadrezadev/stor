using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class migrationnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cours_Deteilfiles_courss_coursid",
                table: "cours_Deteilfiles");

            migrationBuilder.DropIndex(
                name: "IX_cours_Deteilfiles_coursid",
                table: "cours_Deteilfiles");

            migrationBuilder.DropColumn(
                name: "coursid",
                table: "cours_Deteilfiles");

            migrationBuilder.AddColumn<int>(
                name: "courseId",
                table: "cours_Deteilfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cours_Deteilfiles_courseId",
                table: "cours_Deteilfiles",
                column: "courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_cours_Deteilfiles_courss_courseId",
                table: "cours_Deteilfiles",
                column: "courseId",
                principalTable: "courss",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cours_Deteilfiles_courss_courseId",
                table: "cours_Deteilfiles");

            migrationBuilder.DropIndex(
                name: "IX_cours_Deteilfiles_courseId",
                table: "cours_Deteilfiles");

            migrationBuilder.DropColumn(
                name: "courseId",
                table: "cours_Deteilfiles");

            migrationBuilder.AddColumn<int>(
                name: "coursid",
                table: "cours_Deteilfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cours_Deteilfiles_coursid",
                table: "cours_Deteilfiles",
                column: "coursid");

            migrationBuilder.AddForeignKey(
                name: "FK_cours_Deteilfiles_courss_coursid",
                table: "cours_Deteilfiles",
                column: "coursid",
                principalTable: "courss",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
