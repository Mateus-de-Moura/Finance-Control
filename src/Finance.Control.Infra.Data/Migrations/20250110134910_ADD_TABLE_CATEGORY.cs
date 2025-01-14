using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Control.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ADD_TABLE_CATEGORY : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("1e8b965f-a2ec-408b-a949-9f7fb137b3c4"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "$2a$11$Rg23FnbId1IaHGW7s0OuROmA6m/BW64dD98zEaF1V5ul9pgigweeq", "$2a$11$Rg23FnbId1IaHGW7s0OuRO" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("1e8b965f-a2ec-408b-a949-9f7fb137b3c4"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "$2a$11$Dek/UjfM88NP6dtESR0tTe05bClGjxbMY5fZM34NR9DvlMWr51aHW", "$2a$11$Dek/UjfM88NP6dtESR0tTe" });
        }
    }
}
