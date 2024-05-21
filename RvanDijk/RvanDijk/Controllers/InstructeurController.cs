using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RvanDijk.Models;
using System.Drawing;
using RvanDijkDal;
using RvanDijkLogic.Models;
using RvanDijkLogic;
using RvanDijkLogic.Interfaces;

namespace RvanDijk.Controllers
{
    public class InstructeurController : Controller
    {
        // GET: InstructeurController
        private IConfiguration _configuration;


        public InstructeurController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult Index()
        {
            Iinstructeur NewIDal = new InstructeurSSMS(_configuration.GetConnectionString("ConnectionString")!);
            InstructeurLogic instructeurLogic = new InstructeurLogic(NewIDal);

            List<VMInstructeur> VMinstructeurs = new();

            foreach (Instructeur instructeur in instructeurLogic.GetInstructeurs())
            {
                VMInstructeur VMinstructeur = new();

                VMinstructeur.ID = instructeur.ID;
                VMinstructeur.Name = instructeur.Name;
                VMinstructeur.Prijs = instructeur.Prijs;

                VMinstructeurs.Add(VMinstructeur);
            }

            return View(VMinstructeurs);
        }
    }
}
