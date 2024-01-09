using AspNetCore.Reporting;
using ATD_API.Data;
using ATD_API.Dtos;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.Mime;

namespace gpiaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;
        private readonly ILogger<ReportController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public ReportController(MyDbContext myDbContext, ILogger<ReportController> logger, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _myDbContext = myDbContext;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _mapper = mapper;
        }

        [HttpGet("facture/{id:Guid}")]
        public ActionResult Print(Guid id)
        {
            var param = _myDbContext.factures.FirstOrDefault(c => c.id == id);
            var utilisateur = _myDbContext.utilisateurs.FirstOrDefault(x => x.id == param.utilisateurId);

            if (param != null)
            {
                var dt = new DataTable();
                dt = GetFacture(id);
                int extension1 = (int)(DateTime.Now.Ticks >> 10);
                var mimtype = "";
                var path = $"{this._webHostEnvironment.WebRootPath}\\ReportFacture.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("client", param.client);
                parameters.Add("utilisateur", utilisateur.nom + " " + utilisateur.postnom);
                parameters.Add("numeroFacture", param.numeroFacture);
                parameters.Add("date", param.dateFacture.ToString());
                parameters.Add("total", param.totalHt.ToString());
                parameters.Add("remise", param.remise.ToString());
                parameters.Add("montantPaie", param.montantPayer.ToString());
                parameters.Add("reste", param.resteApayer.ToString());
                LocalReport lr = new(path);
                lr.AddDataSource("DataSet1", dt);
                var result = lr.Execute(RenderType.Pdf, extension1, parameters, mimtype);
                return File(result.MainStream, MediaTypeNames.Application.Pdf, "Facture");
            }
            return Ok(param);
        }

        [HttpGet("pos/{id:Guid}")]
        public ActionResult PrintPOS(Guid id)
        {
            var param = _myDbContext.factures.FirstOrDefault(c => c.id == id);
            var utilisateur = _myDbContext.utilisateurs.FirstOrDefault(x => x.id == param.utilisateurId);

            if (param != null)
            {
                var dt = new DataTable();
                dt = GetFacture(id);
                int extension2 = (int)(DateTime.Now.Ticks >> 10);
                var mimtype = "";
                var path = $"{this._webHostEnvironment.WebRootPath}\\ReportFacturePOS.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("client", param.client);
                parameters.Add("utilisateur", utilisateur.nom + " " + utilisateur.postnom);
                parameters.Add("numeroFacture", param.numeroFacture);
                parameters.Add("date", param.dateFacture.ToString());
                parameters.Add("total", param.totalHt.ToString());
                parameters.Add("remise", param.remise.ToString());
                parameters.Add("montantPaie", param.montantPayer.ToString());
                parameters.Add("reste", param.resteApayer.ToString());
                LocalReport lr = new(path);
                lr.AddDataSource("DataSet1", dt);
                var result = lr.Execute(RenderType.Pdf, extension2, parameters, mimtype);
                return File(result.MainStream, MediaTypeNames.Application.Pdf, "POS");
            }
            return Ok(param);
        }



        private DataTable GetFacture(Guid id)
        {
            var item = (from x in _myDbContext.detailFactures
                        where x.factureId == id
                        select new
                        {
                            ArticleId = x.articleId,
                            FactureId = x.factureId,
                            Article = x.article,
                            Emballage = x.emballage,
                            Quantite = x.quantite,
                            PrixUnit = x.prixUnit,
                            PrixTotal = x.prixTotal,
                        }).ToList();

            var dt = new DataTable();
            dt.Columns.Add("ArticleId");
            dt.Columns.Add("FactureId");
            dt.Columns.Add("Article");
            dt.Columns.Add("Emballage");
            dt.Columns.Add("Quantite");
            dt.Columns.Add("PrixUnit");
            dt.Columns.Add("PrixTotal");
            System.Data.DataRow row;

            foreach (var list in item)
            {
                row = dt.NewRow();

                row["ArticleId"] = list.ArticleId;
                row["Article"] = list.Article;
                row["FactureId"] = list.FactureId;
                row["Emballage"] = list.Emballage;
                row["Quantite"] = list.Quantite;
                row["PrixUnit"] = list.PrixUnit;
                row["PrixTotal"] = list.PrixTotal;
                dt.Rows.Add(row);

            }

            return dt;
        }

        [HttpGet("bc/{id:Guid}")]
        public ActionResult PrintBC(Guid id)
        {
            var param = _myDbContext.commandes.FirstOrDefault(c => c.id == id);
            var utilisateur = _myDbContext.utilisateurs.FirstOrDefault(x => x.id == param.utilisateurId);
            var fournisseeur = _myDbContext.fournisseurs.FirstOrDefault(x => x.id == param.fournisseurId);

            if (param != null)
            {
                var dt = new DataTable();
                dt = GetCommande(id);
                int extension3 = (int)(DateTime.Now.Ticks >> 10);
                var mimtype = "";
                var path = $"{this._webHostEnvironment.WebRootPath}\\ReportBC.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("total", param.totalCommande.ToString());
                parameters.Add("utilis", utilisateur.nom + " " + utilisateur.postnom);
                parameters.Add("numeroC", param.numeroCommande);
                parameters.Add("dateC", param.dateCommande.ToString());
                parameters.Add("dateL", param.dateLivraison.ToString());
                parameters.Add("fournis", fournisseeur.nom);
                LocalReport lr = new(path);
                lr.AddDataSource("DataSet1", dt);
                var result = lr.Execute(RenderType.Pdf, extension3, parameters, mimtype);
                return File(result.MainStream, MediaTypeNames.Application.Pdf, "BC");
            }
            return Ok(param);
        }



        private DataTable GetCommande(Guid id)
        {
            var item = (from x in _myDbContext.detailCommandes
                        where x.commandeId == id
                        select new
                        {
                            ArticleId = x.articleId,
                            commandeId = x.commandeId,
                            Article = x.article,
                            Emballage = x.emballage,
                            Quantite = x.quantite,
                            PrixUnit = x.prixUnit,
                            PrixTotal = x.prixTotal,
                        }).ToList();

            var dt = new DataTable();
            dt.Columns.Add("ArticleId");
            dt.Columns.Add("commandeId");
            dt.Columns.Add("Article");
            dt.Columns.Add("Emballage");
            dt.Columns.Add("Quantite");
            dt.Columns.Add("PrixUnit");
            dt.Columns.Add("PrixTotal");
            System.Data.DataRow row;

            foreach (var list in item)
            {
                row = dt.NewRow();

                row["ArticleId"] = list.ArticleId;
                row["Article"] = list.Article;
                row["commandeId"] = list.commandeId;
                row["Emballage"] = list.Emballage;
                row["Quantite"] = list.Quantite;
                row["PrixUnit"] = list.PrixUnit;
                row["PrixTotal"] = list.PrixTotal;
                dt.Rows.Add(row);

            }

            return dt;
        }

        [HttpGet("bl/{id:Guid}")]
        public ActionResult PrintBL(Guid id)
        {
            var param = _myDbContext.livraisons.FirstOrDefault(c => c.id == id);
            var utilisateur = _myDbContext.utilisateurs.FirstOrDefault(x => x.id == param.utilisateurId);
            var fournisseeur = _myDbContext.fournisseurs.FirstOrDefault(x => x.id == param.fournisseurId);

            if (param != null)
            {
                var dt = new DataTable();
                dt = GetLivraison(id);
                int extension4 = (int)(DateTime.Now.Ticks >> 10);
                var mimtype = "";
                var path = $"{this._webHostEnvironment.WebRootPath}\\ReportBL.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("utilisateur", utilisateur.nom + " " + utilisateur.postnom);
                parameters.Add("numeroCom", param.numeroCommande);
                parameters.Add("numeroLivr", param.numeroLivraison);
                parameters.Add("dateLivr", param.dateLivraison.ToString());
                parameters.Add("totalLivraison", param.totalLivraison.ToString());
                parameters.Add("fournisseur", fournisseeur.nom);
                LocalReport lr = new(path);
                lr.AddDataSource("DataSet1", dt);
                var result = lr.Execute(RenderType.Pdf, extension4, parameters, mimtype);
                return File(result.MainStream, MediaTypeNames.Application.Pdf, "BL");
            }
            return Ok(param);
        }



        private DataTable GetLivraison(Guid id)
        {
            var item = (from x in _myDbContext.detailLivraisons
                        where x.livraisonId == id
                        select new
                        {
                            ArticleId = x.articleId,
                            livraisonId = x.livraisonId,
                            Article = x.article,
                            Emballage = x.emballage,
                            Quantite = x.quantite,
                            PrixUnit = x.prixUnit,
                            PrixTotal = x.prixTotal,
                        }).ToList();

            var dt = new DataTable();
            dt.Columns.Add("ArticleId");
            dt.Columns.Add("livraisonId");
            dt.Columns.Add("Article");
            dt.Columns.Add("Emballage");
            dt.Columns.Add("Quantite");
            dt.Columns.Add("PrixUnit");
            dt.Columns.Add("PrixTotal");
            System.Data.DataRow row;

            foreach (var list in item)
            {
                row = dt.NewRow();

                row["ArticleId"] = list.ArticleId;
                row["Article"] = list.Article;
                row["livraisonId"] = list.livraisonId;
                row["Emballage"] = list.Emballage;
                row["Quantite"] = list.Quantite;
                row["PrixUnit"] = list.PrixUnit;
                row["PrixTotal"] = list.PrixTotal;
                dt.Rows.Add(row);

            }

            return dt;
        }


        [HttpGet("ba/{id:Guid}")]
        public ActionResult PrintBA(Guid id)
        {
            var param = _myDbContext.achats.FirstOrDefault(c => c.id == id);
            var utilisateur = _myDbContext.utilisateurs.FirstOrDefault(x => x.id == param.utilisateurId);
            var fournisseeur = _myDbContext.fournisseurs.FirstOrDefault(x => x.id == param.fournisseurId);
            var location = _myDbContext.locations.FirstOrDefault(x => x.id == param.locationId);

            if (param != null)
            {
                var dt = new DataTable();
                dt = GetAchat(id);
                int extension5 = (int)(DateTime.Now.Ticks >> 10);
                var mimtype = "";
                var path = $"{this._webHostEnvironment.WebRootPath}\\ReportBA.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("utilisateur", utilisateur.nom + " " + utilisateur.postnom);
                parameters.Add("dateAch", param.dateAchat.ToString());
                parameters.Add("numeroAch", param.numeroAchat);
                parameters.Add("numeroFact", param.numeroFacture);
                parameters.Add("fournisseur", fournisseeur.nom);
                parameters.Add("location", location.designation);
                parameters.Add("total", param.montantTotal.ToString());
                LocalReport lr = new(path);
                lr.AddDataSource("DataSet1", dt);
                var result = lr.Execute(RenderType.Pdf, extension5, parameters, mimtype);
                return File(result.MainStream, MediaTypeNames.Application.Pdf, "BA");
            }
            return Ok(param);
        }



        private DataTable GetAchat(Guid id)
        {
            var item = (from x in _myDbContext.detailAchats
                        where x.achatId == id
                        select new
                        {
                            ArticleId = x.articleId,
                            achatId = x.achatId,
                            Article = x.article,
                            Emballage = x.emballage,
                            Quantite = x.quantite,
                            PrixUnit = x.prixUnit,
                            PrixTotal = x.prixTotal,
                        }).ToList();

            var dt = new DataTable();
            dt.Columns.Add("ArticleId");
            dt.Columns.Add("achatId");
            dt.Columns.Add("Article");
            dt.Columns.Add("Emballage");
            dt.Columns.Add("Quantite");
            dt.Columns.Add("PrixUnit");
            dt.Columns.Add("PrixTotal");
            System.Data.DataRow row;

            foreach (var list in item)
            {
                row = dt.NewRow();

                row["ArticleId"] = list.ArticleId;
                row["Article"] = list.Article;
                row["achatId"] = list.achatId;
                row["Emballage"] = list.Emballage;
                row["Quantite"] = list.Quantite;
                row["PrixUnit"] = list.PrixUnit;
                row["PrixTotal"] = list.PrixTotal;
                dt.Rows.Add(row);

            }

            return dt;
        }


        //[HttpPost("fs")]
        //public ActionResult PrintFS(FicheStockRequest request)
        //{


        //    if (request != null)
        //    {
        //        var dt = new DataTable();
        //        dt = GetFS(request.utilisateurId, request.date1, request.date2);
        //        int extension = 1;
        //        var mimtype = "";
        //        var path = $"{this._webHostEnvironment.WebRootPath}\\ReportFS.rdlc";
        //        Dictionary<string, string> parameters = new Dictionary<string, string>();
        //        parameters.Add("date1", request.date1);
        //        parameters.Add("date2", request.date2);
        //        LocalReport lr = new(path);
        //        lr.AddDataSource("DataSet1", dt);
        //        var result = lr.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //        return File(result.MainStream, MediaTypeNames.Application.Pdf, "BA");
        //    }
        //    return Ok("Founded");
        //}



        //private DataTable GetFS(Guid utilisateurId, string date1, string date2)
        //{
        //    var item = (from x in _myDbContext.detailAchats
        //                join ac in _myDbContext.achats on x.achatId equals ac.id
        //                join c in _myDbContext.detailCommandes on x.articleId equals c.articleId
        //                join l in _myDbContext.detailLivraisons on c.articleId equals l.articleId
        //                join li in _myDbContext.livraisons on l.livraisonId equals li.id
        //                join f in _myDbContext.detailFactures on l.articleId equals f.articleId
        //                join fa in _myDbContext.factures on f.factureId equals fa.id
        //                join a in _myDbContext.articles on f.articleId equals a.id
        //                join u in _myDbContext.utilisateurs on utilisateurId equals u.id
        //                join lo in _myDbContext.locations on u.locationId equals lo.id
        //                join e in _myDbContext.emballageByArticles on a.id equals e.articleId
        //                where (ac.dateAchat >= DateTime.Parse(date1) && ac.dateAchat <= DateTime.Parse(date2)
        //                 && li.dateLivraison >= DateTime.Parse(date1) && li.dateLivraison <= DateTime.Parse(date2)
        //                 && fa.dateFacture >= DateTime.Parse(date1) && fa.dateFacture <= DateTime.Parse(date2))
        //                select new
        //                {
        //                    libelle = a.designation,
        //                    entrees = x.quantite + l.quantite,
        //                    sorties = f.quantite,
        //                    diponible = (x.quantite + l.quantite) - f.quantite,
        //                    seuil = a.stockMinimal,
        //                    emballage = e.emballageDetail

        //                }).ToList();

        //    var dt = new DataTable();
        //    dt.Columns.Add("ArticleId");
        //    dt.Columns.Add("achatId");
        //    dt.Columns.Add("Article");
        //    dt.Columns.Add("Emballage");
        //    dt.Columns.Add("Quantite");
        //    dt.Columns.Add("PrixUnit");
        //    dt.Columns.Add("PrixTotal");
        //    System.Data.DataRow row;

        //    foreach (var list in item)
        //    {
        //        row = dt.NewRow();

        //        row["ArticleId"] = list.ArticleId;
        //        row["Article"] = list.Article;
        //        row["achatId"] = list.achatId;
        //        row["Emballage"] = list.Emballage;
        //        row["Quantite"] = list.Quantite;
        //        row["PrixUnit"] = list.PrixUnit;
        //        row["PrixTotal"] = list.PrixTotal;
        //        dt.Rows.Add(row);

        //    }

        //    return dt;
        //}


        [HttpGet("paie/{id:Guid}")]
        public ActionResult PrintPaie(Guid id)
        {
            var param = _myDbContext.paiements.FirstOrDefault(c => c.id == id);
            var utilisateur = _myDbContext.utilisateurs.FirstOrDefault(x => x.id == param.utilisateurId);
            var facture = _myDbContext.factures.FirstOrDefault(x => x.id == param.factureId);

            if (param != null)
            {
                var dt = new DataTable();
                dt = GetAchat(id);
                int extension6 = (int)(DateTime.Now.Ticks >> 10);
                var mimtype = "";
                var path = $"{this._webHostEnvironment.WebRootPath}\\ReportRecuPaiePOS.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("utilisateur", utilisateur.nom + " " + utilisateur.postnom);
                parameters.Add("date", param.datePaiement.ToString());
                parameters.Add("numeroFacture", facture.numeroFacture);
                parameters.Add("client", facture.client);
                parameters.Add("montant", param.montantPayer.ToString());
                LocalReport lr = new(path);
                lr.AddDataSource("DataSet1", dt);
                var result = lr.Execute(RenderType.Pdf, extension6, parameters, mimtype);
                return File(result.MainStream, MediaTypeNames.Application.Pdf, "Recu");
            }
            return Ok(param);
        }

    }
}
