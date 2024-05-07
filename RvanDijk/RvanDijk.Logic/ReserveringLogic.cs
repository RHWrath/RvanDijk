using RvanDijkLogic.Interfaces;
using RvanDijkLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RvanDijkLogic
{
    public class ReserveringLogic
    {
        IReservering ReserveringDB { get; }

        public ReserveringLogic(IReservering reservering)
        {
            this.ReserveringDB = reservering;
        }

        public IEnumerable<Reservering> GetReserveringen()
        {
            return ReserveringDB.GetReserveringen();
        }

        

        public void CreateReservering(string klantNaam,DateTime dateTime)
        {
            ReserveringDB.CreateReservering(klantNaam, dateTime);
        }

        public void DeleteReservering(int reserveringID)
        {
            ReserveringDB.DeleteReservering(reserveringID);
        }

    }
}
