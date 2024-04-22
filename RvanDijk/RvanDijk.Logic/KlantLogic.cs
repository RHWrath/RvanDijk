using RvanDijkLogic.Interfaces;
using RvanDijkLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RvanDijkLogic
{
    public class KlantLogic
    {
        IKlant KlantDB { get; }

        public KlantLogic(IKlant klant)
        {
            this.KlantDB = klant;
        }

        public IEnumerable<Klant> GetKlanten()
        {
            return KlantDB.GetKlanten();
        }
    }
}
