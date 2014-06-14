using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.BE
{
    public class ModulesBE
    {
        public Guid ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public List<WorkGroupsBE> WorkGroups { get; set; }
 
        public ModulesBE(){}

        public ModulesBE(string moduleName, string moduleDescription)
        {
            this.ModuleName = moduleName;
            this.ModuleDescription = moduleDescription;
        }

        public ModulesBE(Guid moduleId, string moduleName, string moduleDescription) 
        {
            this.ModuleId = moduleId;
            this.ModuleName = moduleName;
            this.ModuleDescription = moduleDescription;
        }

        public ModulesBE(Guid moduleId, string moduleName, string moduleDescription, List<WorkGroupsBE> workGroups) 
        {
            this.ModuleId = moduleId;
            this.ModuleName = moduleName;
            this.ModuleDescription = moduleDescription;
            this.WorkGroups = workGroups;
        }

    }
}
