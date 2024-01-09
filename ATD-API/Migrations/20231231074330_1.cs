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
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dateEnCours = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tauxAchat = table.Column<double>(type: "float", nullable: false),
                    tauxVente = table.Column<double>(type: "float", nullable: false),
                    monnaie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coursDeChanges", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "depenses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    motif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    montant = table.Column<double>(type: "float", nullable: false),
                    beneficiaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_depenses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "detailIventaires",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    inventaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emballage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantitePhysique = table.Column<double>(type: "float", nullable: false),
                    quantiteLogique = table.Column<double>(type: "float", nullable: false),
                    ecart = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailIventaires", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "emballageByArticles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emballageGros = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emballageDetail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emballageByArticles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "emballages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emballages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "familles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_familles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fournisseurs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fournisseurs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "historiquePrixVentes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    locationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dateModification = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ancienPrixDeVenteGros = table.Column<double>(type: "float", nullable: false),
                    ancienPrixDeVenteDetail = table.Column<double>(type: "float", nullable: false),
                    nouveauPrixDeVenteGros = table.Column<double>(type: "float", nullable: false),
                    nouveauPrixDeVenteDetail = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historiquePrixVentes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inventaireComptables",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    locationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    stockInit = table.Column<double>(type: "float", nullable: false),
                    montantInit = table.Column<double>(type: "float", nullable: false),
                    qteEnt = table.Column<double>(type: "float", nullable: false),
                    montantEnt = table.Column<double>(type: "float", nullable: false),
                    qteSort = table.Column<double>(type: "float", nullable: false),
                    montantSort = table.Column<double>(type: "float", nullable: false),
                    stockFinal = table.Column<double>(type: "float", nullable: false),
                    montantFinal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventaireComptables", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pwd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "monnaies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    devise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estLocal = table.Column<bool>(type: "bit", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monnaies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mouvements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    article = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emballage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quantite = table.Column<double>(type: "float", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mouvements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "parametreSocietes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    denomination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idNat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rccm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tva = table.Column<double>(type: "float", nullable: false),
                    monnaie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    attachement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parametreSocietes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "portefeuilles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    clientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    montant = table.Column<double>(type: "float", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portefeuilles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    locationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "signaletiques",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    categorie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_signaletiques", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "utilisateurs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postnom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    roleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilisateurs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    familleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emballageGrosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emballageDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    stockMinimal = table.Column<int>(type: "int", nullable: false),
                    quantiteDetail = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.id);
                    table.ForeignKey(
                        name: "FK_articles_familles_familleId",
                        column: x => x.familleId,
                        principalTable: "familles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "commandes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    numeroCommande = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateCommande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateLivraison = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fournisseurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    totalCommande = table.Column<double>(type: "float", nullable: false),
                    tauxDeChange = table.Column<double>(type: "float", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commandes", x => x.id);
                    table.ForeignKey(
                        name: "FK_commandes_fournisseurs_fournisseurId",
                        column: x => x.fournisseurId,
                        principalTable: "fournisseurs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    societeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dateCloture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    flag = table.Column<bool>(type: "bit", nullable: false),
                    addresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroAchat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroCommande = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroFacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroLivraison = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.id);
                    table.ForeignKey(
                        name: "FK_locations_parametreSocietes_societeId",
                        column: x => x.societeId,
                        principalTable: "parametreSocietes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prixAchatArticles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dateAchat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    monnaieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prixAchatGros = table.Column<double>(type: "float", nullable: false),
                    prixAchatDetail = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prixAchatArticles", x => x.id);
                    table.ForeignKey(
                        name: "FK_prixAchatArticles_articles_articleId",
                        column: x => x.articleId,
                        principalTable: "articles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prixAchatArticles_monnaies_monnaieId",
                        column: x => x.monnaieId,
                        principalTable: "monnaies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailCommandes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    article = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    commandeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emballage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantite = table.Column<double>(type: "float", nullable: false),
                    quantiteLivree = table.Column<double>(type: "float", nullable: false),
                    resteQuantite = table.Column<double>(type: "float", nullable: false),
                    prixUnit = table.Column<double>(type: "float", nullable: false),
                    prixTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailCommandes", x => x.id);
                    table.ForeignKey(
                        name: "FK_detailCommandes_commandes_commandeId",
                        column: x => x.commandeId,
                        principalTable: "commandes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "achats",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    numeroFacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    locationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fournisseurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tauxAchat = table.Column<double>(type: "float", nullable: false),
                    montantTotal = table.Column<double>(type: "float", nullable: false),
                    numeroAchat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achats", x => x.id);
                    table.ForeignKey(
                        name: "FK_achats_fournisseurs_fournisseurId",
                        column: x => x.fournisseurId,
                        principalTable: "fournisseurs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_achats_locations_locationId",
                        column: x => x.locationId,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "article_stocks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    locationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quantite = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_stocks", x => x.id);
                    table.ForeignKey(
                        name: "FK_article_stocks_articles_articleId",
                        column: x => x.articleId,
                        principalTable: "articles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_article_stocks_locations_locationId",
                        column: x => x.locationId,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "articleLocations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    locationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emballageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    seuil = table.Column<double>(type: "float", nullable: false),
                    qteStock = table.Column<double>(type: "float", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleLocations", x => x.id);
                    table.ForeignKey(
                        name: "FK_articleLocations_articles_articleId",
                        column: x => x.articleId,
                        principalTable: "articles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articleLocations_emballages_emballageId",
                        column: x => x.emballageId,
                        principalTable: "emballages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articleLocations_locations_locationId",
                        column: x => x.locationId,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "factures",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    numeroFacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    locationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dateFacture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    client = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    taux = table.Column<double>(type: "float", nullable: false),
                    remise = table.Column<double>(type: "float", nullable: false),
                    totalHt = table.Column<double>(type: "float", nullable: false),
                    montantPayer = table.Column<double>(type: "float", nullable: false),
                    resteApayer = table.Column<double>(type: "float", nullable: false),
                    monnaie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    montantLettre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paiement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factures", x => x.id);
                    table.ForeignKey(
                        name: "FK_factures_locations_locationId",
                        column: x => x.locationId,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventaires",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    locationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quantitePhysique = table.Column<double>(type: "float", nullable: false),
                    quantiteLogique = table.Column<double>(type: "float", nullable: false),
                    ecart = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventaires", x => x.id);
                    table.ForeignKey(
                        name: "FK_inventaires_articles_articleId",
                        column: x => x.articleId,
                        principalTable: "articles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventaires_locations_locationId",
                        column: x => x.locationId,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "livraisons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    numeroLivraison = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroCommande = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateLivraison = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fournisseurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    locationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livraisons", x => x.id);
                    table.ForeignKey(
                        name: "FK_livraisons_fournisseurs_fournisseurId",
                        column: x => x.fournisseurId,
                        principalTable: "fournisseurs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_livraisons_locations_locationId",
                        column: x => x.locationId,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prixArticleLocations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prixVenteDetail = table.Column<double>(type: "float", nullable: false),
                    prixVenteGros = table.Column<double>(type: "float", nullable: false),
                    locationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prixArticleLocations", x => x.id);
                    table.ForeignKey(
                        name: "FK_prixArticleLocations_articles_articleId",
                        column: x => x.articleId,
                        principalTable: "articles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prixArticleLocations_locations_locationId",
                        column: x => x.locationId,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailAchats",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    article = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    achatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emballage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantite = table.Column<double>(type: "float", nullable: false),
                    prixUnit = table.Column<double>(type: "float", nullable: false),
                    prixTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailAchats", x => x.id);
                    table.ForeignKey(
                        name: "FK_detailAchats_achats_achatId",
                        column: x => x.achatId,
                        principalTable: "achats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailAchats_articles_articleId",
                        column: x => x.articleId,
                        principalTable: "articles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailFactures",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    article = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    factureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emballage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantite = table.Column<double>(type: "float", nullable: false),
                    prixUnit = table.Column<double>(type: "float", nullable: false),
                    prixTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailFactures", x => x.id);
                    table.ForeignKey(
                        name: "FK_detailFactures_factures_factureId",
                        column: x => x.factureId,
                        principalTable: "factures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paiements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    factureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    utilisateurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    datePaiement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    montantPayer = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paiements", x => x.id);
                    table.ForeignKey(
                        name: "FK_paiements_factures_factureId",
                        column: x => x.factureId,
                        principalTable: "factures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailLivraisons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    articleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    article = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    livraisonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emballage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantite = table.Column<double>(type: "float", nullable: false),
                    prixUnit = table.Column<double>(type: "float", nullable: false),
                    prixTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailLivraisons", x => x.id);
                    table.ForeignKey(
                        name: "FK_detailLivraisons_livraisons_livraisonId",
                        column: x => x.livraisonId,
                        principalTable: "livraisons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_achats_fournisseurId",
                table: "achats",
                column: "fournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_achats_locationId",
                table: "achats",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_article_stocks_articleId",
                table: "article_stocks",
                column: "articleId");

            migrationBuilder.CreateIndex(
                name: "IX_article_stocks_locationId",
                table: "article_stocks",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_articleLocations_articleId",
                table: "articleLocations",
                column: "articleId");

            migrationBuilder.CreateIndex(
                name: "IX_articleLocations_emballageId",
                table: "articleLocations",
                column: "emballageId");

            migrationBuilder.CreateIndex(
                name: "IX_articleLocations_locationId",
                table: "articleLocations",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_articles_familleId",
                table: "articles",
                column: "familleId");

            migrationBuilder.CreateIndex(
                name: "IX_commandes_fournisseurId",
                table: "commandes",
                column: "fournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_detailAchats_achatId",
                table: "detailAchats",
                column: "achatId");

            migrationBuilder.CreateIndex(
                name: "IX_detailAchats_articleId",
                table: "detailAchats",
                column: "articleId");

            migrationBuilder.CreateIndex(
                name: "IX_detailCommandes_commandeId",
                table: "detailCommandes",
                column: "commandeId");

            migrationBuilder.CreateIndex(
                name: "IX_detailFactures_factureId",
                table: "detailFactures",
                column: "factureId");

            migrationBuilder.CreateIndex(
                name: "IX_detailLivraisons_livraisonId",
                table: "detailLivraisons",
                column: "livraisonId");

            migrationBuilder.CreateIndex(
                name: "IX_factures_locationId",
                table: "factures",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_inventaires_articleId",
                table: "inventaires",
                column: "articleId");

            migrationBuilder.CreateIndex(
                name: "IX_inventaires_locationId",
                table: "inventaires",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_livraisons_fournisseurId",
                table: "livraisons",
                column: "fournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_livraisons_locationId",
                table: "livraisons",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_locations_societeId",
                table: "locations",
                column: "societeId");

            migrationBuilder.CreateIndex(
                name: "IX_paiements_factureId",
                table: "paiements",
                column: "factureId");

            migrationBuilder.CreateIndex(
                name: "IX_prixAchatArticles_articleId",
                table: "prixAchatArticles",
                column: "articleId");

            migrationBuilder.CreateIndex(
                name: "IX_prixAchatArticles_monnaieId",
                table: "prixAchatArticles",
                column: "monnaieId");

            migrationBuilder.CreateIndex(
                name: "IX_prixArticleLocations_articleId",
                table: "prixArticleLocations",
                column: "articleId");

            migrationBuilder.CreateIndex(
                name: "IX_prixArticleLocations_locationId",
                table: "prixArticleLocations",
                column: "locationId");
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
                name: "depenses");

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
                name: "inventaireComptables");

            migrationBuilder.DropTable(
                name: "inventaires");

            migrationBuilder.DropTable(
                name: "logins");

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
                name: "roles");

            migrationBuilder.DropTable(
                name: "signaletiques");

            migrationBuilder.DropTable(
                name: "utilisateurs");

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
                name: "monnaies");

            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "fournisseurs");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "familles");

            migrationBuilder.DropTable(
                name: "parametreSocietes");
        }
    }
}
