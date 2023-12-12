using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATD_API.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coursDeChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateEnCours = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TauxAchat = table.Column<double>(type: "float", nullable: false),
                    TauxVente = table.Column<double>(type: "float", nullable: false),
                    Monnaie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coursDeChanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "detailIventaires",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Emballage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantitePhysique = table.Column<double>(type: "float", nullable: false),
                    QuantiteLogique = table.Column<double>(type: "float", nullable: false),
                    Ecart = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailIventaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emballageByArticles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmballageGros = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmballageDetail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emballageByArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emballages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emballages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "familles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_familles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fournisseurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fournisseurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "historiquePrixVentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateModification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AncienPrixDeVenteGros = table.Column<double>(type: "float", nullable: false),
                    AncienPrixDeVenteDetail = table.Column<double>(type: "float", nullable: false),
                    NouveauPrixDeVenteGros = table.Column<double>(type: "float", nullable: false),
                    NouveauPrixDeVenteDetail = table.Column<double>(type: "float", nullable: false),
                    Monnaie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historiquePrixVentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "monnaies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Devise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estLocal = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monnaies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mouvements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantite = table.Column<float>(type: "real", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mouvements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "parametreSocietes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Denomination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdNat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rccm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tva = table.Column<double>(type: "float", nullable: false),
                    Monnaie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parametreSocietes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "signaletiques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaisonSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_signaletiques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmballageGrosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmballageDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockMinimal = table.Column<int>(type: "int", nullable: false),
                    QuantiteDetail = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_articles_familles_FamilleId",
                        column: x => x.FamilleId,
                        principalTable: "familles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "commandes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroCommande = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCommande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLivraison = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Echeance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FournisseurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concerne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCommande = table.Column<double>(type: "float", nullable: false),
                    MonnaieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TauxDeChange = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_commandes_fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_commandes_monnaies_MonnaieId",
                        column: x => x.MonnaieId,
                        principalTable: "monnaies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "portefeuilles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    clientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    monnaieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    montant = table.Column<double>(type: "float", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portefeuilles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portefeuilles_monnaies_monnaieId",
                        column: x => x.monnaieId,
                        principalTable: "monnaies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SocieteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCloture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flag = table.Column<bool>(type: "bit", nullable: false),
                    Addresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroAchat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroCommande = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroFacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroLivraison = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_locations_parametreSocietes_SocieteId",
                        column: x => x.SocieteId,
                        principalTable: "parametreSocietes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prixAchatArticles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAchat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MonnaieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrixAchatGros = table.Column<double>(type: "float", nullable: false),
                    PrixAchatDetail = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prixAchatArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prixAchatArticles_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prixAchatArticles_monnaies_MonnaieId",
                        column: x => x.MonnaieId,
                        principalTable: "monnaies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailCommandes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommandeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Emballage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantite = table.Column<double>(type: "float", nullable: false),
                    QuantiteLivree = table.Column<double>(type: "float", nullable: false),
                    ResteQuantite = table.Column<double>(type: "float", nullable: false),
                    PrixUnit = table.Column<double>(type: "float", nullable: false),
                    PrixTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailCommandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detailCommandes_commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "achats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroFacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonnaieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FournisseurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TauxAchat = table.Column<double>(type: "float", nullable: false),
                    MontantTotal = table.Column<double>(type: "float", nullable: false),
                    NumeroAchat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_achats_fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_achats_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_achats_monnaies_MonnaieId",
                        column: x => x.MonnaieId,
                        principalTable: "monnaies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "article_stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantite = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_article_stocks_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_article_stocks_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "articleLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmballageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Seuil = table.Column<double>(type: "float", nullable: false),
                    QteStock = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_articleLocations_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articleLocations_emballages_EmballageId",
                        column: x => x.EmballageId,
                        principalTable: "emballages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articleLocations_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "factures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroFacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateFacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Taux = table.Column<double>(type: "float", nullable: false),
                    Tva = table.Column<double>(type: "float", nullable: false),
                    Remise = table.Column<double>(type: "float", nullable: false),
                    TotalHt = table.Column<double>(type: "float", nullable: false),
                    TotalTva = table.Column<double>(type: "float", nullable: false),
                    TotalRemise = table.Column<double>(type: "float", nullable: false),
                    TotalTtc = table.Column<double>(type: "float", nullable: false),
                    MontantPayer = table.Column<double>(type: "float", nullable: false),
                    ResteApayer = table.Column<double>(type: "float", nullable: false),
                    Monnaie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MontantLettre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paiement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_factures_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventaires",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateInventaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Monnaie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmballageGros = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmballageDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrixAchat = table.Column<double>(type: "float", nullable: false),
                    PrixVente = table.Column<double>(type: "float", nullable: false),
                    QuantitePhysiqueGros = table.Column<double>(type: "float", nullable: false),
                    QuantitePhysiqueDetail = table.Column<double>(type: "float", nullable: false),
                    QuantiteLogiqueGros = table.Column<double>(type: "float", nullable: false),
                    QuatiteLogiqueDetail = table.Column<double>(type: "float", nullable: false),
                    Ecart = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventaires_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventaires_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "livraisons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroLivraison = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroCommande = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLivraison = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FournisseurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MonnaieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livraisons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_livraisons_fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_livraisons_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_livraisons_monnaies_MonnaieId",
                        column: x => x.MonnaieId,
                        principalTable: "monnaies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prixArticleLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrixVenteDetail = table.Column<double>(type: "float", nullable: false),
                    PrixVenteGros = table.Column<double>(type: "float", nullable: false),
                    Monnaie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prixArticleLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prixArticleLocations_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prixArticleLocations_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailAchats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AchatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Emballage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantite = table.Column<double>(type: "float", nullable: false),
                    PrixUnit = table.Column<double>(type: "float", nullable: false),
                    PrixTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailAchats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detailAchats_achats_AchatId",
                        column: x => x.AchatId,
                        principalTable: "achats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailAchats_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailFactures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FactureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Emballage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantite = table.Column<double>(type: "float", nullable: false),
                    PrixUnit = table.Column<double>(type: "float", nullable: false),
                    PrixTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailFactures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detailFactures_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailFactures_factures_FactureId",
                        column: x => x.FactureId,
                        principalTable: "factures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paiements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FactureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatePaiement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Monnaie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MontantPayer = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paiements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_paiements_factures_FactureId",
                        column: x => x.FactureId,
                        principalTable: "factures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailLivraisons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LivraisonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Emballage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantite = table.Column<double>(type: "float", nullable: false),
                    PrixUnit = table.Column<double>(type: "float", nullable: false),
                    PrixTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailLivraisons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detailLivraisons_livraisons_LivraisonId",
                        column: x => x.LivraisonId,
                        principalTable: "livraisons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_achats_FournisseurId",
                table: "achats",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_achats_LocationId",
                table: "achats",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_achats_MonnaieId",
                table: "achats",
                column: "MonnaieId");

            migrationBuilder.CreateIndex(
                name: "IX_article_stocks_ArticleId",
                table: "article_stocks",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_article_stocks_LocationId",
                table: "article_stocks",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_articleLocations_ArticleId",
                table: "articleLocations",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_articleLocations_EmballageId",
                table: "articleLocations",
                column: "EmballageId");

            migrationBuilder.CreateIndex(
                name: "IX_articleLocations_LocationId",
                table: "articleLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_articles_FamilleId",
                table: "articles",
                column: "FamilleId");

            migrationBuilder.CreateIndex(
                name: "IX_commandes_FournisseurId",
                table: "commandes",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_commandes_MonnaieId",
                table: "commandes",
                column: "MonnaieId");

            migrationBuilder.CreateIndex(
                name: "IX_detailAchats_AchatId",
                table: "detailAchats",
                column: "AchatId");

            migrationBuilder.CreateIndex(
                name: "IX_detailAchats_ArticleId",
                table: "detailAchats",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_detailCommandes_CommandeId",
                table: "detailCommandes",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_detailFactures_ArticleId",
                table: "detailFactures",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_detailFactures_FactureId",
                table: "detailFactures",
                column: "FactureId");

            migrationBuilder.CreateIndex(
                name: "IX_detailLivraisons_LivraisonId",
                table: "detailLivraisons",
                column: "LivraisonId");

            migrationBuilder.CreateIndex(
                name: "IX_factures_LocationId",
                table: "factures",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_inventaires_ArticleId",
                table: "inventaires",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_inventaires_LocationId",
                table: "inventaires",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_livraisons_FournisseurId",
                table: "livraisons",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_livraisons_LocationId",
                table: "livraisons",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_livraisons_MonnaieId",
                table: "livraisons",
                column: "MonnaieId");

            migrationBuilder.CreateIndex(
                name: "IX_locations_SocieteId",
                table: "locations",
                column: "SocieteId");

            migrationBuilder.CreateIndex(
                name: "IX_paiements_FactureId",
                table: "paiements",
                column: "FactureId");

            migrationBuilder.CreateIndex(
                name: "IX_portefeuilles_monnaieId",
                table: "portefeuilles",
                column: "monnaieId");

            migrationBuilder.CreateIndex(
                name: "IX_prixAchatArticles_ArticleId",
                table: "prixAchatArticles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_prixAchatArticles_MonnaieId",
                table: "prixAchatArticles",
                column: "MonnaieId");

            migrationBuilder.CreateIndex(
                name: "IX_prixArticleLocations_ArticleId",
                table: "prixArticleLocations",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_prixArticleLocations_LocationId",
                table: "prixArticleLocations",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article_stocks");

            migrationBuilder.DropTable(
                name: "articleLocations");

            migrationBuilder.DropTable(
                name: "coursDeChanges");

            migrationBuilder.DropTable(
                name: "detailAchats");

            migrationBuilder.DropTable(
                name: "detailCommandes");

            migrationBuilder.DropTable(
                name: "detailFactures");

            migrationBuilder.DropTable(
                name: "detailIventaires");

            migrationBuilder.DropTable(
                name: "detailLivraisons");

            migrationBuilder.DropTable(
                name: "emballageByArticles");

            migrationBuilder.DropTable(
                name: "historiquePrixVentes");

            migrationBuilder.DropTable(
                name: "inventaires");

            migrationBuilder.DropTable(
                name: "mouvements");

            migrationBuilder.DropTable(
                name: "paiements");

            migrationBuilder.DropTable(
                name: "portefeuilles");

            migrationBuilder.DropTable(
                name: "prixAchatArticles");

            migrationBuilder.DropTable(
                name: "prixArticleLocations");

            migrationBuilder.DropTable(
                name: "signaletiques");

            migrationBuilder.DropTable(
                name: "emballages");

            migrationBuilder.DropTable(
                name: "achats");

            migrationBuilder.DropTable(
                name: "commandes");

            migrationBuilder.DropTable(
                name: "livraisons");

            migrationBuilder.DropTable(
                name: "factures");

            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "fournisseurs");

            migrationBuilder.DropTable(
                name: "monnaies");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "familles");

            migrationBuilder.DropTable(
                name: "parametreSocietes");
        }
    }
}
