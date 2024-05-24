using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RvanDijk.Models;
using RvanDijkDal;
using RvanDijkLogic.Interfaces;
using RvanDijkLogic;
using RvanDijkLogic.Models;

namespace RvanDijk.Controllers
{
    public class AbbonementController : Controller
    {
        // GET: AbbonementController
        private IConfiguration _configuration;


        public AbbonementController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ActionResult Index()
        {
            IAbbonementDAL NewIDal = new AbbonementDAL(_configuration.GetConnectionString("ConnectionString")!);
            AbbonementLogic abbonementLogic = new AbbonementLogic(NewIDal);

            List<VMAbbonement> VMAbbonementen = new();

            foreach (Abbonement abbonement in abbonementLogic.GetAbbonementen())
            {
                VMAbbonement VMabbonement = new();

                VMabbonement.ID = abbonement.ID;
                VMabbonement.Name = abbonement.Name;
                VMabbonement.Vergoeding = abbonement.Vergoeding;
                VMabbonement.Prijs = abbonement.Prijs;

                VMAbbonementen.Add(VMabbonement);
            }
            return View(VMAbbonementen);
        }
    }
}
