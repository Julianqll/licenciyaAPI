using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace licenciyaAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionNombreCampoImagen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Questions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Questions");
        }
    }
}
