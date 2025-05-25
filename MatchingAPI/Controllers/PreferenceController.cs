using MatchingAPI.DTO;
using MatchingAPI.Helper;
using MatchingAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MatchingAPI.Controllers
{

    [Route("Preference/[controller]")]
    [ApiController]
    public class PreferenceController : ControllerBase
    {
       
        private readonly IPreferenceInfo _preferenceInfoService;

        public PreferenceController(IPreferenceInfo preferenceInfoService)
        {
            _preferenceInfoService = preferenceInfoService;
        }


        [HttpPost]
        [Route("CreateUserPreferenceInfo")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]

        public async Task<CustomizeHelper> CreateUserPreferenceInfo(UserPreferenceDTO preference)
        {

            try
            {

                var msg= await _preferenceInfoService.CreateUserPreferenceInfo(preference);
              
                    return msg;
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
