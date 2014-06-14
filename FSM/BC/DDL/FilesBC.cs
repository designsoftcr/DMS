using FSM.BE.DDL;
using FSM.DAC.DDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.BC.DDL
{
    public class FilesBC
    {
        private FilesDAC filesDAC;

        public FilesBC(string connectionString)
        {
            filesDAC = new FilesDAC(connectionString);
        }

        public FilesBE NewFile()
        {
            return filesDAC.NewFile();
        }

        public void Update(FilesBE x)
        {
            //filesDAC.Update(x);
            filesDAC.updateDDL_Files(x);
        }

        public string ImportData(bool deleteData, Guid companyId, Guid userId, FilesBE x, string path, int iExcelCoulumnCount)
        {
            return filesDAC.ImportData(deleteData, companyId, userId, path, x, iExcelCoulumnCount);
        }


        public string ConvertExcel(FilesBE x, string path, ref int iExcelCoulumnCount)
        {
            return filesDAC.ConvertExcel(x, path, ref iExcelCoulumnCount);
        }
    }
}
