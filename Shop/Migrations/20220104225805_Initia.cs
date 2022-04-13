using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class Initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shopCartItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tovarid = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    ShopCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopCartItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_shopCartItem_Tovar_tovarid",
                        column: x => x.tovarid,
                        principalTable: "Tovar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shopCartItem_tovarid",
                table: "shopCartItem",
                column: "tovarid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shopCartItem");
        }
    }
}
