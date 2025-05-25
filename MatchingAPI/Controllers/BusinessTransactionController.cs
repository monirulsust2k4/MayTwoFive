//using MatchingAPI.IServices;
//using MatchingAPI.Services;
//using Microsoft.AspNetCore.Mvc;
//using Swashbuckle.AspNetCore.Annotations;
//using static MatchingAPI.DTO.BusinessTransactionDTO;
//using static MatchingAPI.Models.ExceptionMessage;

using MatchingAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using static MatchingAPI.DTO.BusinessTransactionDTO;
using static MatchingAPI.Models.ExceptionMessage;
using Swashbuckle.AspNetCore.Annotations;
using MatchingAPI.DTO;
using MatchingAPI.Data.Entity;



namespace MatchingAPI.Controllers
{
    [Route("BusinessTransaction/[controller]")]
    [ApiController]
    public class BusinessTransactionController : ControllerBase
    {
        private readonly IBusinessTransaction _businessTransaction;


        public BusinessTransactionController(IBusinessTransaction businessTransaction)
        {
            _businessTransaction = businessTransaction;
        }

        [HttpPost]
        [Route("CreateBusinessTransaction")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]

        public async Task<MessageHelper> CreateBusinessTransaction(CreateBusinessTransactionDTO objCreate)
        {
            try
            {
                var msg = await _businessTransaction.CreateBusinessTransaction(objCreate);
                return msg;
                throw new Exception();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetBusinessTransactionLandingPasignation")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]

        public async Task<BusinessTransactionLandingPagination> GetBusinessTransactionLandingPasignation(long AccountId, long BusinessUnitId, string viewOrder, long PageNo, long PageSize)
        {

            try
            {
                var msg = await _businessTransaction.GetBusinessTransactionLandingPasignation(AccountId, BusinessUnitId, viewOrder, PageNo, PageSize);
                return msg;
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("EditBusinessTransaction")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]

        public async Task<MessageHelper> EditBusinessTransaction(EditBusinessTransactionDTO objEdit)
        {

            try
            {
                var msg = await _businessTransaction.EditBusinessTransaction(objEdit);
                return msg;
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
