using AspNetCore.Reporting;
using ATD_API.Data;
using ATD_API.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Mime;

namespace ATD_API.Controllers.Editions
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportInventaireController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;
        private readonly ILogger<ReportInventaireController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public ReportInventaireController(MyDbContext myDbContext, ILogger<ReportInventaireController> logger, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _myDbContext = myDbContext;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _mapper = mapper;
        }

        [HttpPost("fis")]
        public async Task<ActionResult<object>> PrintFIS([FromBody] VerifyRequest request)
        {
            var param = _myDbContext.inventaires.FirstOrDefault(c => c.locationId == request.locationId && (c.date1 >= DateTime.Parse(request.date1) && c.date2 <= DateTime.Parse(request.date2)));

            if (param != null)
            {
                var dt = new DataTable();
                dt = GetFIS(param.locationId, param.date1, param.date2);
                int extension7 = (int)(DateTime.Now.Ticks >> 10);
                var mimtype = "";
                var path = $"{this._webHostEnvironment.WebRootPath}\\ReportFIS.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("date1", param.date1.ToString());
                parameters.Add("date2", param.date2.ToString());
                LocalReport lr = new(path);
                lr.AddDataSource("DataSet1", dt);
                var result = lr.Execute(RenderType.Pdf, extension7, parameters, mimtype);
                return File(result.MainStream, MediaTypeNames.Application.Pdf, "FIS");
            }
            return Ok(param);
        }



        private DataTable GetFIS(Guid locationId, DateTime date1, DateTime date2)
        {
            var item = (from x in _myDbContext.inventaires
                        join a in _myDbContext.articles on x.articleId equals a.id
                        where x.locationId == locationId && (x.date1 >= date1 && x.date2 <= date2)
                        select new
                        {
                            libelle = a.designation,
                            quantitePhysique = x.quantitePhysique,
                            quantiteLogique = x.quantiteLogique,
                            ecart = x.ecart,

                        }).ToList();

            var dt = new DataTable();
            dt.Columns.Add("libelle");
            dt.Columns.Add("quantitePhysique");
            dt.Columns.Add("quantiteLogique");
            dt.Columns.Add("ecart");
            System.Data.DataRow row;

            foreach (var list in item)
            {
                row = dt.NewRow();

                row["libelle"] = list.libelle;
                row["quantiteLogique"] = list.quantiteLogique;
                row["quantitePhysique"] = list.quantitePhysique;
                row["ecart"] = list.ecart;
                dt.Rows.Add(row);

            }

            return dt;
        }




        [HttpPost("fs")]
        public async Task<ActionResult> PrintFS([FromBody] MouvementStockRequest request)
        {
            var param = _myDbContext.mouvementStocks.FirstOrDefault(c => c.locationId == request.locationId && c.articleId == request.articleId && c.periode == request.periode.ToString());

            if (param != null)
            {
                var dt = new DataTable();
                dt = GetFS(param.locationId, param.articleId, param.periode);
                int extension8 = (int)(DateTime.Now.Ticks >> 10);
                var mimtype = "";
                var path = $"{this._webHostEnvironment.WebRootPath}\\ReportFS1.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("periode", param.periode);
                parameters.Add("article", param.article);
                LocalReport lr = new(path);
                lr.AddDataSource("DataSet1", dt);
                var result = lr.Execute(RenderType.Pdf, extension8, parameters, mimtype);
                return File(result.MainStream, MediaTypeNames.Application.Pdf, "FS");
            }
            return Ok(param);
        }



        private DataTable GetFS(Guid locationId, Guid articleId, string periode)
        {
            var item = (from m in _myDbContext.mouvementStocks
                        where m.locationId == locationId && m.periode == periode && m.articleId == articleId
                        select new
                        {
                            libelle = m.libelle,
                            date = m.date,
                            qteEntr = m.qteEntr,
                            puEntr = m.puEntr,
                            ptEnt = m.ptEnt,
                            qteSort = m.qteSort,
                            puSort = m.puSort,
                            ptSort = m.ptSort,
                            qteSt = m.qteSt

                        }).ToList();

            var dt = new DataTable();
            dt.Columns.Add("libelle");
            dt.Columns.Add("date");
            dt.Columns.Add("qteEntr");
            dt.Columns.Add("puEntr");
            dt.Columns.Add("ptEnt");
            dt.Columns.Add("qteSort");
            dt.Columns.Add("puSort");
            dt.Columns.Add("ptSort");
            dt.Columns.Add("qteSt");
            System.Data.DataRow row;

            foreach (var list in item)
            {
                row = dt.NewRow();

                row["libelle"] = list.libelle;
                row["date"] = list.date;
                row["qteEntr"] = list.qteEntr;
                row["puEntr"] = list.puEntr;
                row["ptEnt"] = list.ptEnt;
                row["qteSort"] = list.qteSort;
                row["puSort"] = list.puSort;
                row["ptSort"] = list.ptSort;
                row["qteSt"] = list.qteSt;
                dt.Rows.Add(row);

            }

            return dt;
        }

        [HttpPost("vente")]
        public async Task<ActionResult> PrintVente([FromBody] VerifyRequest request)
        {
            var param = _myDbContext.factures.FirstOrDefault(c => c.locationId == request.locationId && (c.dateFacture >= DateTime.Parse(request.date1) && c.dateFacture <= DateTime.Parse(request.date2)));
            var utilisateur = _myDbContext.utilisateurs.FirstOrDefault(x => x.id == param.utilisateurId);
            var location = _myDbContext.locations.FirstOrDefault(x => x.id == request.locationId);

            var item = (from x in _myDbContext.factures
                        where x.locationId == request.locationId && (x.dateFacture >= DateTime.Parse(request.date1) && x.dateFacture <= DateTime.Parse(request.date2))
                        select new
                        {
                            locationId = x.locationId,
                            total = x.totalHt,

                        }).ToList();

            var sorties = _myDbContext.factures
               .Where(x => x.locationId == request.locationId && (x.dateFacture >= DateTime.Parse(request.date1) && x.dateFacture <= DateTime.Parse(request.date2)))

               .GroupBy(e => e.locationId)
               .Select(group => new
               {
                   total = group.Sum(c => c.totalHt),
               }).ToList();

            if (param != null)
            {
                var dt = new DataTable();
                dt = GetVente(request.locationId, request.date1, request.date2);
                int extension9 = (int)(DateTime.Now.Ticks >> 10);
                var mimtype = "";
                var path = $"{this._webHostEnvironment.WebRootPath}\\ReportVente.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("date1", request.date1);
                parameters.Add("date2", request.date2);
                parameters.Add("location", location.designation);
                parameters.Add("total", sorties.Sum(c => c.total).ToString());
                LocalReport lr = new(path);
                lr.AddDataSource("DataSet1", dt);
                var result = lr.Execute(RenderType.Pdf, extension9, parameters, mimtype);
                return File(result.MainStream, MediaTypeNames.Application.Pdf, "rapport");
            }
            return Ok(param);
        }


        private DataTable GetVente(Guid locationId, string date1, string date2)
        {
            var item = (from x in _myDbContext.detailFactures
                        join f in _myDbContext.factures on x.factureId equals f.id
                        where f.locationId == locationId && (f.dateFacture >= DateTime.Parse(date1) && f.dateFacture <= DateTime.Parse(date2))
                        select new
                        {
                            id = x.id,
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


        [HttpGet("resultat/{annee:int}")]
        public ActionResult PrintResultat(int annee)
        {


            var entres = _myDbContext.mouvementStocks
           .Where(c => c.libelle == "Entrées" && c.date.Year == annee)
           .GroupBy(x => x.date.Year)
           .Select(group => new
           {
               annee = group.Key,
               montantEntre = group.Sum(c => c.ptEnt),
           }).ToList();


            var sorties = _myDbContext.mouvementStocks
            .Where(c => c.libelle == "Sorties" && c.date.Year == annee)
            .GroupBy(x => x.date.Year)
            .Select(group => new
            {
                annee = group.Key,
                montantSortie = group.Sum(c => c.ptSort),
            }).ToList();

            var depenses = _myDbContext.depenses
            .Where(c => c.created.Year == annee)
            .GroupBy(x => x.created.Year)
            .Select(group => new
            {
                annee = group.Key,
                montantDepense = group.Sum(c => c.montant),
            }).ToList();

            ResultatResponse resultat = new ResultatResponse();
            foreach (var item in entres)
            {
                foreach (var item1 in sorties)
                {
                    foreach (var item2 in depenses)
                    {
                        resultat.entree = item.montantEntre;
                        resultat.sortie = item1.montantSortie;
                        resultat.depense = item2.montantDepense;
                        resultat.resultat = (resultat.entree - resultat.sortie) - resultat.depense;
                    }
                }
            }

            if (resultat != null)
            {
                var dt = new DataTable();
                dt = GetResultat();
                int extension10 = (int)(DateTime.Now.Ticks >> 10);
                var mimtype = "";
                var path = $"{this._webHostEnvironment.WebRootPath}\\ReportResultat.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("entree", resultat.entree.ToString());
                parameters.Add("sortie", resultat.sortie.ToString());
                parameters.Add("depense", resultat.depense.ToString());
                parameters.Add("resultat", resultat.resultat.ToString());
                parameters.Add("annee", annee.ToString());
                LocalReport lr = new(path);
                lr.AddDataSource("DataSet1", dt);
                var result = lr.Execute(RenderType.Pdf, extension10, parameters, mimtype);
                return File(result.MainStream, MediaTypeNames.Application.Pdf, "resultat");
            }
            return Ok(resultat);
        }


        private DataTable GetResultat()
        {
            var item = (from x in _myDbContext.detailFactures
                            //where x.factureId == id
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

    }
}
