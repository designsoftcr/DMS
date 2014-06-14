using MTM.BE;
using MTM.DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.BC
{
    public class CompaniesBC
    {
        private CompaniesDAC companiesDAC;

        public CompaniesBC(string connectionString) 
        {
            companiesDAC = new CompaniesDAC(connectionString);
        }

        public List<CompaniesBE> Select()
        {
            return companiesDAC.Select();
        }

        public List<CompaniesBE> GetCompaniesByUserGuid(string guid)
        {
            return companiesDAC.GetCompaniesByUserGuid(guid);
        }

        public void Insert(String name)
        {
            companiesDAC.Insert(name);
        }

        public void InactiveCompanyById(string guid)
        {
            companiesDAC.InactiveCompanyByGuid(guid);
        }

        public CompaniesBE GetCompanyByGuid(string guid)
        {
            return companiesDAC.GetCompanyByGuid(guid);
        }

        public void UpdateCompany(CompaniesBE x)
        {
            companiesDAC.UpdateCompany(x);
        }

    }
}
