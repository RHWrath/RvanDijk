using Microsoft.Data.SqlClient;
using RvanDijkLogic.Interfaces;
using RvanDijkLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            SqlCommand cmd = new SqlCommand("SELECT R.ID as 'R.ID', K.Naam as 'K.Naam', R.Tijd_Datum as 'R.Tijd_Datum' FROM Reservation as R" +
                " INNER JOIN Klant as K ON R.Klant_ID = K.ID", Con);
            Con.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Reservering reservering = new Reservering();
                reservering.ReservationID = Convert.ToInt32(Reader["R.ID"]);
                reservering.KlantNaam = Convert.ToString(Reader["K.Naam"])!;
                DateTime Tijd_Datum = new DateTime();
                Tijd_Datum = Convert.ToDateTime(Reader["R.Tijd_Datum"].ToString());
                reservering.Tijd_Datum = Tijd_Datum;
                Reserveringen.Add(reservering);
            }
            Reader.Close();
            Con.Close();
            return Reserveringen;
        }

        

        public void CreateReservering(string klantNaam, DateTime dateTime)
        {            
            SqlConnection Con = new SqlConnection(_DBcon);
            Con.Open();
            SqlCommand cmd = new SqlCommand("INSERT Reservation (Klant_ID, Tijd_Datum) VALUES ((SELECT ID FROM Klant WHERE Naam = @klantNaam), @dateTime)", Con);
            cmd.Parameters.AddWithValue("klantNaam", klantNaam);
            cmd.Parameters.AddWithValue("dateTime", dateTime);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("UPDATE Klant SET Vergoeding = (SELECT Vergoeding From Klant WHERE Naam = @klantNaam) - 1 WHERE Naam = @klantNaam;", Con);
            cmd.Parameters.AddWithValue("klantNaam", klantNaam);
            cmd.ExecuteNonQuery();
            Con.Close();
        }

        public void DeleteReservering(int reserveringID)
        {
            SqlConnection Con =new SqlConnection(_DBcon);
            Con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Reservation WHERE ID = @reserveringID;", Con);
            cmd.Parameters.AddWithValue("reserveringID", reserveringID);
            cmd.ExecuteNonQuery();
            Con.Close();
        }

        public int ReserveringCounter()
        {
            int Count = 0;
            SqlConnection Con = new SqlConnection(_DBcon);
            DateTime dateTimeNow = DateTime.Now;
            string formatDateTime = dateTimeNow.ToString("yyyy-MM-dd");

            

            SqlCommand cmd = new SqlCommand("SELECT DISTINCT COUNT(R.ID) AS 'R.ID' FROM Reservation AS R WHERE CONVERT(Date, R.Tijd_Datum) = @DatumParameter");
            cmd.Parameters.AddWithValue("DatumParameter", formatDateTime);
            cmd.Connection = Con;
            Con.Open();
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {                
                    Count = Convert.ToInt32(Reader["R.ID"]);                
            }

            Con.Close();
            return Count;
            

        }

    }
}
