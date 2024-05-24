using RvanDijkLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RvanDijkLogic.Interfaces
{
    public interface IReserveringDAL
    {
        IEnumerable<Reservering> GetReserveringen();
        void CreateReservering(string klantNaam, DateTime dateTime);
        void DeleteReservering(int reserveringID);

        int ReserveringCounter();
    }
}
