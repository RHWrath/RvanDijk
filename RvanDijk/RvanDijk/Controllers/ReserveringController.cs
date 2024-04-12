using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RvanDijk.Models;
using RvanDijkDal;
using RvanDijkLogic.Models;

namespace RvanDijk.Controllers
{
    public class ReserveringController : Controller
    {
        // GET: ReserveringController
        private IConfiguration _configuration;


        public ReserveringController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ActionResult Index()
        {
            ReserveringSSMS NewDal = new ReserveringSSMS(_configuration.GetConnectionString("ConnectionString")!);

            List<VMReservering> VMReserveringen = new();

            foreach (Reservering reservering in NewDal.GetReserveringen())
            {
                VMReservering VMreservering = new();

                VMreservering.KlantID = reservering.KlantID;
                VMreservering.KlantNaam = reservering.KlantNaam;
                VMreservering.AbbonementNaam = reservering.AbbonementNaam;
                VMreservering.KlantVergoeding = reservering.KlantVergoeding;

                VMReserveringen.Add(VMreservering);
            }
            return View(VMReserveringen);

        }

        // GET: ReserveringController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReserveringController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReserveringController/Create
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

        // GET: ReserveringController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReserveringController/Edit/5
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

        // GET: ReserveringController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReserveringController/Delete/5
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
