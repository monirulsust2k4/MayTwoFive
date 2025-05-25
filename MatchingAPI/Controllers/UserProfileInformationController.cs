using System.Data;
using MatchingAPI.Data;
using MatchingAPI.StoreProcedure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using static MatchingAPI.StoreProcedure.UserProfileInformation;

namespace MatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileInformationController : ControllerBase
    {
        private readonly PeopleDeskContext _dbContext;
        UserProfileInformation con = new UserProfileInformation();


        public UserProfileInformationController(PeopleDeskContext dbContext)
        {
            _dbContext = dbContext;
           
        }



        [HttpGet]
        [Route("GetUserProfileInfo")]


        public async Task<IActionResult> GetUserProfileInfo(int intPartid, int intLoginUserId, string strWantsForGender, int intCustomerId, int intUnitId, DateTime dteFromDate, DateTime dteToDate)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(await con.GetUserProfileInfo(intPartid, intLoginUserId, strWantsForGender, intCustomerId, intUnitId, dteFromDate, dteToDate));
                return Ok(jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
