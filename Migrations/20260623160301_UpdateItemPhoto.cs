using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoUsoApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "ItemPhoto");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ItemPhoto");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ItemPhoto",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "ItemPhoto");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "ItemPhoto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ItemPhoto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
