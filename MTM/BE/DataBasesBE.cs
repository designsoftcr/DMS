using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.BE
{
    public class DataBasesBE
    {
        public Guid DataBaseId { get; set; }
        public string Name { get; set; }
        public string ServerName { get; set; }
        public string DataBaseName { get; set; }
        public string DataBaseUser { get; set; }
        public string DataBasePassword { get; set; }
        public string ConnectionString { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public DataBasesBE(){}

        public DataBasesBE(string name, string serverName, string dbname, string dbuser, string dbpassword, string connection, string description, bool active)
        {
            this.Name = name;
            this.ServerName = serverName;
            this.DataBaseName = dbname;
            this.DataBaseUser = dbuser;
            this.DataBasePassword = dbpassword;
            this.ConnectionString = connection;
            this.Description = description;
            this.Active = active;
        }

        public DataBasesBE(Guid id, string name, string serverName, string dbname, string dbuser, string dbpassword, string connection, string description, bool active)
        {
            this.DataBaseId = id;
            this.Name = name;
            this.ServerName = serverName;
            this.DataBaseName = dbname;
            this.DataBaseUser = dbuser;
            this.DataBasePassword = dbpassword;
            this.ConnectionString = connection;
            this.Description = description;
            this.Active = active;
        }
    }
}
