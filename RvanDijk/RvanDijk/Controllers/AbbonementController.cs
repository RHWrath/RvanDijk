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
            IAbbonement NewIDal = new AbbonementSSMS(_configuration.GetConnectionString("ConnectionString")!);
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

        // GET: AbbonementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AbbonementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AbbonementController/Create
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

        // GET: AbbonementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AbbonementController/Edit/5
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

        // GET: AbbonementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AbbonementController/Delete/5
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
