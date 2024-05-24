using Microsoft.Data.SqlClient;
using RvanDijkLogic.Interfaces;
using RvanDijkLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RvanDijkDal
{
    public class KlantDAL : IKlantDAL
    {
        string _DBcon;

        public KlantDAL(string DBcon)
        {
            _DBcon = DBcon;
        }
        public IEnumerable<Klant> GetKlanten()
        {
            List<Klant> Klanten = new();
            SqlConnection Con = new SqlConnection(_DBcon);
            SqlCommand cmd = new SqlCommand("SELECT K.ID as 'K.ID', K.Naam as 'K.Naam', K.Vergoeding as 'K.Vergoeding' FROM Klant as K", Con);
            Con.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Klant klant = new Klant();
                klant.ID = Convert.ToInt32(Reader["K.ID"]);
                klant.Naam = Convert.ToString(Reader["K.Naam"]);
                klant.Vergoeding = Convert.ToInt32(Reader["K.Vergoeding"]);
                Klanten.Add(klant);
            }
            Reader.Close();
            Con.Close();
            return Klanten;
        }
    }
    
}
