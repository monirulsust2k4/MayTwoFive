using MatchingAPI.DTO;
using MatchingAPI.Helper;
using MatchingAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using static MatchingAPI.DTO.SucbcriptionPlanDTO;
using static MatchingAPI.Models.ExceptionMessage;

namespace MatchingAPI.Controllers
{
    [Route("Subscription/[controller]")]
    [ApiController]
    public class SucbcriptionPlanController : ControllerBase
    {
        private readonly ISucbcriptionPlan _subscriptionplan;

        public SucbcriptionPlanController(ISucbcriptionPlan subscriptionplan)
        {
            _subscriptionplan = subscriptionplan;
        }

  
        [HttpPost]
        [Route("CreateUpdateSubscriptionPlan")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<MessageHelper> CreateUpdateSubscriptionPlan(SubscriptionPlanMainDTO objCreate)
        {
            try
            {

                var msg = await _subscriptionplan.CreateUpdateSubscriptionPlan(objCreate);
                return msg;
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetSubscriptionPlans")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<IActionResult> GetSubscriptionPlans()
        {
            try
            {

                var dt = await _subscriptionplan.GetSubscriptionPlans();
                if (dt == null)
                {
                    return NotFound();
                }
                return Ok(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("CreateSubscriptionPlanInformationByUser")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<MessageHelper> CreateSubscriptionPlanInformationByUser(CreateSubscriptionPlanByUserCommonDTO createSubscriptionPlan)
        {
            try
            {

                var msg = await _subscriptionplan.CreateSubscriptionPlanInformationByUser(createSubscriptionPlan);
                return msg;
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("EditSubscriptionPlanByUser")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<IActionResult> EditSubscriptionPlanByUser(EditSubscriptionPlanByUserCommonDTO editSubscriptionPlan)
        {
            try
            {

                var dt = await _subscriptionplan.EditSubscriptionPlanByUser(editSubscriptionPlan);
                if (dt == null)
                {
                    return NotFound();
                }
                return Ok(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //[HttpGet]
        //[Route("GetSubscriptionPlanById")]
        //[SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        //public async Task<IActionResult> GetSubscriptionPlanById(long membershipId, long userId)
        //{
        //    try
        //    {

        //        var dt = await _subscriptionplan.GetSubscriptionPlanById(membershipId,  userId);
        //        if (dt == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [HttpGet]
        [Route("GetRunningSusscriptionInfoForUser")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<IActionResult> GetRunningSusscriptionInfoForUser(long userid, long unitid, long customerid)
        {
            try
            {

                var dt = await _subscriptionplan.GetRunningSusscriptionInfoForUser(userid,  unitid,  customerid);
                if (dt == null)
                {
                    return NotFound();
                }
                return Ok(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("GetUserProfileInfo")]


        public async Task<IActionResult> GetUserProfileInfo(int intPartid, int intLoginUserId, string strWantsForGender, int intCustomerId, int intUnitId, DateTime dteFromDate, DateTime dteToDate)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(_subscriptionplan.GetUserProfileInfo(intPartid, intLoginUserId, strWantsForGender, intCustomerId, intUnitId, dteFromDate, dteToDate));
                return Ok(jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
