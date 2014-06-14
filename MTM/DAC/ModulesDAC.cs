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
    public class ModulesDAC
    {
        private SqlConnection connection;
        private SqlDataReader reader;

        public ModulesDAC(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void Insert(ModulesBE x)
        {
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                using (SqlCommand query = new SqlCommand("INSERT INTO Modules (ModuleId, ModuleName, ModuleDescription) VALUES (NEWID(), @ModuleName, @ModuleDescription)", connection))
                {
                    query.Parameters.AddWithValue("@ModuleName", x.ModuleName);
                    query.Parameters.AddWithValue("@ModuleDescription", x.ModuleDescription);
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

        public List<ModulesBE> Select()
        {

            List<ModulesBE> list = null;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT * FROM Modules ORDER BY Modules.ModuleName", connection))
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

        private List<ModulesBE> ListMap(SqlDataReader reader)
        {
            List<ModulesBE> list = new List<ModulesBE>();
            while (reader.Read())
            {
                list.Add(NodeMap(reader));
            }
            return list;
        }

        private ModulesBE NodeMap(SqlDataReader reader)
        {
            ModulesBE module = new ModulesBE();
            module.ModuleId = reader.GetGuid(0);
            module.ModuleName = reader.GetString(1);
            module.ModuleDescription = reader.GetString(2);

            return module;
        }

        public ModulesBE GetModuleByGuid(string guid)
        {

            ModulesBE module = null;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT * FROM Modules WHERE Modules.ModuleId=@ModuleId", connection))
                {
                    query.Parameters.AddWithValue("@ModuleId", guid);
                    reader = query.ExecuteReader();
                    module = new ModulesBE();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            module.ModuleId = reader.GetGuid(0);
                            module.ModuleName = reader.GetString(1);
                            module.ModuleDescription = reader.GetString(2);
                        }
                    }
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            module.WorkGroups = GetWorkGroupsInModules(guid);

            return module;

        }

        public List<WorkGroupsBE> GetWorkGroupsInModules(string guid)
        {
            List<WorkGroupsBE> workGroups = new List<WorkGroupsBE>();

            try
            {
                connection.Open();
                using (SqlCommand query = new SqlCommand("SELECT Roles.RoleId, Roles.RoleName FROM Roles INNER JOIN RolesInModules ON Roles.RoleId=RolesInModules.RoleId WHERE RolesInModules.ModuleId=@ModuleId", connection))
                {
                    query.Parameters.AddWithValue("@ModuleId", guid);
                    reader = query.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            workGroups.Add(new WorkGroupsBE(reader.GetGuid(0), reader.GetString(1)));
                    }
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            return workGroups;
        }

        public void UpdateModule(ModulesBE x)
        {
            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("UPDATE Modules SET Modules.ModuleName=@ModuleName, Modules.ModuleDescription=@ModuleDescription WHERE Modules.ModuleId=@ModuleId;DELETE FROM RolesInModules WHERE RolesInModules.ModuleId=@ModuleId", connection))
                {
                    query.Parameters.AddWithValue("@ModuleId", x.ModuleId);
                    query.Parameters.AddWithValue("@ModuleName", x.ModuleName);
                    query.Parameters.AddWithValue("@ModuleDescription", x.ModuleDescription);
                    query.ExecuteNonQuery();
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            UpdateWorkGroupsInModules(x);
        }

        private void UpdateWorkGroupsInModules(ModulesBE x)
        {
            //SqlTransaction transaction = null;

            try
            {
                connection.Open();
                //transaction = connection.BeginTransaction();

                foreach (WorkGroupsBE aux in x.WorkGroups)
                {
                    using (SqlCommand query = new SqlCommand("INSERT INTO RolesInModules(RoleId,ModuleId) VALUES (@RoleId, @ModuleId)", connection))
                    {
                        query.Parameters.AddWithValue("@RoleId", aux.RoleId);
                        query.Parameters.AddWithValue("@ModuleId", x.ModuleId);
                        //query.Transaction = transaction;

                        try
                        {
                            query.ExecuteNonQuery();
                            //transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            //transaction.Rollback();
                            System.Diagnostics.Trace.WriteLine(e.Message);
                        }
                    }
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }
        }

        public bool IsValidForUser(string userId, string moduleId )
        {
            bool pass = false;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT UsersInRoles.UserId, UsersInRoles.RoleId FROM UsersInRoles INNER JOIN RolesInModules ON UsersInRoles.RoleId = RolesInModules.RoleId WHERE UsersInRoles.UserId=@UserId AND RolesInModules.ModuleId=@ModuleId", connection))
                {
                    query.Parameters.AddWithValue("@UserId", userId);
                    query.Parameters.AddWithValue("@ModuleId", moduleId);

                    reader = query.ExecuteReader();
                    if (reader.HasRows)
                        pass = true;
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }


            return pass;
        }
    }
}
