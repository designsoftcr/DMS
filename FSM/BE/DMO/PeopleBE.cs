using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.BE.DMO
{
    public class PeopleBE
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }

        public PeopleBE(){}

        public PeopleBE(string name, string lastName)
        {
            this.Name = name;
            this.LastName = lastName;
        }

        public PeopleBE(int id, string name, string lastName)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
        }
    }
}
