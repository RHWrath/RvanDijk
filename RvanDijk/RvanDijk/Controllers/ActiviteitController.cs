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

        // GET: ActiviteitController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActiviteitController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActiviteitController/Create
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

        // GET: ActiviteitController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ActiviteitController/Edit/5
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

        // GET: ActiviteitController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActiviteitController/Delete/5
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
