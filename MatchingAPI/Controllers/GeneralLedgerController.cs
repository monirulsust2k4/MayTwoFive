using MatchingAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using static MatchingAPI.DTO.SucbcriptionPlanDTO;
using static MatchingAPI.Models.ExceptionMessage;
using Swashbuckle.AspNetCore.Annotations;
using MatchingAPI.DTO;
using MatchingAPI.Data.Entity;

namespace MatchingAPI.Controllers
{
[Route("GeneralLedger/[controller]")]
    [ApiController]
    public class GeneralLedgerController : ControllerBase
    {
        private readonly IGeneralLedger _generalLedger;


        public GeneralLedgerController(IGeneralLedger generalLedger)
        {
            _generalLedger = generalLedger;
        }


        [HttpPost]
        [Route("CreateGeneralLedger")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<MessageHelper> CreateGeneralLedger(GeneralLedgerDTO objCreateGlDTO)
        {
            try
            {

                var msg = await _generalLedger.CreateGeneralLedger(objCreateGlDTO);
                return msg;
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [Route("EditGeneralLedger")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<MessageHelper> EditGeneralLedger(EditGeneralLedgerDTO objEditGlDTO)
        {
            try
            {

                var msg = await _generalLedger.EditGeneralLedger(objEditGlDTO);
                return msg;
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetGeneralLedgerById")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<IActionResult> GetGeneralLedgerById(long GLID)
        {
            try
            {

                var data = await _generalLedger.GetGeneralLedgerById(GLID);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("GetGeneralLedgerDDL")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<IActionResult> GetGeneralLedgerDDL(long AccountId, long GeneralLedgerTypeId)
        {
            try
            {

                var data = await _generalLedger.GetGeneralLedgerDDL( AccountId,  GeneralLedgerTypeId);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetGeneralLedgerByCategoryDDL")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<IActionResult> GetGeneralLedgerByCategoryDDL(long AccountId, long GeneralLedgerCategoryId, long BusinessUnitId)
        {
            try
            {

                var data = await _generalLedger.GetGeneralLedgerByCategoryDDL( AccountId,  GeneralLedgerCategoryId,  BusinessUnitId);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete]
        [Route("DeleteAccountClass")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<IActionResult> DeleteAccountClass(long ClassId, long ActionBy)
        {
            try
            {

                var data = await _generalLedger.DeleteAccountClass( ClassId,  ActionBy);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("GetGeneralLedgerDDLByAccountGroup")]
        [SwaggerOperation(Description = "Example { ")]
        public async Task<IActionResult> GetGeneralLedgerDDLByAccountGroup(long AccountId, long BusinessUnitId, long AccountGroupId)
        {
            try
            {

                var data = await _generalLedger.GetGeneralLedgerDDLByAccountGroup(AccountId, BusinessUnitId, AccountGroupId);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
