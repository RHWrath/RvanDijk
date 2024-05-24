using RvanDijkLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RvanDijkLogic.Interfaces
{
    public interface IAbbonementDAL
    {
        IEnumerable<Abbonement> GetAbbonementen();
    }
}
