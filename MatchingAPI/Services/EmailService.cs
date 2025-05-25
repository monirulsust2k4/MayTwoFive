using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using MatchingAPI.IServices;
using MatchingAPI.Helper;

namespace MatchingAPI.Services
{
    public class EmailService : iEmailService
    {

        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> SendEmail(string strProfile_name, string strEmailAdd, string strCCEmailAdd, string strBCEmailAdd,
          string strSubject, string strBody, string strHTML)
        {
            try
            {
                var connection = new SqlConnection(Helper.Connection.PeopleDeskARLConnection);
                string sql = "saas.sprSendEmail";
                SqlCommand sqlCmd = new SqlCommand(sql, connection);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@strProfile_name", strProfile_name);
                sqlCmd.Parameters.AddWithValue("@strEmailAdd", strEmailAdd);
                sqlCmd.Parameters.AddWithValue("@strCCEmailAdd", strCCEmailAdd);
                sqlCmd.Parameters.AddWithValue("@strBCEmailAdd", strBCEmailAdd);
                sqlCmd.Parameters.AddWithValue("@strSubject", strSubject);
                sqlCmd.Parameters.AddWithValue("@strBody", strBody);
                sqlCmd.Parameters.AddWithValue("@strHTML", strHTML);
                connection.Open();
                sqlCmd.ExecuteNonQuery();
                connection.Close();

                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

    }
}
