using Microsoft.Data.SqlClient;
using RvanDijkLogic.Interfaces;
using RvanDijkLogic.Models;

namespace RvanDijkDal
{
    public class ActiviteitDAL : IActiviteitDAL
    {
        string _DBcon = "";

        public ActiviteitDAL(string DBcon)
        {
            _DBcon = DBcon;
        }
        public IEnumerable<Activiteit> GetActiviteit()
        {
            List<Activiteit> activiteiten = new List<Activiteit>();
            SqlConnection Con = new SqlConnection(_DBcon!);
            SqlCommand cmd = new SqlCommand("SELECT ID, Naam, Prijs FROM Activiteit", Con);
            Con.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Activiteit activiteit = new Activiteit();
                activiteit.ID = Reader.GetInt32(0);
                activiteit.Naam = Reader.GetString(1);
                activiteit.Prijs = Reader.GetDecimal(2);
                activiteiten.Add(activiteit);
            }
            Reader.Close();
            Con.Close();
            return activiteiten;
        }
    }
}
