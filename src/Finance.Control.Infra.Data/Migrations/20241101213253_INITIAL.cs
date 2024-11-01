using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Control.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class INITIAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f39b093c-9887-4a86-bba5-48be3c1466e4"), "Administrator" });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AppRoleId", "Email", "IsActive", "Name", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("1e8b965f-a2ec-408b-a949-9f7fb137b3c4"), new Guid("00000000-0000-0000-0000-000000000000"), "admin@admin.com", true, "Admin", "$2a$11$5gfe82V/itxoCVt.rIBLRuvSLuUyAT5Xlc5/DzQKqREb4bNSP4fzC", "$2a$11$5gfe82V/itxoCVt.rIBLRu" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "AppRoleId", "AppUserId" },
                values: new object[] { new Guid("716edf53-63ac-499a-9579-093492b99b10"), new Guid("f39b093c-9887-4a86-bba5-48be3c1466e4"), new Guid("1e8b965f-a2ec-408b-a949-9f7fb137b3c4") });

            migrationBuilder.CreateIndex(
                name: "IX_Role_AppUserId",
                table: "Role",
                column: "AppUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "AppUser");
        }
    }
}
