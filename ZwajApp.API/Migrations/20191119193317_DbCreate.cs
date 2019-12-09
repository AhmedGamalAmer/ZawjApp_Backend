using Microsoft.EntityFrameworkCore.Migrations;

namespace ZwajApp.API.Migrations
{
    //بيبنى قاعده البيانات كامله
    //مع Id 20191023141249 بيعمل تاريخ لقاعده البيانات
    public partial class DbCreate : Migration
    {
        //Up تبنى الجدول
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    //اى حاجه يشوفها id يعتبره PK
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.id);
                });
        }
        //توقع Table
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}
