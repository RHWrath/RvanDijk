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
    public class ReserveringSSMS : IReservering
    {
        string _DBcon;

        public ReserveringSSMS(string DBcon)
        {
            _DBcon = DBcon;
        }
        public IEnumerable<Reservering> GetReserveringen()
        {
            List<Reservering> Reserveringen = new List<Reservering>();
            SqlConnection Con = new SqlConnection(_DBcon);
            SqlCommand cmd = new SqlCommand("SELECT Klant.ID, Klant.Naam, Abbonement.Naam, Klant.Vergoeding FROM Klant" +
                " INNER JOIN Abbonement ON Klant.Abbonement_ID = Abbonement.ID", Con);
            Con.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Reservering reservering = new Reservering();
                reservering.KlantID = Reader.GetInt32(0);
                reservering.KlantNaam = Reader.GetString(1);
                reservering.AbbonementNaam = Reader.GetString(2);
                reservering.KlantVergoeding = Reader.GetInt32(3);
                Reserveringen.Add(reservering);
            }
            Reader.Close();
            Con.Close();
            return Reserveringen;
        }
    }
}
