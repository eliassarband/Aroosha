using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralDAL.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sec");

            migrationBuilder.EnsureSchema(
                name: "Gnr");

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Gnr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    StrCode = table.Column<string>(maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                schema: "Gnr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenant_Tenant_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Gnr",
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuCategory",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    ShowInMenu = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(maxLength: 60, nullable: true),
                    HashPassword = table.Column<string>(maxLength: 60, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    ForceFirstLoginChange = table.Column<bool>(nullable: false),
                    PasswordHint = table.Column<string>(maxLength: 200, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Gnr",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "Gnr",
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    ControllerName = table.Column<string>(maxLength: 50, nullable: true),
                    ActionName = table.Column<string>(maxLength: 50, nullable: true),
                    ShowInMenu = table.Column<bool>(nullable: false),
                    DialogSize = table.Column<string>(maxLength: 20, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_MenuCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Sec",
                        principalTable: "MenuCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupUser",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupUser_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Sec",
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Sec",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginAttempt",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    Username = table.Column<string>(maxLength: 60, nullable: true),
                    Logined = table.Column<bool>(nullable: false),
                    LoginResult = table.Column<string>(maxLength: 200, nullable: true),
                    Date = table.Column<string>(maxLength: 10, nullable: true),
                    Time = table.Column<string>(maxLength: 8, nullable: true),
                    DeviceName = table.Column<string>(maxLength: 100, nullable: true),
                    ClientIPAddr = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAttempt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginAttempt_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Sec",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoginedData",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    Date = table.Column<string>(maxLength: 10, nullable: true),
                    Time = table.Column<string>(maxLength: 8, nullable: true),
                    DeviceName = table.Column<string>(maxLength: 100, nullable: true),
                    ClientIPAddr = table.Column<string>(maxLength: 20, nullable: true),
                    LogoutDate = table.Column<string>(maxLength: 10, nullable: true),
                    LogoutTime = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginedData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginedData_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Sec",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuAccess",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuAccess_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalSchema: "Sec",
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuAccess_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Sec",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuAction",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    ShowInToolbar = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    MenuItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuAction_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalSchema: "Sec",
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuActionAccess",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuActionId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuActionAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuActionAccess_MenuAction_MenuActionId",
                        column: x => x.MenuActionId,
                        principalSchema: "Sec",
                        principalTable: "MenuAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuActionAccess_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Sec",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "Person",
                columns: new[] { "Id", "Active", "Code", "FirstName", "LastName", "StrCode" },
                values: new object[] { 1, true, 1, "مدیر", "سیستم", "1" });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "Tenant",
                columns: new[] { "Id", "Code", "Name", "ParentId" },
                values: new object[] { 1, 1, "سازمان میادین میوه و تره بار و ساماندهی مشاغل شهری شهرداری اصفهان", null });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "Group",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "مدیر سیستم" },
                    { 2, "کاربران عمومی" }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuCategory",
                columns: new[] { "Id", "Name", "Priority", "ShowInMenu" },
                values: new object[] { 1, "مدریریت کاربران", 2, true });

            migrationBuilder.InsertData(
                schema: "Gnr",
                table: "Tenant",
                columns: new[] { "Id", "Code", "Name", "ParentId" },
                values: new object[] { 2, 2, "جمعه بازار بعثت", 1 });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuItem",
                columns: new[] { "Id", "ActionName", "CategoryId", "Code", "ControllerName", "DialogSize", "Name", "Priority", "ShowInMenu" },
                values: new object[,]
                {
                    { 1, "Users", 1, "Users", "Security", "medium", "تعریف کاربران", 2, true },
                    { 2, "UserDefine", 1, "UserDefine", "Security", "medium", "ایجاد و ویرایش کاربران", 3, false },
                    { 3, "Groups", 1, "Groups", "Security", "medium", "تعریف گروه‌های کاربری", 3, true },
                    { 4, "GroupDefine", 1, "GroupDefine", "Security", "small", "ایجاد و ویرایش گروه‌های کاربری", 4, false },
                    { 5, "GroupUsers", 1, "GroupUsers", "Security", "medium", "ایجاد و ویرایش اعضای گروه‌", 5, false }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "User",
                columns: new[] { "Id", "Active", "ForceFirstLoginChange", "HashPassword", "PasswordHint", "PersonId", "TenantId", "Username" },
                values: new object[] { 1, true, false, "65bb559e8ed079554da6b55d4b6fec00", "nothing", 1, 1, "admin" });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "GroupUser",
                columns: new[] { "Id", "GroupId", "UserId" },
                values: new object[,]
                {
                    { 2, 2, 1 },
                    { 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAccess",
                columns: new[] { "Id", "MenuItemId", "UserId" },
                values: new object[,]
                {
                    { 5, 5, 1 },
                    { 3, 3, 1 },
                    { 2, 2, 1 },
                    { 1, 1, 1 },
                    { 4, 4, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuAction",
                columns: new[] { "Id", "MenuItemId", "Name", "Priority", "ShowInToolbar", "Title" },
                values: new object[,]
                {
                    { 15, 5, "Add", 1, true, "اضافه کردن" },
                    { 13, 4, "SaveAndContinue", 4, true, "ذخیره و ادامه" },
                    { 14, 4, "SaveAndNew", 3, true, "ذخیره و جدید" },
                    { 12, 4, "Save", 2, true, "ذخیره" },
                    { 11, 4, "GroupUsers", 1, true, "انتخاب اعضای گروه" },
                    { 9, 3, "Delete", 3, true, "حذف گروه" },
                    { 8, 3, "Edit", 2, true, "ویرایش گروه" },
                    { 7, 3, "New", 1, true, "تعریف گروه جدید" },
                    { 5, 2, "SaveAndNew", 3, true, "ذخیره و جدید" },
                    { 6, 2, "SaveAndContinue", 2, true, "ذخیره و ادامه" },
                    { 4, 2, "Save", 1, true, "ذخیره" },
                    { 3, 1, "Delete", 3, true, "حذف کاربر" },
                    { 2, 1, "Edit", 2, true, "ویرایش کاربر" },
                    { 10, 3, "GroupUsers", 4, true, "انتخاب اعضای گروه" },
                    { 1, 1, "New", 1, true, "تعریف کاربر جدید" }
                });

            migrationBuilder.InsertData(
                schema: "Sec",
                table: "MenuActionAccess",
                columns: new[] { "Id", "MenuActionId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 6, 6, 1 },
                    { 5, 5, 1 },
                    { 7, 7, 1 },
                    { 8, 8, 1 },
                    { 9, 9, 1 },
                    { 10, 10, 1 },
                    { 11, 11, 1 },
                    { 12, 12, 1 },
                    { 14, 14, 1 },
                    { 13, 13, 1 },
                    { 15, 15, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_ParentId",
                schema: "Gnr",
                table: "Tenant",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_GroupId",
                schema: "Sec",
                table: "GroupUser",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UserId",
                schema: "Sec",
                table: "GroupUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAttempt_UserId",
                schema: "Sec",
                table: "LoginAttempt",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginedData_UserId",
                schema: "Sec",
                table: "LoginedData",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuAccess_MenuItemId",
                schema: "Sec",
                table: "MenuAccess",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuAccess_UserId",
                schema: "Sec",
                table: "MenuAccess",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuAction_MenuItemId",
                schema: "Sec",
                table: "MenuAction",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuActionAccess_MenuActionId",
                schema: "Sec",
                table: "MenuActionAccess",
                column: "MenuActionId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuActionAccess_UserId",
                schema: "Sec",
                table: "MenuActionAccess",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_CategoryId",
                schema: "Sec",
                table: "MenuItem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                schema: "Sec",
                table: "User",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TenantId",
                schema: "Sec",
                table: "User",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUser",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "LoginAttempt",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "LoginedData",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "MenuAccess",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "MenuActionAccess",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "MenuAction",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "MenuItem",
                schema: "Sec");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "Gnr");

            migrationBuilder.DropTable(
                name: "Tenant",
                schema: "Gnr");

            migrationBuilder.DropTable(
                name: "MenuCategory",
                schema: "Sec");
        }
    }
}
