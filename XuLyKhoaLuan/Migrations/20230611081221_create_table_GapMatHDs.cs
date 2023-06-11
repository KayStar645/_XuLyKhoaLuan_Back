using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XuLyKhoaLuan.Migrations
{
    public partial class create_table_GapMatHDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GapMatHD",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    MaGV = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MaDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    ThoiGianBd = table.Column<DateTime>(type: "datetime", nullable: true),
                    ThoiGianKt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiaDiem = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GapMatHD", x => x.id);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "GapMatHD");
        }
    }
}
