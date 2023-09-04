using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WishVine.Server.Migrations
{
    /// <inheritdoc />
    public partial class wishlistfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WishLists",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ItemCount",
                table: "WishLists",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "NewItems",
                table: "WishLists",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "WishLists");

            migrationBuilder.DropColumn(
                name: "ItemCount",
                table: "WishLists");

            migrationBuilder.DropColumn(
                name: "NewItems",
                table: "WishLists");
        }
    }
}
