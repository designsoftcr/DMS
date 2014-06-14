using FSM.BE.DMO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.DAC.DMO
{
    public class PeopleDAC
    {
        private SqlConnection connection;
        private SqlDataReader reader;

        public PeopleDAC(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public List<PeopleBE> Select(){

            List<PeopleBE> list = null;

            try
            {
                connection.Open();

                using (SqlCommand query = new SqlCommand("SELECT TOP 1000 CEDULA AS Id, NOMBRE AS Name, [1.APELLIDO]+' '+[2.APELLIDO] AS LastName FROM [dbo].[DMO_People]", connection))
                {
                    reader = query.ExecuteReader();
                    list = ListMap(reader);
                }
            }
            catch (Exception e) { System.Diagnostics.Trace.WriteLine(e.Message); }

            finally { connection.Close(); }

            return list;
        }

        private List<PeopleBE> ListMap(SqlDataReader reader)
        {
            List<PeopleBE> list = new List<PeopleBE>();
            while (reader.Read())
            {
                list.Add(NodeMap(reader));
            }
            return list;
        }

        private PeopleBE NodeMap(SqlDataReader reader)
        {
            PeopleBE person = new PeopleBE();
            person.Id = reader.GetInt32(0);
            person.Name = reader.GetString(1);
            person.LastName = reader.GetString(2);

            return person;
        }
    }
}
