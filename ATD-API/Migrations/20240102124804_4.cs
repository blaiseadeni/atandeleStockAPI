using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATD_API.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "libelle",
                table: "mouvementStocks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "article",
                table: "mouvementStocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "articleId",
                table: "mouvementStocks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "locationId",
                table: "mouvementStocks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "article",
                table: "mouvementStocks");

            migrationBuilder.DropColumn(
                name: "articleId",
                table: "mouvementStocks");

            migrationBuilder.DropColumn(
                name: "locationId",
                table: "mouvementStocks");

            migrationBuilder.AlterColumn<double>(
                name: "libelle",
                table: "mouvementStocks",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
