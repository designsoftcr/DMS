using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.BE
{
    public class CompaniesBE
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int TotalUsers { get; set; }
        public List<UsersBE> Users { get; set; }

        public CompaniesBE(){ }

        public CompaniesBE(string name) { this.CompanyName = name; }

        public CompaniesBE(Guid id, string name) { this.CompanyId = id; this.CompanyName = name; }

        public CompaniesBE(Guid id, string name, int totalUsers) { this.CompanyId = id; this.CompanyName = name; this.TotalUsers = totalUsers; }

        public CompaniesBE(Guid id, string name, List<UsersBE> users)
        { this.CompanyId = id; this.CompanyName = name; this.Users = users; }
    }
}
