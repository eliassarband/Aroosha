using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class PCPosSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PCPosSetting",
                schema: "Gnr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerName = table.Column<string>(maxLength: 100, nullable: true),
                    PosType = table.Column<string>(maxLength: 50, nullable: true),
                    ConnectionType = table.Column<string>(maxLength: 20, nullable: true),
                    IPAddress = table.Column<string>(maxLength: 20, nullable: true),
                    PortNumber = table.Column<int>(nullable: false),
                    ComPortName = table.Column<string>(maxLength: 20, nullable: true),
                    ComBaudRate = table.Column<int>(nullable: false),
                    ConnectionTimeout = table.Column<int>(nullable: false),
                    ResponceTimeout = table.Column<int>(nullable: false),
                    OptionalData = table.Column<string>(maxLength: 200, nullable: true),
                    TerminalSerialID = table.Column<string>(maxLength: 50, nullable: true),
                    AcceptorID = table.Column<string>(maxLength: 50, nullable: true),
                    TerminalID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCPosSetting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PCPosSetting",
                schema: "Gnr");
        }
    }
}
