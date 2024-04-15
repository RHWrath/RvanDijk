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

        // GET: InstructeurController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InstructeurController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstructeurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructeurController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InstructeurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructeurController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InstructeurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
