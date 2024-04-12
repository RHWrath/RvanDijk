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
        Iinstructeur InstructeurDB { get;  }

        public InstructeurLogic(Iinstructeur instructeur)
        {
            this.InstructeurDB = instructeur;
        }

        public IEnumerable<Instructeur> GetInstructeurs()
        {
            return InstructeurDB.GetInstructeurs();
        }
    }
}
