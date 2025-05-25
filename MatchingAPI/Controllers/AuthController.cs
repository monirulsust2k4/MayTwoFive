using MatchingAPI.Data;
using MatchingAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static MatchingAPI.Models.ExceptionMessage;

namespace MatchingAPI.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly PeopleDeskContext _context;
        //private readonly PDSaasContext _saasContext;
        private readonly iBOSDDDbContext _iBOSDDDbContext;
        private readonly IConfiguration _configuration;
      private readonly IAuthService _authService;
        //private readonly IMasterService _masterService;
        //private readonly ITokenService _tokenService;
        private readonly iEmailService _iEmailService;
        //private readonly IApprovalPipelineService _approvalPipelineService;
        private readonly IEmployeeService _employeeService;
        //private ReturnVM responseData = new ReturnVM();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;
        private readonly INotificationService _notificationService;

        [Route("GetLoginOTP")]
        [HttpGet]
        public async Task<IActionResult> GetLoginOTP(string mailAddress)
        {
            MessageHelper message = new MessageHelper();
            try
            {
                if (!string.IsNullOrEmpty(mailAddress))
                {
                    Random generator = new Random();
                    message.Message = generator.Next(0, 1000000).ToString("D6");
                    message.StatusCode = 200;

                    string mailBody = "<!DOCTYPE html>" +
                                        "<html>" +
                                        "<body>" +
                                            "<div style=" + '"' + "font-size:12px" + '"' +
                                                "<p>Hi <a href=" + '"' + '"' + "style=" + '"' + "color:blue" + '"' + ">" + mailAddress + "</a> </p>" +
                                                "<p>We received your request for a single-use code to use with your PeopleDesk account.</p>" +
                                                "<p>Your single-use code is: " + message.Message + "</p>" +
                                                "<p>If you didn't request this code, you can safely ignore this email. Someone else might have typed your email address by mistake.</p>" +
                                                "<p>" +
                                                    "Thanks, <Br /> " +
                                                    "The PeopleDesk team" +
                                                "</p>" +
                                            "</div>" +
                                        "</body>" +
                                        "</html>";

                    string res = await _iEmailService.SendEmail("iBOS", mailAddress, "", "", "PeopleDesk Login OTP", mailBody, "HTML");
                    if (res != "success")
                    {
                        message.StatusCode = 500;
                        message.Message = res;
                    }
                    return Ok(message);
                }
                else
                {
                    message.Message = "Mail Address was not passed";
                    message.StatusCode = 401;

                    return BadRequest(message);
                }
            }
            catch (Exception ex)
            {
                message.Message = ex.Message;
                message.StatusCode = 500;
                return BadRequest(message);
            }
        }



        //[HttpGet]
        //[Route("ChangePassword")]
        //public async Task<IActionResult> ChangePassword(long accountId, string loginId, string oldPassword, string newPassword, long updatedBy)
        //{
        //    try
        //    {
        //        MessageHelper messageHelper = new MessageHelper();
        //        string oldData, newData;

        //        string encodedOLDPass = _authService.EnCoding(oldPassword);
        //        User user = await _context.Users.FirstOrDefaultAsync(x => x.IntAccountId == accountId && x.StrLoginId == loginId && x.StrPassword == encodedOLDPass);
        //        if (user != null)
        //        {
        //            oldData = JsonConvert.SerializeObject(user);

        //            var ibosUser = await _iBOSDDDbContext.TblUsers.Where(x => x.StrEmailAddress.ToLower() == loginId.ToLower() && x.IntUserType == 1 && x.IsActive == true).FirstOrDefaultAsync();
        //            if (ibosUser == null)
        //            {
        //                throw new Exception("Erp User Not Found");
        //            }
        //            ibosUser.StrPassword = newPassword;
        //            _iBOSDDDbContext.TblUsers.Update(ibosUser);
        //            await _iBOSDDDbContext.SaveChangesAsync();

        //            user.StrOldPassword = user.StrPassword;
        //            user.StrPassword = _authService.EnCoding(newPassword);
        //            user.DteUpdatedAt = DateTime.Now.BD();
        //            user.IntUpdatedBy = updatedBy;

        //            _context.Users.Update(user);
        //            await _context.SaveChangesAsync();

        //            newData = JsonConvert.SerializeObject(user);
        //            var logData = new AllTableUpdateLogHistory()
        //            {
        //                StrTableName = "Users",
        //                IntTablePrimaryKey = user.IntUserId,
        //                StrOldData = oldData,
        //                StrNewData = newData,
        //                StrComments = "Auth/ChangePassword",
        //                IntActionBy = updatedBy,
        //                DteAction = DateTime.Now.BD(),
        //            };
        //            await _context.AllTableUpdateLogHistories.AddAsync(logData);
        //            await _context.SaveChangesAsync();

        //            messageHelper.Message = "Password Updated Successfully";
        //            messageHelper.StatusCode = 200;

        //            return Ok(messageHelper);
        //        }
        //        else
        //        {
        //            messageHelper.Message = "Invalid User !!!";
        //            messageHelper.StatusCode = 401;

        //            return BadRequest(messageHelper);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}


    }
}
