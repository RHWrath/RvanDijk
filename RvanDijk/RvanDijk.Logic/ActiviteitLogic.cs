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
        IActiviteit ActiviteitGB { get; }

        public ActiviteitLogic(IActiviteit activiteit)
        {
            this.ActiviteitGB = activiteit;
        }

        public IEnumerable<Activiteit> GetActiviteit()
        {
            return ActiviteitGB.GetActiviteit();
        }
    }
}
