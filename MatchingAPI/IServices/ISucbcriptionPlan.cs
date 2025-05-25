using System.Data;
using static MatchingAPI.DTO.SucbcriptionPlanDTO;
using static MatchingAPI.Models.ExceptionMessage;

namespace MatchingAPI.IServices
{
    public interface ISucbcriptionPlan
    {

        public Task<MessageHelper> CreateUpdateSubscriptionPlan(SubscriptionPlanMainDTO objCreate);
        public  Task<List<SubscriptionPlanMainDTO>> GetSubscriptionPlans();
        public Task<MessageHelper> CreateSubscriptionPlanInformationByUser(CreateSubscriptionPlanByUserCommonDTO createSubscriptionPlan);
        public Task<MessageHelper> EditSubscriptionPlanByUser(EditSubscriptionPlanByUserCommonDTO editSubscriptionPlan);

        public Task<List<GetSubscriptionDetailsDTO>> GetRunningSusscriptionInfoForUser(long userid, long unitid, long customerid);
        public  Task<DataTable> GetUserProfileInfo(int intPartid, int intLoginUserId, string strWantsForGender, int intCustomerId, int intUnitId, DateTime dteFromDate, DateTime dteToDate);
    }
}
