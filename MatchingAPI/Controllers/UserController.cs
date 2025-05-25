using MatchingAPI.Data;
using MatchingAPI.IServices;
using MatchingAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text;
//using static OrderManagement.StoreProcedure.SalesInformation;


namespace MatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       // private readonly IEmployeeService _employeeService;
        private readonly PeopleDeskContext _dbContext;
        // SalesInformation con = new SalesInformation();
      //  EmployeeService con = new EmployeeService();
        public UserController(PeopleDeskContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public SalesInformationController(ReadDbContext contextR, WriteDbContext contextW, ILogger<SalesInformationController> logger)
        //{
        //    _contextR = contextR;
        //    _contextW = contextW;
        //    _logger = logger;
        //}

        //[Route("GetAllUsers")]
        //[HttpGet]
        //public async Task<IActionResult> GetAllUsers(long accountId)
        //{
        //    var res = await _employeeService.GetUsers(accountId);
        //    return Ok(res);
        //}

      
    }
}
