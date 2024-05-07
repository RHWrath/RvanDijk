using RvanDijkLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RvanDijkLogic.Interfaces
{
    public interface IReservering
    {
        IEnumerable<Reservering> GetReserveringen();
        void CreateReservering(string klantNaam, DateTime dateTime);
        void DeleteReservering(int reserveringID);
    }
}
