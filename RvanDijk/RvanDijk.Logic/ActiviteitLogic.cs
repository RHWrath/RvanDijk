using RvanDijkLogic.Interfaces;
using RvanDijkLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RvanDijkLogic
{
    public class ActiviteitLogic
    {
        IActiviteitDAL ActiviteitGB { get; }

        public ActiviteitLogic(IActiviteitDAL activiteit)
        {
            this.ActiviteitGB = activiteit;
        }

        public IEnumerable<Activiteit> GetActiviteit()
        {
            return ActiviteitGB.GetActiviteit();
        }
    }
}
