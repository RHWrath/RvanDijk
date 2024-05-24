using RvanDijkLogic.Interfaces;
using RvanDijkLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rvandijk_UnitTest
{
    public class MockDal : IReservering
    {
        public int ID = 1;
        public string Name = "Bert";
        public DateTime dateTime = new DateTime(2024,8,23);
        public int Counter = 10;

        public void CreateReservering(string klantNaam, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public void DeleteReservering(int reserveringID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservering> GetReserveringen()
        {
            return new List<Reservering>() { new Reservering() 
            { 
                ReservationID = ID, 
                KlantNaam = Name, 
                Tijd_Datum = dateTime, 
                ReserveringCount = 1 
            } 
            };
        }

        public int ReserveringCounter()
        {
            return Counter;
        }
    }
}
