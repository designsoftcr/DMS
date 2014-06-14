using CapaLog;
using MTM.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.DAC
{
    public class CompaniesDAC
    {
        private SqlConnection connection;
        private SqlDataReader reader;

        public CompaniesDAC(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void Insert(string name)
        {
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                using (SqlCommand query = new SqlCommand("INSERT INTO Companies (CompanyId,CompanyName,Active) VALUES (NEWID(),@CompanyName,'true')", connection))
                {
                    query.Parameters.AddWithValue("@CompanyName", name);
                    query.Transaction = transaction;
                    try
                    {
                        query.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception e)
            {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message);
            }
            finally { connection.Close(); }
        }

        public void InactiveCompanyByGuid(string guid)
        {
            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("UPDATE Companies SET Active='false' WHERE CompanyId=@CompanyId", connection))
                {
                    query.Parameters.AddWithValue("@CompanyId", guid);
                    query.ExecuteNonQuery();
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }
        }

        public List<CompaniesBE> Select(){

            List<CompaniesBE> list = null;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT Companies.CompanyId, Companies.CompanyName, (SELECT COUNT(UsersInCompanies.UserId) FROM UsersInCompanies WHERE UsersInCompanies.CompanyId = Companies.CompanyId ) AS Users FROM Companies WHERE Companies.Active='true' ORDER BY CompanyName", connection))
                {
                    reader = query.ExecuteReader();
                    list = ListMap(reader);
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            return list;
        }

        private List<CompaniesBE> ListMap(SqlDataReader reader)
        {
            List<CompaniesBE> list = new List<CompaniesBE>();
            while (reader.Read())
            {
                list.Add(NodeMap(reader));
            }
            return list;
        }

        private CompaniesBE NodeMap(SqlDataReader reader)
        {
            CompaniesBE company = new CompaniesBE();
            company.CompanyId = reader.GetGuid(0);
            company.CompanyName = reader.GetString(1);
                if(reader.FieldCount > 2)
                    company.TotalUsers = reader.GetInt32(2);
            return company;
        }

        public List<CompaniesBE> GetCompaniesByUserGuid(string guid)
        {

            List<CompaniesBE> list = null;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT Companies.CompanyId, Companies.CompanyName FROM Companies INNER JOIN UsersInCompanies ON Companies.CompanyId = UsersInCompanies.CompanyId WHERE  Companies.Active='true' AND UsersInCompanies.UserId=@UserId", connection))
                {
                    query.Parameters.AddWithValue("@UserId", guid);
                    reader = query.ExecuteReader();
                    list = ListMap(reader);
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            return list;
        }

        public CompaniesBE GetCompanyByGuid(string guid)
        {

            CompaniesBE company = null;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT Companies.CompanyId, Companies.CompanyName FROM Companies WHERE Companies.CompanyId=@CompanyId", connection))
                {
                    query.Parameters.AddWithValue("@CompanyId", guid);
                    reader = query.ExecuteReader();
                    company = new CompaniesBE();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            company.CompanyId = reader.GetGuid(0);
                            company.CompanyName = reader.GetString(1);
                        }
                    }
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            company.Users = GetUsersInCompanies(guid);

            return company;

        }

        private void UpdateUsersInCompany(CompaniesBE x)
        {
            //SqlTransaction transaction = null;
            
            try
            {
                connection.Open();
                //transaction = connection.BeginTransaction();

                foreach (UsersBE aux in x.Users)
                {
                    using (SqlCommand query = new SqlCommand("INSERT INTO UsersInCompanies(UserId,CompanyId) VALUES (@UserId, @CompanyId)", connection))
                    {
                        query.Parameters.AddWithValue("@UserId", aux.UserId);
                        query.Parameters.AddWithValue("@CompanyId", x.CompanyId);
                        //query.Transaction = transaction;

                        try
                        {
                            query.ExecuteNonQuery();
                            //transaction.Commit();
                        }
                        catch (Exception e) {
                            //transaction.Rollback();
                            Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                            System.Diagnostics.Trace.WriteLine(e.Message); 
                        }
                    }
                }
            }
            catch (Exception e) { System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }
        }

        public void UpdateCompany(CompaniesBE x)
        {
            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("UPDATE Companies SET Companies.CompanyName=@CompanyName WHERE Companies.CompanyId=@CompanyId;DELETE FROM UsersInCompanies WHERE UsersInCompanies.CompanyId=@CompanyId", connection))
                {
                    query.Parameters.AddWithValue("@CompanyId", x.CompanyId);
                    query.Parameters.AddWithValue("@CompanyName", x.CompanyName);
                    query.ExecuteNonQuery();
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            UpdateUsersInCompany(x);
        }

        private List<UsersBE> GetUsersInCompanies(string companyId)
        {
            List<UsersBE> users = new List<UsersBE>();

            try
            {
                connection.Open();
                using (SqlCommand query = new SqlCommand("SELECT Users.UserId, Users.UserName, Memberships.Email, SUBSTRING(Memberships.Email,(CHARINDEX('@',Memberships.Email)+1),100) AS Domain " +
                        "FROM Memberships INNER JOIN Users ON Memberships.UserId = Users.UserId INNER JOIN " +
                        "UsersInCompanies ON Users.UserId = UsersInCompanies.UserId INNER JOIN " +
                        "Companies ON Companies.CompanyId = UsersInCompanies.CompanyId " +
                        "WHERE UsersInCompanies.CompanyId=@CompanyId ORDER BY Domain, UserName", connection))
                {
                    query.Parameters.AddWithValue("@CompanyId", companyId);
                    reader = query.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            users.Add(new UsersBE(reader.GetGuid(0), reader.GetString(1), reader.GetString(2)));
                    }
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            return users;
        }
    }
}
