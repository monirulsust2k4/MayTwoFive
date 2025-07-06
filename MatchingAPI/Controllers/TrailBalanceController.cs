using MatchingAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailBalanceController : ControllerBase
    {
        //private readonly ITrailBalance _trailbalance;

        //public TrailBalanceController(ITrailBalance trailbalance)
        //{
        //    _trailbalance = trailbalance;
        //}

        //[HttpGet]
        //[Route("GetTrailBalanceByPamsReport")]
        //[SwaggerOperation(Description = "Example { ")]
        //public async Task<IActionResult> GetTrailBalanceByPamsReport(long AccountId, long BusinessUnitId, DateTime StartDate, DateTime EndDate, long ViewType)
        //{

        //    try
        //    {
        //        var dt = await _trailbalance.GetTrailBalanceByPamReport(AccountId, BusinessUnitId, StartDate,
        //            EndDate, ViewType);
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

    }
}
