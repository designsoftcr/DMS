using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.BE.DDL
{
    public class ProfilesBE
    {
        public Guid ProfileId { get; set; }
        public string Name { get; set; }
        public string StoreProcedure { get; set; }
        public string Description { get; set; }
        public string Plantilla { get; set; }

        public ProfilesBE() { }

        public ProfilesBE(string name, string storeProcedure, string description)
        {
            this.Name = name;
            this.StoreProcedure = storeProcedure;
            this.Description = description;
        }

        public ProfilesBE(Guid id, string name, string storeProcedure, string description, string plantilla)
        {
            this.ProfileId = id;
            this.Name = name;
            this.StoreProcedure = storeProcedure;
            this.Description = description;
            this.Plantilla = plantilla;
        }

    }
}
