using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Seuphone.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_provider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: false),
                    CNPJ = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    HouseNumber = table.Column<int>(nullable: false),
                    District = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_provider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    Password = table.Column<string>(maxLength: 60, nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Genre = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CPF = table.Column<string>(maxLength: 14, nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    HouseNumber = table.Column<int>(nullable: false),
                    District = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    Storage = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    StockQuantity = table.Column<int>(nullable: false),
                    Image = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    ProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_product_tb_provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "tb_provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    ContractDuration = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    OrderType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_order_tb_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_user_role",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user_role", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_tb_user_role_tb_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tb_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_user_role_tb_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_order_items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_order_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_order_items_tb_order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "tb_order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_order_items_tb_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tb_product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_UserId",
                table: "tb_order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_items_OrderId",
                table: "tb_order_items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_items_ProductId",
                table: "tb_order_items",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_product_ProviderId",
                table: "tb_product",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_CPF",
                table: "tb_user",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_Email",
                table: "tb_user",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_role_RoleId",
                table: "tb_user_role",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_order_items");

            migrationBuilder.DropTable(
                name: "tb_user_role");

            migrationBuilder.DropTable(
                name: "tb_order");

            migrationBuilder.DropTable(
                name: "tb_product");

            migrationBuilder.DropTable(
                name: "tb_role");

            migrationBuilder.DropTable(
                name: "tb_user");

            migrationBuilder.DropTable(
                name: "tb_provider");
        }
    }
}
