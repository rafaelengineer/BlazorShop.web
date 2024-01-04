using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorShop.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Category",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IconCSS = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Category", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "tb_User",
                columns: table => new
                {
                    userId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_User", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "tb_Product",
                columns: table => new
                {
                    productId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ImagemUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Manufacturer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtdInStock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Product", x => x.productId);
                    table.ForeignKey(
                        name: "FK_tb_Product_tb_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tb_Category",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_ShopCars",
                columns: table => new
                {
                    carId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    productId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ShopCars", x => x.carId);
                    table.ForeignKey(
                        name: "FK_tb_ShopCars_tb_Product_productId",
                        column: x => x.productId,
                        principalTable: "tb_Product",
                        principalColumn: "productId");
                    table.ForeignKey(
                        name: "FK_tb_ShopCars_tb_User_userId",
                        column: x => x.userId,
                        principalTable: "tb_User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_ShopItems",
                columns: table => new
                {
                    shopItemsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productId = table.Column<int>(type: "integer", nullable: false),
                    carId = table.Column<int>(type: "integer", nullable: false),
                    qtd = table.Column<int>(type: "integer", nullable: false),
                    shopCarcarId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ShopItems", x => x.shopItemsId);
                    table.ForeignKey(
                        name: "FK_tb_ShopItems_tb_Product_productId",
                        column: x => x.productId,
                        principalTable: "tb_Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_ShopItems_tb_ShopCars_shopCarcarId",
                        column: x => x.shopCarcarId,
                        principalTable: "tb_ShopCars",
                        principalColumn: "carId");
                });

            migrationBuilder.InsertData(
                table: "tb_Category",
                columns: new[] { "categoryId", "IconCSS", "Name" },
                values: new object[,]
                {
                    { 1, "fas fa-spa", "Beauty" },
                    { 2, "Bev fa-spa", "Beverages" },
                    { 3, "Auto fa-spa", "AutoParts" },
                    { 4, "fas fa-shoe-prints", "Shoes" },
                    { 5, "fas fa-couch", "Forniture" },
                    { 6, "fas fa-headphones", "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "tb_User",
                columns: new[] { "userId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "John Doe" },
                    { 2, "janedoe@example.com", "Jane Doe" },
                    { 3, "bobsmith@example.com", "Bob Smith" }
                });

            migrationBuilder.InsertData(
                table: "tb_Product",
                columns: new[] { "productId", "CategoryId", "Description", "ImagemUrl", "Manufacturer", "Name", "Price", "qtdInStock" },
                values: new object[,]
                {
                    { 1, 1, "Um kit fornecido pela Natura, contendo produtos para cuidados com a pele", "/Imagens/Beauty/Beleza1.png", null, "Glossier - Beauty Kit", 100m, 100 },
                    { 2, 1, "Um kit fornecido pela Curology, contendo produtos para cuidados com a pele", "/Imagens/Beauty/Beleza2.png", null, "Curology - Kit para Pele", 50m, 45 },
                    { 3, 1, "Um kit fornecido pela Glossier, contendo produtos para cuidados com a pele", "/Imagens/Beauty/Beleza3.png", null, "Óleo de Coco Orgânico", 20m, 30 },
                    { 4, 1, "Um kit fornecido pela Curology, contendo produtos para cuidados com a pele", "/Imagens/Beauty/Beleza4.png", null, "Schwarzkopf - Kit de cuidados com a pele e cabelo", 50m, 60 },
                    { 5, 1, "Kit de cuidados com a pele, contendo produtos para cuidados com a pele e cabelos", "/Imagens/Beauty/Beleza5.png", null, "Kit de cuidados com a pele", 30m, 85 },
                    { 6, 6, "Air Pods - fones de ouvido sem fio intra-auriculares", "/Imagens/Electronics/eletronico1.png", null, "Fones de ouvidos", 100m, 120 },
                    { 7, 6, "Fones de ouvido dourados na orelha - esses fones de ouvido não são sem fio", "/Imagens/Electronics/eletronico2.png", null, "Fones de ouvido dourados", 40m, 200 },
                    { 8, 6, "Fones de ouvido pretos na orelha - esses fones de ouvido não são sem fio", "/Imagens/Electronics/eletronico3.png", null, "Fones de ouvido pretos", 40m, 300 },
                    { 9, 6, "Câmera Digital Sennheiser - Câmera digital de alta qualidade fornecida pela Sennheiser - inclui tripé", "/Imagens/Electronics/eletronico4.png", null, "Câmera digital Sennheiser com tripé", 600m, 20 },
                    { 10, 6, "Canon Digital Camera - Câmera digital de alta qualidade fornecida pela Canon", "/Imagens/Electronics/eletronico5.png", null, "Câmera Digital Canon", 500m, 15 },
                    { 11, 6, "Gameboy - Fornecido por Nintendo", "/Imagens/Electronics/tecnologia6.png", null, "Nintendo Gameboy", 100m, 60 },
                    { 12, 5, "Cadeira de escritório em couro preto muito confortável", "/Imagens/Forniture/moveis1.png", null, "Cadeira de escritório de couro preto", 50m, 212 },
                    { 13, 5, "Cadeira de escritório em couro rosa muito confortável", "/Imagens/Forniture/moveis2.png", null, "Cadeira de escritório de couro rosa", 50m, 112 },
                    { 14, 5, "Poltrona muito confortável", "/Imagens/Forniture/moveis3.png", null, "Espreguiçadeira", 70m, 90 },
                    { 15, 5, "Poltrona prateada muito confortável", "/Imagens/Forniture/moveis4.png", null, "Silver Lounge Chair", 120m, 95 },
                    { 16, 5, "Abajur de mesa de porcelana branco e azul", "/Imagens/Forniture/moveis6.png", null, "Luminária de mesa de porcelana", 15m, 100 },
                    { 17, 5, "Abajur de mesa de escritório", "/Imagens/Forniture/moveis7.png", null, "Office Table Lamp", 20m, 73 },
                    { 18, 4, "Tênis Puma confortáveis na maioria dos tamanhos", "/Imagens/Shoes/calcado1.png", null, "Tênis Puma", 100m, 50 },
                    { 19, 4, "Tênis coloridos - disponíveis na maioria dos tamanhos", "/Imagens/Shoes/calcado2.png", null, "Tênis Colodiros", 150m, 60 },
                    { 20, 4, "Tênis Nike azul - disponível na maioria dos tamanhos", "/Imagens/Shoes/calcado3.png", null, "Tênis Nike Azul", 200m, 70 },
                    { 21, 4, "Treinadores Hummel coloridos - disponíveis na maioria dos tamanhos", "/Imagens/Shoes/calcado4.png", null, "Tênis Hummel Coloridos", 120m, 120 },
                    { 22, 4, "Tênis Nike vermelho - disponível na maioria dos tamanhos", "/Imagens/Shoes/calcado5.png", null, "Tênis Nike Vermelho", 200m, 100 },
                    { 23, 4, "Sandálias Birkenstock - disponíveis na maioria dos tamanhos", "/Imagens/Shoes/calcado6.png", null, "Sandálidas Birkenstock", 50m, 150 },
                    { 30, 1, "Small tires.", "/Imagens/AutoParts/AutoParts30.png", "Pirelle", "Tire_165'60'13R", 323m, 10 },
                    { 31, 1, "Sprt tire.", "/Imagens/AutoParts/AutoParts31.png", "Toyo", "Tire_220'90'19R", 550m, 11 },
                    { 32, 1, "windscreen wiper blade for Ford focus.", "/Imagens/AutoParts/AutoParts32.png", "ChinaCo", "windscreen_wiper_blade", 13.32m, 12 },
                    { 41, 1, "A long-lasting lipstick in a vibrant red color.", "/Imagens/Beauty/Beleza41.png", "BeautyCo", "Lipstick", 15.99m, 13 },
                    { 42, 1, "A waterproof mascara that adds volume and length to your lashes.", "/Imagens/Beauty/Beleza42.png", "BeautyCo", "Mascara", 12.99m, 14 },
                    { 43, 1, "A lightweight foundation that provides medium coverage for a natural look.", "/Imagens/Beauty/Beleza43.png", "BeautyCo", "Foundation", 20.99m, 15 },
                    { 44, 2, "Disgusting syrup.", "/Imagens/Beverages/Beverage20.png", "CocaCo", "CocaCola_600ml", 1.99m, 16 },
                    { 45, 2, "Just like beer, but only a sour-smelling drink. .", "/Imagens/Beverages/Beverage21.png", "HeinikenCo", "Heiniken_0%", 1.79m, 17 },
                    { 46, 2, "Sweet and dense beer.", "/Imagens/Beverages/Beverage23.png", "TresLobosCo", "Bäcker_trigo_600ml", 2.59m, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Product_CategoryId",
                table: "tb_Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ShopCars_productId",
                table: "tb_ShopCars",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ShopCars_userId",
                table: "tb_ShopCars",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_ShopItems_productId",
                table: "tb_ShopItems",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ShopItems_shopCarcarId",
                table: "tb_ShopItems",
                column: "shopCarcarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_ShopItems");

            migrationBuilder.DropTable(
                name: "tb_ShopCars");

            migrationBuilder.DropTable(
                name: "tb_Product");

            migrationBuilder.DropTable(
                name: "tb_User");

            migrationBuilder.DropTable(
                name: "tb_Category");
        }
    }
}
