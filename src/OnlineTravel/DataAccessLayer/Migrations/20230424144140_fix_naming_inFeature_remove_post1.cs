using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class fix_naming_inFeature_remove_post1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Post1Name",
                table: "Features",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Post1Image",
                table: "Features",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Post1Description",
                table: "Features",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Features",
                newName: "Post1Name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Features",
                newName: "Post1Image");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Features",
                newName: "Post1Description");
        }
    }
}
