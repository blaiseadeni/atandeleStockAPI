using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATD_API.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "periode",
                table: "portefeuilles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "periode",
                table: "paiements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "periode",
                table: "livraisons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "periode",
                table: "factures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "periode",
                table: "depenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "periode",
                table: "commandes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "periode",
                table: "achats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "mouvementStocks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    periode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    libelle = table.Column<double>(type: "float", nullable: false),
                    qteEntr = table.Column<double>(type: "float", nullable: false),
                    puEntr = table.Column<double>(type: "float", nullable: false),
                    ptEnt = table.Column<double>(type: "float", nullable: false),
                    qteSort = table.Column<double>(type: "float", nullable: false),
                    puSort = table.Column<double>(type: "float", nullable: false),
                    ptSort = table.Column<double>(type: "float", nullable: false),
                    qteSt = table.Column<double>(type: "float", nullable: false),
                    puSt = table.Column<double>(type: "float", nullable: false),
                    ptSt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mouvementStocks", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mouvementStocks");

            migrationBuilder.DropColumn(
                name: "periode",
                table: "portefeuilles");

            migrationBuilder.DropColumn(
                name: "periode",
                table: "paiements");

            migrationBuilder.DropColumn(
                name: "periode",
                table: "livraisons");

            migrationBuilder.DropColumn(
                name: "periode",
                table: "factures");

            migrationBuilder.DropColumn(
                name: "periode",
                table: "depenses");

            migrationBuilder.DropColumn(
                name: "periode",
                table: "commandes");

            migrationBuilder.DropColumn(
                name: "periode",
                table: "achats");
        }
    }
}
