using CapaLog;
using FSM.BE.DDL;
using FSM.DAC.DDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.BC.DDL
{
    public class LogBC
    {
        private LogDAC logDAC;

        public LogBC(string connectionString)
        {
            logDAC = new LogDAC(connectionString);
        }

        public List<LogBE> Select(string userId, string companyId)
        {
            return logDAC.Select(userId, companyId);
        }

        public LogBE SelectByFileId(string id)
        {
            return logDAC.SelectByFileId(Guid.Parse(id));
        }

        public DataTable getError_Log(string id)
        {
            return logDAC.GetError_Log(Guid.Parse(id));
        }

        public DataTable getDDL_Error_Log(string id)
        {
            return logDAC.getDDL_Error_Log(id);
        }

        public void ClearHistory(string dirPath, string userId, string companyId)
        {
            if (logDAC.ClearHistory(userId, companyId))
            {
                try
                {
                    string[] files = Directory.GetFiles(dirPath, "*.*");
                    foreach(string f in files)
                    {
                        //File.Delete(f);
                    }
                }
                catch (Exception e)
                {
                    Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                    System.Diagnostics.Trace.WriteLine(e.Message);
                }

            }
        }
    }
}
