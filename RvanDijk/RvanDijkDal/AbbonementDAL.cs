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
    public class AbbonementDAL:IAbbonementDAL
    {
        string _DBcon;

        public AbbonementDAL(string DBcon)
        {
            _DBcon = DBcon;
        }
        public IEnumerable<Abbonement> GetAbbonementen()
        {
            List<Abbonement> Abbonementen = new List<Abbonement>();
            SqlConnection Con = new SqlConnection(_DBcon);
            SqlCommand cmd = new SqlCommand("SELECT ID, Naam, Max_Vergoeding, Prijs FROM Abbonement", Con);
            Con.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Abbonement abbonement = new Abbonement();
                abbonement.ID = Reader.GetInt32(0);
                abbonement.Name = Reader.GetString(1);
                abbonement.Vergoeding = Reader.GetInt32(2);
                abbonement.Prijs = Reader.GetDecimal(3);
                Abbonementen.Add(abbonement);
            }
            Reader.Close();
            Con.Close();
            return Abbonementen;
        }
    }
}
