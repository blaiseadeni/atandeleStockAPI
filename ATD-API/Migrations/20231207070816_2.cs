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
            migrationBuilder.DropForeignKey(
                name: "FK_detailFactures_articles_ArticleId",
                table: "detailFactures");

            migrationBuilder.DropIndex(
                name: "IX_detailFactures_ArticleId",
                table: "detailFactures");

            migrationBuilder.DropColumn(
                name: "Monnaie",
                table: "paiements");

            migrationBuilder.DropColumn(
                name: "TotalRemise",
                table: "factures");

            migrationBuilder.DropColumn(
                name: "TotalTtc",
                table: "factures");

            migrationBuilder.DropColumn(
                name: "TotalTva",
                table: "factures");

            migrationBuilder.DropColumn(
                name: "Tva",
                table: "factures");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePaiement",
                table: "paiements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Emballage",
                table: "mouvements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "factures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFacture",
                table: "factures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Article",
                table: "detailFactures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emballage",
                table: "mouvements");

            migrationBuilder.DropColumn(
                name: "Article",
                table: "detailFactures");

            migrationBuilder.AlterColumn<string>(
                name: "DatePaiement",
                table: "paiements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Monnaie",
                table: "paiements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "factures",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DateFacture",
                table: "factures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<double>(
                name: "TotalRemise",
                table: "factures",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalTtc",
                table: "factures",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalTva",
                table: "factures",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Tva",
                table: "factures",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_detailFactures_ArticleId",
                table: "detailFactures",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_detailFactures_articles_ArticleId",
                table: "detailFactures",
                column: "ArticleId",
                principalTable: "articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
