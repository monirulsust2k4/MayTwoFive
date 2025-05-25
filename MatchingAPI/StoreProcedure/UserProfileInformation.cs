using System.Data;
using MatchingAPI.Helper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MatchingAPI.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MatchingAPI.StoreProcedure
{
    public class UserProfileInformation: IUserProfileInformation
    {

      
        public async Task<DataTable> GetUserProfileInfo (int intPartid, int intLoginUserId, string strWantsForGender, int intCustomerId, int intUnitId, DateTime dteFromDate, DateTime dteToDate)
        {

            DataTable dt = new DataTable();

            try
            {

                using (var connection = new SqlConnection(Connection.PeopleDeskARLConnection))
                {
                    string sql = "mar.sprUserProfileInformation";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@intPartid", intPartid);
                        cmd.Parameters.AddWithValue("@intLoginUserId", intLoginUserId);
                        cmd.Parameters.AddWithValue("@strWantsForGender", strWantsForGender);
                        cmd.Parameters.AddWithValue("@intCustomerId", intCustomerId);
                        cmd.Parameters.AddWithValue("@intUnitId", intUnitId);
                        cmd.Parameters.AddWithValue("@dteFromDate", dteFromDate);
                        cmd.Parameters.AddWithValue("@dteToDate", dteToDate);

                        connection.Open();
                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                        {
                            sqlAdapter.Fill(dt);
                        }
                        connection.Close();
                    }
                }
                return (dt);
            }
            catch (Exception)
            {

                throw;
            }

        }

        Task<IActionResult> IUserProfileInformation.GetUserProfileInfo(int intPartid, int intLoginUserId, string strWantsForGender, int intCustomerId, int intUnitId, DateTime dteFromDate, DateTime dteToDate)
        {
            throw new NotImplementedException();
        }
    }
}
