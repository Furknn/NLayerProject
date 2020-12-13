using Microsoft.EntityFrameworkCore.Migrations;

namespace NLayerProject.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Categories",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Categories", x => x.Id); });

            migrationBuilder.CreateTable(
                "Products",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>("decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    InnerBarcode = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        "FK_Products_Categories_CategoryId",
                        x => x.CategoryId,
                        "Categories",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                "Categories",
                new[] {"Id", "IsDeleted", "Name"},
                new object[] {1, false, "Kalemler"});

            migrationBuilder.InsertData(
                "Categories",
                new[] {"Id", "IsDeleted", "Name"},
                new object[] {2, false, "Defterler"});

            migrationBuilder.InsertData(
                "Products",
                new[] {"Id", "CategoryId", "InnerBarcode", "IsDeleted", "Name", "Price", "Stock"},
                new object[,]
                {
                    {1, 1, null, false, "Pilot Kalem", 12.50m, 100},
                    {2, 1, null, false, "Kurşun Kalem", 4.50m, 90},
                    {3, 1, null, false, "Tükenmez Kalem", 10.50m, 150},
                    {4, 2, null, false, "Küçük Kareli Defter", 14.99m, 60},
                    {5, 2, null, false, "Küçük Çizgili Defter", 14.99m, 60},
                    {6, 2, null, false, "Orta Kareli Defter", 19.99m, 60}
                });

            migrationBuilder.CreateIndex(
                "IX_Products_CategoryId",
                "Products",
                "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Products");

            migrationBuilder.DropTable(
                "Categories");
        }
    }
}