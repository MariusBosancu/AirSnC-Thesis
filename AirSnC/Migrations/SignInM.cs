using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirSnC.Migrations
{
    public partial class InitianCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SingIns",
                columns: table => new
                {
                    UserType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingIns", x => x.Username);
                });
            //migrationBuilder.CreateTable(
            //    name: "Products",
            //    columns: table => new
            //    {
            //        Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
            //        Price = table.Column<string>(type: "nvarchar(50)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(50)", nullable: false),
            //        Picture1 = table.Column<string>(type: "nvarchar(50)", nullable: false),
            //        Picture2 = table.Column<string>(type: "nvarchar(50)", nullable: false),
            //        Picture3 = table.Column<string>(type: "nvarchar(50)", nullable: false)
            //    },
            //    constraints: table=>
            //    {
            //        table.PrimaryKey("PK_Products", x => x.Name);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SingIns");
        }
    }
}
