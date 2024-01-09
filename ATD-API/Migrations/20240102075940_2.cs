using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATD_API.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "totalLivraison",
                table: "livraisons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "date1",
                table: "inventaires",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "date2",
                table: "inventaires",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalLivraison",
                table: "livraisons");

            migrationBuilder.DropColumn(
                name: "date1",
                table: "inventaires");

            migrationBuilder.DropColumn(
                name: "date2",
                table: "inventaires");
        }
    }
}
