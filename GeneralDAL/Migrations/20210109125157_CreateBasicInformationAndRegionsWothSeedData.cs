using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class CreateBasicInformationAndRegionsWothSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicInformationCategory",
                schema: "Gnr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Viewable = table.Column<bool>(nullable: false),
                    RelatedCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicInformationCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicInformationCategory_BasicInformationCategory_RelatedCategoryId",
                        column: x => x.RelatedCategoryId,
                        principalSchema: "Gnr",
                        principalTable: "BasicInformationCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasicInformation",
                schema: "Gnr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    StrCode = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    RelatedBasicInformationId = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AllowChange = table.Column<bool>(nullable: false),
                    AllowDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicInformation_BasicInformationCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Gnr",
                        principalTable: "BasicInformationCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasicInformation_BasicInformation_RelatedBasicInformationId",
                        column: x => x.RelatedBasicInformationId,
                        principalSchema: "Gnr",
                        principalTable: "BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "Gnr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Region_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Gnr",
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Region_BasicInformation_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "Gnr",
                        principalTable: "BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformationCategory",
                columns: new[] { "Id", "Code", "Name", "RelatedCategoryId", "Viewable" },
                values: new object[] { 1, "RegionType", "نوع منطقه", null, false });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformation",
                columns: new[] { "Id", "Active", "AllowChange", "AllowDelete", "CategoryId", "Code", "IsDeleted", "Name", "Priority", "RelatedBasicInformationId", "StrCode" },
                values: new object[] { 1, true, false, false, 1, 1, false, "کشور", 1, null, "Country" });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformation",
                columns: new[] { "Id", "Active", "AllowChange", "AllowDelete", "CategoryId", "Code", "IsDeleted", "Name", "Priority", "RelatedBasicInformationId", "StrCode" },
                values: new object[] { 2, true, false, false, 1, 2, false, "استان", 2, null, "Province" });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "BasicInformation",
                columns: new[] { "Id", "Active", "AllowChange", "AllowDelete", "CategoryId", "Code", "IsDeleted", "Name", "Priority", "RelatedBasicInformationId", "StrCode" },
                values: new object[] { 3, true, false, false, 1, 3, false, "شهر", 3, null, "City" });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "Region",
                columns: new[] { "Id", "Code", "Name", "ParentId", "TypeId" },
                values: new object[] { 1, 98, "ایران", null, 1 });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "Region",
                columns: new[] { "Id", "Code", "Name", "ParentId", "TypeId" },
                values: new object[] { 2, 31, "اصفهان", 1, 2 });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "Region",
                columns: new[] { "Id", "Code", "Name", "ParentId", "TypeId" },
                values: new object[] { 3, 313, "اصفهان", 2, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_BasicInformation_CategoryId",
                schema: "Gnr",
                table: "BasicInformation",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicInformation_RelatedBasicInformationId",
                schema: "Gnr",
                table: "BasicInformation",
                column: "RelatedBasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicInformationCategory_RelatedCategoryId",
                schema: "Gnr",
                table: "BasicInformationCategory",
                column: "RelatedCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_ParentId",
                schema: "Gnr",
                table: "Region",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_TypeId",
                schema: "Gnr",
                table: "Region",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Region",
                schema: "Gnr");

            migrationBuilder.DropTable(
                name: "BasicInformation",
                schema: "Gnr");

            migrationBuilder.DropTable(
                name: "BasicInformationCategory",
                schema: "Gnr");
        }
    }
}
