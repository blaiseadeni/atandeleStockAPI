using ATD_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Achat> achats { get; set; }

        public virtual DbSet<Article> articles { get; set; }

        public virtual DbSet<ArticleLocation> articleLocations { get; set; }

        public virtual DbSet<Commande> commandes { get; set; }

        public virtual DbSet<CoursDeChange> coursDeChanges { get; set; }

        public virtual DbSet<DetailAchat> detailAchats { get; set; }

        public virtual DbSet<DetailCommande> detailCommandes { get; set; }

        public virtual DbSet<DetailFacture> detailFactures { get; set; }

        public virtual DbSet<DetailIventaire> detailIventaires { get; set; }

        public virtual DbSet<DetailLivraison> detailLivraisons { get; set; }

        public virtual DbSet<Emballage> emballages { get; set; }

        public virtual DbSet<EmballageByArticle> emballageByArticles { get; set; }

        public virtual DbSet<Facture> factures { get; set; }

        public virtual DbSet<Famille> familles { get; set; }

        public virtual DbSet<Fournisseur> fournisseurs { get; set; }

        public virtual DbSet<HistoriquePrixVente> historiquePrixVentes { get; set; }

        public virtual DbSet<Inventaire> inventaires { get; set; }

        public virtual DbSet<Livraison> livraisons { get; set; }

        public virtual DbSet<Location> locations { get; set; }

        public virtual DbSet<Monnaie> monnaies { get; set; }

        public virtual DbSet<Paiement> paiements { get; set; }

        public virtual DbSet<ParametreSociete> parametreSocietes { get; set; }

        public virtual DbSet<PrixAchatArticle> prixAchatArticles { get; set; }

        public virtual DbSet<PrixArticleLocation> prixArticleLocations { get; set; }

        public virtual DbSet<Signaletique> signaletiques { get; set; }

        public virtual DbSet<Stock> article_stocks { get; set; }

        public virtual DbSet<Portefeuille> portefeuilles { get; set; }

        public virtual DbSet<Mouvement> mouvements { get; set; }

        public virtual DbSet<Depense> depenses { get; set; }

        public virtual DbSet<Utilisateur> utilisateurs { get; set; }

        public virtual DbSet<Login> logins { get; set; }

        public virtual DbSet<Role> roles { get; set; }

        public virtual DbSet<InvetaireComptable> inventaireComptables { get; set; }

        public virtual DbSet<MouvementStock> mouvementStocks { get; set; }

    }
}
