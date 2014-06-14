using CapaLog;
using MTM.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.DAC
{
    public class DataBasesDAC
    {
        private SqlConnection connection;
        private SqlDataReader reader;

        public DataBasesDAC(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void Insert(DataBasesBE x)
        {
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                using (SqlCommand query = new SqlCommand(
                    "INSERT INTO DataBases" + 
                    "(DataBaseId, Name, Server, DataBaseName, DataBaseUser, DataBasePassword, ConnectionString, Description, Active) " + 
                    "VALUES (NEWID(),@Name, @ServerName,@DataBaseName,@DataBaseUser,@DataBasePassword,@ConnectionString,@Description,@Active)", connection))
                {
                    query.Parameters.AddWithValue("@Name", x.Name);
                    query.Parameters.AddWithValue("@ServerName", x.ServerName);
                    query.Parameters.AddWithValue("@DataBaseName", x.DataBaseName);
                    query.Parameters.AddWithValue("@DataBaseUser", x.DataBaseUser);
                    query.Parameters.AddWithValue("@DataBasePassword", x.DataBasePassword);
                    query.Parameters.AddWithValue("@ConnectionString", x.ConnectionString);
                    query.Parameters.AddWithValue("@Description", x.Description);
                    query.Parameters.AddWithValue("@Active", x.Active);

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

        public void InsertDefault(DataBasesBE x)
        {
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                using (SqlCommand query = new SqlCommand(
                    "DELETE FROM DataBases;"+
                    "INSERT INTO DataBases" +
                    "(DataBaseId, Name, ServerName, DataBaseName, DataBaseUser, DataBasePassword, ConnectionString, Description, Active) " +
                    "VALUES (NEWID(), @Name, @ServerName, @DataBaseName, @DataBaseUser, @DataBasePassword, @ConnectionString, @Description, @Active);", connection))
                {
                    query.Parameters.AddWithValue("@Name", x.Name);
                    query.Parameters.AddWithValue("@ServerName", x.ServerName);
                    query.Parameters.AddWithValue("@DataBaseName", x.DataBaseName);
                    query.Parameters.AddWithValue("@DataBaseUser", x.DataBaseUser);
                    query.Parameters.AddWithValue("@DataBasePassword", x.DataBasePassword);
                    query.Parameters.AddWithValue("@ConnectionString", x.ConnectionString);
                    query.Parameters.AddWithValue("@Description", x.Description);
                    query.Parameters.AddWithValue("@Active", x.Active.ToString());

                    query.Transaction = transaction;
                    try
                    {
                        query.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch(Exception e)
                    {
                        Log.appendToLog(Log.LEVEL_WARN, e.ToString());
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

        public DataBasesBE SelectDefaultDataBase()
        {
            DataBasesBE database = null;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT * FROM DataBases WHERE Active='true'", connection))
                {
                    reader = query.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            database = new DataBasesBE();
                            database.DataBaseId = reader.GetGuid(0);
                            database.Name = reader.GetString(1);
                            database.ServerName = reader.GetString(2);
                            database.DataBaseName = reader.GetString(3);
                            database.DataBaseUser = reader.GetString(4);
                            database.DataBasePassword = reader.GetString(5);
                            database.ConnectionString = reader.GetString(6);
                            database.Description = reader.GetString(7);
                            database.Active = reader.GetBoolean(8);
                        }
                    }

                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            return database;
        }

        public string SelectDefaultConnectionString()
        {
            string connectionString = String.Empty;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT ConnectionString FROM DataBases WHERE Active='true'", connection))
                {
                    reader = query.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            connectionString = reader.GetString(0);
                        }
                    }

                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            return connectionString;

        }
    }
}
