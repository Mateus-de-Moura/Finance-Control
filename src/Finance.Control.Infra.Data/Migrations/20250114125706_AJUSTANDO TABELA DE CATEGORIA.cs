using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Control.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AJUSTANDOTABELADECATEGORIA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryType",
                table: "Category",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);
           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Category",
                newName: "CategoryType");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Category",
                newName: "CategoryName");

           
        }
    }
}
