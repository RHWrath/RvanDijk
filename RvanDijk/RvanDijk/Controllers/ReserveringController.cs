using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RvanDijk.Models;
using RvanDijkDal;
using RvanDijkLogic.Interfaces;
using RvanDijkLogic;
using RvanDijkLogic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            IReservering NewIDal = new ReserveringSSMS(_configuration.GetConnectionString("ConnectionString")!);
            ReserveringLogic reserveringLogic = new ReserveringLogic(NewIDal);

            List<VMReservering> VMReserveringen = new();

            foreach (Reservering reservering in reserveringLogic.GetReserveringen())
            {
                VMReservering VMreservering = new();

                VMreservering.ReserveringID = reservering.ReservationID;
                VMreservering.KlantNaam = reservering.KlantNaam;
                VMreservering.Tijd_Datum = reservering.Tijd_Datum;

                VMReserveringen.Add(VMreservering);
            }
            return View(VMReserveringen);

        }





        // GET: ReserveringController/Create
        [HttpGet]
        public ActionResult Create()
        {
            IKlant NewIDal = new KlantSSMS(_configuration.GetConnectionString("ConnectionString")!);
            KlantLogic klantLogic = new KlantLogic(NewIDal);
            List<string> KlantLijst = new List<string>();

            foreach (Klant klant in klantLogic.GetKlanten())
            {
                KlantLijst.Add(klant.Naam);
            }

            ViewBag.Klanten = new SelectList(KlantLijst);
            VMReservering vMReservering = new VMReservering();
            return View(vMReservering);
        }

        // POST: ReserveringController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMReservering reservering)
        {
            IReservering NewDal = new ReserveringSSMS(_configuration.GetConnectionString("ConnectionString")!);
            ReserveringLogic reserveringLogic = new ReserveringLogic(NewDal);
            reserveringLogic.CreateReservering(reservering.KlantNaam, reservering.Tijd_Datum);
            return RedirectToAction("Index");
        }
        

        // GET: ReserveringController/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: ReserveringController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {            
                IReservering NewDal = new ReserveringSSMS(_configuration.GetConnectionString("ConnectionString")!);
                ReserveringLogic reserveringLogic = new ReserveringLogic(NewDal);
                reserveringLogic.DeleteReservering(id);
                return RedirectToAction("Index");           
        }
    }
}
