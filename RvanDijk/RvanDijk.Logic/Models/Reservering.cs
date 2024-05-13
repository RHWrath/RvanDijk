using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RvanDijkLogic.Models
{
    public class Reservering
    {
        public int ReservationID { get; set; }
        public string KlantNaam { get; set; }
        public DateTime Tijd_Datum { get; set; }
        
        public int ReserveringCount {  get; set; }
    }
}
