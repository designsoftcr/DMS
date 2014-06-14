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
    public class WorkGroupsDAC
    {
        private SqlConnection connection;
        private SqlDataReader reader;

        public WorkGroupsDAC(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public List<WorkGroupsBE> SelectWorkGroups()
        {

            List<WorkGroupsBE> list = null;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT Roles.RoleId, Roles.RoleName, (SELECT COUNT(UsersInRoles.UserId) FROM UsersInRoles WHERE Roles.RoleId = UsersInRoles.RoleId) AS TotalUsers FROM Roles ORDER BY  Roles.RoleName", connection))
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

        private List<WorkGroupsBE> ListMap(SqlDataReader reader)
        {
            List<WorkGroupsBE> list = new List<WorkGroupsBE>();
            while (reader.Read())
            {
                list.Add(NodeMap(reader));
            }
            return list;
        }

        private WorkGroupsBE NodeMap(SqlDataReader reader)
        {
            WorkGroupsBE workGroup = new WorkGroupsBE();
            workGroup.RoleId = reader.GetGuid(0);
            workGroup.RoleName = reader.GetString(1);
            workGroup.TotalUsers = reader.GetInt32(2);
            return workGroup;
        }

        public WorkGroupsBE GetWorkGroupByGuid(string guid)
        {
            WorkGroupsBE workGroup = null;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT Roles.RoleId, Roles.RoleName FROM Roles WHERE Roles.RoleId=@RoleId", connection))
                {
                    query.Parameters.AddWithValue("@RoleId", guid);
                    reader = query.ExecuteReader();
                    workGroup = new WorkGroupsBE();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            workGroup.RoleId = reader.GetGuid(0);
                            workGroup.RoleName = reader.GetString(1);
                        }
                    }
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }
            
            if(workGroup != null)
                workGroup.Users = GetUsersInRole(guid);

            return workGroup;
        }

        private List<UsersBE> GetUsersInRole(string roleId)
        {
            List<UsersBE> users = new List<UsersBE>();

            try
            {
                connection.Open();
                using (SqlCommand query = new SqlCommand("SELECT Users.UserId, Users.UserName, Memberships.Email, SUBSTRING(Memberships.Email,(CHARINDEX('@',Memberships.Email)+1),100) AS Domain " +
                        "FROM Memberships INNER JOIN Users ON Memberships.UserId = Users.UserId INNER JOIN " +
                        "UsersInRoles ON Users.UserId = UsersInRoles.UserId " +
                        "WHERE UsersInRoles.RoleId=@RoleId ORDER BY Domain, UserName", connection))
                {
                    query.Parameters.AddWithValue("@RoleId", roleId);
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

        private void UpdateUsersInCompany(WorkGroupsBE x)
        {
            //SqlTransaction transaction = null;

            try
            {
                connection.Open();
                //transaction = connection.BeginTransaction();

                foreach (UsersBE aux in x.Users)
                {
                    using (SqlCommand query = new SqlCommand("INSERT INTO UsersInRoles(UserId,RoleId) VALUES (@UserId, @RoleId)", connection))
                    {
                        query.Parameters.AddWithValue("@UserId", aux.UserId);
                        query.Parameters.AddWithValue("@RoleId", x.RoleId);
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

        public void UpdateWorkGroup(WorkGroupsBE x)
        {
            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("UPDATE Roles SET Roles.RoleName=@RoleName WHERE Roles.RoleId=@RoleId;DELETE FROM UsersInRoles WHERE UsersInRoles.RoleId=@RoleId", connection))
                {
                    query.Parameters.AddWithValue("@RoleId", x.RoleId);
                    query.Parameters.AddWithValue("@RoleName", x.RoleName);
                    query.ExecuteNonQuery();
                }
            }
            catch (Exception e) {
                Log.appendToLog(Log.LEVEL_WARN, e.ToString());
                System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            UpdateUsersInCompany(x);
        }
    }
}
