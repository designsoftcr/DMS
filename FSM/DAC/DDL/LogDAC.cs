using CapaLog;
using FSM.BE.DDL;
using Sykes.Web.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.DAC.DDL
{
    public class LogDAC
    {
        private SqlConnection connection;
        private SqlDataReader reader;

        public LogDAC(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public List<LogBE> Select(string userId, string companyId)
        {
            List<LogBE> list = new List<LogBE>();
            try
            {
                ExecuteScript objE = new ExecuteScript();
                DataTable dt = objE.executeQuertyAndReturnDatatable("sp_GetDataLoadHistory", new object[] { userId, companyId });
                if (dt == null || dt.Rows.Count <= 0) return null;
                for (int i = 0; i < dt.Rows.Count; i++) {
                    LogBE log = new LogBE();
                    log.FileId = Guid.Parse(dt.Rows[i]["FileId"].ToString());
                    log.Date = DateTime.Parse(dt.Rows[i]["Date"].ToString());
                    log.FileName = dt.Rows[i]["FileName"].ToString();
                    log.FileLink = dt.Rows[i]["FileLink"].ToString();
                    log.Inserts = int.Parse(dt.Rows[i]["Inserts"].ToString());
                    log.Updates = int.Parse(dt.Rows[i]["Updates"].ToString());
                    log.Deletes = int.Parse(dt.Rows[i]["Deletes"].ToString());
                    log.Errors = int.Parse(dt.Rows[i]["Errors"].ToString());
                    log.Duration = int.Parse(dt.Rows[i]["Duration"].ToString());
                    list.Add(log);
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); 
            }

            finally { connection.Close(); }

            return list;
        }

        private List<LogBE> ListMap(SqlDataReader reader)
        {
            List<LogBE> list = new List<LogBE>();
            while (reader.Read())
            {
                list.Add(NodeMap(reader));
            }
            return list;
        }

        private LogBE NodeMap(SqlDataReader reader)
        {
            LogBE log = new LogBE();
            log.FileId = reader.GetGuid(0);
            log.Date = reader.GetDateTime(1);
            log.FileName = reader.GetString(2);
            log.FileLink = reader.GetString(3);
            log.Inserts = reader.GetInt32(4);
            log.Updates = reader.GetInt32(5);
            log.Deletes = reader.GetInt32(6);
            log.Errors = reader.GetInt32(7);
            log.Duration = reader.GetInt32(8);

            return log;
        }

        public DataTable GetError_Log(Guid fileId)
        {
            try
            {
                ExecuteScript objE = new ExecuteScript();
                return objE.executeQuertyAndReturnDatatable("sp_GetError_Log", new object[] { fileId });
            }
            catch (Exception e)
            {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                throw;
            }
        }

        public DataTable getDDL_Error_Log(string fileId)
        {
            DataTable dt = new DataTable();
            try
            {
                if (connection == null) return null;
                switch (connection.State)
                {
                    case ConnectionState.Connecting:
                    case ConnectionState.Executing:
                    case ConnectionState.Fetching:
                    case ConnectionState.Closed:
                    case ConnectionState.Broken:
                        connection.Open();
                        break;
                    default:
                        break;
                }
                ExecuteScript objES = new ExecuteScript();
                dt = objES.executeQuertyAndReturnDatatable(connection, "usp_Get_DDL_Error_Log", new[] {fileId});
                return dt;
            }
            catch (Exception e)
            {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                throw;
            }
            finally
            {
                if (dt != null) dt.Dispose();
                dt = null;
                connection.Close();
            }
        }

        public LogBE SelectByFileId(Guid fileId)
        {
            LogBE log = null;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT DDL_Files.FileId, DDL_Files.ProfileId, DDL_Log.CompanyId, DDL_Log.UserId, DDL_Profiles.Name AS ProfileName, DDL_Profiles.Description AS ProfileDescription, DDL_Files.FileName, " + 
                         "DDL_Files.FileLink, DDL_Files.Description AS FileDescription, DDL_Files.Date, DDL_Log.Inserts, DDL_Log.Updates, DDL_Log.Deletes, DDL_Log.Errors, " + 
                         "DDL_Log.ErrorDescription, DDL_Log.Duration " +
                         "FROM DDL_Files INNER JOIN " +
                         "DDL_Log ON DDL_Files.FileId = DDL_Log.FileId INNER JOIN " +
                         "DDL_Profiles ON DDL_Files.ProfileId = DDL_Profiles.ProfileId " +
                         "WHERE DDL_Files.FileId = @FileId", connection))
                {
                    query.Parameters.AddWithValue("@FileId", fileId);
                    reader = query.ExecuteReader();

                    if (reader.HasRows)
                    {
                        log = new LogBE();
 
                        while (reader.Read())
                        {
                            log.FileId = reader.GetGuid(0);
                            log.ProfileId = reader.GetGuid(1);
                            log.CompanyId = reader.GetGuid(2);
                            log.UserId = reader.GetGuid(3);
                            log.ProfileName = reader.GetString(4);
                            log.ProfileDescription = reader.GetString(5);
                            log.FileName = reader.GetString(6);
                            log.FileLink = reader.GetString(7);
                            log.FileDescription = reader[8].ToString();//reader.GetString(8);
                            log.Date = reader.GetDateTime(9);
                            log.Inserts = reader.GetInt32(10);
                            log.Updates = reader.GetInt32(11);
                            log.Deletes = reader.GetInt32(12);
                            log.Errors = reader.GetInt32(13);
                            log.Duration = reader.GetInt32(15);
                            if (reader.GetString(14) != null)
                            {
                                log.ErrorDescription = reader.GetString(14);
                            }
                        }
                    }
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); 
            }

            finally { connection.Close(); }

            return log;
        }

        public bool ClearHistory(string userId, string companyId)
        {
            bool cleared = false;
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                using (SqlCommand query = new SqlCommand("UPDATE DDL_Files SET DDL_Files.Deleted='true' FROM DDL_Files INNER JOIN DDL_Log ON DDL_Files.FileId = DDL_Log.FileId WHERE DDL_Log.CompanyId=@CompanyId AND DDL_Log.UserId=@UserId", connection))
                {
                    query.Parameters.AddWithValue("@UserId", userId);
                    query.Parameters.AddWithValue("@CompanyId", companyId);

                    query.Transaction = transaction;
                    try
                    {
                        query.ExecuteNonQuery();
                        transaction.Commit();
                        cleared = true;
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message);
            }

            finally { connection.Close(); }

            return cleared;
        }
    }
}
