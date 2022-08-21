using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class TariffTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tariff",
                schema: "Mrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Formula = table.Column<string>(maxLength: 200, nullable: true),
                    StartDate = table.Column<string>(maxLength: 10, nullable: true),
                    EndDate = table.Column<string>(maxLength: 10, nullable: true),
                    RentAmount = table.Column<int>(nullable: false),
                    ReserveAmount = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariff", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tariff",
                schema: "Mrk");
        }
    }
}
