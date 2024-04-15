using Microsoft.Data.SqlClient;
using RvanDijkLogic.Interfaces;
using RvanDijkLogic.Models;

namespace RvanDijkDal
{
    public class InstructeurSSMS:Iinstructeur
    {
        string _DBcon;

        public InstructeurSSMS(string DBcon)
        {
            _DBcon = DBcon;
        }
        public IEnumerable<Instructeur> GetInstructeurs()
        {
            List<Instructeur> instructeurs = new List<Instructeur>();
            SqlConnection Con = new SqlConnection(_DBcon);
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
            return instructeurs;
        }

    }
}
