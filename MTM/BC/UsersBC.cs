using MTM.BE;
using MTM.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.BC
{
    public class UsersBC
    {
        private UsersDAC userDAC;

        public UsersBC(string connectionString)
        {
            userDAC = new UsersDAC(connectionString);
        }

        public List<UsersBE> SelectUsers()
        {
            return userDAC.SelectUsers();
        }

        public string GetUserGuid(string userName)
        {
            return userDAC.GetUserGuid(userName);
        }
    }
}
