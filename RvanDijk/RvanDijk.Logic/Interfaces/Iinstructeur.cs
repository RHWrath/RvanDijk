using RvanDijkLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RvanDijkLogic.Interfaces
{
    public interface Iinstructeur
    {
        IEnumerable<Instructeur> GetInstructeurs();
    }
}
