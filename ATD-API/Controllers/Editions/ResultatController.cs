using ATD_API.Data;
using ATD_API.Dtos;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATD_API.Controllers.Editions
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultatController : ControllerBase
    {
        public readonly MyDbContext _context;
        public ResultatController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("facture")]
        public ActionResult Print(int annee)
        {
            var entres = _context.mouvementStocks
            .Where(c => c.libelle == "Entrées" && c.date.Year == annee)
            .GroupBy(x => x.date.Year)
            .Select(group => new
            {
                annee = group.Key,
                montantEntre = group.Sum(c => c.ptEnt),
            }).ToList();


            var sorties = _context.mouvementStocks
            .Where(c => c.libelle == "Sorties" && c.date.Year == annee)
            .GroupBy(x => x.date.Year)
            .Select(group => new
            {
                annee = group.Key,
                montantSortie = group.Sum(c => c.ptSort),
            }).ToList();

            var depenses = _context.depenses
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



            return Ok(resultat);
        }
    }
}
