using MatchingAPI.DTO;
using MatchingAPI.IServices;
using MatchingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using static MatchingAPI.Models.ExceptionMessage;
using Swashbuckle.AspNetCore.Annotations;

namespace MatchingAPI.Controllers
{
    [Route("CashJournal/[controller]")]
    [ApiController]
    public class CashJournalController : ControllerBase
    {
        private readonly ICashJournal _cashjournal;


        public CashJournalController(ICashJournal cashjournal)
        {
            _cashjournal = cashjournal;
        }


        [HttpPost]
        [Route("CreateGeneralLedger")]
        [SwaggerOperation(Description = "Example { BusinessUnitId: 0, ItemMasterId: 0, ItemCode: string, ItemName: string, ItemTypeId: 0,ItemTypeName:string,ItemCategoryId: 0,ItemCategoryName:string,ItemSubCategoryId:0,ItemSubCategoryName:string,Uomid:0,Uomname:string,GrossWeightKg:0,NetWeightKg:0,ActionBy:0, LastActionDateTime: 2020-02-09T11:42:09.172Z }")]
        public async Task<MessageHelper> CreateGeneralLedger(CashJournalDTO objCreate)
        {
            try
            {

                var msg = await _cashjournal.CreateCashJournalNew(objCreate); 
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
