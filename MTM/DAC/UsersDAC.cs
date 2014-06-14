using CapaLog;
using MTM.BE;
using Sykes.Web.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.DAC
{
    public class UsersDAC
    {
        private SqlConnection connection;
        private SqlDataReader reader;

        public UsersDAC(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public UsersDAC() { 
        
        }

        public List<UsersBE> SelectUsers()
        {

            List<UsersBE> list = null;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT Users.UserId, Users.UserName, Memberships.Email, Memberships.CreateDate, Memberships.LastLoginDate, SUBSTRING(Memberships.Email,(CHARINDEX('@',Memberships.Email)+1),100) AS Domain FROM Memberships INNER JOIN Users ON Memberships.UserId = Users.UserId ORDER BY Domain, UserName", connection))
                {
                    reader = query.ExecuteReader();
                    list = ListMap(reader);
                }
            }
            catch (Exception e) { System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            return list;
        }

        private List<UsersBE> ListMap(SqlDataReader reader)
        {
            List<UsersBE> list = new List<UsersBE>();
            while (reader.Read())
            {
                list.Add(NodeMap(reader));
            }
            return list;
        }

        private UsersBE NodeMap(SqlDataReader reader)
        {
            UsersBE user = new UsersBE();
            user.UserId = reader.GetGuid(0);
            user.UserName = reader.GetString(1);
            user.Email = reader.GetString(2);
            user.CreateDate = reader.GetDateTime(3);
            user.LastLoginDate = reader.GetDateTime(4);
            return user;
        }

        public string GetUserGuid(string userName)
        {

            string userId = null;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT UserId FROM Users WHERE UserName=@UserName", connection))
                {
                    query.Parameters.AddWithValue("@UserName", userName);
                    reader = query.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            userId = reader.GetGuid(0).ToString();
                        }
                    }
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            return userId;
        }

        public void UpdateUser(string strUserName, string strExternalID, string strEmail, string strCompanyList, string strRolList, string strPassword) {
            try
            {
                ExecuteScript objEx = new ExecuteScript();
                objEx.executeQuertyAndReturnNothing("sp_UpdateUser", new object[] { strUserName, strExternalID, strEmail,strCompanyList, strRolList, strPassword});

            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message);
            }
        }

        public DataTable GetCompany()
        {
            try
            {
                ExecuteScript objEx = new ExecuteScript();
                return objEx.executeQuertyAndReturnDatatable("sp_GetAllCompany");

            }
            catch (Exception e)
            {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message);
                throw;
            }
        }

        public DataTable GetWorkGroup()
        {
            try
            {
                ExecuteScript objEx = new ExecuteScript();
                return objEx.executeQuertyAndReturnDatatable("sp_GetAllRol");

            }
            catch (Exception e)
            {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message);
                throw;
            }
        }

        public DataTable GetUserInformation(string strUserName)
        {
            try
            {
                ExecuteScript objEx = new ExecuteScript();
                return objEx.executeQuertyAndReturnDatatable("sp_GetUserInformation", new object[] { strUserName });

            }
            catch (Exception e)
            {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message);
                throw;
            }
        }

        public DataTable GetRolByUser(string strUserName)
        {
            try
            {
                ExecuteScript objEx = new ExecuteScript();
                return objEx.executeQuertyAndReturnDatatable("sp_GetRolByUser", new object[] { strUserName });
            }
            catch (Exception e)
            {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message);
                throw;
            }
        }

        public DataTable GetCompanyByUser(string strUserName)
        {
            try
            {
                ExecuteScript objEx = new ExecuteScript();
                return objEx.executeQuertyAndReturnDatatable("sp_GetCompanyByUser", new object[] { strUserName });
            }
            catch (Exception e)
            {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message);
                throw;
            }
        }
    }
}
