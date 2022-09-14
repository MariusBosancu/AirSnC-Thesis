using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirSnC.Migrations.ProductsDb
{
    public partial class Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productss",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Picture1 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Picture2 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Picture3 = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productss", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productss");
        }
    }
}
