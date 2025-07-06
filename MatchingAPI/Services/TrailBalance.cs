using MatchingAPI.Data;
using MatchingAPI.Helper;
using MatchingAPI.IServices;
using Microsoft.Graph.Models;
using static MatchingAPI.DTO.TrailBalanceDTO;


namespace MatchingAPI.Services
{
    public class TrailBalance 
    {

        //private readonly PeopleDeskContext _dbContext;
        //public TrailBalance(PeopleDeskContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //public async Task<List<GetTrailBalanceReportDTO>> GetTrailBalanceByPamReport(
        //    long AccountId, long BusinessUnitId,
        //    DateTime StartDate, DateTime EndDate, long ViewType)
        //{
        //    try
        //    {
        //        var sp = "mar.sprTrailBalance";
        //        var input = new List<KeyValue>
        //{
        //    new KeyValue { Key = "@unitId", Value = BusinessUnitId },
        //    new KeyValue { Key = "@fromDate", Value = StartDate },
        //    new KeyValue { Key = "@toDate", Value = EndDate },
        //    new KeyValue { Key = "@typeId", Value = ViewType },
        //    new KeyValue { Key = "@AccountId", Value = AccountId } // Added if your SP expects it
        //};

        //        // Ensure you have an async implementation to avoid deadlocks:
        //        return await StoreProcedureCall.GetDataTableAsync<GetTrailBalanceReportDTO>(sp, input);
        //    }
        //    catch (Exception)
        //    {
        //        throw; // preserves the stack trace
        //    }
        //}



    }
}
