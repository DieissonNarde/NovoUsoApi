using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NovoUsoApi.Migrations
{
    /// <inheritdoc />
    public partial class FixModelErrors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_OwnerId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemAgreement_Bid_WinningBidId",
                table: "ItemAgreement");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemAgreement_Item_ItemId",
                table: "ItemAgreement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemAgreement",
                table: "ItemAgreement");

            migrationBuilder.RenameColumn(
                name: "WinningBidId",
                table: "ItemAgreement",
                newName: "BidId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemAgreement_WinningBidId",
                table: "ItemAgreement",
                newName: "IX_ItemAgreement_BidId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Item",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_OwnerId",
                table: "Item",
                newName: "IX_Item_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ItemAgreement",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemAgreement",
                table: "ItemAgreement",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemAgreement_ItemId",
                table: "ItemAgreement",
                column: "ItemId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_UserId",
                table: "Item",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemAgreement_Bid_BidId",
                table: "ItemAgreement",
                column: "BidId",
                principalTable: "Bid",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemAgreement_Item_ItemId",
                table: "ItemAgreement",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Address_AddressId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_UserId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemAgreement_Bid_BidId",
                table: "ItemAgreement");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemAgreement_Item_ItemId",
                table: "ItemAgreement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemAgreement",
                table: "ItemAgreement");

            migrationBuilder.DropIndex(
                name: "IX_ItemAgreement_ItemId",
                table: "ItemAgreement");

            migrationBuilder.DropIndex(
                name: "IX_Item_AddressId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemAgreement");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "BidId",
                table: "ItemAgreement",
                newName: "WinningBidId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemAgreement_BidId",
                table: "ItemAgreement",
                newName: "IX_ItemAgreement_WinningBidId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Item",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_UserId",
                table: "Item",
                newName: "IX_Item_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemAgreement",
                table: "ItemAgreement",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_OwnerId",
                table: "Item",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemAgreement_Bid_WinningBidId",
                table: "ItemAgreement",
                column: "WinningBidId",
                principalTable: "Bid",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemAgreement_Item_ItemId",
                table: "ItemAgreement",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
