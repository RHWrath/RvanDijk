using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RvanDijk.Models;

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
            List<Abbonement> abbonementen = new List<Abbonement>();
            SqlConnection Con = new SqlConnection(_configuration.GetConnectionString("ConnectionString")!);
            SqlCommand cmd = new SqlCommand("SELECT ID, Naam, Vergoeding, Prijs FROM Abbonement", Con);
            Con.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Abbonement abbonement = new Abbonement();
                abbonement.Id = Reader.GetInt32(0);
                abbonement.Name = Reader.GetString(1);
                abbonement.Vergoeding = Reader.GetInt32(2);
                abbonement.Prijs = Reader.GetDecimal(3);
                abbonementen.Add(abbonement);
            }
            Reader.Close();
            Con.Close();
            return View(abbonementen);
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
