using FSM.BE.DMO;
using FSM.DAC.DMO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.BC.DMO
{
    public class PeopleBC
    {
        private PeopleDAC personDAC;

        public PeopleBC(string connectionString)
        {
            personDAC = new PeopleDAC(connectionString);
        }

        public List<PeopleBE> Select()
        {
            return personDAC.Select();
        }
    }
}
