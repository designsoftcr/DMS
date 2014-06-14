using MTM.BE;
using MTM.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.BC
{
    public class DataBasesBC
    {
        private DataBasesDAC databasesDAC;

        public DataBasesBC(string connectionString)
        {
            databasesDAC = new DataBasesDAC(connectionString);
        }

        public void Insert(string name, string serverName, string dbname, string dbuser, string dbpassword, string description, bool active)
        {
            string connection = "Data Source="+serverName+"; Initial Catalog="+dbname+"; User ID="+dbuser+"; Password='"+dbpassword+"'";
            databasesDAC.Insert(new DataBasesBE(name, serverName, dbname, dbuser, dbpassword, connection, description, active));
        }

        public void InsertDefault(string name, string serverName, string dbname, string dbuser, string dbpassword, string description)
        {
            string connection = "Data Source=" + serverName + "; Initial Catalog=" + dbname + "; User ID=" + dbuser + "; Password='" + dbpassword + "'";
            databasesDAC.InsertDefault(new DataBasesBE(name, serverName, dbname, dbuser, dbpassword, connection, description, true));
        }

        public DataBasesBE SelectDefaultDataBase()
        {
            return databasesDAC.SelectDefaultDataBase();
        }

        public string ConnectionString()
        {
            return databasesDAC.SelectDefaultConnectionString();
        }
    }
}
