using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NovoUsoApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveItemAddressTableAndAddFieldsToItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Address_AddressId",
                table: "Item");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Item_AddressId",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Item",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Item",
                newName: "DurationDays");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Item",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Item",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "Item",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "Item",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Item",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Item",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Complement",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Item",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "DurationDays",
                table: "Item",
                newName: "AddressId");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Item",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Complement = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Neighborhood = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    State = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_AddressId",
                table: "Item",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Address_AddressId",
                table: "Item",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");
        }
    }
}
