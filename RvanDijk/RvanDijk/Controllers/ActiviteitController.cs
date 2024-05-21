using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RvanDijk.Models;
using RvanDijkDal;
using RvanDijkLogic;
using RvanDijkLogic.Interfaces;
using RvanDijkLogic.Models;
using System.Drawing;

namespace RvanDijk.Controllers
{
    public class ActiviteitController : Controller
    {
        // GET: ActiviteitController
        private IConfiguration _configuration;


        public ActiviteitController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        
        public ActionResult Index()
        {
            IActiviteit NewIDal = new ActiviteitSSMS(_configuration.GetConnectionString("ConnectionString")!);
            ActiviteitLogic activiteitLogic = new ActiviteitLogic(NewIDal);

            List<VMActiviteit> VMActiviteiten = new();

            foreach (Activiteit activiteit in activiteitLogic.GetActiviteit())
            {
                VMActiviteit VMactiviteit = new();

                VMactiviteit.ID = activiteit.ID;
                VMactiviteit.Naam = activiteit.Naam;
                VMactiviteit.Prijs = activiteit.Prijs;

                VMActiviteiten.Add(VMactiviteit);
            }
            return View(VMActiviteiten);
        }

    }
}
