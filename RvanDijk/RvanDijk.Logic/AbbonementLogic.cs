using RvanDijkLogic.Interfaces;
using RvanDijkLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RvanDijkLogic
{
    public class AbbonementLogic
    {
        IAbbonement AbbonementDB { get;}
        public AbbonementLogic(IAbbonement abbonement)
        {
            this.AbbonementDB = abbonement;
        }

        public IEnumerable<Abbonement> GetAbbonementen()
        {
            return AbbonementDB.GetAbbonementen();
        }
    }
}
