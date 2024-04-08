using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RvanDijk.Models;
using System.Drawing;

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
            List<Instructeur> instructeurs = new List<Instructeur>();
            SqlConnection Con = new SqlConnection(_configuration.GetConnectionString("ConnectionString")!);
            SqlCommand cmd = new SqlCommand("SELECT ID, Naam, Prijs FROM Instructeur", Con);
            Con.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Instructeur instructeur = new Instructeur();
                instructeur.ID = Reader.GetInt32(0);
                instructeur.Name = Reader.GetString(1);
                instructeur.Prijs = Reader.GetDecimal(2);
                instructeurs.Add(instructeur);
            }
            Reader.Close();
            Con.Close();
            return View(instructeurs);
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
