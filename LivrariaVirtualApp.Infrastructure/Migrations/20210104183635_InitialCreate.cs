using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LivrariaVirtualApp.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    ISBN = table.Column<string>(maxLength: 20, nullable: false),
                    Parental_guide = table.Column<string>(maxLength: 3, nullable: true),
                    Language = table.Column<string>(maxLength: 45, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Available = table.Column<int>(nullable: false),
                    Realease_date = table.Column<DateTime>(nullable: false),
                    Publisher = table.Column<string>(maxLength: 100, nullable: false),
                    Pages = table.Column<string>(maxLength: 20, nullable: false),
                    Overview = table.Column<string>(maxLength: 256, nullable: false),
                    Image = table.Column<byte[]>(nullable: false),
                    Category_id = table.Column<int>(nullable: false),
                    CartId = table.Column<int>(nullable: true),
                    WishlistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_Category_id",
                        column: x => x.Category_id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 45, nullable: true),
                    Birth_date = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Admin = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<decimal>(nullable: false),
                    Date_created = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Shipping_address = table.Column<string>(nullable: false),
                    User_id = table.Column<int>(nullable: false),
                    Cart_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_Cart_id",
                        column: x => x.Cart_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    User_id = table.Column<int>(nullable: false),
                    Book_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    Subtotal = table.Column<decimal>(nullable: false),
                    User_id = table.Column<int>(nullable: false),
                    Book_id = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Admin", "Birth_date", "Email", "Name", "Password", "Phone" },
                values: new object[] { 1, 1, null, "admin@admin.com", "admin", "D033E22AE348AEB5660FC2140AEC35850C4DA997", null });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CartId",
                table: "Books",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Category_id",
                table: "Books",
                column: "Category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_WishlistId",
                table: "Books",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_OrderId",
                table: "Carts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Cart_id",
                table: "Orders",
                column: "Cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_User_id",
                table: "Wishlists",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Carts_CartId",
                table: "Books",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Wishlists_WishlistId",
                table: "Books",
                column: "WishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Carts_Id",
                table: "Users",
                column: "Id",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Carts_Id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
