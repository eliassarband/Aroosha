using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class SMSMadule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMSTemplate",
                schema: "Gnr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Query = table.Column<string>(maxLength: 4000, nullable: true),
                    TemplateText = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SMSMessage",
                schema: "Gnr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMSTemplateId = table.Column<int>(nullable: true),
                    SMSMessageText = table.Column<string>(maxLength: 4000, nullable: true),
                    ReceiverMobile = table.Column<string>(maxLength: 20, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    RegisterDateTime = table.Column<DateTime>(nullable: false),
                    FetchDateTime = table.Column<DateTime>(nullable: false),
                    SendDateTime = table.Column<DateTime>(nullable: false),
                    DeliveryDateTime = table.Column<DateTime>(nullable: false),
                    TrackingNumber = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMSMessage_SMSTemplate_SMSTemplateId",
                        column: x => x.SMSTemplateId,
                        principalSchema: "Gnr",
                        principalTable: "SMSTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SMSMessage_SMSTemplateId",
                schema: "Gnr",
                table: "SMSMessage",
                column: "SMSTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SMSMessage",
                schema: "Gnr");

            migrationBuilder.DropTable(
                name: "SMSTemplate",
                schema: "Gnr");
        }
    }
}
