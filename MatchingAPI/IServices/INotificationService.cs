using MatchingAPI.Data.Entity;

namespace MatchingAPI.IServices
{
    public interface INotificationService
    {

      //Task<IEnumerable<NotificationMaster>> GetAllNotificationMasterByOrgId(long orgId);
        Task<IEnumerable<NotificationMaster>> GetNotificationCount(long employeeId, long accountId);
        Task<long> SaveNotificationMaster(NotificationMaster obj);

    }
}
