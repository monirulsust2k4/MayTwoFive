using Microsoft.AspNetCore.Mvc;

namespace MatchingAPI.IServices
{
    public interface IUserProfileInformation
    {

        public Task<IActionResult> GetUserProfileInfo(int intPartid, int intLoginUserId, string strWantsForGender, int intCustomerId, int intUnitId, DateTime dteFromDate, DateTime dteToDate);
    }
}
