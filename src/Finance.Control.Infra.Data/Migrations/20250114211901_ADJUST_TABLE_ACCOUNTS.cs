using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Control.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ADJUST_TABLE_ACCOUNTS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MaturityDate",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("1e8b965f-a2ec-408b-a949-9f7fb137b3c4"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "$2a$11$rBpoPpyYH8x27K4VMdU4Suex0v7C/p4plc8MKLVBuTYZK57u.YaB6", "$2a$11$rBpoPpyYH8x27K4VMdU4Su" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaturityDate",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("1e8b965f-a2ec-408b-a949-9f7fb137b3c4"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "$2a$11$yWw8XnhxMTY8BflOSLiYvewGexxXcYqLDNlLRVZ.EPrFvDyfBZ.Im", "$2a$11$yWw8XnhxMTY8BflOSLiYve" });
        }
    }
}
