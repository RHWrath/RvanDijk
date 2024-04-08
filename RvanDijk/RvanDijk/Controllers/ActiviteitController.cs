using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RvanDijk.Models;
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
            List<Activiteit> activiteiten = new List<Activiteit>();
            SqlConnection Con = new SqlConnection(_configuration.GetConnectionString("ConnectionString")!);
            SqlCommand cmd = new SqlCommand("SELECT ID, Naam, Prijs FROM Activiteit", Con);
            Con.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Activiteit activiteit = new Activiteit();
                activiteit.ID = Reader.GetInt32(0);
                activiteit.Name = Reader.GetString(1);
                activiteit.Prijs = Reader.GetDecimal(2);
                activiteiten.Add(activiteit);
            }
            Reader.Close();
            Con.Close();
            return View(activiteiten);
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
