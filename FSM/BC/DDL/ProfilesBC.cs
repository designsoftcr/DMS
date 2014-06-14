using FSM.BE.DDL;
using FSM.DAC.DDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.BC.DDL
{
    public class ProfilesBC
    {
        private ProfilesDAC profilesDAC;

        public ProfilesBC(string connectionString)
        {
            profilesDAC = new ProfilesDAC(connectionString);
        }

        public List<ProfilesBE> Select()
        {
            return profilesDAC.Select();
        }

        public void Insert(string name, string storeProcedure, string description)
        {
            profilesDAC.Insert(new ProfilesBE(name, storeProcedure, description));
        }

        public void Update(string id, string name, string storeProcedure, string description)
        {
            profilesDAC.Update(new ProfilesBE(Guid.Parse(id), name, storeProcedure, description));
        }

        public DataTable SelectStoreProcedures()
        {
            return profilesDAC.SelectStoreProcedures();
        }

        public void Delete(string id)
        {
            profilesDAC.Delete(id);
        }

        public ProfilesBE SelectProfileById(string id)
        {
            return profilesDAC.SelectProfileById(id);
        }
    }
}
