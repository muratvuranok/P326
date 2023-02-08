using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StateManagements.Models.Migrations
{
    /// <inheritdoc />
    public partial class Initialize08022023182756 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CartImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartImage",
                table: "Products");
        }
    }
}
