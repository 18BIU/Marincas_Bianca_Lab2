using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marincas_Bianca_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class PublisherAdress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Publisher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Publisher");
        }
    }
}
