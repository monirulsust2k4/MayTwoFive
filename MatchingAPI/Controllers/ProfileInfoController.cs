using MatchingAPI.DTO;
using MatchingAPI.Helper;
using MatchingAPI.IServices;
using MatchingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Swagger;

namespace MatchingAPI.Controllers
{
    [Route("ProfileInfo/[controller]")]
    [ApiController]
    public class ProfileInfoController : ControllerBase
    {
        private readonly IProfileInfo _profileinfService;

        public ProfileInfoController(IProfileInfo profileinfService)
        {
            _profileinfService = profileinfService;
        }



        [HttpPost]
        [Route("CreateUserProfileInfo")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<CustomizeHelper> CreateUserProfileInfo( UserProfileDTO head)
        {
            try
            {
                string jwtToken = HttpContext.Request.Headers["Authorization"].ToString()?.Replace("Bearer ", "");
                //postUserCreate.jwtToken = jwtToken;
                var msg = await _profileinfService.CreateUserProfileInfo(head);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPut]
        [Route("EditUserProfileInfo")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<CustomizeHelper> EditUserProfileInfo( UserProfileSummeryDTO editinfo)
        {
            try
            {
                string jwtToken = HttpContext.Request.Headers["Authorization"].ToString()?.Replace("Bearer ", "");
                //postUserCreate.jwtToken = jwtToken;
                var msg = await _profileinfService.EditUserProfileInfo(editinfo);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPut]
        [Route("EditUserProfileEducationInfo")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<CustomizeHelper> EditUserProfileEducationInfo( List<CreateUserEducationRowDTO> editEducationinfo)
        {
            try
            {
                string jwtToken = HttpContext.Request.Headers["Authorization"].ToString()?.Replace("Bearer ", "");
                //postUserCreate.jwtToken = jwtToken;
                var msg = await _profileinfService.EditUserProfileEducationInfo(editEducationinfo);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("EditUserProfileWorkInfo")]
        [SwaggerOperation(Description ="")]
        public async Task<CustomizeHelper> EditUserProfileWorkInfo(  List<CreateUserWorkInfoRowDTO> editWorkinfo)
        {
            try
            {
                var msg= await _profileinfService.EditUserProfileWorkInfo(editWorkinfo);
                return msg;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPut]
        [Route("EditUserHobbiesNInterestInfo")]
        [SwaggerOperation(Description = "")]
        public async Task<CustomizeHelper> EditUserHobbiesNInterestInfo(List<CreateUserRowDTO> editHobbiesinfo)
        {
            try
            {
                var msg = await _profileinfService.EditUserHobbiesNInterestInfo(editHobbiesinfo);
                return msg;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("GetSubcriptionPlanList")]
        [HttpGet]
        public async Task<IActionResult> GetSubcriptionPlanList()
        {
            var res = await _profileinfService.GetSubcriptionPlanList();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetDivisionDDL")]
        [SwaggerOperation(Description = "Example { UId: 0 }")]
        public async Task<IActionResult> GetDivisionDDL(long CountryID)
        {
            try
            {
                var dt = await _profileinfService.GetDivisionDDL(CountryID);
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
        [Route("GetDistrictDDL")]
        [SwaggerOperation(Description = "Example {DivisionID: 1}")]

        public async Task<IActionResult> GetDistrictDDL(long DivisionID)
        {

            try
            {
                var dt = await _profileinfService.GetDistrictDDL(DivisionID);
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
        [Route("GetThanaDDL")]
        [SwaggerOperation(Description = "Example{DistricID:1}")]

        public async Task<IActionResult> GetThanaDDL(long DistrictID)
        {

            try
            {
                var dt = await _profileinfService.GetThanaDDL(DistrictID);
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
        [Route("GetRegionDDL")]
        [SwaggerOperation(Description = "Example{RegionID:1}")]
        public async Task<IActionResult> GetRegionDDL()
        {
            try
            {
                var dt = await _profileinfService.GetRegionDDL();
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
        [Route("GetCommunityDDL")]
        [SwaggerOperation(Description = "Example")]
        public async Task<IActionResult> GetCommunityDDL()
        {
            try {
                var dt = await _profileinfService.GetCommunityDDL();
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
        [Route("GetCountryDDL")]
        [SwaggerOperation(Description = "Example")]

        public async Task<IActionResult> GetCountryDDL()
        {

            try{

                var dt= await _profileinfService.GetCountryDDL();
                if(dt == null)
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
        [Route("GetDietPreferenceDDL")]
        [SwaggerOperation(Description = "Example")]
        public async Task<IActionResult> GetDietPreferenceDDL()
        {
            try
            {
                var dt = await _profileinfService.GetDietPreferenceDDL();
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
        [Route("GetHightestQualification")]
        [SwaggerOperation(Description = "Example")]
        public async Task<IActionResult> GetHightestQualification()
        {
            try
            {
                var dt = await _profileinfService.GetHightestQualification();
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
        [Route("GetHobbiesNInterest")]
        [SwaggerOperation(Description = "Example")]
        public async Task<IActionResult> GetHobbiesNInterest(string CategoryName)
        {
            try
            {
                var dt = await _profileinfService.GetHobbiesNInterest( CategoryName);
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
        [Route("GetMaritalStatus")]
        [SwaggerOperation(Description = "Example")]
        public async Task<IActionResult> GetMaritalStatus()
        {
            try
            {
                var dt = await _profileinfService.GetMaritalStatus();
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
        [Route("GetParentOccupation")]
        [SwaggerOperation(Description = "Example")]
        public async Task<IActionResult> GetParentOccupation(string strParentType)
        {
            try
            {
                var dt = await _profileinfService.GetParentOccupation( strParentType);
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
        [Route("GetResidencyStatus")]
        [SwaggerOperation(Description = "Example")]
        public async Task<IActionResult> GetResidencyStatus()
        {
            try
            {
                var dt = await _profileinfService.GetResidencyStatus();
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
        [Route("GetSubCommunity")]
        [SwaggerOperation(Description = "Example")]
        public async Task<IActionResult> GetSubCommunity(long ReligiousID)
        {
            try
            {
                var dt = await _profileinfService.GetSubCommunity(ReligiousID);
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
        [Route("GetWorkDesignation")]
        [SwaggerOperation(Description = "Example")]
        public async Task<IActionResult> GetWorkDesignation()
        {
            try
            {
                var dt = await _profileinfService.GetWorkDesignation();
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
        [Route("GetWorkIndustry")]
        [SwaggerOperation(Description = "Example")]
        public async Task<IActionResult> GetWorkIndustry()
        {
            try
            {
                var dt = await _profileinfService.GetWorkIndustry();
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
    } 
}
