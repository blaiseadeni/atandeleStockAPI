using AspNetCore.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using ATD_API.Data;
using ATD_API.Dtos;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ATD_API.Controllers.Editions
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventaireComptableController : ControllerBase
    {
        public readonly MyDbContext _context;
        private readonly IIventaitaireComptable _repository;
        private readonly IMapper _mapper;

        public InventaireComptableController(MyDbContext context, IIventaitaireComptable repository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("ajouter")]
        public async Task<ActionResult<InvetaireComptable>> Add([FromBody] List<InvetaireComptableMod> request)
        {
            if (request != null)
            {
                foreach (var item in request)
                {
                    InvetaireComptable invetaire = new InvetaireComptable();
                    invetaire.articleId = item.articleId;
                    invetaire.locationId = item.locationId;
                    invetaire.utilisateurId = item.utilisateurId;
                    invetaire.date1 = item.date1;
                    invetaire.created = item.created;
                    invetaire.date = item.date;
                    invetaire.montantEnt = item.montantEnt;
                    invetaire.qteEnt = item.qteEnt;
                    invetaire.montantFinal = item.montantFinal;
                    invetaire.stockFinal = item.stockFinal;
                    invetaire.montantInit = item.montantInit;
                    invetaire.stockInit = item.stockInit;
                    invetaire.montantSort = item.montantSort;
                    invetaire.qteSort = invetaire.qteSort;
                    _context.inventaireComptables.Add(invetaire);
                }
            }
            _context.SaveChanges();
            return Ok("Saved successfullly");
        }

        [HttpPost("invCompt")]
        public async Task<ActionResult> IventCompable(InventaireRequest request)
        {

            //var id = "B097FA86-B69D-4A3C-DF2E-08DBF03BE257";
            //var date1 = "2023-12-07";
            //var date2 = "2023-12-21";

            var entres = _context.mouvements
                .Where(c => c.type == "ENTRE" && c.locationId == request.id && (c.created >= DateTime.Parse(request.date1) && c.created <= DateTime.Parse(request.date2)))
                .GroupBy(x => x.articleId)
                .Select(group => new
                {
                    articleId = group.Key,
                    quantite = group.Sum(c => c.quantite),
                })
                .OrderBy(dc => dc.articleId)
                .ToList();

            var sorties = _context.mouvements
                .Where(c => c.type == "SORTIE" && c.locationId == request.id && (c.created >= DateTime.Parse(request.date1) && c.created <= DateTime.Parse(request.date2)))

                .GroupBy(e => e.articleId)
                .Select(group => new
                {
                    articleId = group.Key,
                    quantite = group.Sum(c => c.quantite),
                })
                .OrderBy(dc => dc.articleId)
                .ToList();


            List<InvComtpableResponse> items = new List<InvComtpableResponse>();
            foreach (var entre in entres)
            {
                InvComtpableResponse model = new InvComtpableResponse();
                var prix = await _context.prixArticleLocations.FirstOrDefaultAsync(c => c.articleId == entre.articleId);
                var article = await _context.articles.FirstOrDefaultAsync(c => c.id == entre.articleId);
                var emballage = await _context.emballageByArticles.FirstOrDefaultAsync(c => c.articleId == article.id);
                var invent = _context.inventaireComptables
                    .Where(c => c.articleId == article.id)
                    .OrderByDescending(x => x.date)
                    .Take(1)
                    .OrderBy(x => x.date)
                    .FirstOrDefault();

                foreach (var sortie in sorties)
                {


                    if (entre.articleId == null)
                    {
                        model.articleId = entre.articleId;
                        model.article = article.designation;
                        model.qteEnt += 0;
                        model.qteSort = sortie.quantite;
                        model.montantEnt = prix.prixVenteDetail * model.qteEnt;
                        model.montantSort = prix.prixVenteDetail * model.qteSort;
                        model.stockInitial = invent.stockFinal;
                        model.montantInitial = invent.montantFinal;
                        model.stockFinal = model.stockInitial + model.qteEnt - model.qteSort;
                        model.montantFinal = model.stockInitial + model.qteEnt - model.qteSort * prix.prixVenteDetail;
                        model.emballage = emballage.emballageDetail;
                    }
                    else if (sortie.articleId == null)
                    {
                        model.articleId = entre.articleId;
                        model.article = article.designation;
                        model.article = article.designation;
                        model.qteEnt = entre.quantite;
                        model.qteSort += 0;
                        model.montantEnt = prix.prixVenteDetail * model.qteEnt;
                        model.montantSort = prix.prixVenteDetail * model.qteSort;
                        if (invent != null)
                        {
                            model.stockInitial = invent.stockFinal;
                            model.montantInitial = invent.montantFinal;
                        }
                        else
                        {
                            model.stockInitial += 0;
                            model.montantInitial += 0;
                        }
                        model.stockFinal = model.stockInitial + model.qteEnt - model.qteSort;
                        model.montantFinal = model.stockFinal * prix.prixVenteDetail;
                        model.emballage = emballage.emballageDetail;
                    }
                    else if (entre.articleId == sortie.articleId)
                    {
                        model.articleId = entre.articleId;
                        model.article = article.designation;
                        model.qteEnt = entre.quantite;
                        model.qteSort = sortie.quantite;
                        model.montantEnt = prix.prixVenteDetail * model.qteEnt;
                        model.montantSort = prix.prixVenteDetail * model.qteSort;
                        model.emballage = emballage.emballageDetail;

                        if (invent != null)
                        {
                            model.stockInitial = invent.stockFinal;
                            model.montantInitial = invent.montantFinal;
                        }
                        else
                        {
                            model.stockInitial += 0;
                            model.montantInitial += 0;
                        }
                        model.stockFinal = model.stockInitial + model.qteEnt - model.qteSort;
                        model.montantFinal = model.stockFinal * prix.prixVenteDetail;
                        model.emballage = emballage.emballageDetail;
                    }
                    else if (entre.articleId != null && sortie.articleId == null)
                    {
                        model.articleId = entre.articleId;
                        model.article = article.designation;
                        model.qteEnt = entre.quantite;
                        model.qteSort += 0;
                        model.montantEnt = prix.prixVenteDetail * model.qteEnt;
                        model.montantSort = prix.prixVenteDetail * model.qteSort;
                        if (invent != null)
                        {
                            model.stockInitial = invent.stockFinal;
                            model.montantInitial = invent.montantFinal;
                        }
                        else
                        {
                            model.stockInitial += 0;
                            model.montantInitial += 0;
                        }
                        model.stockFinal = model.stockInitial + model.qteEnt - model.qteSort;
                        model.montantFinal = model.stockFinal * prix.prixVenteDetail;
                        model.emballage = emballage.emballageDetail;
                    }
                    else if (entre.articleId == null && sortie.articleId != null)
                    {
                        model.articleId = entre.articleId;
                        model.article = article.designation;
                        model.qteEnt = entre.quantite;
                        model.qteSort += 0;
                        model.montantEnt = prix.prixVenteDetail * model.qteEnt;
                        model.montantSort = prix.prixVenteDetail * model.qteSort;
                        if (invent != null)
                        {
                            model.stockInitial = invent.stockFinal;
                            model.montantInitial = invent.montantFinal;
                        }
                        else
                        {
                            model.stockInitial += 0;
                            model.montantInitial += 0;
                        }
                        model.stockFinal = model.stockInitial + model.qteEnt - model.qteSort;
                        model.montantFinal = model.stockFinal * prix.prixVenteDetail;
                        model.emballage = emballage.emballageDetail;
                    }
                    else if (entre.articleId != null && entre.articleId != sortie.articleId)
                    {
                        model.articleId = entre.articleId;
                        model.article = article.designation;
                        model.qteEnt = entre.quantite;
                        model.qteSort += 0;
                        model.montantEnt = prix.prixVenteDetail * model.qteEnt;
                        model.montantSort = prix.prixVenteDetail * model.qteSort;
                        if (invent != null)
                        {
                            model.stockInitial = invent.stockFinal;
                            model.montantInitial = invent.montantFinal;
                        }
                        else
                        {
                            model.stockInitial += 0;
                            model.montantInitial += 0;
                        }
                        model.stockFinal = model.stockInitial + model.qteEnt - model.qteSort;
                        model.montantFinal = model.stockFinal * prix.prixVenteDetail;
                        model.emballage = emballage.emballageDetail;
                    }
                    items.Add(model);
                }
            }
            return Ok(items.Distinct());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<InvetaireComptable>> FindAll(Guid id)
        {
            var items = (from c in _context.inventaireComptables
                         join a in _context.articles on c.articleId equals a.id
                         join e in _context.emballageByArticles on a.id equals e.articleId
                         where c.locationId == id
                         select new
                         {
                             articleId = a.id,
                             article = a.designation,
                             qteEnt = c.qteEnt,
                             qteSort = c.qteSort,
                             montantEnt = c.montantEnt,
                             montantSort = c.montantSort,
                             stockInitial = c.stockInit,
                             montantInitial = c.montantInit,
                             stockFinal = c.stockFinal,
                             montantFinal = c.montantFinal,
                             emballage = e.emballageDetail,
                             date = c.date,
                             date1 = c.date1,
                         });
            return Ok(items.Distinct());
        }
    }
}
