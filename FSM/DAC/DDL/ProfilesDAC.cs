using CapaLog;
using FSM.BE.DDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.DAC.DDL
{
    public class ProfilesDAC
    {
        private SqlConnection connection;
        private SqlDataReader reader;
        private SqlDataAdapter adapter;

        public ProfilesDAC(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void Insert(ProfilesBE x)
        {
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                using (SqlCommand query = new SqlCommand("INSERT INTO DDL_Profiles (ProfileId, Name, StoreProcedure, Description) VALUES (NEWID(), @Name, @StoreProcedure, @Description)", connection))
                {
                    query.Parameters.AddWithValue("@Name", x.Name);
                    query.Parameters.AddWithValue("@StoreProcedure", x.StoreProcedure);
                    query.Parameters.AddWithValue("@Description", x.Description);
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
            catch (Exception e){
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); 
            }

            finally { connection.Close(); }
        }

        public void Update(ProfilesBE x)
        {
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                using (SqlCommand query = new SqlCommand("UPDATE DDL_Profiles SET Name=@Name, StoreProcedure=@StoreProcedure, Description=@Description, NOMBRE_PLANTILLA=@Plantilla WHERE ProfileId=@ProfileId", connection))
                {
                    query.Parameters.AddWithValue("@Name", x.Name);
                    query.Parameters.AddWithValue("@StoreProcedure", x.StoreProcedure);
                    query.Parameters.AddWithValue("@Description", x.Description);
                    query.Parameters.AddWithValue("@ProfileId", x.ProfileId);
                    query.Parameters.AddWithValue("@Plantilla", x.Plantilla);
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
            catch (Exception e) { System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }
        }

        public void Delete(string id)
        {
            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("DELETE FROM DDL_Profiles WHERE ProfileId=@ProfileId", connection))
                {
                    query.Parameters.AddWithValue("@ProfileId", id);
                    query.ExecuteNonQuery();
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }
        }

        public DataTable SelectStoreProcedures()
        {
            DataTable data = new DataTable();
            data.TableName = "Store Procedures";

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT DISTINCT(specific_name) FROM information_schema.parameters WHERE specific_name LIKE 'DDL%' ORDER BY specific_name", connection))
                {
                    query.CommandTimeout = 0;
                    adapter = new SqlDataAdapter();
                    adapter.SelectCommand = query;
                    adapter.Fill(data);
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            return data;
        }

        public ProfilesBE SelectProfileById(string profileId)
        {
            ProfilesBE profile = null;
            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT * FROM DDL_Profiles WHERE ProfileId=@ProfileId", connection))
                {
                    query.Parameters.AddWithValue("@ProfileId", profileId);
                    reader = query.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            profile = new ProfilesBE();
                            profile.ProfileId = reader.GetGuid(0);
                            profile.Name = reader.GetString(1);
                            profile.StoreProcedure = reader.GetString(2);
                            profile.Description = reader.GetString(3);
                            profile.Plantilla = reader[4].ToString();
                        }
                    }

                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            return profile;
        }

        public List<ProfilesBE> Select(){

            List<ProfilesBE> list = null;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT * FROM DDL_Profiles ORDER BY DDL_Profiles.Name", connection))
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

        private List<ProfilesBE> ListMap(SqlDataReader reader)
        {
            List<ProfilesBE> list = new List<ProfilesBE>();
            while (reader.Read())
            {
                list.Add(NodeMap(reader));
            }
            return list;
        }

        private ProfilesBE NodeMap(SqlDataReader reader)
        {
            ProfilesBE profile = new ProfilesBE();
            profile.ProfileId = reader.GetGuid(0);
            profile.Name = reader.GetString(1);
            profile.StoreProcedure = reader.GetString(2);
            profile.Description = reader.GetString(3);
            profile.Plantilla = reader[4].ToString();

            return profile;
        }
    }
}
