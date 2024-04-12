using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RvanDijk.Models;

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
            List<Reservering> reserverings = new List<Reservering>();
            SqlConnection Con = new SqlConnection(_configuration.GetConnectionString("ConnectionString")!);
            SqlCommand cmd = new SqlCommand("SELECT Klant.ID, Klant.Naam, Abbonement.Naam, Klant.Vergoeding FROM Klant INNER JOIN Abbonement ON Klant.Abbonement_ID = Abbonement.ID", Con);
            Con.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Reservering reservering = new Reservering();
                reservering.KlantID = Reader.GetInt32(0);
                reservering.KlantNaam = Reader.GetString(1);
                reservering.AbbonementNaam = Reader.GetString(2);
                reservering.KlantVergoeding = Reader.GetInt32(3);
                reserverings.Add(reservering);
            }
            Reader.Close();
            Con.Close();
            return View(reserverings);
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
