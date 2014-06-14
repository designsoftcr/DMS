using CapaLog;
using FSM.BE.DDL;
using Sykes.Web.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSM.DAC.DDL
{
    public class FilesDAC
    {
        private SqlConnection connection;
        private ProfilesDAC profilesDAC;

        public FilesDAC(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            profilesDAC = new ProfilesDAC(connectionString);
        }

        public string ConvertExcel(FilesBE x, string path, ref int iExcelCoulumnCount)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");//""es-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");//("es-ES");//
            string result = string.Empty;
            string excelStringConnection = String.Concat("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=",path, x.FileId,".",x.FileName.Split('.')[1],";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1\'");
            OleDbConnection excelConnection = null;
            StreamWriter streamWriter = null;
            OleDbCommand query = null;
            OleDbDataAdapter adapter = null;

            try
            {
                excelConnection = new OleDbConnection(excelStringConnection);
                excelConnection.Open();

                var sheet = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows.Cast<DataRow>().Select(row => row["TABLE_NAME"].ToString());
                query = new OleDbCommand(String.Concat("SELECT * FROM [", sheet.ElementAt(0), "]"), excelConnection);
                query.CommandTimeout = 0;
                query.CommandType = CommandType.Text;
                streamWriter = new StreamWriter(String.Concat(path,x.FileId));
                adapter = new OleDbDataAdapter(query);
                DataTable data = new DataTable();
                adapter.Fill(data);
                iExcelCoulumnCount = data.Columns.Count;
                for (int z = 0; z < data.Rows.Count; z++)
                {
                    string rowString = String.Empty;
                    for (int y = 0; y < data.Columns.Count; y++)
                    {
                        rowString += data.Rows[z][y].ToString().Trim() + "|";
                    }
                    streamWriter.WriteLine(rowString.Remove(rowString.Length - 1));
                }
            }

            catch (Exception ex) 
            {
                Log.appendToLog(Log.LEVEL_WARN, ex.ToString());
                result = ex.Message;
                System.Diagnostics.Trace.WriteLine(ex.Message); 
            }

            finally {

                if (excelConnection.State == ConnectionState.Open)
                    excelConnection.Close();

                excelConnection.Dispose();
                query.Dispose();
                adapter.Dispose();
                streamWriter.Close();
                streamWriter.Dispose();
            }

            return result;
        }
        
        public FilesBE NewFile()
        {
            FilesBE file = new FilesBE();

            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                using (SqlCommand query = new SqlCommand("DECLARE @newId uniqueidentifier = NEWID();INSERT INTO DDL_Files(FileId,Date) VALUES(@newId,GETDATE());SELECT @newId AS FileId", connection))
                {
                    query.Transaction = transaction;
                    try
                    {
                        file.FileId = (Guid)query.ExecuteScalar();
                        transaction.Commit();
                    }
                    catch { transaction.Rollback(); }
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message);
            }

            finally { connection.Close(); }

            return file;
        }

        public void updateDDL_Files(FilesBE x)
        {
            try
            {
                ExecuteScript objE = new ExecuteScript();
                objE.executeQuertyAndReturnNothing("sp_UpdateDDL_Files", new object[] { x.FileId, x.ProfileId, x.FileName, x.FileLink, x.Description });
            }
            catch (Exception ex)
            {
                Log.appendToLog(Log.LEVEL_WARN, ex.ToString());
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        public void Update(FilesBE x)
        {
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                using (SqlCommand query = new SqlCommand("UPDATE DDL_Files SET ProfileId=@ProfileId, FileName=@FileName, FileLink=@FileLink, Description=@Description WHERE FileId=@FileId", connection))
                {
                    query.Parameters.AddWithValue("@FileId", x.FileId);
                    query.Parameters.AddWithValue("@ProfileId", x.ProfileId);
                    query.Parameters.AddWithValue("@FileName", x.FileName);
                    query.Parameters.AddWithValue("@FileLink", x.FileLink);
                    query.Parameters.AddWithValue("@Description", x.Description);

                    query.Transaction = transaction;
                    try
                    {
                        query.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch{ transaction.Rollback(); }
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); 
            }

            finally { connection.Close(); }
        }

        public string ImportData(bool deleteData, Guid companyId, Guid userId, string path, FilesBE x, int iExcelCoulumnCount)
        {
            StringBuilder errorMessages = new StringBuilder();

            ProfilesBE profile = profilesDAC.SelectProfileById(x.ProfileId.ToString());

               // SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    //transaction = connection.BeginTransaction();
                    using (SqlCommand query = new SqlCommand(profile.StoreProcedure, connection))
                    {
                        query.CommandTimeout = 0;
                        query.CommandType = CommandType.StoredProcedure;
                        query.Parameters.AddWithValue("@DeleteData", deleteData);
                        query.Parameters.AddWithValue("@CompanyId", companyId);
                        query.Parameters.AddWithValue("@UserId", userId);
                        query.Parameters.AddWithValue("@FileId", x.FileId);
                        query.Parameters.AddWithValue("@SourceFilePath", String.Concat(path, x.FileId));// x.FileId);
                        query.Parameters.AddWithValue("@ErrorFilePath", String.Concat(path, x.FileId, "_Error.txt"));//String.Concat(x.FileId,"_Error.txt"));
                        query.Parameters.AddWithValue("@ExcelColumnCount", iExcelCoulumnCount);
                       // query.Transaction = transaction;

                        try
                        {
                            query.ExecuteNonQuery();
                            //transaction.Commit();
                        }
                        catch (SqlException e)
                        {
                            Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                            System.Diagnostics.Trace.WriteLine(e.Message);
                            //transaction.Rollback();

                                for (int i = 0; i < e.Errors.Count; i++)
                                {
                                    errorMessages.Append("Index #" + i + "\n" +
                                        "Message: " + e.Errors[i].Message + "\n" +
                                        "LineNumber: " + e.Errors[i].LineNumber + "\n" +
                                        "Source: " + e.Errors[i].Source + "\n" +
                                        "Procedure: " + e.Errors[i].Procedure +  "\n");
                                }
                                System.Diagnostics.Trace.WriteLine(errorMessages.ToString());
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                    System.Diagnostics.Trace.WriteLine(e.Message);
                    errorMessages.Append(e.Message);
                }
                finally { connection.Close(); }

                return errorMessages.ToString();
        }
    }
}
