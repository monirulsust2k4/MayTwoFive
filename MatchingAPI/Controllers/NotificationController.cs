using MatchingAPI.Data;
using MatchingAPI.Data.Entity;
using MatchingAPI.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MatchingAPI.Controllers
{
    public class NotificationController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}


        private readonly INotificationService _notificationService;
        private readonly PeopleDeskContext _context;
        public NotificationController(INotificationService _notificationService, PeopleDeskContext _context)
        {
            this._context = _context;
            this._notificationService = _notificationService;
          //this._pushNotifyServices = _pushNotifyServices;
        }
        //[Route("Iftar2023NotificationSEND")]
        //[HttpPost]
        //public async Task<IActionResult> Iftar2023NotificationSEND(List<BulkNotificationSENDVM> modelList)
        //{
        //    try
        //    {
        //        long accountId = 1;
        //        foreach (BulkNotificationSENDVM model in modelList)
        //        {
        //            NotificationMaster notificationObj = new NotificationMaster
        //            {
        //                IntId = 0,
        //                IntOrgId = accountId,
        //                StrNotifyTitle = "Partner Meetup & Iftar 2023",
        //                StrNotifyDetails = "Your are invited to join iBOS Family for our Partner Meetup & Iftar 2023, starting today at 5 pm at The Forest Lounge (10/A, Satmasjid Road,  Dhanmondi) and make our evening of celebration a fruitful one.\r\n",
        //                StrModule = "Iftar Invitation",
        //                StrFeature = "iftar_invitation",
        //                IntFeatureTableAutoId = 0,
        //                IntEmployeeId = 0,
        //                IsCommon = false,
        //                StrReceiver = model.recByEmployeeId.ToString(),
        //                IsSeen = false,
        //                IsActive = true,
        //                StrCreatedBy = "System",
        //                DteCreatedAt = DateTime.Now
        //            };

        //            /*========================REAL TIME========================*/

        //            await _notificationService.SaveNotificationMaster(notificationObj);
        //            await _notificationService.SendToSingleUserByUsername(accountId.ToString(), model.recByEmployeeId.ToString());

        //            /*===========================PUSH NOTIFY=============================*/
        //            List<PushNotifyDeviceRegistration> deviceList = await _pushNotifyServices.GetAllPushNotifyDeviceRegistrationByEmployeeId(model.recByEmployeeId);
        //            PushNotificationViewModel notificationModel = new PushNotificationViewModel
        //            {
        //                DeviceId = "",
        //                Title = notificationObj.StrNotifyTitle,
        //                Body = notificationObj.StrNotifyDetails,
        //                Sound = "meet",
        //                SoundIOS = "meet.wav",
        //                ChannelId = "meet",
        //                Name = "meet"
        //            };

        //            foreach (PushNotifyDeviceRegistration pushNotifyDevice in deviceList)
        //            {
        //                notificationModel.DeviceId = pushNotifyDevice.StrDeviceId;
        //                await _pushNotifyServices.SendNotification(notificationModel);
        //            }
        //        }

        //        return Ok(true);
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("something went wrong !!!");
        //    }
        //}

        [Route("GetNotificationCount")]
        [HttpGet]
        public async Task<IActionResult> GetNotificationCount(long employeeId, long accountId)
        {
            try
            {
                var data = await _notificationService.GetNotificationCount(employeeId, accountId);
                return Ok(data.Count());
            }
            catch (Exception)
            {
                throw new Exception("internal server error occur");
            }
        }


       


    }
}
