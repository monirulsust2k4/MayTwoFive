using MatchingAPI.Helper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MatchingAPI.StoreProcedure
{
    public class CodeGenerate
    {
        DataTable dt = new DataTable();
        public DataTable getCodeGenerate(long AccId, long unitid, long CodegeneratorId)
        {
            try
            {
                using (var connection = new SqlConnection(Connection.PeopleDeskARLConnection))
                {
                    string sql = "mar.sprCodeGenerate";
                    using (SqlCommand sqlCmd = new SqlCommand(sql, connection))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@AccId", AccId);
                        sqlCmd.Parameters.AddWithValue("@unitid", unitid);
                        sqlCmd.Parameters.AddWithValue("@CodegeneratorId", CodegeneratorId);
                        connection.Open();
                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd))
                        {
                            sqlAdapter.Fill(dt);
                        }
                        connection.Close();
                    }

                }

                return dt;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

    }
}
