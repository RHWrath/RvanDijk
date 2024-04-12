using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RvanDijkLogic.Models
{
    public class Reservering
    {
        public int KlantID { get; set; }
        public string KlantNaam { get; set; }
        public string AbbonementNaam { get; set; }
        public int KlantVergoeding { get; set; }
    }
}
