using RvanDijkLogic.Interfaces;
using RvanDijkLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RvanDijkLogic
{
    public class InstructeurLogic
    {
        IinstructeurDAL InstructeurDB { get;  }

        public InstructeurLogic(IinstructeurDAL instructeur)
        {
            this.InstructeurDB = instructeur;
        }

        public IEnumerable<Instructeur> GetInstructeurs()
        {
            return InstructeurDB.GetInstructeurs();
        }
    }
}
