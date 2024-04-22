﻿using Microsoft.Data.SqlClient;
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
                //reservering.Tijd = DateTime.TryParse(Reader["R.Tijd"].ToString());
                Reserveringen.Add(reservering);
            }
            Reader.Close();
            Con.Close();
            return Reserveringen;
        }
        
    }
}
