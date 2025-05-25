using System.Data;
using MatchingAPI.Data;
using MatchingAPI.Data.Entity.iBOSDDD;
using MatchingAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MatchingAPI.Helper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MatchingAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        //private readonly iBOSDDDbContext _dbContext;
        private readonly PeopleDeskContext _dbContext;
        DataTable dt = new DataTable();

        //private readonly PeopleDeskContext _dbContext;
        //public SucbcriptionPlan(PeopleDeskContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public EmployeeService(PeopleDeskContext dbContext)
        {
            _dbContext= dbContext;
        }
        //public async Task<List<TblUser>> GetUsers(long intAccountId)
        //{
        //    var result =await _dbContext.TblUsers
        //                    .Where(x=>x.IntAccountId== intAccountId)
        //                    .Take(10)
        //                    .ToListAsync();
        //    return result;  
        //}

      
   
    }
}
