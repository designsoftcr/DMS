using MTM.BE;
using MTM.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.BC
{
    public class ModulesBC
    {
        private ModulesDAC modulesDAC;

        public ModulesBC(string connectionString)
        {
            modulesDAC = new ModulesDAC(connectionString);
        }

        public void Insert(string moduleName, string moduleDescription)
        {
            modulesDAC.Insert(new ModulesBE(moduleName, moduleDescription ));
        }

        public List<ModulesBE> Select()
        {
            return modulesDAC.Select();
        }

        public ModulesBE GetModuleByGuid(string guid)
        {
            return modulesDAC.GetModuleByGuid(guid);
        }

        public void UpdateModule(ModulesBE x)
        {
            modulesDAC.UpdateModule(x);
        }

        public bool IsValidForUser(string userId, string moduleId)
        {
            return modulesDAC.IsValidForUser(userId, moduleId);
        }
    }
}
