using MTM.BE;
using MTM.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.BC
{
    public class WorkGroupsBC
    {
        private WorkGroupsDAC workGroupDAC;

        public WorkGroupsBC(string connectionString)
        {
            workGroupDAC = new WorkGroupsDAC(connectionString);
        }

        public List<WorkGroupsBE> SelectWorkGroups()
        {
            return workGroupDAC.SelectWorkGroups();
        }

        public WorkGroupsBE GetWorkGroupByGuid(string guid)
        {
            return workGroupDAC.GetWorkGroupByGuid(guid);
        }

        public void UpdateWorkGroup(WorkGroupsBE x)
        {
            workGroupDAC.UpdateWorkGroup(x);
        }
    }
}
